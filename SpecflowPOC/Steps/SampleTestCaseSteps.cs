using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecflowPOC.Pages;
using SpecflowPOC.CommonUtil;
using TechTalk.SpecFlow;

namespace SpecflowPOC.Steps
{
    [Binding]
    class SampleTestCaseSteps
    {
        #region Fields
        private readonly IWebDriver _driver;
        HomePage Homepage;
        LoginPage LoginPage;
        BookAppointmentPage BookAppointmentPage;
        AppointmentSummaryPage AppointmentSummaryPage;
        #endregion

        #region Constructor
        public SampleTestCaseSteps(IWebDriver driver)
        {
            _driver = driver;
            Homepage = new HomePage(_driver);
            LoginPage = new LoginPage(_driver);
            BookAppointmentPage = new BookAppointmentPage(_driver);
            AppointmentSummaryPage = new AppointmentSummaryPage(_driver);
        }
        #endregion

        #region Methods
        [Given(@"Navigate to the (.*)")]
        public void GivenNavigateToThe(string URL)
        {
            _driver.Navigate().GoToUrl(URL);
        }

        [Given(@"Navigate to Home Page")]
        public void GivenNavigateToHomePage()
        {
            Homepage.ClickOnLoginLink();
        }

        [When(@"User enter (.*) and (.*)")]
        public void WhenUserEnterAnd(string userName, string passWord)
        {
            LoginPage.EnterCredentials(userName, passWord);
        }

        [When(@"Click on the LogIn button")]
        public void WhenClickOnTheLogInButton()
        {
            LoginPage.ClickLogin();
        }

        [Then(@"Page name should be displayed as (.*)")]
        public void ThenPageNameShouldBeDisplayedAs(string pageTitle)
        {
            BookAppointmentPage.VerifyPageText();
        }

        [When(@"Enter details likes (.*) and (.*) to Make Appointment")]
        public void WhenEnterDetailsLikesAndToMakeAppointment(string date, string comments)
        {
            BookAppointmentPage.MakeAppointment(date, comments);
        }

        [Then(@"Verify appointment is booked successfully as (.*)")]
        public void ThenVerifyAppointmentIsBookedSuccessfullyAs(string pagetitle)
        {
            AppointmentSummaryPage.VerifyAppointmentConfirmation(pagetitle);
        }

        [When(@"Enter days in addition to (current date as per .*)")]
        public void WhenEnterDaysInAdditionToCurrentDateAsPer(DateTime correctDate)
        {
            BookAppointmentPage.EnterDate(correctDate);
        }
        
        [When(@"Enter (.*) to book Appointment")]
        public void WhenEnterBookingAppointmentToBookAppointment(string comments)
        {
            BookAppointmentPage.EnterComments(comments);
        }

        [Given(@"Verify application is logged out")]
        public void GivenVerifyApplicationIsLoggedOut()
        {
            ScenarioContext.Current.Pending();
        }
        #endregion

    }
}
