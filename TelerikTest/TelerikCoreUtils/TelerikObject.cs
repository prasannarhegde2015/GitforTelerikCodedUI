using ArtOfTest.WebAii.Controls.HtmlControls;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.ObjectModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TelerikTest
{
    static class TelerikObject
    {

        public  static  Manager mgr;
        public static string strGlobalTimeout = ConfigurationManager.AppSettings["globaltimeout"].ToString();
        public static string appBrowser = ConfigurationManager.AppSettings["browser"].ToString();
        public static int globalTimeout = Convert.ToInt32(strGlobalTimeout);


        public static void InitializeManager()
        {
            Settings mySettings = new Settings();
            mySettings.ClientReadyTimeout = 300000;
            mgr = new Manager(mySettings);
            mgr.Start();
            var browserUsed = BrowserType.InternetExplorer;
            switch(appBrowser.ToLower())
            {
                case "ie":
                    { browserUsed = BrowserType.InternetExplorer; break; }
                case "chrome":
                    { browserUsed = BrowserType.Chrome; break; }
                case "firefox":
                    { browserUsed = BrowserType.FireFox; break; }
            }
            mgr.LaunchNewBrowser(browserUsed, true, ProcessWindowStyle.Maximized);
            // return mgr;
        }
     
        

        public static Element getElement(string searchby, string searchvalue, string eleminfo)
        {
          //  mgr = InitializeManager();
            Element el = null;
            for (int i = 0; i < globalTimeout; i++)
            {
                mgr.ActiveBrowser.RefreshDomTree();
                Thread.Sleep(1000);
                Trace.WriteLine("using  Values for  Searchby :" + searchby + "Saerch value " + searchvalue);
                el = getElementSearchValue(searchby, searchvalue);
                if (el != null)
                {
                    Trace.WriteLine("Obtained Test Object"+eleminfo);
                    Thread.Sleep(1000);
                    break;
                }
            }
            return el;
        }

        public static Element  getElementSearchValue(string _searchBy, string  _searchValue)
        {
            Element _el = null;
            #region SearchCrieria
            switch(_searchBy.ToLower())
            {
                case "id":
                    {
                        try
                        {
                            _el = mgr.ActiveBrowser.Find.ById(_searchValue);
                        }
                        catch(Exception e)
                        {
                            throw e;
                        }
                        break;
                    }

                case "content":
                    {
                        try
                        {
                            _el = mgr.ActiveBrowser.Find.ByContent(_searchValue);
                        }
                        catch (Exception e)
                        {
                            throw e;
                        }
                        break;
                    }
                case "xpath":
                    {
                        try
                        {
                            _el = mgr.ActiveBrowser.Find.ByXPath(_searchValue);
                        }
                        catch (Exception e)
                        {
                            throw e;
                        }
                        break;
                    }
                case "name":
                    {
                        try
                        {
                            _el = mgr.ActiveBrowser.Find.ByName(_searchValue);
                        }
                        catch (Exception e)
                        {
                            throw e;
                        }
                        break;
                    }
                default:
                    {
                        break;

                    }

                    #endregion
            }
            return _el;
        }


        public static void click(Element el)
        {
            try
            {
     //           el.Wait.ForAttributes("Visible=True", "Enabled=True");
                HtmlControl ctl = new HtmlControl(el);
                waitForEnabled(ctl);
             //   ctl.Wait.ForCondition(ctl.IsEnabled, true, 5000);
                mgr.ActiveBrowser.Actions.Click(el);
            }
            catch(Exception e)
            {
                throw e;
            }

        }

        public static void sendkeys(Element el,string strval)
        {
            try
            {
                //           el.Wait.ForAttributes("Visible=True", "Enabled=True");
                HtmlControl ctl = new HtmlControl(el);
                waitForEnabled(ctl);
                //   ctl.Wait.ForCondition(ctl.IsEnabled, true, 5000);
                mgr.ActiveBrowser.Actions.SetText(el,strval);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static void waitForEnabled(HtmlControl _ctl)
        {
            for (int i=0; i<globalTimeout; i++)
            {
                Thread.Sleep(1000);
                if (_ctl.IsEnabled)
                {
                    Thread.Sleep(1000);
                    break;
                }
            }
        }
        public static void gotoPage(string url)
        {
            mgr.ActiveBrowser.NavigateTo(url);
        }
    }
}
