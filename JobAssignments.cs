using FloAR.TestAutomation.Pages.HomeScreen;
using OpenQA.Selenium;
using Protractor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloAR.TestAutomation.Pages.Jobs
{
    public class JobAssignments : Page
    {
        public JobAssignments(IWebDriver driver) : base(driver) { }

        public JobAssignments(NgWebDriver driver) : base(driver) { }

        #region UI Controls
        public IWebElement JobTabHeader
        {
            get
            {
                return driver.FindElement(By.XPath("//a[@href='/layout/job' and contains(text(),'Jobs')]"));
            }
        }

        public IWebElement CreateJobAssignmentButton
        {
            get
            {
                return driver.FindElement(By.XPath("//*[contains(text(),'Create Job Assignment')]"));
            }
        }

        public IWebElement createJobSuccessfullyMessage
        {
            get
            {
                return driver.FindElement(By.XPath("//*[contains(text(),'create Job Successfully')]"));
            }
        }

        #endregion
        #region UI Actions
        public void ClickJobsTab()
        {
            JobTabHeader.Click();
        }

        public void ClickCreateJobAssignmentButton()
        {
            CreateJobAssignmentButton.Click();
        }
        #endregion
    }
}
