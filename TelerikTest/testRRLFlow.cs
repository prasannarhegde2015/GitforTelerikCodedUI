using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.ObjectModel;
using System.Diagnostics;
using System.Threading;
using System.Configuration;

namespace TelerikTest
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class testRRLFlow
    {

        public string appURL = ConfigurationManager.AppSettings["serverlurl"];
       
        public testRRLFlow()
        {
        }

        
        [TestInitialize]
        public void Init()
        {
        }
        
        [TestMethod]
        [DeploymentItem(@"C:\Program Files (x86)\Progress\Test Studio\Bin\Newtonsoft.Json.dll")]
        public void CodedUITestMethod1()
        {
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
            try
            {
                Trace.WriteLine("In First Line");
                Settings mySettings = new Settings();
                mySettings.ClientReadyTimeout = 300000;
                Manager mgr = new Manager(mySettings);
                mgr.Start();
                mgr.LaunchNewBrowser(BrowserType.InternetExplorer, true, ProcessWindowStyle.Maximized);
                Thread.Sleep(5000);
               mgr.ActiveBrowser.NavigateTo("http://localhost:2678");
       //      mgr.ActiveBrowser.NavigateTo("http://usdcpopsqlqa001:8000");
                Element _config = custWaitforElem(mgr, null, 300);
                _config.Wait.ForAttributes("Visible", "true");
                Thread.Sleep(1000);
                mgr.ActiveBrowser.Actions.Click(_config);

                //  mgr.Desktop.Mouse.Click(MouseClickType.LeftClick, el.GetRectangle());
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [TestMethod]
        [DeploymentItem(@"C:\Program Files (x86)\Progress\Test Studio\Bin\Newtonsoft.Json.dll")]
        public void test2()
        {
            TelerikObject.InitializeManager();
            TelerikObject.gotoPage(appURL);
            TelerikObject.click(Dashboard.configurationtab);
            TelerikObject.click(Dashboard.wellConfigurationtab);
            TelerikObject.click(Dashboard.btn_createNewWell);
            TelerikObject.click(WellConfig.cmb_WellType);
            TelerikObject.click(WellConfig.listitem_ESP);
            TelerikObject.sendkeys(WellConfig.txt_WellName, "ESP_002");
         //   dummywait();

        }

        public Element  custWaitforElem( Manager mgr ,Element el, int timeout)
        {
            for (int i = 0; i < timeout; i++)
            {
                mgr.ActiveBrowser.RefreshDomTree();
                Thread.Sleep(1000);
                el = mgr.ActiveBrowser.Find.ByContent("Configuration");
                if (el != null)
                {
                    Thread.Sleep(1000);
                    break;
                }
            }
            return el;
        }


        public void dummywait()
        {
            bool final = true;
            while (final)
            {
                //wait....
            }
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
        ///
        public Manager StartApplication()
        {
            try
            {
              //  string Browser = ConfigurationManager.AppSettings.Get("Browser");
                Settings ForeUIAutoSettings = new Settings();
                Manager ForeSiteUIAutoManager = new Manager(ForeUIAutoSettings);
                ForeSiteUIAutoManager.Start();
                // Launch a new browser instance. [This will launch an IE instance given the setting above]
                ForeSiteUIAutoManager.LaunchNewBrowser(BrowserType.InternetExplorer, true, ProcessWindowStyle.Maximized);
                // Navigate to Foresite
                ForeSiteUIAutoManager.ActiveBrowser.NavigateTo("http://localhost:2678");
                Thread.Sleep(5000);
                Trace.WriteLine("Using browserType : " + ForeSiteUIAutoManager.ActiveBrowser.BrowserType.ToString());
                return ForeSiteUIAutoManager;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
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
