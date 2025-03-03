using FloAR.TestAutomation.Tests.ExtentReports;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloAR.TestAutomation.Tests
{
    [TestFixture]
    public class Fixture_003_ExtendFileJiraIntegration : TestBase
    {
        [Test, Order(1)]
        public void RunIntegrationTest()
        {
            string jiraServerUrl = "https://jira.atlassian.com";
            string username = "guest";
            string password = "guest";
            string projectKey = "TUTORIAL";
            string summary = "Sample issue summary";
            string description = "Sample issue description";
            string htmlFilePath = @"C:\Users\Pubudini\source\repos\FloAR\FloAR.TestAutomation.Tests\ExtentReports\ExtentReports.html";
            string pdfFilePath = @"C:\Users\Pubudini\source\repos\FloAR\FloAR.TestAutomation.Tests\ExtentReports\ExtentReports.pdf";

            var extentFileJiraIntegration = new ExtentFile_JiraIntegration();
            extentFileJiraIntegration.ConvertHtmlToPdfAndCreateJiraIssue(htmlFilePath, pdfFilePath, jiraServerUrl, username, password, projectKey, summary, description);
        }
    }
}
