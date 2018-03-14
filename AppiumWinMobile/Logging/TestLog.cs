using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppiumWinMobile.Logging
{
    public static class TestLog
    {
        private static int _stepNumber = 0;
        public static void Write(string text, params object[] args)
        {
            _stepNumber++;
            //TODO
            //System.Diagnostics.Debug.WriteLine($"Step {_stepNumber}: {string.Format(text, args)}");
        }

        public static void ResetStepNumber()
        {
            _stepNumber = 0;
        }
    }
}
