using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;


namespace Exercise_3___Automation_C_v2
{
    [TestClass]
    public class UnitTest1
    {

        private IWebDriver driver;
        

        [TestInitialize]
        public void BrowserCreation()
        {
            BrowserFactory browser = new BrowserFactory();
            driver = browser.CreateBrowser();
        }

        [TestMethod]
        public void amazon_test1()
        {
            Reader conf = new Reader();
            conf.read();
            HomePage home = new HomePage(driver);
            home.goToPage(conf.url);
            Thread.Sleep(1000);
            home.signin();
            LoginPage login = new LoginPage(driver);
            login.login(conf.user, conf.password);
            Thread.Sleep(1000);
            home.search(conf.search1);
            Thread.Sleep(1000);
            home.price_validation();
            Assert.AreEqual(home.price1, home.price2, "Prices are not equal");
            Console.WriteLine("Price1: " + home.price1 + "   Price2: " + home.price2);
            Assert.AreEqual(home.price1, home.price3, "Prices are not equal");
            Console.WriteLine("Price1: " + home.price1 + "   Price3: " + home.price3);
            home.cart_validation();
            Assert.IsTrue(home.items.Contains("1"), "The cart does not have 1 element");
            Console.WriteLine("Items" + home.items);
            home.search(conf.search2);
            home.select();
            home.add_cart();
            home.cart_validation();
            Assert.IsTrue(home.items.Contains("2"), "The cart does not have 2 element");
            Console.WriteLine("Items" + home.items);
        }

        [TestCleanup()]
        public void testcleanp()
        {
            driver.Quit();
        }




    }
}
