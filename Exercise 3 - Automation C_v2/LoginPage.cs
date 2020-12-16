using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;


namespace Exercise_3___Automation_C_v2
{
    class LoginPage
    {
        private IWebDriver Webdriver;

        public LoginPage(IWebDriver Webdriver)
        {
            this.Webdriver = Webdriver;
            PageFactory.InitElements(Webdriver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "#ap_email")]
        private IWebElement email;

        [FindsBy(How = How.XPath, Using = "//input[@id='continue']")]
        private IWebElement continuar;

        [FindsBy(How = How.CssSelector, Using = "#ap_password")]
        private IWebElement password;

        [FindsBy(How = How.CssSelector, Using = "#signInSubmit")]
        private IWebElement iniciar;

        //Implement explicit waits for all the elements.
        public void waitelement(IWebElement locator)
        {
            WebDriverWait wait = new WebDriverWait(Webdriver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        public void login(string email_log, string pass)
        {
            waitelement(email);
            email.SendKeys(email_log);
            waitelement(continuar);
            continuar.Click();
            waitelement(password);
            password.SendKeys(pass);
            waitelement(iniciar);
            iniciar.Click();
        }
    }
}
