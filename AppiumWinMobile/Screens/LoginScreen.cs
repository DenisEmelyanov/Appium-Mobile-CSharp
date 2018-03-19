using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.PageObjects.Attributes;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppiumWinMobile.Screens
{
    public class LoginScreen : Screen
    {
        public LoginScreen(AppiumDriver<IWebElement> driver) : base(driver)
        {
            WaitForNoOverlay();
        }

        [FindsBySequence]
        [MobileFindsBySequence(Android = true, IOS = true)]
        [FindsBy(How = How.Id, Using = "LoginUsername", Priority = 1)]
        [FindsByAndroidUIAutomator(Accessibility = "LoginUsername", Priority = 2)]
        [FindsByIOSUIAutomation(Accessibility = "LoginUsername", Priority = 3)]
        private IWebElement LoginField { get; set; }

        [FindsBy(How = How.Id, Using = "LoginPassword")]
        private IWebElement PasswordField { get; set; }

        [FindsBy(How = How.Id, Using = "SmxLoginButton")]
        private IWebElement LoginButton { get; set; }

        public string Login
        {
            get
            {
                return LoginField.Text;
            }
            set
            {
                LoginField.Clear();
                LoginField.SendKeys(value);
            }
        }

        public string Password
        {
            get
            {
                return PasswordField.Text;
            }
            set
            {
                PasswordField.Clear();
                PasswordField.SendKeys(value);
            }
        }

        public T TapLoginButton<T>()
            where T : Screen
        {
            LoginButton.Click();
            WaitForNoOverlay();
            return (T)Activator.CreateInstance(typeof(T), Driver);
        }
    }
}
