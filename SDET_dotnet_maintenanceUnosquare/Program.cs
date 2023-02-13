using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UnoSquare_Maintenance
{
    
    class Program
    {
        
        IWebDriver driver;
        public IWebDriver SetUpDriver()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            return driver;
        }

        public void Click(IWebElement element)
        {
            element.Click();
        }

        public void SendText(IWebElement element, string value)
        {
            element.SendKeys(value);
        }

        #region Google Locators
        By GoogleSearchBar = By.XPath("//input[@name='q']");
        By GoogleSearchIcon = By.XPath("//div[@class='wM6W7d']//span[text()='Unosquare Americas']");
        By UnoSquareGoogleResult = By.XPath("//div[@class='yuRUbf']//a/h3[contains(text(),'Unosquare')]");
        
        #endregion

        #region UnoSquare Locators
        By UnoSquareServicesMenu = By.XPath("//ul[@id='menu-main-menu-1']//li/a[text()='Services']");
        //"Practice Area" is no longer available  
        //By PracticeAreas = By.XPath("need maintenance"); 
        By ContactUs = By.XPath("//div[@class='elementor-button-wrapper']//a//span/span[contains(text(),'Contact Us')]");
        #endregion 
        static void Main(string[] args)
        {
            IWebDriver Browser;
            IWebElement element;
            Program program = new Program(); 
            Browser = program.SetUpDriver();
            Browser.Url = "https://www.google.com";

            element = Browser.FindElement(program.GoogleSearchBar);

            program.SendText(element, "Unosquare");

            element = Browser.FindElement(program.GoogleSearchIcon);

            program.Click(element);

            element = Browser.FindElement(program.UnoSquareGoogleResult);

            program.Click(element);

            element = Browser.FindElement(program.UnoSquareServicesMenu);

            program.Click(element);

            //element = Browser.FindElement(program.PracticeAreas);
            //program.Click(element);
             
            element = Browser.FindElement(program.ContactUs);

            program.Click(element);

            Thread.Sleep(3000);

            Assert.IsTrue(Browser.Url.Contains("contact-us"));
            
            Browser.Close();


            


        }
    }
}
