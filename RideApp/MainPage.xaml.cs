using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net;
using System.Collections.Specialized;

namespace RideApp
{
    public partial class MainPage : ContentPage
    {
        int otp;
        public MainPage()
        {
            InitializeComponent();
            
        }

        async public void OnButtonClicked(object sender, EventArgs args)
        {
            otp = Generate_otp();
            string mobileNo = PhoneNumberEntry.Text;
            string SMSContents = "", smsResult = "";
            SMSContents = otp.ToString() + " is your One-Time Password, valid for 10 minutes only, Please do not share your OTP with anyone.";
            smsResult = SendSMS(mobileNo, SMSContents);
            OTPSent.Text = " OTP is sent to your registered mobile no.";
            await Navigation.PushAsync(new EnterOTP(this.otp));
        }
        protected int Generate_otp()
        {
            char[] charArr = "0123456789".ToCharArray();
            string strrandom = string.Empty;
            Random objran = new Random();
            for (int i = 0; i < 4; i++)
            {
                //It will not allow Repetation of Characters
                int pos = objran.Next(1, charArr.Length);
                if (!strrandom.Contains(charArr.GetValue(pos).ToString())) strrandom += charArr.GetValue(pos);
                else i--;
            }
            return int.Parse(strrandom);
        }
        public static string SendSMS(string MblNo, string Msg)
        {
            using (var wb = new WebClient())
            {
                byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                {
                {"apikey" , "NDc2ZTUwNjk1MzU5NzQ0YzU3N2E0ZTM1NzY3OTY1NmU="},
                {"numbers" , MblNo},
                {"message" , Msg},
                {"sender" , "XTCTCF"}
                });
                string result = System.Text.Encoding.UTF8.GetString(response);
                return result;
            }
        }
    }        
}

