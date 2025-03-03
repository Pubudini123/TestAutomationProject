using FloAR.TestAutomation.Base;
using FloAR.TestAutomation.Constant;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using Protractor;

namespace FloAR.TestAutomation.Tests
{
    public class TestBase
    {
        protected IWebDriver driver;
        protected NgWebDriver ngDriver;
        protected DriverInitialiser init;

        protected string BaseUrl = "https://baseURL";

        /// <summary>
        /// Initialize new Web Driver instance
        /// </summary>
        public void Initialize()
        {
            init = new DriverInitialiser(BrowserTypes.CHROME);
            driver = init.GetDriver();
            driver.Url = BaseUrl;
            driver.Manage().Window.Maximize();
        }

        /// <summary>
        /// Initializes the ng.
        /// </summary>
        public void InitializeNg()
        {

            init = new DriverInitialiser(BrowserTypes.CHROME);

            ngDriver = init.GetNgDriver();
            this.driver = ngDriver;
            ngDriver.Url = BaseUrl;
            ngDriver.Manage().Window.Maximize();
            SetTimeouts();
        }

        /// <summary>
        /// Initializes the ng with given URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        public void InitializeNgWithGivenUrl(string url)
        {
            init = new DriverInitialiser(BrowserTypes.CHROME);

            ngDriver = init.GetNgDriver();
            this.driver = ngDriver;
            ngDriver.Url = url;
            ngDriver.Manage().Window.Maximize();
            SetTimeouts();
        }

        /// <summary>
        /// Sets the timeouts.
        /// </summary>
        private void SetTimeouts()
        {
            ngDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(300);

            ngDriver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(3600);
        }

        /// <summary>
        /// Close existing web driver instance
        /// </summary>
        public void Close()
        {
            driver.Quit();
            if (init.BrowserType == BrowserTypes.FIREFOX)
            {
                init.Service.Dispose();
            }
        }

        public void CloseNG()
        {
            ngDriver.Close();
        }

        public static string BackTrackToSpecificParent(string parent)
        {
            return DriverInitialiser.BackTrackToSpecificParent(parent);
        }
        public static string BackTrackToSpecificParent()
        {
            return DriverInitialiser.BackTrackToSpecificParent(EnvironmentConstant.SolutionFolder);
        }
    }
}
