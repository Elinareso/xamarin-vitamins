using DemoApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.UWP.PlatformSpecifict
{
    public class PlatformMessages : IPlatformMessages
    {
        public string GetDeviceMessage()
        {
            return "This is a platform specifict message from Windows Device!";
        }
    }
}
