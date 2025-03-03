using OpenQA.Selenium;
using Protractor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloAR.TestAutomation.Pages.HomeScreen
{
    public class HomePage : Page
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
            // PageFactory.InitElements(driver, this);
        }

        public HomePage(NgWebDriver driver) : base(driver)
        {
            //PageFactory.InitElements(driver, this);
        }

        public IWebElement HomeTabHeader
        {
            get
            {
                return driver.FindElement(By.XPath("//a[@href='/layout/home' and contains(text(),'Home')]"));
            }
        }

    }
}
