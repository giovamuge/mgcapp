using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mugelli.Software.It.Mgc.Fonts
{
    public static class Fonts
    {
        public static string FontAwesome = Device.OnPlatform("FontAwesome", "fontawesome.ttf", null);
    }
}
