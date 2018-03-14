using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AppiumWinMobile.TestBase;

namespace AppiumWinMobile.TestConfiguration
{
    public interface IHostConfiguration
    {
        string MachineName { get; }
        string AppiumIP { get; }
        string AppiumPort { get;  }
        TestPlatform TargetPlatform { get; }
        string PathToApk { get; }
        string PathToIpa { get; }
        string AndroidDeviceName { get; }
        string AndroidPlatformVersion { get; }
        string AndroidAppPackage { get; }
        string AndroidAppActivity { get; }
        string IosDeviceName { get; }
        string EnvName { get; }
    }
}
