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
        public static By DashboardTitle => By.XPath("//h6[text() = 'Dashboard']");
        public static By SidePanelMenu => By.CssSelector("nav[aria-label='Sidepanel'] ul a span");
        public static By Cards(string title) => By.XPath("//div[contains(@class,'oxd-sheet')]//p[text()='{title}']");
        public static By CardSpinner => By.XPath("//div[contains(@class , 'loading-spinner-container')]");
        public static By CardContent => By.CssSelector("div.orangehrm-attendance-card");

    }
}
