using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace Exercise_3___Automation_C_v2
{
    [Binding]
    public class AmazonLoginAndSearchSteps
    {
        IWebDriver driver;


        [Given(@"The following page amazon\.com\.mx")]
        public void GivenTheFollowingPageAmazon_Com_Mx()
        {
            BrowserFactory browser = new BrowserFactory();
            driver = browser.CreateBrowser();
            Reader conf = new Reader();
            conf.read();
            HomePage home = new HomePage(driver);
            home.goToPage(conf.url);
            Thread.Sleep(1000);
        }
        
        [Given(@"I have valid credentials to login")]
        public void GivenIHaveValidCredentialsToLogin()
        {
            HomePage home = new HomePage(driver);
            home.signin();
            Reader conf = new Reader();
            conf.read();
            LoginPage login = new LoginPage(driver);
            login.login(conf.user, conf.password);
            Thread.Sleep(1000);
        }
        
        [When(@"I search for Samsung Galaxy S(.*)GB")]
        public void WhenISearchForSamsungGalaxySGB(string p0)
        {
            HomePage home = new HomePage(driver);
            Reader conf = new Reader();
            conf.read();
            home.search(conf.search1);
            Thread.Sleep(1000);
            home.price_validation();
            Assert.AreEqual(home.price1, home.price2, "Prices are not equal");
            Console.WriteLine("Price1: " + home.price1 + "   Price2: " + home.price2);
            Assert.AreEqual(home.price1, home.price3, "Prices are not equal");
            Console.WriteLine("Price1: " + home.price1 + "   Price3: " + home.price3);
        }

        [Then(@"I validate that I have (.*) item in the cart")]
        public void ThenIValidateThatIHaveItemInTheCart(int p0)
        {
            HomePage home = new HomePage(driver);
            home.cart_validation();
            Assert.IsTrue(home.items.Contains("1"), "The cart does not have 1 element");
            Console.WriteLine("Items" + home.items);
        }


        [When(@"I search for Alienware Aw(.*)DW")]
        public void WhenISearchForAlienwareAwDW(int p0)
        {
            HomePage home = new HomePage(driver);
            Reader conf = new Reader();
            conf.read();
            home.search(conf.search2);
            home.select();
            home.add_cart();
            home.cart_validation();
            Assert.IsTrue(home.items.Contains("2"), "The cart does not have 2 element");
            Console.WriteLine("Items" + home.items);
            
        }


        [Then(@"I validate that I have (.*) items in the cart")]
        public void ThenIValidateThatIHaveItemsInTheCart(int p0)
        {
            HomePage home = new HomePage(driver);
            home.cart_validation();
            Assert.IsTrue(home.items.Contains("2"), "The cart does not have 2 element");
            Console.WriteLine("Items" + home.items);
            driver.Quit();
        }



    }
}
