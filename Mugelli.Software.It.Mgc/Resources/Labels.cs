using System;
using Xamarin.Forms;

namespace Mugelli.Software.It.Mgc.Resources
{
    public static class Labels
    {
        public static ResourceDictionary Init(ResourceDictionary resources)
        {
            //
            //
            // Style
            //
            //

            if (!resources.ContainsKey("PageHeaderLabel"))
            {
                var stylee = new Style(typeof(Label))
                {
                    Setters =
                    {
                        new Setter { Property = Label.TextColorProperty, Value = resources["PrimaryTextColor"] },
                        new Setter { Property = Label.FontSizeProperty, Value = resources["HeaderFont"]},
                        new Setter { Property = Label.FontFamilyProperty, Value = resources["MediumFontFamily"]}
                    }
                };
                resources.Add("PageHeaderLabel", stylee);
            }

            if (!resources.ContainsKey("SubHeaderLabel"))
            {
                var stylee = new Style(typeof(Label))
                {
                    Setters =
                    {
                        new Setter { Property = Label.TextColorProperty, Value = resources["PrimaryTextColor"] },
                        new Setter { Property = Label.FontSizeProperty, Value = resources["SubHeaderFont"]},
                        new Setter { Property = Label.FontFamilyProperty, Value = resources["MediumFontFamily"]}
                    }
                };
                resources.Add("SubHeaderLabel", stylee);
            }

            if (!resources.ContainsKey("SecondaryPageHeaderLabel"))
            {
                var stylee = new Style(typeof(Label))
                {
                    Setters =
                    {
                        new Setter { Property = Label.TextColorProperty, Value = resources["SecondaryTextColor"] },
                        new Setter { Property = Label.FontSizeProperty, Value = resources["HeaderFont"]},
                        new Setter { Property = Label.FontFamilyProperty, Value = resources["MediumFontFamily"]}
                    }
                };
                resources.Add("SecondaryPageHeaderLabel", stylee);
            }

            if (!resources.ContainsKey("SecondarySubHeaderLabel"))
            {
                var stylee = new Style(typeof(Label))
                {
                    Setters =
                    {
                        new Setter { Property = Label.TextColorProperty, Value = resources["SecondaryTextColor"] },
                        new Setter { Property = Label.FontSizeProperty, Value = resources["SubHeaderFont"]},
                        new Setter { Property = Label.FontFamilyProperty, Value = resources["MediumFontFamily"]}
                    }
                };
                resources.Add("SecondarySubHeaderLabel", stylee);
            }

            if (!resources.ContainsKey("ClassTimeLabel"))
            {
                var stylee = new Style(typeof(Label))
                {
                    Setters =
                    {
                        new Setter { Property = Label.TextColorProperty, Value = resources["PrimaryTextColor"] },
                        new Setter { Property = Label.FontSizeProperty, Value = resources["TitleFont"]},
                        new Setter { Property = Label.FontFamilyProperty, Value = resources["BoldFontFamily"]}
                    }
                };
                resources.Add("ClassTimeLabel", stylee);
            }

            if (!resources.ContainsKey("ClassNameLabel"))
            {
                var stylee = new Style(typeof(Label))
                {
                    Setters =
                    {
                        new Setter { Property = Label.TextColorProperty, Value = resources["PrimaryTextColor"] },
                        new Setter { Property = Label.FontSizeProperty, Value = resources["TitleFont"]},
                        new Setter { Property = Label.FontFamilyProperty, Value = resources["BoldFontFamily"]}
                    }
                };
                resources.Add("ClassNameLabel", stylee);
            }

            if (!resources.ContainsKey("ClassInstructorLabel"))
            {
                var stylee = new Style(typeof(Label))
                {
                    Setters =
                    {
                        new Setter { Property = Label.TextColorProperty, Value = resources["PrimaryTextColor"] },
                        new Setter { Property = Label.FontSizeProperty, Value = resources["BodyFont"]},
                        new Setter { Property = Label.FontFamilyProperty, Value = resources["LightFontFamily"]}
                    }
                };
                resources.Add("ClassInstructorLabel", stylee);
            }

            if (!resources.ContainsKey("HandleLabelSecondary"))
            {
                var stylee = new Style(typeof(Label))
                {
                    Setters =
                    {
                        new Setter { Property = Label.TextColorProperty, Value = resources["SecondaryTextColor"] },
                        new Setter { Property = Label.FontSizeProperty, Value = resources["HandleFont"]},
                        new Setter { Property = Label.FontFamilyProperty, Value = resources["MediumFontFamily"]}
                    }
                };
                resources.Add("HandleLabelSecondary", stylee);
            }

            if (!resources.ContainsKey("PageHeaderLabel"))
            {
                var stylee = new Style(typeof(Label))
                {
                    Setters =
                    {
                        new Setter { Property = Label.TextColorProperty, Value = resources["PrimaryTextColor"] },
                        new Setter { Property = Label.FontSizeProperty, Value = resources["HeaderFont"]},
                        new Setter { Property = Label.FontFamilyProperty, Value = resources["MediumFontFamily"]}
                    }
                };
                resources.Add("PageHeaderLabel", stylee);
            }

            if (!resources.ContainsKey("BodyLabelSecondary"))
            {
                var stylee = new Style(typeof(Label))
                {
                    Setters =
                    {
                        new Setter { Property = Label.TextColorProperty, Value = resources["SecondaryTextColor"] },
                        new Setter { Property = Label.FontSizeProperty, Value = resources["BodyFont"]},
                        new Setter { Property = Label.FontFamilyProperty, Value = resources["LightFontFamily"]}
                    }
                };
                resources.Add("BodyLabelSecondary", stylee);
            }

            if (!resources.ContainsKey("TitleLabelPrimary"))
            {
                var stylee = new Style(typeof(Label))
                {
                    Setters =
                    {
                        new Setter { Property = Label.TextColorProperty, Value = resources["PrimaryTextColor"] },
                        new Setter { Property = Label.FontSizeProperty, Value = resources["TitleFont"]},
                        new Setter { Property = Label.FontFamilyProperty, Value = resources["BoldFontFamily"]}
                    }
                };
                resources.Add("TitleLabelPrimary", stylee);
            }

            if (!resources.ContainsKey("TitleLabelSecondary"))
            {
                var stylee = new Style(typeof(Label))
                {
                    Setters =
                    {
                        new Setter { Property = Label.TextColorProperty, Value = resources["SecondaryTextColor"] },
                        new Setter { Property = Label.FontSizeProperty, Value = resources["TitleFont"]},
                        new Setter { Property = Label.FontFamilyProperty, Value = resources["BoldFontFamily"]}
                    }
                };
                resources.Add("TitleLabelSecondary", stylee);
            }

            if (!resources.ContainsKey("HandleLabelPrimary"))
            {
                var stylee = new Style(typeof(Label))
                {
                    Setters =
                    {
                        new Setter { Property = Label.TextColorProperty, Value = resources["PrimaryTextColor"] },
                        new Setter { Property = Label.FontSizeProperty, Value = resources["HandleFont"]},
                        new Setter { Property = Label.FontFamilyProperty, Value = resources["MediumFontFamily"]}
                    }
                };
                resources.Add("HandleLabelPrimary", stylee);
            }

            if (!resources.ContainsKey("BodyLabelPrimary"))
            {
                var stylee = new Style(typeof(Label))
                {
                    Setters =
                    {
                        new Setter { Property = Label.TextColorProperty, Value = resources["PrimaryTextColor"] },
                        new Setter { Property = Label.FontSizeProperty, Value = resources["BodyFont"]},
                        new Setter { Property = Label.FontFamilyProperty, Value = resources["LightFontFamily"]}
                    }
                };
                resources.Add("BodyLabelPrimary", stylee);
            }

            return resources;
        }
    }
}
