using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AppiumWinMobile.TestBase;

namespace AppiumWinMobile.TestConfiguration
{
    public class DenisWinConfigurationcs : IHostConfiguration
    {
        public string MachineName => "*******";

        public string AppiumIP => "127.0.0.1";

        public string AppiumPort => "4723";

        public TestPlatform TargetPlatform => TestPlatform.Android;
        public string EnvName => "env name1";

        public string PathToApk => @"****.apk";

        public string AndroidDeviceName => "emulator-5554";
        public string AndroidPlatformVersion => "4.4.2";
        public string AndroidAppPackage => "****";
        public string AndroidAppActivity => "****.MainActivity";//adb shell dumpsys window windows

        public string IosDeviceName => throw new NotImplementedException();
        public string PathToIpa => @"";

    }
}
