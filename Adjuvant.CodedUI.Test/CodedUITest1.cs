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
using Adjuvant.CodedUI.Test.Tests.Login;
namespace Adjuvant.CodedUI.Test
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class CodedUITest1
    {

        static string web = ConfigurationManager.AppSettings.Get("website");
        static BrowserWindow bw = BrowserWindow.Launch(new Uri(web));
        //private var bw = BrowserWindow.Launch();
        public CodedUITest1()
        {

        }

        [TestMethod]
        public void CodedUITestMethod1()
        {
            Login login = new Login(bw);
            login.LogInWithCorrectDetails("johan@rmms.co.za", "Fgx1234!");
        }

                   
        
        [TestMethod]
        public void Login1()
        {
            BrowserWindow.CurrentBrowser = "chrome";
            bw = BrowserWindow.Launch(new Uri("https://localhost:44323/")); ;
            //var bw = BrowserWindow.Launch(new Uri("https://fgxadjuvantdev.azurewebsites.net"));
            //var bw = brw;
            HtmlEdit txtUsername = new HtmlEdit(bw);
            HtmlEdit txtPassword = new HtmlEdit(bw);
            HtmlButton btnLogin = new HtmlButton(bw);
            txtUsername.SearchProperties.Add(HtmlEdit.PropertyNames.Id, "username");
            txtPassword.SearchProperties.Add(HtmlEdit.PropertyNames.Id, "password");
            btnLogin.SearchProperties.Add(HtmlButton.PropertyNames.Id, "btn_login");

            Keyboard.SendKeys(txtUsername, "johan@rmms.co.za");
            Keyboard.SendKeys(txtPassword, "Fgx1234!");
            Mouse.Click(btnLogin);

           // SelectBusinessPartner();
        }

        [TestMethod]
        public void SelectBusinessPartner()
        {
           Login1();
            HtmlComboBox lstBusinessPartner = new HtmlComboBox(bw);
            HtmlComboBox lstLocation = new HtmlComboBox(bw);
            HtmlButton btnFinish = new HtmlButton(bw);
            lstBusinessPartner.SearchProperties.Add(HtmlListItem.PropertyNames.Id, "BusinessPartner");
            lstLocation.SearchProperties.Add(HtmlListItem.PropertyNames.Id, "LocationId");
            btnFinish.SearchProperties.Add(HtmlButton.PropertyNames.Id, "btn_finish");
            
            UITestControlCollection col = lstBusinessPartner.FindMatchingControls();
            List<HtmlComboBox> partners = new List<HtmlComboBox>();
            if (col.Count > 0)
            {
                foreach (HtmlComboBox comboBox in col)
                {
                    #region ricky
                    /*if (lstBusinessPartner.Name == "BusinessPartnerId")
                    {

                        UITestControlCollection col2 = comboBox.Items;
                        foreach (HtmlListItem item in col2)
                        {

                            Playback.PlaybackSettings.DelayBetweenActions = 5000;
                            if (item.ValueAttribute == valueToSelect)
                            {
                                comboBox.SelectedItem = item.InnerText;

                                Playback.PlaybackSettings.DelayBetweenActions = 5000;
                                break;
                            }

                        }
                    }*/
                    #endregion
                    int item = comboBox.SelectedIndex = 1;
                    if (comboBox.SelectedIndex == 1)
                    {
                        lstBusinessPartner.SelectedItem = comboBox.SelectedItem;
                    }
                }
            }
            Playback.PlaybackSettings.DelayBetweenActions = 10000;
            Mouse.Click(btnFinish);

            Playback.PlaybackSettings.DelayBetweenActions = 5000;
            OpenCashierArea();
            OpenCashHouse();
        }

        public void OpenCashierArea()
        {
            HtmlHyperlink cashier = new HtmlHyperlink(bw);
            cashier.SearchProperties.Add(HtmlHyperlink.PropertyNames.Id, "cashier");
            Mouse.Click(cashier);
        }

        public void OpenCashHouse()
        {
            // controls to be used
            HtmlDiv cashHouse = new HtmlDiv(bw);
            //HtmlComboBox cashHouseSelect = new HtmlComboBox(bw);
            //HtmlEdit floatAmount = new HtmlEdit(bw);
            //HtmlTextArea note = new HtmlTextArea(bw);
            //HtmlButton btnOpenCashHouse = new HtmlButton(bw);
            //btnOpenCashHouse.SearchProperties.Add(HtmlButton.PropertyNames.Id, "cmdOpenCashHouse");
            //note.SearchProperties.Add(HtmlTextArea.PropertyNames.Id, "note");
            //floatAmount.SearchProperties.Add(HtmlEdit.PropertyNames.Id, "floatAmount");
            //cashHouseSelect.SearchProperties.Add(HtmlComboBox.PropertyNames.Id, "cashHouseSelect");
            cashHouse.SearchProperties.Add(HtmlDiv.PropertyNames.Name, "openCashHouse");

            Playback.PlaybackSettings.DelayBetweenActions = 5000;
            Mouse.Click(cashHouse);

            // entering the data for opening the cash house
           /* UITestControlCollection col = cashHouseSelect.FindMatchingControls();
            List<HtmlComboBox> partners = new List<HtmlComboBox>();
            if (col.Count > 0)
            {
                foreach (HtmlComboBox comboBox in col)
                {
                    if (comboBox.SelectedIndex == 0)
                    {
                        cashHouseSelect.SelectedItem = comboBox.SelectedItem;
                    }
                }
            }
            
            // ente test values in the text areas
            Keyboard.SendKeys(floatAmount,"1");
            Keyboard.SendKeys(note, "testing");

            Mouse.Click(btnOpenCashHouse);*/
        }



        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;
    }
}
