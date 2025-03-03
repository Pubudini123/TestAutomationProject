using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FloAR.TestAutomation.Pages.Login;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace FloAR.TestAutomation.Tests
{
    [TestFixture]
    public class Fixture_001_Login : TestBase
    {
        ExReports exReports = null;
        string rootFolder = string.Empty;
        Utility utility;

        [OneTimeSetUp]
        public void SetUp()
        {
            /** TO DO : -  Use a environment Initilizer to get browser 
              and URL from user configuration**/
            InitializeNg();
            exReports = new ExReports();
            rootFolder = BackTrackToSpecificParent();
            exReports.InitializeExtentReports(Path.Combine(rootFolder, @"FloAR.TestAutomation.Tests\ExtentReports\ExtentReports.html"));
        }


        [SetUp]
        public void TestSetup()
        {
            exReports.CurrentTestDetails();
        }


        [OneTimeTearDown]
        public void TearDown()
        {
            CloseNG();
            exReports.FlushExtentReports();
            utility = new Utility();
            utility.CopyReport(rootFolder);
        }

        [TearDown]
        public void TestTearDown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stackTrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace) ? string.Empty : $"{TestContext.CurrentContext.Result.StackTrace}";
            exReports.TestTearDownLog(status, stackTrace, ngDriver);
        }


        [Test, Order(1)]
        [Description("Test on Login")]
        [Category("Regression")]
        [TestCase("pbadmin", "pbadmin")]
        public void Test_001_VerifyValidLogin(string username, string password)
        {
            LoginPage login = new LoginPage(ngDriver);
            ngDriver.WaitForAngular();
            login.TypeInCreadetials(username, password);
            var HomePage = login.ClickLoginValid();
            Thread.Sleep(5000);
            Assert.That(HomePage.HomeTabHeader.Text.Contains("Home"));
            exReports.AddScreenShotAsBase64String(exReports.CaptureBase64String(ngDriver), "image1");
        }
    }
}
