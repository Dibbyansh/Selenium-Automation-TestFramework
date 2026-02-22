using OpenQA.Selenium;
using OrangeHRM_Revised.Utilities;
using OrangeHRM_Revised.Locators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM_Revised.Pages.Dashboard.Components
{
    public class TimeAtWorkCardPage
    {
        private readonly IWebDriver WebDriver;
        public TimeAtWorkCardPage(IWebDriver WebDriver) { 
            this.WebDriver = WebDriver;
            //WaitHelper.WaitForSpinnerToDisappear(WebDriver, DashbardPageLocators.CardSpinner, 30);
        }
    }
}
