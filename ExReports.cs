using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using log4net.Util;
using System.Drawing.Imaging;

namespace FloAR.TestAutomation.Tests
{
    public class ExReports
    {
        public AventStack.ExtentReports.ExtentReports Extent  = null;
        public AventStack.ExtentReports.ExtentTest Test = null;

        public void InitializeExtentReports(string reportName)
        {
            Extent = new AventStack.ExtentReports.ExtentReports();
            var sparkReporter = new ExtentSparkReporter(reportName);
            Extent.AttachReporter(sparkReporter);
            SetSystemInfo();
        }

        private void SetSystemInfo()
        {
            Dictionary<string, string> systemInfo = (new SystemInfo()).GetSystemInfo();
            foreach (var info in systemInfo)
            {
                Extent.AddSystemInfo(info.Key, info.Value);
            }
        }
        public void CurrentTestDetails()
        {
            Test = Extent.CreateTest(TestContext.CurrentContext.Test.MethodName);
        }
        public void LogInfo(string info)
        {
            Test.Log(Status.Info, info);
        }

        public ExtentTest AddScreenShot(string path)
        {
            return Test.AddScreenCaptureFromPath(path);
        }

        public ExtentTest AddScreenShotAsBase64String(string base64String, string imageName)
        {
            return Test.AddScreenCaptureFromBase64String(base64String, imageName);
        }

        //public ExtentTest Info(string TestInformation, MediaEntityModelProvider provider = null)
        //{
        //    return Test.Info(TestInformation);
        //}

        public void FlushExtentReports()
        {
            Extent.Flush();
        }



        public string Capture(Protractor.NgWebDriver driver, string screenShotNameWithoutExtension, string rootFolder)
        {
            ITakesScreenshot ts = (ITakesScreenshot)driver.WrappedDriver;
            Screenshot screenshot = ts.GetScreenshot();
            var finalPath = Path.Combine(rootFolder, @"FloAR.TestAutomation.Tests\Screenshots", $"{screenShotNameWithoutExtension}.png");
            byte[] screenshotAsBytes = Convert.FromBase64String(screenshot.AsBase64EncodedString);
            File.WriteAllBytes(finalPath, screenshotAsBytes);
            return finalPath;
        }


        public string CaptureBase64String(Protractor.NgWebDriver driver)
        {
            ITakesScreenshot ts = ((ITakesScreenshot)(driver.WrappedDriver));
            Screenshot screenshot = ts.GetScreenshot();
            return screenshot.AsBase64EncodedString;
        }

        public void TestTearDownLog(TestStatus status, string stackTrace, Protractor.NgWebDriver driver)
        {
            Status logstatus;
            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    DateTime time = DateTime.Now;
                    Test.Log(logstatus, "Test Failed");
                    Test.Log(logstatus, stackTrace);
                    //AddScreenShotAsBase64String(CaptureBase64String(driver), "");
                    Test.Log(logstatus, "Screenshot", MediaEntityBuilder.CreateScreenCaptureFromBase64String(CaptureBase64String(driver)).Build());
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }
            Test.Log(logstatus, $"Test ended with {logstatus} {stackTrace}");
        }

    }

}
