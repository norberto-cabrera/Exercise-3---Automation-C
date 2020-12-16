using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise_3___Automation_C_v2
{
    public class BrowserFactory
    {
        private IWebDriver driver;

        public IWebDriver CreateBrowser()
        {
            try
            {
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
            }
            catch(Exception e) 
            {
                Console.WriteLine("The Driver was not created {0} ", e);
            }
            return driver;
        }
        
    }
}
