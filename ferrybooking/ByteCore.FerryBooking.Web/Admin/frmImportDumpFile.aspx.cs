using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using ByteCore.FerryBooking.Core;

namespace ByteCore.FerryBooking.Web
{
    public partial class frmImportDumpFile : BasePage
    {
        private string _folderErrorMessage = "Errors occured while creating/saving the file. "
                                                + "Please make sure the folder is writable "
                                                + "or contact your administrator for assistance.";
        private string _errorMessage = "Errors occured while parsing the file.  "
                                        + "Please make sure the file matches the template " 
                                        + "or contact your administrator for assistance.";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void rdoImportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.rdoImportType.SelectedIndex == 0)
            {
                this.pnlFareDump.Visible = true;
                this.pnlScheduleDump.Visible = false;
            }
            else if (this.rdoImportType.SelectedIndex == 1)
            {
                this.pnlFareDump.Visible = false;
                this.pnlScheduleDump.Visible = true;
            }
            else
            {
                this.pnlFareDump.Visible = false;
                this.pnlScheduleDump.Visible = false;
            }
        }

        protected void btnImportFare_Click(object sender, EventArgs e)
        {
            if (this.FU_Fare.FileName == "")
                return;
            string filePath = GetUploadPath();
            string phyFilePath = Server.MapPath(filePath + this.FU_Fare.FileName);
            try
            {
                if (System.IO.File.Exists(phyFilePath))
                    phyFilePath = Server.MapPath(filePath + System.Guid.NewGuid().ToString() + ".xls");
                this.FU_Fare.SaveAs(phyFilePath);
            }
            catch
            {
                this.lblError.Text = _folderErrorMessage;
                return;
            }          

            this.GV_Result.DataSource = ImportFareDumpFile(phyFilePath);
            this.GV_Result.DataBind();

            //System.IO.File.Delete(phyFilePath);          
        }

        private string GetUploadPath()
        {
            string uploadPath = ConfigurationManager.AppSettings["UploadDumpFilePath"];
            if (uploadPath == null || uploadPath == "")
                uploadPath = "~/";
            if (!uploadPath.EndsWith("/"))
                uploadPath += "/";
            return uploadPath;
        }

        public DataTable ImportFareDumpFile(string fileName)
        {
            DataTable dt = null;
            DataTable dtErrInfo = new DataTable();
            dtErrInfo.Columns.Add("RowNumber", typeof(int));
            dtErrInfo.Columns.Add("ErrColumnName", typeof(string));
            dtErrInfo.Columns.Add("ErrColumnData", typeof(string));
            dtErrInfo.Columns.Add("ErrDescription", typeof(string));

            dt = this.GetDataTableFromExcel(fileName);

            //Check Column in imported Excel file match the template, no missing column
            string columnNames;
            columnNames = ",Dep,Arr,Dreg,Areg,Category,Facility,Minlength,Maxlength,Amount,Byfootamt,Startdate,Enddate,Recid,Description,";
            int rowNumber = 0;
            foreach (DataColumn column in dt.Columns)
            {
                if (columnNames.IndexOf("," + column.ColumnName + ",") < 0)
                    dtErrInfo.Rows.Add(new object[] { rowNumber, column.ColumnName, "Template Error", "The column in XLS file does not match orinigal template" });
            }
            if (dtErrInfo.Rows.Count > 0)
                return dtErrInfo;

            //Check if column “Dep” and “Arr”(Port Code) exists in Port table. 
            //If not then create port
            foreach (DataRow row in dt.Rows)
            {
                string depPortId = row["Dep"].ToString();
                string arrPortId = row["Arr"].ToString();
                Port dport = new Port().GetById(depPortId, false);
                if (dport == null)
                {
                    Port dp = new Port();
                    dp.DoInsert(depPortId, depPortId);
                }
                Port aport = new Port().GetById(arrPortId, false);
                if (aport == null)
                {
                    Port ap = new Port();
                    ap.DoInsert(arrPortId, arrPortId);
                }
            }

            //Select distinct column “Dep” and “Arr” from Route table, if not exist, insert into Route table
            Company c = Company.GetCompanyByShortName("AMHS");
            int operatorId = c.ID;
            foreach (DataRow row in dt.Rows)
            {
                string depPortId = row["Dep"].ToString();
                string arrPortId = row["Arr"].ToString();
                if (string.IsNullOrEmpty(depPortId) || string.IsNullOrEmpty(arrPortId))
                    continue;

                Route r = Route.GetRouteByPortId(depPortId, arrPortId, operatorId);
                if (r == null)
                {
                    Route newRoute = new Route();
                    newRoute.OperatorId = operatorId;
                    newRoute.DeparturePortId = depPortId;
                    newRoute.ArriavlPortId = arrPortId;
                    newRoute.IsActive = true;
                    Route.DoInsert(newRoute);
                }
            }

            //Create a record in Fare table (RouteID, StartDate, EndDate)
            foreach (DataRow row in dt.Rows)
            {
                string strStartDate = row["Startdate"].ToString();
                string strEndDate = row["Enddate"].ToString();
                DateTime startDate = DateTime.MaxValue;
                DateTime endDate = DateTime.MaxValue;
                if (string.IsNullOrEmpty(strStartDate) || string.IsNullOrEmpty(strEndDate))
                {
                    dtErrInfo.Rows.Add(new object[] { rowNumber, "StartDate/EndDate", "Null", " StartDate/EndDate is worng format or value" });
                    continue;
                }

                if (DateTime.TryParse(strStartDate, out startDate) && DateTime.TryParse(strEndDate, out endDate))
                {
                    string depPortId = row["Dep"].ToString();
                    string arrPortId = row["Arr"].ToString();
                    if (string.IsNullOrEmpty(depPortId) || string.IsNullOrEmpty(arrPortId))
                        continue;
                    Route r = Route.GetRouteByPortId(depPortId, arrPortId, operatorId);
                    Fare existingFare = Fare.GetFareByRouteAndDateRange(r.ID, startDate, endDate);
                    if (existingFare == null)
                    {
                        Fare newFare = new Fare();
                        newFare.RoutesID = r.ID;
                        newFare.StartDate = startDate;
                        newFare.EndDate = endDate;
                        Fare.DoInsert(newFare);
                    }
                }
                else
                {
                    dtErrInfo.Rows.Add(new object[] { rowNumber, "StartDate/EndDate", "Null", " StartDate/EndDate is worng format or value" });
                    continue;
                }
            }


            foreach (DataRow row in dt.Rows)
            {
                string strCategory = row["Category"].ToString();
                FareCategory fareCategory = FareCategory.GetCategoryByName(strCategory);
                int categoryId = fareCategory.ID;
                string strFacility = row["Facility"].ToString();
                string strDescription = row["Description"].ToString();
                if (!string.IsNullOrEmpty(strFacility) && !string.IsNullOrEmpty(strDescription) && strFacility.ToLower() == "car")
                {
                    int newId;
                    int minLength = 0;
                    int maxLength = 0;
                    FareType existingFareType = FareType.GetFareTypeByValue(operatorId, categoryId, strFacility, strDescription);
                    if (existingFareType == null)
                    {
                        string strMinLength = row["Minlength"].ToString();
                        string strMaxLength = row["Maxlength"].ToString();
                        string strAmount = row["Amount"].ToString();
                        decimal amount = 0.0m;
                        if (int.TryParse(strMinLength, out minLength)
                            && int.TryParse(strMaxLength, out maxLength)
                            && decimal.TryParse(strAmount, out amount))
                        {
                            FareType newFareType = new FareType();
                            newFareType.OperatorId = operatorId;
                            newFareType.CategoryId = categoryId;
                            newFareType.FareTypeName = strFacility;
                            newFareType.FareTypeDescription = strDescription;
                            FareType.DoInsert(newFareType);

                            newId = newFareType.ID;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else
                        newId = existingFareType.ID;

                    VehicleType newVehicleType = new VehicleType(newId);
                    newVehicleType.MinLegth = minLength;
                    newVehicleType.MaxLegth = maxLength;
                    newVehicleType.ByFootAmount = 0.0m;
                    VehicleType.DoInsert(newVehicleType);

                    FareItem newFareItem = new FareItem();


                }
                else
                {
                    dtErrInfo.Rows.Add(new object[] { rowNumber, "Facility/Description", "Null", " Facility/Description is worng format or value" });
                    continue;
                }
            }

            return dtErrInfo;

        }

        private DataTable GetDataTableFromExcel(string fileName)
        {
            DataTable dt = null;
            ExcelReader er = new ExcelReader();
            try
            {
                er.ExcelFilename = fileName;
                er.Headers = true;
                er.MixedData = true;
                string[] sheetNames = er.GetExcelSheetNames();
                if (sheetNames != null)
                    er.SheetName = sheetNames[0];
                er.Open();
                dt = er.GetTable();
                er.Close();

                //Delete empty rows in the datatable
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];
                    bool hasValue = false;
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (!string.IsNullOrEmpty(row[j].ToString()))
                        {
                            hasValue = true;
                            break;
                        }
                    }
                    if (!hasValue)
                        row.Delete();
                }
                dt.AcceptChanges();
                return dt;
            }
            catch
            {
                try
                {
                    er.Close();
                }
                catch
                {
                }                
                this.lblError.Text = _errorMessage;
                return dt;
            }
        }
    }
}
