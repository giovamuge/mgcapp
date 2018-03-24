using System;
using Xamarin.Forms;

namespace Mugelli.Software.It.Mgc.Resources
{
    public static class Colors
    {
        public static ResourceDictionary Init(ResourceDictionary resources)
        {
            if (!resources.ContainsKey("PrimaryTextColor"))
            {
                resources.Add("PrimaryTextColor", Color.FromHex("#333"));
            }
            if (!resources.ContainsKey("SecondaryTextColor"))
            {
                resources.Add("SecondaryTextColor", Color.FromHex("#FFFFFF"));
            }
            if (!resources.ContainsKey("MgcColor"))
            {
                resources.Add("MgcColor", Color.FromHex("#63388a"));
            }
            if (!resources.ContainsKey("AsphaltPrimary"))
            {
                resources.Add("AsphaltPrimary", Color.FromHex("#5c7d90"));
            }
            if (!resources.ContainsKey("RedPrimary"))
            {
                resources.Add("RedPrimary", Color.FromHex("#F56D50"));
            }
            if (!resources.ContainsKey("GrayUltraLight"))
            {
                resources.Add("GrayUltraLight", Color.FromHex("#FFFFFF"));
            }
            if (!resources.ContainsKey("GrayPrimary"))
            {
                resources.Add("GrayPrimary", Color.FromHex("#B9B9B9"));
            }
            if (!resources.ContainsKey("GrayLight"))
            {
                resources.Add("GrayLight", Color.FromHex("#F2F2F2"));
            }
            if (!resources.ContainsKey("GrayDark"))
            {
                resources.Add("GrayDark", Color.FromHex("#959595"));
            }
            if (!resources.ContainsKey("GrayMedium"))
            {
                resources.Add("GrayMedium", Color.FromHex("#B9B9B9"));
            }
            if (!resources.ContainsKey("PinkLight"))
            {
                resources.Add("PinkLight", Color.FromHex("#EA3874"));
            }
            if (!resources.ContainsKey("PurplePrimary"))
            {
                resources.Add("PurplePrimary", Color.FromHex("#9378CD"));
            }
            if (!resources.ContainsKey("IndigoLight"))
            {
                resources.Add("IndigoLight", Color.FromHex("#5362B6"));
            }
            if (!resources.ContainsKey("BlueDark"))
            {
                resources.Add("BlueDark", Color.FromHex("#258499"));
            }

            return resources;

        }
    }
}
