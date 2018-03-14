using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.PageObjects;

namespace AppiumWinMobile.Screens
{
    public class Dialog : Screen
    {
        public Dialog(AppiumDriver<IWebElement> driver) : base(driver) { }

        [FindsBy(How = How.Id, Using = "android:id/alertTitle")]
        private IWebElement TitleElement { get; set; }

        [FindsBy(How = How.Id, Using = "android:id/message")]
        private IWebElement MessageElement { get; set; }

        [FindsBy(How = How.Id, Using = "android:id/button2")]
        private IWebElement OKButton { get; set; }

        public string Title => TitleElement.Text;

        public string Message => MessageElement.Text;

        public T TapOK<T>()
            where T : Screen
        {
            OKButton.Click();
            return (T)Activator.CreateInstance(typeof(T), Driver);
        }
    }
}
