using System;
using Mugelli.Software.It.Mgc.Converters;
using Xamarin.Forms;

namespace Mugelli.Software.It.Mgc.Resources
{
    public static class Converters
    {
        public static ResourceDictionary Init(ResourceDictionary resources)
        {
            if (!resources.ContainsKey("SelectedItemEventArgsToSelectedItemConverter"))
            {
                resources.Add("SelectedItemEventArgsToSelectedItemConverter", new SelectedItemEventArgsToSelectedItemConverter());
            }
            if (!resources.ContainsKey("InverseBoolConverter"))
            {
                resources.Add("InverseBoolConverter", new InverseBoolConverter());
            }
            if (!resources.ContainsKey("IsEmptyConverter"))
            {
                resources.Add("IsEmptyConverter", new IsEmptyConverter());
            }
            if (!resources.ContainsKey("IsNotNullToBoolConverter"))
            {
                resources.Add("IsNotNullToBoolConverter", new IsNotNullToBoolConverter());
            }
            if (!resources.ContainsKey("IsNullToBoolConverter"))
            {
                resources.Add("IsNullToBoolConverter", new IsNullToBoolConverter());
            }
            if (!resources.ContainsKey("NullIntValueConverter"))
            {
                resources.Add("NullIntValueConverter", new NullIntValueConverter());
            }
            if (!resources.ContainsKey("TypeEventColorConverter"))
            {
                resources.Add("TypeEventColorConverter", new TypeEventColorConverter());
            }
            if (!resources.ContainsKey("TypeEventImageConverter"))
            {
                resources.Add("TypeEventImageConverter", new TypeEventImageConverter());
            }
            if (!resources.ContainsKey("TypeEventTextConverter"))
            {
                resources.Add("TypeEventTextConverter", new TypeEventTextConverter());
            }
            if (!resources.ContainsKey("NotBooleanConverter"))
            {
                resources.Add("NotBooleanConverter", new NotBooleanConverter());
            }

            return resources;
        }
    }
}
