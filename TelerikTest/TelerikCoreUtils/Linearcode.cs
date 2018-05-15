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
using System.Diagnostics;
using ArtOfTest.WebAii.Controls.HtmlControls;
using ArtOfTest.WebAii.ObjectModel;
using System.Threading;



namespace TelerikProject
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

        [TestMethod, DeploymentItem(@"E:\Prasanna\C#Tutorial\Telerik\Newtonsoft.Json.dll")]
        public void SampleTest()
        {
            Settings mySettings = new Settings();
            mySettings.ClientReadyTimeout = 100000;
            Manager mgr = new Manager(mySettings);
            mgr.Start();
            var browserUsed = BrowserType.InternetExplorer;
            mgr.LaunchNewBrowser(browserUsed, true, ProcessWindowStyle.Maximized);
            mgr.ActiveBrowser.ClearCache(BrowserCacheType.Cookies);
            mgr.ActiveBrowser.NavigateTo("https://dev46183.service-now.com");
            mgr.ActiveBrowser.WaitUntilReady();
            mgr.ActiveBrowser.WaitForAjax(30000);
            mgr.ActiveBrowser.Frames["gsft_main"].Find.ById<HtmlInputText>("user_name").Text = "admin";
            mgr.ActiveBrowser.Frames["gsft_main"].Find.ById<HtmlInputPassword>("user_password").Text = "ServiceNow97bd916$";
            mgr.ActiveBrowser.Frames["gsft_main"].Find.ById<HtmlButton>("sysverb_login").Click();
            mgr.ActiveBrowser.WaitForAjax(30000);
            mgr.ActiveBrowser.WaitUntilReady();
            Thread.Sleep(9000);
            mgr.ActiveBrowser.RefreshDomTree();
            Element e = mgr.ActiveBrowser.Find.ByXPath("//a[@title='Incidents']");
            HtmlWait wt = new HtmlWait(new HtmlControl(e), 50000);
            wt.ForExists();
            mgr.Desktop.Mouse.Click(MouseClickType.LeftClick, e.GetRectangle());
            Thread.Sleep(3000);
            mgr.ActiveBrowser.Frames["gsft_main"].Find.ById<HtmlButton>("sysverb_new").Click();
            Thread.Sleep(3000);
            string incnum = mgr.ActiveBrowser.Frames["gsft_main"].Find.ById<HtmlInputText>("incident.number").Value;
            Trace.WriteLine("Got num as "+incnum);
            Thread.Sleep(3000);
            mgr.ActiveBrowser.Frames["gsft_main"].Find.ById<HtmlInputText>("incident.short_description").Text = "5566";
            //incident.short_description
            incnum = mgr.ActiveBrowser.Frames["gsft_main"].Find.ById<HtmlInputText>("incident.short_description").Text;
            Trace.WriteLine("Got desc as "+incnum);   
            Thread.Sleep(5000);
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
