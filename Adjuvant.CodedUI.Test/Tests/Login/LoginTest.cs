using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Adjuvant.CodedUI.Test.Automation.Login;
namespace Adjuvant.CodedUI.Test.Tests.Login
{
    [CodedUITest]
    public class LoginTest
    {
        //TODO: move to base class
        protected BrowserWindow bw { get; set; }
        protected Uri applicationBaseUri { get; set; }


        private readonly string username;
        private readonly string password;

        public LoginTest()
        {
            //TODO: move to base class constructor
            string web = ConfigurationManager.AppSettings.Get("website");
            applicationBaseUri = new Uri(web);

            //Setup values for this test (not from base class)
            username = "johan@rmms.co.za";
            password = "Fgx1234!";
        }

        public void AccessBrowser()
        {
            if (bw == null)
            {
                BrowserWindow.CurrentBrowser = "Chrome";
                bw = BrowserWindow.Launch(applicationBaseUri);
            }
        }

        [TestMethod]
        public void LogInWithCorrectDetails()
        {
            //Setup our browser for the test
            AccessBrowser();

            //Perform test actions using Automation
            Automation.Login.Login login = new Automation.Login.Login();
            login.LoginUser(username, password, bw);

            //Get output from user interface
            bw.

            //Assert that output is as expected
            Assert.AreEqual("johan@rmms.co.za", username, "username is invalid");
            Assert.AreEqual("Fgx1234!", password, "password is invalid");
            
           
        }
    }
}
