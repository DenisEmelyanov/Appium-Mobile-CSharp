using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppiumWinMobile.Screens
{
    public class AddEndpointScreen : Screen
    {
        public AddEndpointScreen(AppiumDriver<IWebElement> driver) : base(driver) { }

        [FindsBy(How = How.Id, Using = "SMXServiceAliasEntry")]
        private IWebElement AlliasField { get; set; }

        [FindsBy(How = How.Id, Using = "SMXServiceUrlEntry")]
        private IWebElement ServiceURLField { get; set; }

        [FindsBy(How = How.Id, Using = "SMXEndPointEditSaveButton")]
        private IWebElement SaveButton { get; set; }

        public string Allias
        {
            get
            {
                return AlliasField.Text;
            }
            set
            {
                AlliasField.SendKeys(value);
            }
        }

        public string ServiceURL
        {
            get
            {
                return ServiceURLField.Text;
            }
            set
            {
                ServiceURLField.SendKeys(value);
            }
        }

        public ServiceEndpointsScreen TapSaveButton()
        {
            SaveButton.Click();
            return new ServiceEndpointsScreen(Driver);
        }
    }
}
