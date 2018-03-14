using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppiumWinMobile.Screens
{
    public class PatientsListScreen : Screen
    {
        public PatientsListScreen(AppiumDriver<IWebElement> driver) : base (driver)
        {
            WaitForNoOverlay();
        }
    }
}
