using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics;
using System.Threading;

namespace ForeSiteSelenium
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class CodedUITest1
    {
        public CodedUITest1()
        {
        }

        [TestMethod ]
        [DeploymentItem(@"C:\Users\E159279\Downloads\chromedriver_win32latest\chromedriver.exe")]
        [DeploymentItem(@"C:\Users\E159279\Downloads\IEDriverServer_Win32_3.9.0\IEDriverServer.exe")]
        public void CodedUITestMethod1()
        {
            //string chromeDriverDirectory = @"C:\Users\E159279\Downloads\chromedriver_win32latest"; 
            //var timespan = TimeSpan.FromMinutes(3);
            //var options = new ChromeOptions();
            //options.AddArgument("-no-sandbox");
            //ChromeDriver drv = new ChromeDriver(chromeDriverDirectory,options,timespan);

            var ieoptions = new InternetExplorerOptions();
            ieoptions.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            InternetExplorerDriver drv = new InternetExplorerDriver();



            WebDriverWait wt = new WebDriverWait(drv, System.TimeSpan.FromSeconds(300));
            drv.Manage().Window.Maximize();
            drv.Navigate().GoToUrl("http://usdcpopsqlqa001:8000");
            By byloc = By.XPath("//div[text()='Configuration']");
            wt.Until(ExpectedConditions.ElementToBeClickable(byloc));
            By loadingImage = By.XPath("//div[@class='loader']");
            WebDriverWait wait = new WebDriverWait(drv, System.TimeSpan.FromSeconds(300));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(loadingImage));
            wt.Until(ExpectedConditions.ElementToBeClickable(byloc));
            Thread.Sleep(2000);
            drv.FindElement(byloc).Click();
            Trace.WriteLine("Clicked Configuration Link");
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[text()='Well Configuration']")));
            drv.FindElement(By.XPath("//div[text()='Well Configuration']")).Click();
            Trace.WriteLine("Clicked Well Configuration Link");
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(loadingImage));
            Thread.Sleep(2000);
            Trace.WriteLine("Trying to click New Well button"+DateTime.Now.ToString());
            drv.FindElement(By.XPath("//button[contains(text(),'Create New Well')]")).Click();
            Trace.WriteLine("Clicked New Well Button"+DateTime.Now.ToString());

            
            //wellName
            drv.FindElement(By.Id("wellName")).SendKeys("RRL_0001");
            drv.FindElement(By.XPath("//kendo-dropdownlist[@id='wellType']")).Click();
            drv.FindElement(By.XPath("//li[text()='RRL']")).Click();
            //cygNetDomain
            drv.FindElement(By.XPath("//kendo-dropdownlist[@id='cygNetDomain']")).Click();
            drv.FindElement(By.XPath("//li[text()='27212']")).Click();
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(loadingImage));

            //siteService
            drv.FindElement(By.XPath("//kendo-dropdownlist[@id='siteService']")).Click();
            drv.FindElement(By.XPath("//li[contains(.,'.UIS')]")).Click();
            ////div[@id='facilityButtonDiv']
            drv.FindElement(By.XPath("//div[@id='facilityButtonDiv']")).Click();
            Trace.WriteLine("Extranoes wait to esnure Browser is open");
            Thread.Sleep(5000000);

            //kendo-dropdownlist[@id='wellType']
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
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
