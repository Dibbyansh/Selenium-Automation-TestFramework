using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeHRM_Revised.Locators
{
    public class MyInfoPageLocators
    {
        public static By CardSpinner  => By.XPath("//div[contains(@class , 'loading-spinner-container')]");
        public static By PersonalDetailsTitle => By.CssSelector("div.orangehrm-card-container h6.orangehrm-main-title");
        public static By EmployeeNameInUserdropdown => By.CssSelector("div.oxd-topbar-header-userarea p");
        public static By EmployeeNameInCard => By.CssSelector("div.orangehrm-card-container div.orangehrm-edit-employee-name h6");
        public static By EmployeeFirstNameInput => By.CssSelector("form.oxd-form input.oxd-input[name = 'firstName']");
        public static By EmployeeLastNameInput => By.CssSelector("form.oxd-form input.oxd-input[name = 'lastName']");
        public static By EmployeeImg => By.CssSelector("div.orangehrm-card-container div.orangehrm-edit-employee-image img");
        public static By EmployeeImgUI => By.CssSelector("div.orangehrm-employee-picture img.employee-image");
        public static By EmployeeImgInput => By.CssSelector("input[type = 'file'].oxd-file-input");
        public static By FormUpdateSubmitBtn => By.CssSelector("form.oxd-form button");
        public static By ToastMessage => By.CssSelector("div.oxd-toast-container p.oxd-text--toast-message");
        public static By ProfilePicUpdateSubmitBtn => By.CssSelector("button[type= 'Submit'].orangehrm-left-space");



    }
}
