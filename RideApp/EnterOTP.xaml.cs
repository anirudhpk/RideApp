using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace RideApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EnterOTP : ContentPage
	{
		int OTPNo;
		public EnterOTP (int otpNumber)
		{
			InitializeComponent ();
			//int OTP = otpNumber;
			OTPNo = otpNumber;
		}
        public void OnButtonClicked(object sender, EventArgs args)
        {
            if (OTPNo == int.Parse(enterOTPTxt.Text))
              {
				SQLConnector.InsertData(enterOTPTxt.Text);
				App.Current.MainPage = new MainMaps();
            }

		}
    }
}