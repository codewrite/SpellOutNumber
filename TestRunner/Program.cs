using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace TestRunner
{
    class Program
    {
        private static readonly string nunitFolder = @"C:\Program Files\NUnit 2.6.2\bin";

        [STAThread]
        public static void Main()
        {
            AppDomainSetup setup = new AppDomainSetup();
            setup.ApplicationBase = nunitFolder;
            setup.ConfigurationFile = Path.Combine(nunitFolder, "NUnit.exe.config");

            AppDomain nunitDomain = AppDomain.CreateDomain("NUnit", null, setup);
            nunitDomain.ExecuteAssembly(Path.Combine(nunitFolder, "NUnit.exe"),
                new string[] { Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                @"..\..\..\NumberSpeller\bin\Debug\NumberSpeller.dll") });
        }
    }
}
