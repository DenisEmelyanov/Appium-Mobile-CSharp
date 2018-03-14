using AppiumWinMobile.Screens;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppiumWinMobile.Tests
{
    public class LoginTests : TestBase
    {
        [TestCase(Author = "Denis Emelyanov")]
        [Category("Endpoints")]
        public void LoginWithCustomEndpointTest()
        {
            EulaScreen eulaScreen = new EulaScreen(Driver);
            var serviceEndpointsScreen = eulaScreen.TapAccept();

            var addEndpointScreen = serviceEndpointsScreen.TapAddButton();

            addEndpointScreen.Allias = TestConfig.EnvName;
            addEndpointScreen.ServiceURL = TestConfig.HwsURL;

            serviceEndpointsScreen = addEndpointScreen.TapSaveButton();

            var loginScreen = serviceEndpointsScreen.TapEndpoint(TestConfig.EnvName);

            loginScreen.Login = "xxxx";
            loginScreen.Password = "xxxx";

            var patientsListScreen = loginScreen.TapLoginButton<PatientsListScreen>();
        }

        [TestCase(Author = "Denis Emelyanov")]
        [Category("Endpoints")]
        public void LoginWithPredefinedEndpointTest()
        {
            EulaScreen eulaScreen = new EulaScreen(Driver);
            var serviceEndpointsScreen = eulaScreen.TapAccept();

            var loginScreen = serviceEndpointsScreen.TapEndpoint(TestConfig.EnvName);

            loginScreen.Login = "xxxx";
            loginScreen.Password = "xxxx";

            var patientsListScreen = loginScreen.TapLoginButton<PatientsListScreen>();
        }

        [Test(Author = "Denis Emelyanov")]
        [Category("Login")]
        [TestCaseSource(typeof(UsersData), "TestCases")]
        public void LoginWithDifferentUsersTest(string user, string password)
        {
            EulaScreen eulaScreen = new EulaScreen(Driver);
            var serviceEndpointsScreen = eulaScreen.TapAccept();

            var loginScreen = serviceEndpointsScreen.TapEndpoint(TestConfig.EnvName);

            loginScreen.Login = user;
            loginScreen.Password = password;

            var patientsListScreen = loginScreen.TapLoginButton<PatientsListScreen>();
        }

        [TestCase(Author = "Denis Emelyanov")]
        [Category("Login")]
        public void LoginWithWrongUserTest()
        {
            EulaScreen eulaScreen = new EulaScreen(Driver);
            var serviceEndpointsScreen = eulaScreen.TapAccept();

            var loginScreen = serviceEndpointsScreen.TapEndpoint(TestConfig.EnvName);

            loginScreen.Login = "wronguser";
            loginScreen.Password = "wrongpass";

            var authenticationErrorDialog = loginScreen.TapLoginButton<Dialog>();

            Assert.AreEqual("Authentication Error", authenticationErrorDialog.Title);
            Assert.AreEqual("Authentication Failed", authenticationErrorDialog.Message);

            loginScreen = authenticationErrorDialog.TapOK<LoginScreen>();
        }

        public class UsersData
        {
            public static IEnumerable TestCases
            {
                get
                {
                    yield return new TestCaseData("xxxx", "xxxx");
                    yield return new TestCaseData("yyyy", "yyyy");
                    //yield return new TestCaseData(12, 2).Returns(6);
                }
            }
        }
    }
}
