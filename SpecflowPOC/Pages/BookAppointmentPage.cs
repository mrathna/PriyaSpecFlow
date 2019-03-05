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
    class BookAppointmentPage
    {
        #region Fields
        IWebDriver _driver;
        #endregion

        #region Constructor
        public BookAppointmentPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(_driver, this);
        }
        #endregion

        #region Locators
        [FindsBy(How = How.XPath, Using = "//h2[text()='Make Appointment']")]
        private IWebElement MakeAppointment_txt { get; set; }

        [FindsBy(How = How.Id, Using = "txt_visit_date")]
        private IWebElement Date_txtbx { get; set; }

        [FindsBy(How = How.Id, Using = "txt_comment")]
        private IWebElement Comments_txtbx { get; set; }

        [FindsBy(How = How.Id, Using = "btn-book-appointment")]
        private IWebElement BookAppointment_btn { get; set; }
        #endregion

        #region Methods
        public void MakeAppointment(string Date,string Comments)
        {
            Date_txtbx.EnterText(Date);
            Comments_txtbx.EnterText(Comments);
            BookAppointment_btn.ClickOnElement();
        }
        public void EnterDate(DateTime Date)
        {
            Date_txtbx.EnterText(Date.ToShortDateString());
        }
        public void EnterComments(string Comments)
        {
            Comments_txtbx.EnterText(Comments);
            BookAppointment_btn.ClickOnElement();
        }
        public void VerifyPageText()
        {
            bool isDisplayed = MakeAppointment_txt.IsDisplayed();
            Assert.AreEqual(isDisplayed, true);
        }
        #endregion
    }
}
