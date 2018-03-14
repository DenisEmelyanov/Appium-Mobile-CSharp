using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.PageObjects.Attributes;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AppiumWinMobile.Screens
{
    public class ServiceEndpointsScreen : Screen
    {
        public ServiceEndpointsScreen(AppiumDriver<IWebElement> driver) : base(driver)
        {
            WaitForNoOverlay();
        }

        [FindsBy(How = How.Id, Using = "SMXConnectionAddButton")]
        private IWebElement AddButton { get; set; }

        [FindsBy(How = How.Id, Using = "SMXServiceEndpointsListView")]
        protected override IWebElement ListView { get; set; }

        public AddEndpointScreen TapAddButton()
        {
            AddButton.Click();
            return new AddEndpointScreen(Driver);
        }

        public LoginScreen TapEndpoint(string name)
        {
            //IJavaScriptExecutor js = Driver;
            //js.ExecuteScript("arguments[0].scrollIntoView(true);", elements.First());

            IWebElement endpoint = ScrollDownToText(name);            
            endpoint.Click();

            return new LoginScreen(Driver);
        }
    }
}
