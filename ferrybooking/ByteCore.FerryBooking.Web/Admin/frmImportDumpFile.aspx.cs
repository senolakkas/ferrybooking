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
                       DataTable dt = null;
            DataTable dtErrInfo = new DataTable();
            dtErrInfo.Columns.Add("RowNumber", typeof(int));
            dtErrInfo.Columns.Add("ErrColumnName", typeof(string));
            dtErrInfo.Columns.Add("ErrColumnData", typeof(string));
            dtErrInfo.Columns.Add("ErrDescription", typeof(string));

            dt = this.GetDataTableFromExcel(fileName);

        //    //Check Column in imported Excel file match the template, no missing column
        //    string columnNames;
        //    columnNames = ",Dep,Arr,Dreg,Areg,Category,Facility,Minlength,Maxlength,Amount,Byfootamt,Startdate,Enddate,Recid,Description,";
        //    int rowNumber = 0;
        //    foreach (DataColumn column in dt.Columns)
        //    {
        //        if (columnNames.IndexOf("," + column.ColumnName + ",") < 0)
        //            dtErrInfo.Rows.Add(new object[] { rowNumber, column.ColumnName, "Template Error", "The column in XLS file does not match orinigal template" });
        //    }
        //    if (dtErrInfo.Rows.Count > 0)
        //        return dtErrInfo;

        //    //Validate each column and insert to table
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        //Check if column “Dep” and “Arr”(Port Code) exists in Port table. 
        //        //If not then create port

        //        string depPortId = row["Dep"].ToString();
        //        string arrPortId = row[]
        //        Port port = new Port().GetById(, false);
        //        site newSite = new site();
        //        newSite.ConnectionString = connStr;
        //        newSite.AddNew();

        //        rowNumber++;
        //        bool isFail = false;

        //        #region FuelCastSiteID
        //        if (isCustomerizedID)
        //        {
        //            string fuelcastSiteID = row["FuelCastSiteID"].ToString();
        //            if (fuelcastSiteID.Length > 20)
        //            {
        //                dtErrInfo.Rows.Add(new object[] { rowNumber, "FuelCastSiteID", fuelcastSiteID, "The length is more than 20" });
        //                isFail = true;
        //            }
        //            if (fuelcastSiteID.Length == 0)
        //            {
        //                dtErrInfo.Rows.Add(new object[] { rowNumber, "FuelCastSiteID", fuelcastSiteID, "FuelCastSiteID can not be null" });
        //                isFail = true;
        //            }
        //            newSite.Siteid = fuelcastSiteID;
        //        }
        //        #endregion

        //        #region ProvinceName
        //        string provinceName = row["ProvinceName"].ToString();
        //        int provinceID = 0;
        //        Province province = new Province();
        //        province.ConnectionString = connStr;
        //        province.Where.ProvinceName.Value = provinceName;
        //        if (!province.Query.Load())
        //        {
        //            dtErrInfo.Rows.Add(new object[] { rowNumber, "ProvinceName", provinceName, "Province name not found" });
        //            isFail = true;
        //        }
        //        else
        //        {
        //            provinceID = province.ProvinceID;
        //            newSite.ProvinceID = provinceID;
        //        }
        //        #endregion

        //        #region CityName
        //        string cityName = row["CityName"].ToString().Trim();
        //        int cityID = 0;
        //        if (cityName == "")
        //        {
        //            dtErrInfo.Rows.Add(new object[] { rowNumber, "CityName", "null", "City Name is null" });
        //            isFail = true;
        //        }
        //        else //look up city table
        //        {
        //            City c = new City();
        //            c.ConnectionString = connStr;
        //            c.Where.CityName.Value = cityName;
        //            if (!c.Query.Load()) //not find create new one
        //            {
        //                if (provinceID > 0)
        //                {
        //                    c.AddNew();
        //                    c.CityName = cityName;
        //                    c.ProvinceID = provinceID;
        //                    c.Save();
        //                }
        //                else
        //                {
        //                    dtErrInfo.Rows.Add(new object[] { rowNumber, "CityName", cityName, "City Name can not be found" });
        //                    isFail = true;
        //                }
        //            }
        //            cityID = c.CityID;
        //            newSite.CityID = cityID;
        //        }
        //        #endregion

        //        #region DMAName
        //        string DMAName = row["DMAName"].ToString();
        //        int DMAID = 0;
        //        if (DMAName == "")
        //        {
        //            dtErrInfo.Rows.Add(new object[] { rowNumber, "DMAName", "null", "DMAName is null" });
        //            isFail = true;
        //        }
        //        else //look up DMA table
        //        {
        //            DMA d = new DMA();
        //            d.ConnectionString = connStr;
        //            d.Where.DMAName.Value = DMAName;
        //            if (!d.Query.Load())
        //            {
        //                dtErrInfo.Rows.Add(new object[] { rowNumber, "DMAName", DMAName, "DMAName can not be found" });
        //                isFail = true;
        //            }
        //            else
        //            {
        //                DMAID = d.ID;
        //                newSite.DMAID = DMAID;
        //            }
        //        }
        //        #endregion

        //        #region PetroleumPartnerName
        //        string petroleumPartnerName = row["PetroleumPartnerName"].ToString();
        //        int enterprisePartnerID = 0;
        //        EnterprisePartners e = new EnterprisePartners();
        //        e.ConnectionString = connStr;
        //        e.Where.EnterprisePartnerName.Value = petroleumPartnerName;
        //        if (!e.Query.Load())
        //        {
        //            dtErrInfo.Rows.Add(new object[] { rowNumber, "PetroleumPartnerName", petroleumPartnerName, "PetroleumPartner name not found" });
        //            isFail = true;
        //        }
        //        else
        //        {
        //            enterprisePartnerID = e.EnterprisePartnerID;
        //            newSite.EnterprisePartnerID = enterprisePartnerID;
        //        }

        //        #endregion

        //        #region SiteBrandName
        //        string sitebrandName = row["SiteBrandName"].ToString();
        //        int sitebrandID = 0;
        //        SiteBrand sitebrand = new SiteBrand();
        //        sitebrand.ConnectionString = connStr;
        //        sitebrand.Where.SiteBrandName.Value = sitebrandName;
        //        if (!sitebrand.Query.Load())
        //        {
        //            dtErrInfo.Rows.Add(new object[] { rowNumber, "SiteBrandName", sitebrandName, "SiteBrand name not found" });
        //            isFail = true;
        //        }
        //        else
        //        {
        //            sitebrandID = sitebrand.SiteBrandID;
        //            newSite.SiteBrandID = sitebrandID;
        //        }

        //        #endregion

        //        #region Address
        //        string address = row["Address"].ToString();
        //        newSite.Address = address;
        //        #endregion

        //        #region CustomerSiteID
        //        if (!isCustomerizedID)
        //        {
        //            string customerSiteID = row["CustomerSiteID"].ToString();
        //            if (customerSiteID.Length > 100)
        //            {
        //                dtErrInfo.Rows.Add(new object[] { rowNumber, "CustomerSiteID", customerSiteID, "The length is more than 100" });
        //                isFail = true;
        //            }
        //            if (customerSiteID.Length < 4)
        //            {
        //                dtErrInfo.Rows.Add(new object[] { rowNumber, "CustomerSiteID", customerSiteID, "CustomerSiteID can not be null" });
        //                isFail = true;
        //            }
        //            newSite.CustomerSiteID = customerSiteID;
        //        }
        //        #endregion

        //        #region SiteType
        //        string siteTypeName = row["SiteType"].ToString();
        //        int siteTypeID = 0;
        //        SiteType siteType = new SiteType();
        //        siteType.ConnectionString = connStr;
        //        siteType.Where.SiteTypeName.Value = siteTypeName;
        //        if (!siteType.Query.Load())
        //        {
        //            dtErrInfo.Rows.Add(new object[] { rowNumber, "SiteType", siteTypeName, "site type name not found" });
        //            isFail = true;
        //        }
        //        else
        //        {
        //            siteTypeID = siteType.SiteTypeID;
        //            newSite.SiteTypeID = siteTypeID;
        //        }

        //        #endregion

        //        #region IsCarWash
        //        string isCarWash = row["IsCarWash"].ToString().Trim();
        //        if (isCarWash != "Y" && isCarWash != "N" && isCarWash != "0" && isCarWash != "1" && isCarWash != "")
        //        {
        //            dtErrInfo.Rows.Add(new object[] { rowNumber, "IsCarWash", isCarWash, "IsCarWash Value (not Y, N, 1, 0, or empty)" });
        //            isFail = true;
        //        }
        //        newSite.Carwash = (isCarWash == "Y" || isCarWash == "1");
        //        #endregion

        //        #region PostalCode
        //        string postalCode = row["PostalCode"].ToString();
        //        //todo:Check postal code format
        //        newSite.PostalCode = postalCode;
        //        #endregion

        //        #region PrimaryContactName
        //        string primaryContactName = row["PrimaryContactName"].ToString();
        //        if (primaryContactName == "")
        //        {
        //            dtErrInfo.Rows.Add(new object[] { rowNumber, "PrimaryContactName", "null", "Primary contact Name is null" });
        //            isFail = true;
        //        }
        //        newSite.PCFirstName = primaryContactName;
        //        #endregion

        //        #region PrimaryContactPhone
        //        string primaryContactPhone = row["PrimaryContactPhone"].ToString();
        //        if (primaryContactPhone == "")
        //        {
        //            dtErrInfo.Rows.Add(new object[] { rowNumber, "PrimaryContactPhone", "null", "Primary Contact Phone is null" });
        //            isFail = true;
        //        }
        //        else if (!ValidateFormat(primaryContactPhone, ValidateType.PhoneNum))
        //        {
        //            dtErrInfo.Rows.Add(new object[] { rowNumber, "PrimaryContactPhone", primaryContactPhone, "Primary Contact Phone is wrong format" });
        //            isFail = true;
        //        }
        //        newSite.PCPhone = primaryContactPhone;
        //        #endregion

        //        #region SecondaryContactName
        //        string secondaryContactName = row["SecondaryContactName"].ToString();
        //        newSite.SCFirstName = secondaryContactName;
        //        #endregion

        //        #region SecondaryContactPhone
        //        string secondaryContactPhone = row["SecondaryContactPhone"].ToString();
        //        if (secondaryContactPhone != "")
        //        {
        //            if (!ValidateFormat(secondaryContactPhone, ValidateType.PhoneNum))
        //            {
        //                dtErrInfo.Rows.Add(new object[] { rowNumber, "SecondaryContactPhone", secondaryContactPhone, "Secondary Contact Phone is error format" });
        //                isFail = true;
        //            }
        //        }
        //        newSite.SCPhone = secondaryContactPhone;
        //        #endregion

        //        #region NumPlayers
        //        string numPlayers = row["NumPlayers"].ToString();
        //        int iNumPlayers = Utility.ConvertStrToInt(numPlayers);
        //        if (iNumPlayers <= 0 || iNumPlayers > 50)
        //        {
        //            dtErrInfo.Rows.Add(new object[] { rowNumber, "NumPlayers", numPlayers, "Number of players is wrong" });
        //            isFail = true;
        //        }
        //        newSite.NumPlayers = iNumPlayers;
        //        #endregion

        //        #region RouterIP
        //        string routerIP = row["RouterIP"].ToString();
        //        if (routerIP != "")
        //        {
        //            if (!ValidateFormat(routerIP, ValidateType.IPAdderss))
        //            {
        //                dtErrInfo.Rows.Add(new object[] { rowNumber, "RouterIP", routerIP, "Error format router IP" });
        //                isFail = true;
        //            }
        //            else
        //            {
        //                string[] ips = routerIP.Split('.');
        //                newSite.RouterIP1 = Convert.ToInt32(ips[0].Trim());
        //                newSite.RouterIP2 = Convert.ToInt32(ips[1].Trim());
        //                newSite.RouterIP3 = Convert.ToInt32(ips[2].Trim());
        //                newSite.RouterIP4 = Convert.ToInt32(ips[3].Trim());
        //            }
        //        }
        //        #endregion

        //        #region WapIP
        //        string wapIP = row["WapIP"].ToString();
        //        if (wapIP != "")
        //        {
        //            if (!ValidateFormat(wapIP, ValidateType.IPAdderss))
        //            {
        //                dtErrInfo.Rows.Add(new object[] { rowNumber, "WapIP", wapIP, "Error format wap IP" });
        //                isFail = true;
        //            }
        //            else
        //            {
        //                string[] ips = routerIP.Split('.');
        //                newSite.WAPIP1 = Convert.ToInt32(ips[0].Trim());
        //                newSite.WAPIP2 = Convert.ToInt32(ips[1].Trim());
        //                newSite.WAPIP3 = Convert.ToInt32(ips[2].Trim());
        //                newSite.WAPIP4 = Convert.ToInt32(ips[3].Trim());
        //            }
        //        }
        //        #endregion

        //        #region RouterUserName
        //        string routerUserName = row["RouterUserName"].ToString();
        //        newSite.RouterUsername = routerUserName;
        //        #endregion

        //        #region RouterPassword
        //        string routerPassword = row["RouterPassword"].ToString();
        //        newSite.RouterPass = routerPassword;
        //        #endregion

        //        #region WapUserName
        //        string wapUserName = row["WapUserName"].ToString();
        //        newSite.WAPUsername = wapUserName;
        //        #endregion

        //        #region WapPassword
        //        string wapPassword = row["WapPassword"].ToString();
        //        newSite.WAPPass = wapPassword;
        //        #endregion

        //        #region WapSerial
        //        string wapSerial = row["WapSerial"].ToString();
        //        newSite.WAPSerial = wapSerial;
        //        #endregion

        //        #region Wireless SSID
        //        string wirelessSSID = row["WirelessSSID"].ToString();
        //        newSite.SSID = wirelessSSID;
        //        #endregion

        //        #region WapSecurity
        //        string wapSecurity = row["WapSecurity"].ToString();
        //        newSite.SecurityCode = wapSecurity;
        //        #endregion

        //        #region WeekdayOpenHour
        //        string weekdayOpenHour = row["WeekdayOpenHour"].ToString();
        //        if (weekdayOpenHour != "")
        //        {
        //            int iWeekdayOpenHour = Utility.ConvertStrToInt(weekdayOpenHour);
        //            if (iWeekdayOpenHour < 0 || iWeekdayOpenHour > 23)
        //            {
        //                dtErrInfo.Rows.Add(new object[] { rowNumber, "WeekdayOpenHour", weekdayOpenHour, "Error number is WeekdayOpenHour" });
        //                isFail = true;
        //            }
        //            newSite.WeekdayOpenHour = iWeekdayOpenHour;
        //        }
        //        #endregion

        //        #region WeekdayOpenMin
        //        string weekdayOpenMin = row["WeekdayOpenMin"].ToString();
        //        if (weekdayOpenMin != "")
        //        {
        //            int iWeekdayOpenMin = Utility.ConvertStrToInt(weekdayOpenMin);
        //            if (iWeekdayOpenMin != 0 && iWeekdayOpenMin != 15 && iWeekdayOpenMin != 30 && iWeekdayOpenMin != 45)
        //            {
        //                dtErrInfo.Rows.Add(new object[] { rowNumber, "WeekdayOpenMin", weekdayOpenMin, "Error number is WeekdayOpenMin" });
        //                isFail = true;
        //            }
        //            newSite.WeekdayOpenMin = iWeekdayOpenMin;
        //        }
        //        #endregion

        //        #region WeekdayCloseHour
        //        string weekdayCloseHour = row["WeekdayCloseHour"].ToString();
        //        if (weekdayCloseHour != "")
        //        {
        //            int iWeekdayCloseHour = Utility.ConvertStrToInt(weekdayCloseHour);
        //            if (iWeekdayCloseHour < 0 || iWeekdayCloseHour > 23)
        //            {
        //                dtErrInfo.Rows.Add(new object[] { rowNumber, "WeekdayCloseHour", weekdayCloseHour, "Error number is WeekdayCloseHour" });
        //                isFail = true;
        //            }
        //            newSite.WeekdayCloseHour = iWeekdayCloseHour;
        //        }
        //        #endregion

        //        #region WeekdayCloseMin
        //        string weekdayCloseMin = row["WeekdayCloseMin"].ToString();
        //        if (weekdayCloseMin != "")
        //        {
        //            int iWeekdayCloseMin = Utility.ConvertStrToInt(weekdayCloseMin);
        //            if (iWeekdayCloseMin != 0 && iWeekdayCloseMin != 15 && iWeekdayCloseMin != 30 && iWeekdayCloseMin != 45)
        //            {
        //                dtErrInfo.Rows.Add(new object[] { rowNumber, "WeekdayCloseMin", weekdayCloseMin, "Error number is WeekdayCloseMin" });
        //                isFail = true;
        //            }
        //            newSite.WeekdayCloseMin = iWeekdayCloseMin;
        //        }
        //        #endregion

        //        #region SaturdayOpenHour
        //        string saturdayOpenHour = row["SaturdayOpenHour"].ToString();
        //        if (saturdayOpenHour != "")
        //        {
        //            int iSaturdayOpenHour = Utility.ConvertStrToInt(saturdayOpenHour);
        //            if (iSaturdayOpenHour < 0 || iSaturdayOpenHour > 23)
        //            {
        //                dtErrInfo.Rows.Add(new object[] { rowNumber, "SaturdayOpenHour", saturdayOpenHour, "Error number is SaturdayOpenHour" });
        //                isFail = true;
        //            }
        //            newSite.SaturdayOpenHour = iSaturdayOpenHour;
        //        }
        //        #endregion

        //        #region SaturdayOpenMin
        //        string saturdayOpenMin = row["SaturdayOpenMin"].ToString();
        //        if (saturdayOpenMin != "")
        //        {
        //            int iSaturdayOpenMin = Utility.ConvertStrToInt(saturdayOpenMin);
        //            if (iSaturdayOpenMin != 0 && iSaturdayOpenMin != 15 && iSaturdayOpenMin != 30 && iSaturdayOpenMin != 45)
        //            {
        //                dtErrInfo.Rows.Add(new object[] { rowNumber, "SaturdayOpenMin", saturdayOpenMin, "Error number is SaturdayOpenMin" });
        //                isFail = true;
        //            }
        //            newSite.SaturdayOpenMin = iSaturdayOpenMin;
        //        }
        //        #endregion

        //        #region SaturdayCloseHour
        //        string saturdayCloseHour = row["SaturdayCloseHour"].ToString();
        //        if (saturdayCloseHour != "")
        //        {
        //            int iSaturdayCloseHour = Utility.ConvertStrToInt(saturdayCloseHour);
        //            if (iSaturdayCloseHour < 0 || iSaturdayCloseHour > 23)
        //            {
        //                dtErrInfo.Rows.Add(new object[] { rowNumber, "SaturdayCloseHour", saturdayCloseHour, "Error number is SaturdayCloseHour" });
        //                isFail = true;
        //            }
        //            newSite.SaturdayCloseHour = iSaturdayCloseHour;
        //        }
        //        #endregion

        //        #region SaturdayCloseMin
        //        string saturdayCloseMin = row["SaturdayCloseMin"].ToString();
        //        if (saturdayCloseMin != "")
        //        {
        //            int iSaturdayCloseMin = Utility.ConvertStrToInt(saturdayCloseMin);
        //            if (iSaturdayCloseMin != 0 && iSaturdayCloseMin != 15 && iSaturdayCloseMin != 30 && iSaturdayCloseMin != 45)
        //            {
        //                dtErrInfo.Rows.Add(new object[] { rowNumber, "SaturdayCloseMin", saturdayCloseMin, "Error number is SaturdayCloseMin" });
        //                isFail = true;
        //            }
        //            newSite.SaturdayCloseMin = iSaturdayCloseMin;
        //        }
        //        #endregion

        //        #region SundayOpenHour
        //        string sundayOpenHour = row["SundayOpenHour"].ToString();
        //        if (sundayOpenHour != "")
        //        {
        //            int iSundayOpenHour = Utility.ConvertStrToInt(sundayOpenHour);
        //            if (iSundayOpenHour < 0 || iSundayOpenHour > 23)
        //            {
        //                dtErrInfo.Rows.Add(new object[] { rowNumber, "SundayOpenHour", sundayOpenHour, "Error number is SundayOpenHour" });
        //                isFail = true;
        //            }
        //            newSite.SundayOpenHour = iSundayOpenHour;
        //        }
        //        #endregion

        //        #region SundayOpenMin
        //        string sundayOpenMin = row["SundayOpenMin"].ToString();
        //        if (sundayOpenMin != "")
        //        {
        //            int iSundayOpenMin = Utility.ConvertStrToInt(sundayOpenMin);
        //            if (iSundayOpenMin != 0 && iSundayOpenMin != 15 && iSundayOpenMin != 30 && iSundayOpenMin != 45)
        //            {
        //                dtErrInfo.Rows.Add(new object[] { rowNumber, "SundayOpenMin", sundayOpenMin, "Error number is SundayOpenMin" });
        //                isFail = true;
        //            }
        //            newSite.SundayOpenMin = iSundayOpenMin;
        //        }
        //        #endregion

        //        #region SundayCloseHour
        //        string sundayCloseHour = row["SundayCloseHour"].ToString();
        //        if (sundayCloseHour != "")
        //        {
        //            int iSundayCloseHour = Utility.ConvertStrToInt(sundayCloseHour);
        //            if (iSundayCloseHour < 0 || iSundayCloseHour > 23)
        //            {
        //                dtErrInfo.Rows.Add(new object[] { rowNumber, "SundayCloseHour", sundayCloseHour, "Error number is SundayCloseHour" });
        //                isFail = true;
        //            }
        //            newSite.SundayCloseHour = iSundayCloseHour;
        //        }
        //        #endregion

        //        #region SundayCloseMin
        //        string sundayCloseMin = row["SundayCloseMin"].ToString();
        //        if (sundayCloseMin != "")
        //        {
        //            int iSundayCloseMin = Utility.ConvertStrToInt(sundayCloseMin);
        //            if (iSundayCloseMin != 0 && iSundayCloseMin != 15 && iSundayCloseMin != 30 && iSundayCloseMin != 45)
        //            {
        //                dtErrInfo.Rows.Add(new object[] { rowNumber, "SundayCloseMin", sundayCloseMin, "Error number is SundayCloseMin" });
        //                isFail = true;
        //            }
        //            newSite.SundayCloseMin = iSundayCloseMin;
        //        }
        //        #endregion

        //        //if every data passed validation then save it to database. 
        //        //SiteID generation logic is in site class buessniss layer.
        //        if (!isFail)
        //        {
        //            newSite.CreatedBy = Membership.GetUser().UserName;
        //            newSite.DateCreated = DateTime.Now;
        //            newSite.IsActive = true;
        //            if (!newSite.Save(Session[GlobalVariables.LoggedInCountry].ToString(), isCustomerizedID))
        //            {
        //                dtErrInfo.Rows.Add(new object[] { rowNumber, "SiteID", newSite.Siteid, "This site is already exists in database" });
        //            }
        //        }
        //    }

        //    return dtErrInfo;

        //}

        //private DataTable ImportUpdateSiteFile(string fileName)
        //{
        //    DataTable dt = null;
        //    DataTable dtErrInfo = new DataTable();
        //    dtErrInfo.Columns.Add("RowNumber", typeof(int));
        //    dtErrInfo.Columns.Add("ErrColumnName", typeof(string));
        //    dtErrInfo.Columns.Add("ErrColumnData", typeof(string));
        //    dtErrInfo.Columns.Add("ErrDescription", typeof(string));

        //    dt = this.GetDataTableFromExcel(fileName);

        //    //Check Column in imported Excel file match the template, no missing column
        //    string columnNames;
        //    columnNames = ",SiteID,CustomerSiteID,ProvinceName,CityName,DMAName,PetroleumPartnerName,";
        //    columnNames += "SiteBrandName,Address,SiteType,IsCarWash,PostalCode,";
        //    columnNames += "PrimaryContactName,PrimaryContactPhone,SecondaryContactName,";
        //    columnNames += "SecondaryContactPhone,NumPlayers,RouterIP,WapIP,RouterUserName,";
        //    columnNames += "RouterPassword,WAPUserName,WAPPassword,WapSerial,WirelessSSID,WapSecurity,";
        //    columnNames += "WeekdayOpenHour,WeekdayOpenMin,WeekdayCloseHour,WeekdayCloseMin,";
        //    columnNames += "SaturdayOpenHour,SaturdayOpenMin,SaturdayCloseHour,SaturdayCloseMin,";
        //    columnNames += "SundayOpenHour,SundayOpenMin,SundayCloseHour,SundayCloseMin,";

        //    int rowNumber = 0;
        //    string[] arrColumns = columnNames.Split(',');
        //    if (dt.Columns.Count != arrColumns.Length - 2)
        //    {
        //        dtErrInfo.Rows.Add(new object[] { rowNumber, "XLS Error", "Template", "The column in XLS file does not match orinigal template" });
        //        return dtErrInfo;
        //    }
        //    else
        //    {
        //        foreach (DataColumn column in dt.Columns)
        //        {
        //            if (columnNames.IndexOf("," + column.ColumnName + ",") < 0)
        //            {
        //                dtErrInfo.Rows.Add(new object[] { rowNumber, "XLS Error", "Template", "The column in XLS file does not match orinigal template" });
        //            }
        //        }
        //    }

        //    if (dtErrInfo.Rows.Count > 0)
        //    {
        //        return dtErrInfo;
        //    }

        //    foreach (DataRow row in dt.Rows)
        //    {
        //        site newSite = new site();
        //        newSite.ConnectionString = connStr;

        //        rowNumber++;
        //        bool isFail = false;

        //        #region SiteID
        //        string siteID = row["SiteID"].ToString();
        //        if (siteID == "")
        //        {
        //            dtErrInfo.Rows.Add(new object[] { rowNumber, "SiteID", "null", "SiteID is null" });
        //            isFail = true;
        //            continue;
        //        }
        //        if (!newSite.LoadByPrimaryKey(siteID))
        //        {
        //            dtErrInfo.Rows.Add(new object[] { rowNumber, "SiteID", siteID, "SiteID can not found in database" });
        //            isFail = true;
        //            continue;
        //        }
        //        #endregion

        //        #region ProvinceName
        //        string provinceName = row["ProvinceName"].ToString();
        //        int provinceID = 0;
        //        if (provinceName != "")
        //        {
        //            Province province = new Province();
        //            province.ConnectionString = connStr;
        //            province.Where.ProvinceName.Value = provinceName;
        //            if (!province.Query.Load())
        //            {
        //                dtErrInfo.Rows.Add(new object[] { rowNumber, "ProvinceName", provinceName, "Province name not found" });
        //                isFail = true;
        //            }
        //            else
        //            {
        //                provinceID = province.ProvinceID;
        //                newSite.ProvinceID = provinceID;
        //            }
        //        }
        //        #endregion

        //        #region CityName
        //        string cityName = row["CityName"].ToString().Trim();
        //        int cityID = 0;
        //        if (cityName == "")
        //        {
        //            dtErrInfo.Rows.Add(new object[] { rowNumber, "CityName", "null", "City Name is null" });
        //            isFail = true;
        //        }
        //        else
        //        {
        //            City c = new City();
        //            c.ConnectionString = connStr;
        //            c.Where.CityName.Value = cityName;
        //            if (!c.Query.Load()) //not find create new one
        //            {
        //                if (provinceID > 0)
        //                {
        //                    c.AddNew();
        //                    c.CityName = cityName;
        //                    c.ProvinceID = provinceID;
        //                    c.Save();
        //                }
        //                else
        //                {
        //                    dtErrInfo.Rows.Add(new object[] { rowNumber, "CityName", cityName, "CityName can not be found" });
        //                    isFail = true;
        //                }
        //            }
        //            cityID = c.CityID;
        //            newSite.CityID = cityID;
        //        }
        //        #endregion

        //        #region DMAName
        //        string DMAName = row["DMAName"].ToString();
        //        int DMAID = 0;
        //        if (DMAName == "")
        //        {
        //            dtErrInfo.Rows.Add(new object[] { rowNumber, "DMAName", "null", "DMAName is null" });
        //            isFail = true;
        //        }
        //        else //look up DMA table
        //        {
        //            DMA d = new DMA();
        //            d.ConnectionString = connStr;
        //            d.Where.DMAName.Value = DMAName;
        //            if (!d.Query.Load()) //not find create new one
        //            {
        //                dtErrInfo.Rows.Add(new object[] { rowNumber, "DMAName", DMAName, "DMAName can not be found" });
        //                isFail = true;
        //            }
        //            else
        //            {
        //                DMAID = d.ID;
        //                newSite.DMAID = DMAID;
        //            }
        //        }
        //        #endregion

        //        #region PetroleumPartnerName
        //        string petroleumPartnerName = row["PetroleumPartnerName"].ToString();
        //        int enterprisePartnerID = 0;
        //        EnterprisePartners e = new EnterprisePartners();
        //        e.ConnectionString = connStr;
        //        e.Where.EnterprisePartnerName.Value = petroleumPartnerName;
        //        if (!e.Query.Load())
        //        {
        //            dtErrInfo.Rows.Add(new object[] { rowNumber, "PetroleumPartnerName", petroleumPartnerName, "PetroleumPartner name not found" });
        //            isFail = true;
        //        }
        //        else
        //        {
        //            enterprisePartnerID = e.EnterprisePartnerID;
        //            newSite.EnterprisePartnerID = enterprisePartnerID;
        //        }

        //        #endregion

        //        #region Address
        //        string address = row["Address"].ToString();
        //        if (address != "")
        //        {
        //            newSite.Address = address;
        //        }
        //        #endregion

        //        #region SiteBrandName
        //        string sitebrandName = row["SiteBrandName"].ToString();
        //        if (sitebrandName != "")
        //        {
        //            int sitebrandID = 0;
        //            SiteBrand sitebrand = new SiteBrand();
        //            sitebrand.ConnectionString = connStr;
        //            sitebrand.Where.SiteBrandName.Value = sitebrandName;
        //            if (!sitebrand.Query.Load())
        //            {
        //                dtErrInfo.Rows.Add(new object[] { rowNumber, "SiteBrandName", sitebrandName, "SiteBrand name not found" });
        //                isFail = true;
        //            }
        //            else
        //            {
        //                sitebrandID = sitebrand.SiteBrandID;
        //                newSite.SiteBrandID = sitebrandID;
        //            }
        //        }
        //        #endregion

        //        #region CustomerSiteID
        //        string customerSiteID = row["CustomerSiteID"].ToString();
        //        if (customerSiteID != "")
        //        {
        //            if (customerSiteID.Length > 100)
        //            {
        //                dtErrInfo.Rows.Add(new object[] { rowNumber, "CustomerSiteID", customerSiteID, "The length is more than 100" });
        //                isFail = true;
        //            }
        //            if (customerSiteID.Length < 4)
        //            {
        //                dtErrInfo.Rows.Add(new object[] { rowNumber, "CustomerSiteID", customerSiteID, "CustomerSiteID can not be null" });
        //                isFail = true;
        //            }
        //            newSite.CustomerSiteID = customerSiteID;
        //        }
        //        #endregion

        //        #region SiteType
        //        string siteTypeName = row["SiteType"].ToString();
        //        if (siteTypeName != "")
        //        {
        //            int siteTypeID = 0;
        //            SiteType siteType = new SiteType();
        //            siteType.ConnectionString = connStr;
        //            siteType.Where.SiteTypeName.Value = siteTypeName;
        //            if (!siteType.Query.Load())
        //            {
        //                dtErrInfo.Rows.Add(new object[] { rowNumber, "SiteType", siteTypeName, "site type name not found" });
        //                isFail = true;
        //            }
        //            else
        //            {
        //                siteTypeID = siteType.SiteTypeID;
        //                newSite.SiteTypeID = siteTypeID;
        //            }
        //        }
        //        #endregion

        //        #region IsCarWash
        //        string isCarWash = row["IsCarWash"].ToString();

        //        if (isCarWash != "")
        //        {
        //            if (isCarWash != "Y" && isCarWash != "N" && isCarWash != "0" && isCarWash != "1")
        //            {
        //                dtErrInfo.Rows.Add(new object[] { rowNumber, "IsCarWash", isCarWash, "IsCarWash Value (not Y, N, 1, 0, or empty)" });
        //                isFail = true;
        //            }
        //            newSite.Carwash = (isCarWash == "Y" || isCarWash == "1");
        //        }
        //        #endregion

        //        #region PostalCode
        //        string postalCode = row["PostalCode"].ToString();
        //        if (postalCode != "")
        //        {

        //            //todo:Check postal code format
        //            newSite.PostalCode = postalCode;
        //        }
        //        #endregion

        //        #region SalesPartner
        //        //string salespartnerName = row["SalesPartner"].ToString();
        //        //if (salespartnerName != "")
        //        //{   
        //        //    int salespartnerID = 0;
        //        //    SalesPartner sp = new SalesPartner();
        //        //    sp.ConnectionString = connStr;
        //        //    sp.Where.SalesPartnerName.Value = salespartnerName;
        //        //    if (!sp.Query.Load())
        //        //    {
        //        //        dtErrInfo.Rows.Add(new object[] { rowNumber, "SalesPartner", salespartnerName, "SalesPartner not found" });
        //        //        isFail = true;
        //        //    }
        //        //    else
        //        //    {
        //        //        salespartnerID = sp.SalesPartnerID;
        //        //        newSite.SalesPartnerID = salespartnerID;
        //        //    }
        //        //}
        //        #endregion

        //        #region PrimaryContactName
        //        string primaryContactName = row["PrimaryContactName"].ToString();
        //        if (primaryContactName != "")
        //        {
        //            if (primaryContactName == "")
        //            {
        //                dtErrInfo.Rows.Add(new object[] { rowNumber, "PrimaryContactName", "null", "Primary contact Name is null" });
        //                isFail = true;
        //            }
        //            newSite.PCFirstName = primaryContactName;
        //        }
        //        #endregion

        //        #region PrimaryContactPhone
        //        string primaryContactPhone = row["PrimaryContactPhone"].ToString();
        //        if (primaryContactPhone != "")
        //        {
        //            if (primaryContactPhone == "")
        //            {
        //                dtErrInfo.Rows.Add(new object[] { rowNumber, "PrimaryContactPhone", "null", "Primary Contact Phone is null" });
        //                isFail = true;
        //            }
        //            else if (!ValidateFormat(primaryContactPhone, ValidateType.PhoneNum))
        //            {
        //                dtErrInfo.Rows.Add(new object[] { rowNumber, "PrimaryContactPhone", primaryContactPhone, "Primary Contact Phone is wrong format" });
        //                isFail = true;
        //            }
        //            newSite.PCPhone = primaryContactPhone;
        //        }
        //        #endregion

        //        #region SecondaryContactName
        //        string secondaryContactName = row["SecondaryContactName"].ToString();
        //        if (secondaryContactName != "")
        //        {
        //            newSite.SCFirstName = secondaryContactName;
        //        }
        //        #endregion

        //        #region SecondaryContactPhone
        //        string secondaryContactPhone = row["SecondaryContactPhone"].ToString();
        //        if (secondaryContactPhone != "")
        //        {
        //            if (!ValidateFormat(secondaryContactPhone, ValidateType.PhoneNum))
        //            {
        //                dtErrInfo.Rows.Add(new object[] { rowNumber, "SecondaryContactPhone", secondaryContactPhone, "Secondary Contact Phone is error format" });
        //                isFail = true;
        //            }
        //        }
        //        newSite.SCPhone = secondaryContactPhone;
        //        #endregion

        //        #region NumPlayers
        //        string numPlayers = row["NumPlayers"].ToString();
        //        if (numPlayers != "")
        //        {

        //            int iNumPlayers = Utility.ConvertStrToInt(numPlayers);
        //            if (iNumPlayers <= 0 || iNumPlayers > 50)
        //            {
        //                dtErrInfo.Rows.Add(new object[] { rowNumber, "NumPlayers", numPlayers, "Error number is num players" });
        //                isFail = true;
        //            }
        //            newSite.NumPlayers = iNumPlayers;
        //        }
        //        #endregion

        //        #region RouterIP
        //        string routerIP = row["RouterIP"].ToString();
        //        if (routerIP != "")
        //        {
        //            if (routerIP != "")
        //            {
        //                if (!ValidateFormat(routerIP, ValidateType.IPAdderss))
        //                {
        //                    dtErrInfo.Rows.Add(new object[] { rowNumber, "RouterIP", routerIP, "Error format router IP" });
        //                    isFail = true;
        //                }
        //                else
        //                {
        //                    string[] ips = routerIP.Split('.');
        //                    newSite.RouterIP1 = Convert.ToInt32(ips[0]);
        //                    newSite.RouterIP2 = Convert.ToInt32(ips[1]);
        //                    newSite.RouterIP3 = Convert.ToInt32(ips[2]);
        //                    newSite.RouterIP4 = Convert.ToInt32(ips[3]);
        //                }
        //            }
        //        }
        //        #endregion

        //        #region WapIP
        //        string wapIP = row["WapIP"].ToString();
        //        if (wapIP != "")
        //        {

        //            if (wapIP != "")
        //            {
        //                if (!ValidateFormat(wapIP, ValidateType.IPAdderss))
        //                {
        //                    dtErrInfo.Rows.Add(new object[] { rowNumber, "WapIP", wapIP, "Error format wap IP" });
        //                    isFail = true;
        //                }
        //                else
        //                {
        //                    string[] ips = routerIP.Split('.');
        //                    newSite.WAPIP1 = Convert.ToInt32(ips[0]);
        //                    newSite.WAPIP2 = Convert.ToInt32(ips[1]);
        //                    newSite.WAPIP3 = Convert.ToInt32(ips[2]);
        //                    newSite.WAPIP4 = Convert.ToInt32(ips[3]);
        //                }
        //            }
        //        }
        //        #endregion

        //        #region RouterUserName

        //        string routerUserName = row["RouterUserName"].ToString();

        //        if (routerUserName != "")
        //        {
        //            newSite.RouterUsername = routerUserName;
        //        }
        //        #endregion

        //        #region RouterPassword
        //        string routerPassword = row["RouterPassword"].ToString();
        //        if (routerPassword != "")
        //        {
        //            newSite.RouterPass = routerPassword;
        //        }
        //        #endregion

        //        #region WapUserName
        //        string wapUserName = row["WapUserName"].ToString();
        //        if (wapUserName != "")
        //        {
        //            newSite.WAPUsername = wapUserName;
        //        }
        //        #endregion

        //        #region WapPassword
        //        string wapPassword = row["WapPassword"].ToString();
        //        if (wapPassword != "")
        //        {
        //            newSite.WAPPass = wapPassword;
        //        }
        //        #endregion

        //        #region WapSerial
        //        string wapSerial = row["WapSerial"].ToString();
        //        if (wapSerial != "")
        //        {
        //            newSite.WAPSerial = wapSerial;
        //        }
        //        #endregion

        //        #region WeekdayOpenHour
        //        string weekdayOpenHour = row["WeekdayOpenHour"].ToString();
        //        if (weekdayOpenHour != "")
        //        {
        //            int iWeekdayOpenHour = Utility.ConvertStrToInt(weekdayOpenHour);
        //            if (iWeekdayOpenHour < 0 || iWeekdayOpenHour > 23)
        //            {
        //                dtErrInfo.Rows.Add(new object[] { rowNumber, "WeekdayOpenHour", weekdayOpenHour, "Error number is WeekdayOpenHour" });
        //                isFail = true;
        //            }
        //            newSite.WeekdayOpenHour = iWeekdayOpenHour;
        //        }
        //        #endregion

        //        #region WeekdayOpenMin
        //        string weekdayOpenMin = row["WeekdayOpenMin"].ToString();
        //        if (weekdayOpenMin != "")
        //        {
        //            int iWeekdayOpenMin = Utility.ConvertStrToInt(weekdayOpenMin);
        //            if (iWeekdayOpenMin != 0 && iWeekdayOpenMin != 15 && iWeekdayOpenMin != 30 && iWeekdayOpenMin != 45)
        //            {
        //                dtErrInfo.Rows.Add(new object[] { rowNumber, "WeekdayOpenMin", weekdayOpenMin, "Error number is WeekdayOpenMin" });
        //                isFail = true;
        //            }
        //            newSite.WeekdayOpenMin = iWeekdayOpenMin;
        //        }
        //        #endregion

        //        #region WeekdayCloseHour
        //        string weekdayCloseHour = row["WeekdayCloseHour"].ToString();
        //        if (weekdayCloseHour != "")
        //        {
        //            int iWeekdayCloseHour = Utility.ConvertStrToInt(weekdayCloseHour);
        //            if (iWeekdayCloseHour < 0 || iWeekdayCloseHour > 23)
        //            {
        //                dtErrInfo.Rows.Add(new object[] { rowNumber, "WeekdayCloseHour", weekdayCloseHour, "Error number is WeekdayCloseHour" });
        //                isFail = true;
        //            }
        //            newSite.WeekdayCloseHour = iWeekdayCloseHour;
        //        }
        //        #endregion

        //        #region WeekdayCloseMin
        //        string weekdayCloseMin = row["WeekdayCloseMin"].ToString();
        //        if (weekdayCloseMin != "")
        //        {
        //            int iWeekdayCloseMin = Utility.ConvertStrToInt(weekdayCloseMin);
        //            if (iWeekdayCloseMin != 0 && iWeekdayCloseMin != 15 && iWeekdayCloseMin != 30 && iWeekdayCloseMin != 45)
        //            {
        //                dtErrInfo.Rows.Add(new object[] { rowNumber, "WeekdayCloseMin", weekdayCloseMin, "Error number is WeekdayCloseMin" });
        //                isFail = true;
        //            }
        //            newSite.WeekdayCloseMin = iWeekdayCloseMin;
        //        }
        //        #endregion

        //        #region SaturdayOpenHour
        //        string saturdayOpenHour = row["SaturdayOpenHour"].ToString();
        //        if (saturdayOpenHour != "")
        //        {
        //            int iSaturdayOpenHour = Utility.ConvertStrToInt(saturdayOpenHour);
        //            if (iSaturdayOpenHour < 0 || iSaturdayOpenHour > 23)
        //            {
        //                dtErrInfo.Rows.Add(new object[] { rowNumber, "SaturdayOpenHour", saturdayOpenHour, "Error number is SaturdayOpenHour" });
        //                isFail = true;
        //            }
        //            newSite.SaturdayOpenHour = iSaturdayOpenHour;
        //        }
        //        #endregion

        //        #region SaturdayOpenMin
        //        string saturdayOpenMin = row["SaturdayOpenMin"].ToString();
        //        if (saturdayOpenMin != "")
        //        {
        //            int iSaturdayOpenMin = Utility.ConvertStrToInt(saturdayOpenMin);
        //            if (iSaturdayOpenMin != 0 && iSaturdayOpenMin != 15 && iSaturdayOpenMin != 30 && iSaturdayOpenMin != 45)
        //            {
        //                dtErrInfo.Rows.Add(new object[] { rowNumber, "SaturdayOpenMin", saturdayOpenMin, "Error number is SaturdayOpenMin" });
        //                isFail = true;
        //            }
        //            newSite.SaturdayOpenMin = iSaturdayOpenMin;
        //        }
        //        #endregion

        //        #region SaturdayCloseHour
        //        string saturdayCloseHour = row["SaturdayCloseHour"].ToString();
        //        if (saturdayCloseHour != "")
        //        {
        //            int iSaturdayCloseHour = Utility.ConvertStrToInt(saturdayCloseHour);
        //            if (iSaturdayCloseHour < 0 || iSaturdayCloseHour > 23)
        //            {
        //                dtErrInfo.Rows.Add(new object[] { rowNumber, "SaturdayCloseHour", saturdayCloseHour, "Error number is SaturdayCloseHour" });
        //                isFail = true;
        //            }
        //            newSite.SaturdayCloseHour = iSaturdayCloseHour;
        //        }
        //        #endregion

        //        #region SaturdayCloseMin
        //        string saturdayCloseMin = row["SaturdayCloseMin"].ToString();
        //        if (saturdayCloseMin != "")
        //        {
        //            int iSaturdayCloseMin = Utility.ConvertStrToInt(saturdayCloseMin);
        //            if (iSaturdayCloseMin != 0 && iSaturdayCloseMin != 15 && iSaturdayCloseMin != 30 && iSaturdayCloseMin != 45)
        //            {
        //                dtErrInfo.Rows.Add(new object[] { rowNumber, "SaturdayCloseMin", saturdayCloseMin, "Error number is SaturdayCloseMin" });
        //                isFail = true;
        //            }
        //            newSite.SaturdayCloseMin = iSaturdayCloseMin;
        //        }
        //        #endregion

        //        #region SundayOpenHour
        //        string sundayOpenHour = row["SundayOpenHour"].ToString();
        //        if (sundayOpenHour != "")
        //        {
        //            int iSundayOpenHour = Utility.ConvertStrToInt(sundayOpenHour);
        //            if (iSundayOpenHour < 0 || iSundayOpenHour > 23)
        //            {
        //                dtErrInfo.Rows.Add(new object[] { rowNumber, "SundayOpenHour", sundayOpenHour, "Error number is SundayOpenHour" });
        //                isFail = true;
        //            }
        //            newSite.SundayOpenHour = iSundayOpenHour;
        //        }
        //        #endregion

        //        #region SundayOpenMin
        //        string sundayOpenMin = row["SundayOpenMin"].ToString();
        //        if (sundayOpenMin != "")
        //        {
        //            int iSundayOpenMin = Utility.ConvertStrToInt(sundayOpenMin);
        //            if (iSundayOpenMin != 0 && iSundayOpenMin != 15 && iSundayOpenMin != 30 && iSundayOpenMin != 45)
        //            {
        //                dtErrInfo.Rows.Add(new object[] { rowNumber, "SundayOpenMin", sundayOpenMin, "Error number is SundayOpenMin" });
        //                isFail = true;
        //            }
        //            newSite.SundayOpenMin = iSundayOpenMin;
        //        }
        //        #endregion

        //        #region SundayCloseHour
        //        string sundayCloseHour = row["SundayCloseHour"].ToString();
        //        if (sundayCloseHour != "")
        //        {
        //            int iSundayCloseHour = Utility.ConvertStrToInt(sundayCloseHour);
        //            if (iSundayCloseHour < 0 || iSundayCloseHour > 23)
        //            {
        //                dtErrInfo.Rows.Add(new object[] { rowNumber, "SundayCloseHour", sundayCloseHour, "Error number is SundayCloseHour" });
        //                isFail = true;
        //            }
        //            newSite.SundayCloseHour = iSundayCloseHour;
        //        }
        //        #endregion

        //        #region SundayCloseMin
        //        string sundayCloseMin = row["SundayCloseMin"].ToString();
        //        if (sundayCloseMin != "")
        //        {
        //            int iSundayCloseMin = Utility.ConvertStrToInt(sundayCloseMin);
        //            if (iSundayCloseMin != 0 && iSundayCloseMin != 15 && iSundayCloseMin != 30 && iSundayCloseMin != 45)
        //            {
        //                dtErrInfo.Rows.Add(new object[] { rowNumber, "SundayCloseMin", sundayCloseMin, "Error number is SundayCloseMin" });
        //                isFail = true;
        //            }
        //            newSite.SundayCloseMin = iSundayCloseMin;
        //        }
        //        #endregion

        //        //if every data passed validation then save it to database. 
        //        //do not re generate siteID,because siteID is pKey
        //        if (!isFail)
        //        {
        //            newSite.Save();
        //        }
        //    }
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
