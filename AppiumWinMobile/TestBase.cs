using AppiumWinMobile.Logging;
using AppiumWinMobile.TestConfiguration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppiumWinMobile
{
    [TestFixture]
    public class TestBase
    {
        public AppiumDriver<IWebElement> Driver { get; set; }
        public HostConfiguration TestConfig { get; set; }

        [SetUp]
        public void Init()
        {
            TestConfig = new HostConfiguration();

            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability(MobileCapabilityType.PlatformName, TestConfig.TargetPlatform);

            Uri appiumUri = new Uri($"http://{TestConfig.AppiumIP}:{TestConfig.AppiumPort}/wd/hub");

            switch(TestConfig.TargetPlatform)
            {
                case TestPlatform.Android:
                    {
                        capabilities.SetCapability(MobileCapabilityType.DeviceName, TestConfig.AndroidDeviceName);
                        capabilities.SetCapability(MobileCapabilityType.PlatformVersion, TestConfig.AndroidPlatformVersion);
                        capabilities.SetCapability("appActivity", TestConfig.AndroidAppActivity);
                        capabilities.SetCapability("appPackage", TestConfig.AndroidAppPackage);
                        capabilities.SetCapability(MobileCapabilityType.App, TestConfig.PathToApk);

                        Driver = new AndroidDriver<IWebElement>(appiumUri, capabilities);
                        break;
                    }
                case TestPlatform.iOS:
                    {
                        throw new NotImplementedException("iOS support is not implemented");
                        break;
                    }
                default:
                    {
                        throw new Exception($"The platform [{TestConfig.TargetPlatform}] is not supported");
                    }
            }                     
        }

        [TearDown]
        public void TestTearDown()
        {
            TestLog.ResetStepNumber();
        }

        public enum TestPlatform
        {
            Android,
            iOS
        }
    }
}
