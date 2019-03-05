using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SpecflowPOC.CommonUtil;

namespace SpecflowPOC.Pages
{
    class AppointmentSummaryPage
    {
        #region Fields
        IWebDriver _driver;
        #endregion

        #region Constructor
        public AppointmentSummaryPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }
        #endregion

        #region Locators
        [FindsBy(How = How.XPath, Using = "//h2[text()='Appointment Confirmation']")]
        private IWebElement AppointmentConfirmation_txt { get; set; }
        #endregion

        #region Methods
        public void VerifyAppointmentConfirmation(string PageTitle)
        {
            AppointmentConfirmation_txt.WaitForElement();
            bool AreEqual = AppointmentConfirmation_txt.CompareText(PageTitle);
            Assert.AreEqual(AreEqual, true);
        }
        #endregion
    }
}
