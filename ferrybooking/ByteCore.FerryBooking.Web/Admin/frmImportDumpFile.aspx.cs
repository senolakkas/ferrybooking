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
            //return dtErrInfo;
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
            //return dtErrInfo;
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
                    int fareId;
                    if (string.IsNullOrEmpty(depPortId) || string.IsNullOrEmpty(arrPortId))
                        continue;
                    Route r = Route.GetRouteByPortId(depPortId, arrPortId, operatorId);
                    if (r == null)
                    {
                        dtErrInfo.Rows.Add(new object[] { rowNumber, "Route", "Null", " Route not found" });
                        continue;
                    }
                    Fare existingFare = Fare.GetFareByRouteAndDateRange(r.ID, startDate, endDate);
                    if (existingFare == null)
                    {
                        Fare newFare = new Fare();
                        newFare.RoutesID = r.ID;
                        newFare.StartDate = startDate;
                        newFare.EndDate = endDate;
                        Fare.DoInsert(newFare);
                        fareId = newFare.ID;
                    }
                    else
                    {
                        fareId = existingFare.ID;
                    }

                    string strCategory = row["Category"].ToString();
                    FareCategory fareCategory = FareCategory.GetCategoryByName(strCategory);
                    if (fareCategory == null)
                    {
                        dtErrInfo.Rows.Add(new object[] { rowNumber, "Fare Category", "Null", " Fare Category not found" });
                        continue;
                    } 

                    int categoryId = fareCategory.ID;
                    string strFacility = row["Facility"].ToString();
                    string strDescription = row["Description"].ToString();
                    if (!string.IsNullOrEmpty(strFacility) && !string.IsNullOrEmpty(strDescription))
                    {
                        int fareTypeId = 0;
                        int minLength = 0;
                        int maxLength = 0;
                        decimal amount = 0.0m;
                        decimal byFootAmount = 0.0m;
                        string strMinLength = row["Minlength"].ToString();
                        string strMaxLength = row["Maxlength"].ToString();
                        string strAmount = row["Amount"].ToString();
                        string strByFootAmount = row["Byfootamt"].ToString();
                        decimal.TryParse(strByFootAmount, out byFootAmount);
                        FareType existingFareType = FareType.GetFareTypeByValue(operatorId, categoryId, strFacility);
                        if (existingFareType == null)
                        {
                            if (decimal.TryParse(strAmount, out amount))
                            {
                                int.TryParse(strMinLength, out minLength);
                                int.TryParse(strMaxLength, out maxLength);
                                FareType newFareType = new FareType();
                                newFareType.OperatorId = operatorId;
                                newFareType.CategoryId = categoryId;
                                newFareType.FareTypeName = strFacility;
                                newFareType.FareTypeDescription = strDescription;
                                FareType.DoInsert(newFareType);

                                fareTypeId = newFareType.ID;
                            }
                            else
                            {
                                dtErrInfo.Rows.Add(new object[] { rowNumber, "Minlength/Maxlength/Amount", "Null", "Minlength/Maxlength/Amount is worng format or value" });
                                continue;
                            }
                        }
                        else
                        {
                            int.TryParse(strMinLength, out minLength);
                            int.TryParse(strMaxLength, out maxLength);
                            decimal.TryParse(strAmount, out amount);
                            fareTypeId = existingFareType.ID;
                        }

                        FareItem newFareItem = new FareItem();
                        switch (strFacility.ToUpper())
                        {
                            case "CAR":
                            case "VAN":
                            case "RV":
                                //TODO: Check duplicate
                                if (VehicleType.GetByVehicleTypeId(fareTypeId) == null)
                                {
                                    VehicleType newVehicleType = new VehicleType(fareTypeId);
                                    newVehicleType.MinLegth = minLength;
                                    newVehicleType.MaxLegth = maxLength;
                                    newVehicleType.ByFootAmount = byFootAmount;
                                    VehicleType.DoInsert(newVehicleType);
                                }
                                newFareItem = new FareItem();
                                newFareItem.FareTypeId = fareTypeId;
                                newFareItem.FareId = fareId;
                                newFareItem.RangeStart = minLength;
                                newFareItem.RangeEnd = maxLength;
                                newFareItem.Amount = amount;
                                newFareItem.ByFootAmount = byFootAmount;
                                FareItem.DoInsert(newFareItem);                                
                                break;
                            case "ADT":
                            case "CHD":
                            case "SRC":
                            case "UND":
                                int defaultMinAge = 0;
                                int defaultMaxAge = 0;
                                switch (strFacility.ToUpper())
                                {
                                    case "ADT":
                                        defaultMinAge = 12;
                                        defaultMaxAge = 65;
                                        break;
                                    case "CHD":
                                        defaultMinAge = 6;
                                        defaultMaxAge = 12;
                                        break;
                                    case "SRC":
                                        defaultMinAge = 65;
                                        defaultMaxAge = 99;
                                        break;
                                    case "UND":
                                        defaultMinAge = 0;
                                        defaultMaxAge = 6;
                                        break;
                                    default:
                                        break;
                                }
                                if (PassengerType.GetByPassengerTypeId(fareTypeId) == null)
                                {
                                    PassengerType newPassegerType = new PassengerType(fareTypeId);
                                    if (minLength == 0)
                                    {
                                        minLength = defaultMinAge;
                                        newPassegerType.MinAge = defaultMinAge;
                                    }
                                    else
                                        newPassegerType.MinAge = minLength;
                                    if (maxLength == 0)
                                    {
                                        maxLength = defaultMaxAge;
                                        newPassegerType.MaxAge = defaultMaxAge;
                                    }
                                    else
                                        newPassegerType.MaxAge = maxLength;
                                    PassengerType.DoInsert(newPassegerType);
                                }
                                newFareItem = new FareItem();
                                newFareItem.FareTypeId = fareTypeId;
                                newFareItem.FareId = fareId;
                                newFareItem.RangeStart = minLength;
                                newFareItem.RangeEnd = maxLength;
                                newFareItem.Amount = amount;
                                newFareItem.ByFootAmount = byFootAmount;
                                FareItem.DoInsert(newFareItem);
                                break;
                            case "PET":
                            case "BIKE":
                            case "KYK":
                                newFareItem = new FareItem();
                                newFareItem.FareTypeId = fareTypeId;
                                newFareItem.FareId = fareId;
                                newFareItem.RangeStart = minLength;
                                newFareItem.RangeEnd = maxLength;
                                newFareItem.Amount = amount;
                                newFareItem.ByFootAmount = byFootAmount;
                                FareItem.DoInsert(newFareItem);
                                break;
                            default: //include all accommodation fare
                                newFareItem = new FareItem();
                                newFareItem.FareTypeId = fareTypeId;
                                newFareItem.FareId = fareId;
                                newFareItem.RangeStart = minLength;
                                newFareItem.RangeEnd = maxLength;
                                newFareItem.Amount = amount;
                                newFareItem.ByFootAmount = byFootAmount;
                                FareItem.DoInsert(newFareItem);
                                break;
                        }
                    }
                    else
                    {
                        dtErrInfo.Rows.Add(new object[] { rowNumber, "Facility/Description", "Null", " Facility/Description is worng format or value" });
                        continue;
                    }
                }
                else
                {
                    dtErrInfo.Rows.Add(new object[] { rowNumber, "StartDate/EndDate", "Null", " StartDate/EndDate is worng format or value" });
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

        protected void btnImportSchedule_Click(object sender, EventArgs e)
        {
            if (this.FU_Schedule.FileName == "")
                return;
            string filePath = GetUploadPath();
            string phyFilePath = Server.MapPath(filePath + this.FU_Schedule.FileName);
            try
            {
                if (System.IO.File.Exists(phyFilePath))
                    phyFilePath = Server.MapPath(filePath + System.Guid.NewGuid().ToString() + ".xls");
                this.FU_Schedule.SaveAs(phyFilePath);
            }
            catch
            {
                this.lblError.Text = _folderErrorMessage;
                return;
            }

            this.GV_Result.DataSource = ImportScheduleDumpFile(phyFilePath);
            this.GV_Result.DataBind(); 
        }

        private DataTable ImportScheduleDumpFile(string fileName)
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
            columnNames = ",Sailing,Vessel,Depschid,Dep,Departs,Arrschid,Arr,Arrives,";
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
                string strVessel = row["Vessel"].ToString();
                if (!string.IsNullOrEmpty(strVessel))
                {
                    Vessel vessel = Vessel.GetVesselByCode(strVessel.Trim());
                    if (vessel != null)
                    {
                        string depPortId = row["Dep"].ToString().Trim();
                        string arrPortId = row["Arr"].ToString().Trim();
                        Port dport = new Port().GetById(depPortId, false);
                        Port aport = new Port().GetById(arrPortId, false);
                        if (dport != null && aport != null)
                        {
                            Company c = Company.GetCompanyByShortName("AMHS");
                            int operatorId = c.ID;

                            Route r = Route.GetRouteByPortId(depPortId, arrPortId, operatorId);
                            if (r != null)
                            {
                                int routeId = r.ID;
                                string strDepDatetime = row["Departs"].ToString();
                                string strArrDatetime = row["Arrives"].ToString();
                                DateTime depDatetime=DateTime.MinValue;
                                DateTime arrDatetime=DateTime.MinValue;
                                if (DateTime.TryParse(strDepDatetime, out depDatetime)
                                    && DateTime.TryParse(strArrDatetime, out arrDatetime))
                                {
                                    Fare availableFare = Fare.GetFareForSchedule(routeId, depDatetime);
                                    if (availableFare != null)
                                    {
                                        Schedule newSchedule = new Schedule();
                                        newSchedule.VesselId = vessel.ID;
                                        newSchedule.FareId = availableFare.ID;
                                        newSchedule.SailingTime = depDatetime;
                                        newSchedule.ArrivalTime = arrDatetime;
                                        Schedule.DoInsert(newSchedule);
                                    }
                                    else
                                    {
                                        dtErrInfo.Rows.Add(new object[] { rowNumber, "Fare", "Null", "Fare is worng format or value" });
                                        continue;
                                    }
                                }
                                else
                                {
                                    dtErrInfo.Rows.Add(new object[] { rowNumber, "Dep/Arr DateTime", "Null", "Dep/Arr DateTime is worng format or value" });
                                    continue;
                                }
                            }
                            else
                            {
                                dtErrInfo.Rows.Add(new object[] { rowNumber, "Route", "Null", "Route is worng format or value" });
                                continue;
                            }
                        }
                        else 
                        {
                            dtErrInfo.Rows.Add(new object[] { rowNumber, "Dep/Arr Port", "Null", "Dep/Arr Port is worng format or value" });
                            continue;
                        }
                    }
                }
                else
                {
                    dtErrInfo.Rows.Add(new object[] { rowNumber, "Vessel", "Null", "Vessel is worng format or value" });
                    continue;
                }
            }
            return dtErrInfo;
        }
    }
}
