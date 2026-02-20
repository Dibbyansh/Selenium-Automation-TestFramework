using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM_Revised.Locators
{
    public class DashbardPageLocators
    {
        public static By SidePanelMenu => By.XPath("nav[aria-label='Sidepanel'] ul a span");
    }
}
