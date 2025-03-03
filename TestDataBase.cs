using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Protractor;

namespace FloAR.TestAutomation.TestData
{
    public class TestDataBase
    {
        protected NgWebDriver ngDriver { get; set; }

        /// <summary>
        /// Gets / Sets Selenium driver instance
        /// </summary>
        protected IWebDriver driver { get; set; }


        /// <summary>
        /// Initializesa a object of <see cref="FeatureBase"/>
        /// </summary>
        /// <param name="ngdriver">NG Web driver</param>
        /// <remarks>To be initialize for Ng Driver</remarks>
        public TestDataBase(NgWebDriver ngdriver)
        {
            this.ngDriver = ngdriver;
            this.driver = driver;
        }

        /// <summary>
        /// Initializesa a object of <see cref="FeatureBase"/>
        /// </summary>
        /// <param name="driver"> Web driver</param>
        /// <remarks>To be initialize for Selenium driver </remarks>
        public TestDataBase(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
