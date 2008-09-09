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

            System.IO.File.Delete(phyFilePath);          
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
            DataTable dt = new DataTable();
            return dt;

        }

        private DataTable GetDataTableFromExcel(string fileName)
        {
            DataTable dt = null;
            return dt;
            //ExcelReader er = new ExcelReader();
            //try
            //{
            //    er.ExcelFilename = fileName;
            //    er.Headers = true;
            //    er.MixedData = true;
            //    string[] sheetNames = er.GetExcelSheetNames();
            //    if (sheetNames != null)
            //        er.SheetName = sheetNames[0];
            //    er.Open();
            //    dt = er.GetTable();
            //    er.Close();

            //    //Delete empty rows in the datatable
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        DataRow row = dt.Rows[i];
            //        bool hasValue = false;
            //        for (int j = 0; j < dt.Columns.Count; j++)
            //        {
            //            if (!string.IsNullOrEmpty(row[j].ToString()))
            //            {
            //                hasValue = true;
            //                break;
            //            }
            //        }
            //        if (!hasValue)
            //            row.Delete();
            //    }
            //    dt.AcceptChanges();
            //    return dt;
            //}
            //catch
            //{
            //    try
            //    {
            //        er.Close();
            //    }
            //    catch
            //    {
            //    }
            //    finally
            //    {
            //        lblError.Text = _errorMessage;
            //        return dt;
            //    }
            //}
        }
    }
}
