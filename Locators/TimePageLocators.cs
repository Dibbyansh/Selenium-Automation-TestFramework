using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM_Revised.Locators
{
    public class TimePageLocators
    {
        public static By Attendance_PunchInPunchOut_Title => By.CssSelector("h6.orangehrm-main-title");
        public static By Attendance_PunchInPunchOut_SubmitBtn => By.CssSelector("button[type='Submit']");

        
    }
}
