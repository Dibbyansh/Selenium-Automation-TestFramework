using OpenQA.Selenium;

namespace OrangeHRM_Revised.Locators
{
    public class LoginPageLocators
    {
        // Login Page Locators
        public static By LoginTitle => By.XPath("//h5[text() = 'Login']");
        public static By UsernameField => By.Name("username");
        public static By PasswordField => By.Name("password");
        public static By LoginButton => By.CssSelector("button[type='submit']");
        public static By InvalidCredentialMsg => By.XPath("//p[text() = 'Invalid credentials']");

        // Dashboard Page Locators
        public static By SidePanelMenu => By.XPath("nav[aria-label='Sidepanel'] ul a span");
    }
}
