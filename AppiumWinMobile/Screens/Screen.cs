using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppiumWinMobile.Screens
{
    public class Screen
    {
        protected AppiumDriver<IWebElement> Driver { get; }

        protected virtual IWebElement ListView { get; set; }

        public Screen(AppiumDriver<IWebElement> driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver, this);
        }

        public void WaitForNoOverlay()
        {
            WebDriverWait wdw = new WebDriverWait(Driver, TimeSpan.FromSeconds(120));
            wdw.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            wdw.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id("SMXOverlayIndicator")));
        }

        public IWebElement ScrollDownToText(string text)
        {
            var locator = new ByAndroidUIAutomator("new UiScrollable(new UiSelector()).scrollIntoView("
                + $"new UiSelector().text(\"{text}\"));");
           
            return ListView.FindElement(locator);
        }
    }
}
