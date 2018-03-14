using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppiumWinMobile.Logging;
using Newtonsoft.Json.Linq;
using System.IO;
using Newtonsoft.Json;
using System.Reflection;

namespace AppiumWinMobile.TestConfiguration
{
    public class HostConfiguration : IHostConfiguration
    {
        private IHostConfiguration _host = null;
        private readonly Dictionary<string, IHostConfiguration> _hosts;
        private string _hwsUrl = null;

        public HostConfiguration()
        {
            _hosts = new Dictionary<string, IHostConfiguration>();
            foreach (var type in GetType().Assembly.GetTypes())
            {
                if (type == GetType() || type.IsInterface)
                    continue;

                if (type.GetInterfaces().ToList().Contains(typeof(IHostConfiguration)))
                {
                    var instance = Activator.CreateInstance(type) as IHostConfiguration;
                    if (instance == null)
                        continue;

                    if (_hosts.ContainsKey(instance.MachineName))
                    {
                        _hosts.Remove(instance.MachineName);
                    }
                    _hosts.Add(instance.MachineName, instance);
                }
            }
        }

        public string MachineName => MachineInstance.MachineName;

        public TestBase.TestPlatform TargetPlatform => MachineInstance.TargetPlatform;

        public string PathToApk => MachineInstance.PathToApk;

        public string PathToIpa => MachineInstance.PathToIpa;

        public string AndroidDeviceName => MachineInstance.AndroidDeviceName;

        public string IosDeviceName => MachineInstance.IosDeviceName;

        public string EnvName => MachineInstance.EnvName;

        public string HwsURL => _hwsUrl;

        public IHostConfiguration MachineInstance
        {
            get
            {
                if (_host != null)
                {
                    return _host;
                }
                _host = GetMachineSpecifcHostConfiguration();
                return _host;
            }
        }

        public string AppiumIP => MachineInstance.AppiumIP;

        public string AppiumPort => MachineInstance.AppiumPort;

        public string AndroidPlatformVersion => MachineInstance.AndroidPlatformVersion;

        public string AndroidAppPackage => MachineInstance.AndroidAppPackage;

        public string AndroidAppActivity => MachineInstance.AndroidAppActivity;

        public IHostConfiguration GetMachineSpecifcHostConfiguration()
        {
            var machineName = Environment.MachineName;

            if (_hosts.ContainsKey(machineName))
            {
                TestLog.Write($"HOSTS DEBUG: {machineName}");
                string envName = _hosts[machineName].EnvName;
                //get HWS url from json
                using (StreamReader file = File.OpenText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestConfiguration", "environments.json")))
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    JObject o = (JObject)JToken.ReadFrom(reader);

                    if (o[envName] != null)
                        _hwsUrl = (string)o[(envName)]["service URL"];
                    else
                        throw new Exception($"Cannot find '{envName}' in environments.json");
                }

                return _hosts[machineName];
            }

            throw new Exception("Could not find a matching host configuration class or the default host configuration");
        }
    }
}
