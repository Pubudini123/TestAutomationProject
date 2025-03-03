using FloAR.TestAutomation.Pages.HomeScreen;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Protractor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloAR.TestAutomation.Pages.Login
{
    public class LoginPage : Page
    {
        public LoginPage(IWebDriver driver) : base(driver){ }

        public LoginPage(NgWebDriver driver) : base(driver) { }

        #region UI Controls
        public IWebElement UserNameTextBox
        {
            get
            {
                return driver.FindElement(By.XPath("//*[@formcontrolname= 'username' and @placeholder='Enter Your Username']"));
            }
        }

        public IWebElement PasswordTextBox
        {
            get
            {
                return driver.FindElement(By.XPath("//*[@formcontrolname= 'password' and @placeholder='Enter Your Password']"));
            }
        }

        public IWebElement LoginButton
        {
            get
            {
                return driver.FindElement(By.XPath("//*[@type= 'submit']"));
            }
        }
        #endregion

        #region UI Actions
        public LoginPage TypeInCreadetials(string username, string password)
        {
            UserNameTextBox.Clear();
            UserNameTextBox.SendKeys(username);
            PasswordTextBox.Clear();
            PasswordTextBox.SendKeys(password);
            return this;
        }

        public HomePage ClickLoginValid()
        {
            LoginButton.Click();
            return new HomePage(driver);
        }
        #endregion
    }
}
