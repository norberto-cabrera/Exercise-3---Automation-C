using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;


namespace Exercise_3___Automation_C_v2
{


    public class HomePage
    {
        private IWebDriver Webdriver;
        public string price1;
        public string price2;
        public string price3;
        public string items;

        public HomePage(IWebDriver Webdriver)
        {
            this.Webdriver = Webdriver;
            PageFactory.InitElements(Webdriver, this);
        }

        [FindsBy(How = How.XPath, Using = "//span[contains(text(),'Hola, Identifícate')]")]
        private IWebElement identificate;

        [FindsBy(How = How.CssSelector, Using = "#twotabsearchtextbox")]
        private IWebElement search1;

        [FindsBy(How = How.XPath, Using = "//header/div[@id='navbar']/div[@id='nav-belt']/div[2]/div[1]/form[1]/div[3]/div[1]/span[1]/input[1]")]
        private IWebElement search2;

        [FindsBy(How = How.XPath, Using = "//body/div[@id='a-page']/div[@id='search']/div[1]/div[2]/div[1]/span[3]/div[2]/div[1]/div[1]/span[1]/div[1]/div[1]/div[2]/h2[1]/a[1]/span[1]")]
        private IWebElement item1;

        [FindsBy(How = How.XPath, Using = "//body/div[@id='a-page']/div[@id='search']/div[1]/div[2]/div[1]/span[3]/div[2]/div[1]/div[1]/span[1]/div[1]/div[1]/div[4]/div[1]/div[1]/div[1]/a[1]/span[1]/span[2]/span[2]")]
        private IWebElement search_price;

        [FindsBy(How = How.XPath, Using = "//body/div[@id='a-page']/div[@id='search']/div[1]/div[2]/div[1]/span[3]/div[2]/div[1]/div[1]/span[1]/div[1]/div[1]/div[4]/div[1]/div[1]/div[1]/a[1]/span[1]/span[2]/span[3]")]
        private IWebElement search_cents;

        [FindsBy(How = How.CssSelector, Using = "#price_inside_buybox")]
        private IWebElement detail_price;

        [FindsBy(How = How.CssSelector, Using = "#add-to-cart-button")]
        private IWebElement cart;

        [FindsBy(How = How.CssSelector, Using = "body.a-m-mx.a-aui_149818-c.a-aui_152852-c.a-aui_157141-c.a-aui_160684-c.a-aui_57326-c.a-aui_72554-c.a-aui_accessibility_49860-c.a-aui_attr_validations_1_51371-c.a-aui_bolt_62845-c.a-aui_pci_risk_banner_210084-c.a-aui_perf_130093-c.a-aui_tnr_v2_180836-c.a-aui_ux_113788-c.a-aui_ux_114039-c.a-aui_ux_138741-c.a-aui_ux_145937-c.a-aui_ux_60000-c:nth-child(2) div.huc-v2-page-container:nth-child(27) div.a-row.celwidget:nth-child(6) div.a-box.a-onlychild.a-color-alternate-background.huc-v2-order-row.huc-v23-order-row div.a-box-inner div.a-row.huc-v2-table-row.full-width div.a-row.huc-v2-table-col:nth-child(3) div.a-row.full-width div.a-row.huc-v2-table-row.full-width.order-row-base-height div.a-row.huc-v2-table-col div.a-row.a-spacing-top-small.huc-v2-subcart.a-size-small:nth-child(1) div.a-row.a-spacing-micro:nth-child(1) span.a-size-medium.a-align-center.huc-subtotal > span.a-color-price.hlb-price.a-inline-block.a-text-bold:nth-child(2)")]
        private IWebElement cart_price;


        [FindsBy(How = How.XPath, Using = "//body/div[@id='a-page']/div[@id='cart-page-wrap']/div[@id='huc-page-container']/div[@id='huc-v2-order-row-with-divider']/div[@id='huc-v2-order-row-container']/div[1]/div[1]/div[3]/div[1]/div[1]/div[1]/div[1]/div[1]/span[1]/span[1]")]
        private IWebElement cart_items;

        [FindsBy(How = How.XPath, Using = "//body/div[@id='a-page']/div[@id='search']/div[1]/div[2]/div[1]/span[3]/div[2]/div[1]/div[1]/span[1]/div[1]/div[1]/span[1]/a[1]/div[1]/img[1]")]
        private IWebElement item2;

        //Implement explicit waits for all the elements.
        public void waitelement(IWebElement locator)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Webdriver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            }
            catch(Exception e)
            {
                Console.WriteLine("The element was not found {0} ", e);
            }
        }

        public void goToPage(String url)
        {
            Webdriver.Navigate().GoToUrl(url);
        }

        public void signin()
        {
            waitelement(identificate);
            identificate.Click();
        }

        public void search(String searching) 
        {
            waitelement(search1);
            search1.SendKeys(searching);
            waitelement(search2);
            search2.Click();
        }

        public void price_validation() 
        {
            waitelement(search_price);
            waitelement(search_cents);
            price1 = "$" + search_price.Text + "." + search_cents.Text;
            waitelement(item1);
            item1.Click();
            waitelement(detail_price);
            price2 = detail_price.Text;
            waitelement(cart);
            cart.Click();
            waitelement(cart_price);
            price3 = cart_price.Text;
        }

        public void cart_validation() 
        {
            waitelement(cart_items);
            items = cart_items.Text;
        }

        public void select() 
        {
            waitelement(item2);
            item2.Click();
        }

        public void add_cart() 
        {
            waitelement(cart);
            cart.Click();
        }

    }




}
