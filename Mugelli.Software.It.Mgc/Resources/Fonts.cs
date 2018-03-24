using System;
using Xamarin.Forms;

namespace Mugelli.Software.It.Mgc.Resources
{
    public static class Fonts
    {
        public static ResourceDictionary Init(ResourceDictionary resources)
        {
            if (!resources.ContainsKey("TitleFont"))
            {
                resources.Add("TitleFont", (double)20);
            }
            if (!resources.ContainsKey("HandleFont"))
            {
                resources.Add("HandleFont", (double)12);
            }
            if (!resources.ContainsKey("BodyFont"))
            {
                resources.Add("BodyFont", (double)12);
            }
            if (!resources.ContainsKey("HeaderFont"))
            {
                resources.Add("HeaderFont", (double)30);
            }
            if (!resources.ContainsKey("SubHeaderFont"))
            {
                resources.Add("SubHeaderFont", (double)18);
            }
            if (!resources.ContainsKey("TitleMediumFont"))
            {
                resources.Add("TitleMediumFont", (double)20);
            }
            if (!resources.ContainsKey("BodyMediumFont"))
            {
                resources.Add("BodyMediumFont", (double)18);
            }


            //
            //
            // Font
            //
            //

            if (!resources.ContainsKey("RegularFontFamily"))
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.iOS:
                        resources.Add("RegularFontFamily", "HelveticaNeue");
                        break;
                    case Device.Android:
                        resources.Add("RegularFontFamily", "sans-serif");
                        break;
                }
            }

            if (!resources.ContainsKey("LightFontFamily"))
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.iOS:
                        resources.Add("LightFontFamily", "HelveticaNeue-Light");
                        break;
                    case Device.Android:
                        resources.Add("LightFontFamily", "sans-serif-light");
                        break;
                }
            }

            if (!resources.ContainsKey("MediumFontFamily"))
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.iOS:
                        resources.Add("MediumFontFamily", "HelveticaNeue-Medium");
                        break;
                    case Device.Android:
                        resources.Add("MediumFontFamily", "sans-serif-medium");
                        break;
                }
            }

            if (!resources.ContainsKey("BoldFontFamily"))
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.iOS:
                        resources.Add("BoldFontFamily", "HelveticaNeue-Bold");
                        break;
                    case Device.Android:
                        resources.Add("BoldFontFamily", "sans-serif-bold");
                        break;
                }
            }

            return resources;
        }
    }
}
