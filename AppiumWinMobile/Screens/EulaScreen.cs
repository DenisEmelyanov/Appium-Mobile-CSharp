using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.PageObjects.Attributes;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppiumWinMobile.Screens
{
    public class EulaScreen : Screen
    {
        public EulaScreen(AppiumDriver<IWebElement> driver) : base(driver) { }

        //[FindsBy(How = How.XPath, Using = "//android.view.View[@content-desc=\"Untitled Page\"]")]
        //public IMobileElement<AndroidElement> EulaText {get; set;}

        [FindsBy(How = How.Id, Using = "SMXEulaAcceptButton")]
        //[FindsByAndroidUIAutomator(Accessibility = "SMXEulaAcceptButton")]
        private IWebElement AcceptButton { get; set; }

        public ServiceEndpointsScreen TapAccept()
        {
            AcceptButton.Click();
            return new ServiceEndpointsScreen(Driver);
        }
    }
}
