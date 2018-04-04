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
    public class Login
    {
        BrowserWindow bw;

        public Login(BrowserWindow browser)
        {
            this.bw = browser;
        }

        [TestMethod]
        public void LogInWithCorrectDetails(string user, string pass, BrowserWindow br)
        {
            string web = ConfigurationManager.AppSettings.Get("website");
            Adjuvant.CodedUI.Test.Automation.Login.Login login = new Automation.Login.Login();
            login.LoginWithCorrectDetails(user,pass,br);
            Assert();
        }
    }
}
