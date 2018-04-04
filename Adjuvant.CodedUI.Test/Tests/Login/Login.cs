using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public class Login
    {
        BrowserWindow bw;

        public Login(BrowserWindow browser)
        {
            this.bw = browser;
        }

        [TestMethod]
        public void LogInWithCorrectDetails(string user, string pass)
        {
            string web = ConfigurationManager.AppSettings.Get("website");
            Automation.Login.Login login = new Automation.Login.Login();
            login.LoginWithCorrectDetails(user, pass, bw);
            Assert.AreEqual("johan@rmms.co.za",user,"username is invalid");
            Assert.AreEqual("Fgx1234!", pass, "password is invalid");
        }
    }
}
