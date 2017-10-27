using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Midium.Helpers.Web
{
    public static class WebConnectionChecker
    {
        public static bool IsWebConnectionActive()
        {
            return NetworkInterface.GetIsNetworkAvailable();
        }
    }
}
