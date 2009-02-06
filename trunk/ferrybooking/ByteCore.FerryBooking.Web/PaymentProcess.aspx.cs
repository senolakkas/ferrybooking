using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Moneris;
using ByteCore.FerryBooking.Core;

namespace ByteCore.FerryBooking.Web
{
    public partial class PaymentProcess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Session[ByteCore.FerryBooking.Web.SessionVariable.BookingInstance] is Booking))
            {
                Response.Redirect("Default.aspx");
            }
            
            if (!IsPostBack)
            {
                Booking bookingInstance = (Booking)Session[SessionVariable.BookingInstance];
                this.lblTotal.Text = bookingInstance.TotalAmount.ToString("c") + " USD";
                //TODO: Fillin the fields
                this.lblFirstName.Text = "";
                this.lblSurname.Text = "";
                this.lblPhoneNumber.Text = "";
            }
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            ProcessPayment();
            
        }

        private void ProcessPayment()
        {
            bool result=true;
            string host = "esqa.moneris.com";
            string store_id = "store3";
            string api_token = "yesguy";
            string order_id = "Test_P_01";
            string amount = "5.00";
            string card = "4242424242424242";
            string exp = "0812";
            string crypt = "7";

            HttpsPostRequest mpgReq =
                new HttpsPostRequest(host, store_id, api_token,
                           new Purchase(order_id, amount, card, exp, crypt), true);

            try
            {
                //TODO: Create booking

                //Send payment request
                Receipt receipt = mpgReq.GetReceipt();

                //Console.WriteLine("CardType = " + receipt.GetCardType());
                //Console.WriteLine("TransAmount = " + receipt.GetTransAmount());
                //Console.WriteLine("TxnNumber = " + receipt.GetTxnNumber());
                //Console.WriteLine("ReceiptId = " + receipt.GetReceiptId());
                //Console.WriteLine("TransType = " + receipt.GetTransType());
                //Console.WriteLine("ReferenceNum = " + receipt.GetReferenceNum());
                //Console.WriteLine("ResponseCode = " + receipt.GetResponseCode());
                //Console.WriteLine("ISO = " + receipt.GetISO());
                //Console.WriteLine("BankTotals = " + receipt.GetBankTotals());
                //Console.WriteLine("Message = " + receipt.GetMessage());
                //Console.WriteLine("AuthCode = " + receipt.GetAuthCode());
                //Console.WriteLine("Complete = " + receipt.GetComplete());
                //Console.WriteLine("TransDate = " + receipt.GetTransDate());
                //Console.WriteLine("TransTime = " + receipt.GetTransTime());
                //Console.WriteLine("Ticket = " + receipt.GetTicket());
                //Console.WriteLine("TimedOut = " + receipt.GetTimedOut());

                result = true;

            }
            catch (Exception ex)
            {
                result = false;
                //Console.WriteLine(ex);
            }

            if (result)
                Response.Redirect("PaymentFailed.aspx");
            else
                Response.Redirect("PaymentSucceed.aspx");
        }
    }
}
