using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Edwards.Scada.Test.Framework.Pages
{
    //namespaces
    using Edwards.Scada.Test.Framework.GlobalHelper;

    public class LoginPage : PageBase
    {
        private IWebDriver driver;
        public LoginPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        //objects for login page
        #region 
        [FindsBy(How = How.Id, Using = "txtUsername")]
        private IWebElement txtLoginUserName;

        [FindsBy(How = How.Id, Using = "txtPassword")]
        private IWebElement txtPassword { get; set; }

        [FindsBy(How = How.Id, Using = "btnLogIn")]
        private IWebElement BtnLogin { get; set; }

        [FindsBy(How = How.LinkText, Using = "linktxt")]
        private IWebElement homePageLink { get; set; }

        [FindsBy(How = How.XPath, Using = ".//*[@id='ctl00_lblUserName']")]
        private IWebElement linkUserName { get; set; }

        [FindsBy(How = How.Id, Using = "InvalidCredentialsMessage")]
        private IWebElement loginErrMsg { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class='modalHeader security'][contains(.,'Set Memorable Information')]")]
        private IWebElement lblsetMemorableInformation;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'txtMemorableQuestion')]")]
        private IWebElement txtMemorableQuestion;

        [FindsBy(How = How.Id, Using = "lblMemorableQuestion_ForgotPassword")]
        private IWebElement lblMemorableQuestion;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'txtMemorableAnswer')]")]
        private IWebElement txtMemorableAnswer;

        [FindsBy(How = How.XPath, Using = "//input[contains(@name,'txtPassword_SetQuestion')]")]
        private IWebElement txtReEnterPassword;

        [FindsBy(How = How.XPath, Using = "//input[@value='Apply']")]
        private IWebElement btnApply;

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'btnApplySetQuestion')]")]
        private IWebElement btnApplySetMemorableInfoPopUp;

        [FindsBy(How = How.XPath, Using = "//input[@value='Ok']")]
        private IWebElement btnOK;

        [FindsBy(How = How.Id, Using = "lblConfirmationMessage")]
        private IWebElement lblConfirmationMessage;

        [FindsBy(How = How.Id, Using = "lnkForgotPassword")]
        private IWebElement lnkForgotPassword;

        [FindsBy(How = How.Id, Using = "lblConfirmationTitle")]
        private IWebElement lblConfirmationTitle;

        [FindsBy(How = How.Id, Using = "lnkHelp")]
        private IWebElement lnkHelp;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Help')]")]
        private IWebElement lblHelp;

        [FindsBy(How = How.XPath, Using = "//a[@id='button-home']")]
        private IWebElement btnHome;

        [FindsBy(How = How.Id, Using = "lnkShowLicence")]
        private IWebElement lnkLicenseAgreement;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Software License and Support Agreement')]")]
        private IWebElement lblSoftwareLicense;

        [FindsBy(How = How.Id, Using = "lnkAbout")]
        private IWebElement lnkAbout;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'About')]")]
        private IWebElement lblAbout;

        [FindsBy(How = How.XPath, Using = "//input[contains(@value, 'Activate')]")]
        private IWebElement btnActivate;

        [FindsBy(How = How.XPath, Using = "//input[contains(@value, 'Renew')]")]
        private IWebElement btnRenew;

        [FindsBy(How = How.XPath, Using = "//span[contains(.,'Forgotten Password')]")]
        private IWebElement forgottenPasswordPopUp;

        [FindsBy(How = How.XPath, Using = "//input[@name='txtMemorableAnswer_ForgotPassword']")]
        private IWebElement txtMemorableAns;

        [FindsBy(How = How.Id, Using = "lblForgotPasswordMessage")]
        private IWebElement lblForgotErrorMessage;

        [FindsBy(How = How.Id, Using = "lnkActivate")]
        private IWebElement lnkActivate;

        [FindsBy(How = How.Id, Using = "lblAuthorizationCode")]
        private IWebElement lblAuthorizationCode;
        
        [FindsBy(How = How.XPath, Using = "//span[contains(@id,'popAbout_txtActivationKey')]")]
        private IWebElement txtAuthorizationCode;

        [FindsBy(How = How.Id, Using = "txtActivateKey1")]
        private IWebElement lnkActivationKey;

        [FindsBy(How = How.Id, Using = "chkAgree_imgCheckBox")]
        private IWebElement checkBoxAcceptTheAgreement;

        [FindsBy(How = How.Id, Using = "btnOkLicence")]
        private IWebElement btnOkLicense;
        #endregion

        #region
        public IWebElement BtnOkLicense
        {
            get
            {
                return btnOkLicense;
            }
            set
            {
                btnOkLicense = value;
            }
        }
                

        public IWebElement TxtAuthorizationCode
        {
            get
            {
                return txtAuthorizationCode;
            }
            set
            {
                txtAuthorizationCode = value;
            }
        }

        public IWebElement CheckBoxAcceptTheAgreement
        {
            get
            {
                return checkBoxAcceptTheAgreement;
            }
            set
            {
                checkBoxAcceptTheAgreement = value;
            }
        }

        public IWebElement BtnRenew
        {
            get
            {
                return btnRenew;
            }
            set
            {
                btnRenew = value;
            }
        }

        public IWebElement LnkActivationKey
        {
            get
            {
                return lnkActivationKey;
            }
            set
            {
                lnkActivationKey = value;
            }
        }
        public IWebElement LblAuthorizationCode
        {
            get
            {
                return lblAuthorizationCode;
            }
            set
            {
                lblAuthorizationCode = value;
            }
        }

        public IWebElement LnkActivate
        {
            get
            {
                return lnkActivate;
            }
            set
            {
                lnkActivate = value;
            }
        }
        public IWebElement TxtLoginUserName
        {
            get
            {
                return txtLoginUserName;
            }
            set
            {
                txtLoginUserName = value;
            }
        }

        public IWebElement TxtMemorableAns
        {
            get
            {
                return txtMemorableAns;
            }
            set
            {
                txtMemorableAns = value;
            }
        }

        public IWebElement TxtPassword
        {
            get
            {
                return txtPassword;
            }
            set
            {
                txtPassword = value;
            }

        }

        public IWebElement LblForgotErrorMessage
        {
            get
            {
                return lblForgotErrorMessage;
            }
            set
            {
                lblForgotErrorMessage = value;
            }
        }

        public IWebElement LnkAbout
        {
            get
            {
                return lnkAbout;
            }
            set
            {
                lnkAbout = value;
            }
        }

        public IWebElement LblAbout
        {
            get
            {
                return lblAbout;
            }
            set
            {
                lblAbout = value;
            }
        }

        public IWebElement BtnActivate
        {
            get
            {
                return btnActivate;
            }
            set
            {
                btnActivate = value;
            }
        }

        public IWebElement LnkHelp
        {
            get
            {
                return lnkHelp;
            }
            set
            {
                lnkHelp = value;
            }
        }

        public IWebElement LblsetMemorableInformation
        {
            get
            {
                return lblsetMemorableInformation;
            }
            set
            {
                lblsetMemorableInformation = value;
            }
        }

        public IWebElement TxtMemorableQuestion
        {
            get
            {
                return txtMemorableQuestion;
            }
            set
            {
                txtMemorableQuestion = value;
            }
        }

        public IWebElement TxtMemorableAnswer
        {
            get
            {
                return txtMemorableAnswer;
            }
            set
            {
                txtMemorableAnswer = value;
            }
        }

        public IWebElement LblMemorableQuestion
        {
            get
            {
                return lblMemorableQuestion;
            }
        }

        public IWebElement LinkForgotPassword
        {
            get
            {
                return lnkForgotPassword;
            }
        }

        public IWebElement TxtReEnterPassword
        {
            get
            {
                return txtReEnterPassword;
            }
            set
            {
                txtReEnterPassword = value;
            }
        }

        public IWebElement LblConfirmationTitle
        {
            get
            {
                return lblConfirmationTitle;
            }
            set
            {
                lblConfirmationTitle = value;
            }
        }

        public IWebElement BtnApply
        {
            get
            {
                return btnApply;
            }
            set
            {
                btnApply = value;
            }
        }

        public IWebElement BtnOk
        {
            get
            {
                return btnOK;
            }
            set
            {
                btnOK = value;
            }
        }

        public IWebElement LblConfirmationMessage
        {
            get
            {
                return lblConfirmationMessage;
            }
            set
            {
                lblConfirmationMessage = value;
            }
        }

        public IWebElement BtnApplySetMemorableInfoPopUp
        {
            get
            {
                return btnApplySetMemorableInfoPopUp;
            }
            set
            {
                btnApplySetMemorableInfoPopUp = value;
            }
        }

        public IWebElement LblHelp
        {
            get
            {
                return lblHelp;
            }
            set
            {
                lblHelp = value;
            }
        }

        public IWebElement BtnHome
        {
            get
            {
                return btnHome;
            }
            set
            {
                btnHome = value;
            }
        }

        public IWebElement LnkLicenseAgreement
        {
            get
            {
                return lnkLicenseAgreement;
            }
            set
            {
                lnkLicenseAgreement = value;
            }
        }

        public IWebElement LblSoftwareLicense
        {
            get
            {
                return lblSoftwareLicense;
            }
            set
            {
                lblSoftwareLicense = value;
            }
        }

        public IWebElement ForgottenPasswordPopUp
        {
            get
            {
                return forgottenPasswordPopUp;
            }
            set
            {
                ForgottenPasswordPopUp = value;
            }
        }
        #endregion


        public void SignIn(string username, string password)
        {
            Waits.WaitForElementVisible(driver, txtLoginUserName);
            EnterUSername(username);
            EnterPassword(password);
            ClickOnLoginButton();

            // return new HomePage(driver);

        }

        //Enter username
        public void EnterUSername(string Username)
        {
            try
            {
                txtLoginUserName.Clear();
                txtLoginUserName.SendKeys(Username);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Enter password
        public void EnterPassword(string Password)
        {
            txtPassword.Clear();
            txtPassword.SendKeys(Password);
        }

        //Click on login button
        public void ClickOnLoginButton()
        {
            Waits.WaitAndClick(driver, BtnLogin);
        }

        //Get logged in username
        public string DisplayedUser()
        {
            string LoggedInUser = linkUserName.Text;
            return LoggedInUser;
        }

        public string DisplayedInvalidCredentialsErrorMessage()
        {
            return loginErrMsg.Text;
        }
    }
}
