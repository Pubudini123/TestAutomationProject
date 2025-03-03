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
    public class CreateJobAssignments : Page
    {
        public CreateJobAssignments(IWebDriver driver) : base(driver) { }

        public CreateJobAssignments(NgWebDriver driver) : base(driver) { }

        #region UI Controls
        public IWebElement JobNoTextbox
        {   
            get
            {
                return driver.FindElement(By.XPath("//*[@formcontrolname= 'JobNo']"));
            }
        }

        public IWebElement PTWTextbox
        {
            get
            {
                return driver.FindElement(By.XPath("//*[@formcontrolname= 'PTW']"));
            }
        }

        public IWebElement PurchaseOrderNoTextbox
        {
            get
            {
                return driver.FindElement(By.XPath("//*[@formcontrolname= 'PurchaseOrderNo']"));
            }
        }

        public IWebElement TroubleTicketTextbox
        {
            get
            {
                return driver.FindElement(By.XPath("//*[@formcontrolname= 'TroubleTicket']"));
            }
        }

        public IWebElement AddSiteNowButton
        {
            get
            {
                return driver.FindElement(By.XPath("//*[contains(text(),' Add Site Now ')]"));
            }
        }

        public IWebElement FirstSiteCheckbox
        {
            get
            {
                return driver.FindElement(By.XPath("//*[@type='checkbox' and @id=623]"));
            }
        }

        public IWebElement AddTechnicianNowButton
        {
            get
            {
                return driver.FindElement(By.XPath("//*[contains(text(),' Add Technician Now ')]"));
            }
        }

        public IWebElement FirstTechnicianCheckbox
        {
            get
            {
                return driver.FindElement(By.XPath("(//*[@type='radio' and @class='form-check-input'])[1]"));
            }
        }

        public IWebElement CreateButton
        {
            get
            {
                return driver.FindElement(By.XPath("//*[contains(text(),'Create ') and @class = 'btn btn-r btn-primary me-2']"));
            }
        }
        #endregion
        #region UI Actions
        public void TypeInJobAssignmentMandatoryValues(string JobNo,string PTW, string PurchaseOrderNo, string TroubleTicket, NgWebDriver ngDriver)
        {
            JobNoTextbox.SendKeys(JobNo);
            PTWTextbox.SendKeys(PTW);
            PurchaseOrderNoTextbox.SendKeys(PurchaseOrderNo);
            TroubleTicketTextbox.SendKeys(TroubleTicket);
            AddSiteNowButton.Click();
            Thread.Sleep(5000);
            IJavaScriptExecutor js = (IJavaScriptExecutor)ngDriver;
            js.ExecuteScript("window.scrollBy(0, 500)");
            Thread.Sleep(10000);
            FirstSiteCheckbox.Click();
            Thread.Sleep(6000);
            js.ExecuteScript("window.scrollBy(0,-700)");
            AddTechnicianNowButton.Click();
            js.ExecuteScript("window.scrollBy(0, 600)");
            Thread.Sleep(5000);
            FirstTechnicianCheckbox.Click(); 
        }

        public void ClickCreateJobAssignment(NgWebDriver ngDriver)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)ngDriver;
            js.ExecuteScript("window.scrollBy(0,-1000)");
            Thread.Sleep(5000);
            CreateButton.Click();
        }
        #endregion
    }
}
