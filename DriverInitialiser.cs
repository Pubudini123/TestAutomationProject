using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using Protractor;
using FloAR.TestAutomation.Constant;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloAR.TestAutomation.Base
{
    public class DriverInitialiser
    {
        /// <summary>
        /// Stores the driver type
        /// </summary>
        private DriverTypes driverType;

        /// <summary>
        /// web driver instance
        /// </summary>
        private IWebDriver driver;

        /// <summary>
        /// Firefox Driver Service instance
        /// </summary>
        public FirefoxDriverService Service
        {
            get; set;
        }

        /// <summary>
        /// Stores the browser type
        /// </summary>
        public BrowserTypes BrowserType
        {
            get; set;
        }

        /// <summary>
        /// Initilizes new Driver initiater instance
        /// </summary>
        /// <param name="browsertype">Desired browser</param>
        /// <remarks> Default constructor set to initiate selenium driver </remarks>
        public DriverInitialiser(BrowserTypes type)
        {
            this.BrowserType = type;
            this.driverType = DriverTypes.SELENIUM;
        }


        /// <summary>
        /// Get desired selenium driver instance
        /// </summary>
        /// <returns>Web driver instance</returns>
        public IWebDriver GetDriver()
        {
            SetDriver();
            return driver;

        }

        /// <summary>
        /// Get desired Ngdriver instance
        /// </summary>
        /// <returns>NG Driver instance</returns>
        public NgWebDriver GetNgDriver()
        {
            SetDriver();
            return new NgWebDriver(driver);
        }

        /// <summary>
        /// Set the driver based on web browser
        /// </summary>
        private void SetDriver()
        {
            switch (BrowserType)
            {
                case BrowserTypes.FIREFOX:
                    driver = InitialiseFireFoxDriver();
                    break;
                case BrowserTypes.CHROME:
                    driver = InitialiseChromeDriver();
                    break;
            }

        }

        /// <summary>
        /// Initialize Chrome instance
        /// </summary>
        /// <returns>New Chrome driver Instance</returns>
        private IWebDriver InitialiseChromeDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument(ChromeConstant.NoSandBox);
            options.AddUserProfilePreference(ChromeConstant.CredentialsServiceStatus, false);
            options.AddUserProfilePreference("profile.password_manager_enabled", false);

            var root = BackTrackToSpecificParent(EnvironmentConstant.SolutionFolder);
            if (string.IsNullOrEmpty(root))
            {
                throw new Exception("Root folder does not exists");
            }
            var webDriverPath = Path.Combine(root, ChromeConstant.WebDriverPath);
            return new ChromeDriver(webDriverPath, options, TimeSpan.FromSeconds(120)); //@"C:\Test Automation\Drivers"
        }

        /// <summary>
        /// Initiliaze Fire fox driver instance
        /// </summary>
        /// <returns></returns>
        private IWebDriver InitialiseFireFoxDriver()
        {
            Service = FirefoxDriverService.CreateDefaultService(@"C:\Test Automation\Drivers");
            return new FirefoxDriver(Service);
        }

        public static string BackTrackToSpecificParent(string parent)
        {
            var parentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            while (!string.IsNullOrEmpty(parentDirectory) && !(new DirectoryInfo(parentDirectory)).Name.Equals(parent, StringComparison.OrdinalIgnoreCase))
            {
                parentDirectory = Directory.GetParent(parentDirectory)?.FullName;
            }
            return parentDirectory;
        }

    }
}
