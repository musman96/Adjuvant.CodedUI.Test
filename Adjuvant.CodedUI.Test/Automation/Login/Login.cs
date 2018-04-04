using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
namespace Adjuvant.CodedUI.Test.Automation.Login
{
    public class Login
    {
        public Login()
        {

        }
        public void LoginUser(string user,string pass, BrowserWindow bw)
        {
           
            HtmlEdit txtUsername = new HtmlEdit(bw);
            HtmlEdit txtPassword = new HtmlEdit(bw);
            HtmlButton btnLogin = new HtmlButton(bw);
            txtUsername.SearchProperties.Add(HtmlEdit.PropertyNames.Id, "username");
            txtPassword.SearchProperties.Add(HtmlEdit.PropertyNames.Id, "password");
            btnLogin.SearchProperties.Add(HtmlButton.PropertyNames.Id, "btn_login");
            Keyboard.SendKeys(txtUsername, user);
            Keyboard.SendKeys(txtPassword, pass);
            Mouse.Click(btnLogin);
        }
    }
}
