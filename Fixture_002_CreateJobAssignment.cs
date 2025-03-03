using FloAR.TestAutomation.Pages.Login;
using NUnit.Framework;
using FloAR.TestAutomation.Pages.Jobs;
using FloAR.TestAutomation.TestData.TestDataResources;
using Protractor;

namespace FloAR.TestAutomation.Tests
{
    public class Fixture_002_CreateJobAssignment :TestBase
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
            //CloseNG();
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
            Thread.Sleep(7000);
            Assert.That(HomePage.HomeTabHeader.Text.Contains("Home"));
            exReports.AddScreenShotAsBase64String(exReports.CaptureBase64String(ngDriver), "image1");
        }

        [Test, Order(2)]
        [Description("Test on Create Job Assignments")]
        [Category("Regression")]
        public void Test_002_VerifyCreateJobAssignment()
        {
            JobAssignments JobAssignments = new JobAssignments(ngDriver);
            CreateJobAssignments CreateJobAssignments = new CreateJobAssignments(ngDriver);
            JobAssignments.ClickJobsTab();
            Thread.Sleep(5000);
            JobAssignments.ClickCreateJobAssignmentButton();
            Thread.Sleep(5000);
            exReports.AddScreenShotAsBase64String(exReports.CaptureBase64String(ngDriver), "image1");
            CreateJobAssignments.TypeInJobAssignmentMandatoryValues(NewJobAssignment_TestData.JobNo, NewJobAssignment_TestData.PTW, NewJobAssignment_TestData.PurchaseOrderNo, NewJobAssignment_TestData.TroubleTicket, ngDriver);
            exReports.AddScreenShotAsBase64String(exReports.CaptureBase64String(ngDriver), "image2");
            CreateJobAssignments.ClickCreateJobAssignment(ngDriver);
            Thread.Sleep(5000);
            Assert.That(JobAssignments.createJobSuccessfullyMessage.Text.Contains("create Job Successfully"));
            exReports.AddScreenShotAsBase64String(exReports.CaptureBase64String(ngDriver), "image3");
        }
    }
}
