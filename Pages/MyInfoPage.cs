using OpenQA.Selenium;
using OrangeHRM_Revised.Base;
using OrangeHRM_Revised.Locators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OrangeHRM_Revised.Pages
{
    public class MyInfoPage
    {
        private readonly IWebDriver _driver;

        public MyInfoPage(IWebDriver _driver) { 
            this._driver = _driver;
            WaitHelper.ClickWhenReady(_driver, DashbardPageLocators.SidePanelMenuByName("My Info"));
        } 

        public void VerifyName()
        {
            // verify that employee name is displayed in user dropdown and in card
            WaitHelper.WaitForSpinnerToDisappear(_driver, MyInfoPageLocators.CardSpinner);
            var nameInDropdown = WaitHelper.WaitForElement(_driver, MyInfoPageLocators.EmployeeNameInUserdropdown).Text;
            var nameInCard = WaitHelper.WaitForElement(_driver, MyInfoPageLocators.EmployeeNameInCard).Text;
            Assert.That(nameInDropdown, Is.EqualTo(nameInCard), $"Employee name in dropdown : '{nameInDropdown}' and card : '{nameInCard}' do not match");
        }

        public void ClearAndEnterInput(By locator, string value)
        {
            var input = WaitHelper.WaitForElement(_driver, locator);
            WaitHelper.ClickWhenReady(_driver, locator); 
            input.SendKeys(Keys.Control + "a");
            input.SendKeys(Keys.Delete);
            input.SendKeys(value);
        }

        public static void UploadFile(IWebDriver driver, By locator, string filename)
        {
            var filePath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "TestData", "Attachments", filename));
            driver.FindElement(locator).SendKeys(filePath);
        }
    }
}