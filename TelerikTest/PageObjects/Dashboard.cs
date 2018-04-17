using ArtOfTest.WebAii.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TelerikTest
{
    static class Dashboard
    {
        public static Element configurationtab { get { return TelerikTest.TelerikObject.getElement("Content", "Configuration", "Configuration Tab"); } }
        public static Element wellConfigurationtab { get { return TelerikTest.TelerikObject.getElement("Content", "Well Configuration", "Well Configuration Tab"); } }

        public static Element btn_createNewWell { get { return TelerikTest.TelerikObject.getElement("Content", "Create New Well", "Create New Well Button"); } }
    }
       
}
