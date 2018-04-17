using ArtOfTest.WebAii.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelerikTest
{ 
    static class WellConfig
    {

        public static Element cmb_WellType { get { return TelerikTest.TelerikObject.getElement("Content", "Select type...", "Select Well Type"); } }
        public static Element listitem_ESP { get { return TelerikTest.TelerikObject.getElement("Content", "ESP", "ESP Well Type"); } }
        public static Element txt_WellName { get { return TelerikTest.TelerikObject.getElement("Id", "wellName", "WellName"); } }
    }
}
