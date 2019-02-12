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
            // Style Label
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
                resources.Add("BodyLabelPrimary", stylee);
            }


            //
            //
            // Style Label Font
            //
            //

            if (!resources.ContainsKey("PageHeaderLabelFont"))
            {
                var stylee = new Style(typeof(Label))
                {
                    Setters =
                    {
                        new Setter { Property = Label.TextColorProperty, Value = resources["PrimaryTextColor"] },
                        new Setter { Property = Label.FontSizeProperty, Value = resources["HeaderFont"]}
                    }
                };
                resources.Add("PageHeaderLabelFont", stylee);
            }

            if (!resources.ContainsKey("SubHeaderLabelFont"))
            {
                var stylee = new Style(typeof(Label))
                {
                    Setters =
                    {
                        new Setter { Property = Label.TextColorProperty, Value = resources["PrimaryTextColor"] },
                        new Setter { Property = Label.FontSizeProperty, Value = resources["SubHeaderFont"]}
                    }
                };
                resources.Add("SubHeaderLabelFont", stylee);
            }

            if (!resources.ContainsKey("SecondaryPageHeaderLabelFont"))
            {
                var stylee = new Style(typeof(Label))
                {
                    Setters =
                    {
                        new Setter { Property = Label.TextColorProperty, Value = resources["SecondaryTextColor"] },
                        new Setter { Property = Label.FontSizeProperty, Value = resources["HeaderFont"]}
                    }
                };
                resources.Add("SecondaryPageHeaderLabelFont", stylee);
            }

            if (!resources.ContainsKey("SecondarySubHeaderLabelFont"))
            {
                var stylee = new Style(typeof(Label))
                {
                    Setters =
                    {
                        new Setter { Property = Label.TextColorProperty, Value = resources["SecondaryTextColor"] },
                        new Setter { Property = Label.FontSizeProperty, Value = resources["SubHeaderFont"]}
                    }
                };
                resources.Add("SecondarySubHeaderLabelFont", stylee);
            }

            if (!resources.ContainsKey("ClassTimeLabelFont"))
            {
                var stylee = new Style(typeof(Label))
                {
                    Setters =
                    {
                        new Setter { Property = Label.TextColorProperty, Value = resources["PrimaryTextColor"] },
                        new Setter { Property = Label.FontSizeProperty, Value = resources["TitleFont"]}
                    }
                };
                resources.Add("ClassTimeLabelFont", stylee);
            }

            if (!resources.ContainsKey("ClassNameLabelFont"))
            {
                var stylee = new Style(typeof(Label))
                {
                    Setters =
                    {
                        new Setter { Property = Label.TextColorProperty, Value = resources["PrimaryTextColor"] },
                        new Setter { Property = Label.FontSizeProperty, Value = resources["TitleFont"]}
                    }
                };
                resources.Add("ClassNameLabelFont", stylee);
            }

            if (!resources.ContainsKey("ClassInstructorLabelFont"))
            {
                var stylee = new Style(typeof(Label))
                {
                    Setters =
                    {
                        new Setter { Property = Label.TextColorProperty, Value = resources["PrimaryTextColor"] },
                        new Setter { Property = Label.FontSizeProperty, Value = resources["BodyFont"]}
                    }
                };
                resources.Add("ClassInstructorLabelFont", stylee);
            }

            if (!resources.ContainsKey("HandleLabelSecondaryFont"))
            {
                var stylee = new Style(typeof(Label))
                {
                    Setters =
                    {
                        new Setter { Property = Label.TextColorProperty, Value = resources["SecondaryTextColor"] },
                        new Setter { Property = Label.FontSizeProperty, Value = resources["HandleFont"]}
                    }
                };
                resources.Add("HandleLabelSecondaryFont", stylee);
            }

            if (!resources.ContainsKey("PageHeaderLabelFont"))
            {
                var stylee = new Style(typeof(Label))
                {
                    Setters =
                    {
                        new Setter { Property = Label.TextColorProperty, Value = resources["PrimaryTextColor"] },
                        new Setter { Property = Label.FontSizeProperty, Value = resources["HeaderFont"]}
                    }
                };
                resources.Add("PageHeaderLabeFont", stylee);
            }

            if (!resources.ContainsKey("BodyLabelSecondaryFont"))
            {
                var stylee = new Style(typeof(Label))
                {
                    Setters =
                    {
                        new Setter { Property = Label.TextColorProperty, Value = resources["SecondaryTextColor"] },
                        new Setter { Property = Label.FontSizeProperty, Value = resources["BodyFont"]}
                    }
                };
                resources.Add("BodyLabelSecondaryFont", stylee);
            }

            if (!resources.ContainsKey("TitleLabelPrimaryFont"))
            {
                var stylee = new Style(typeof(Label))
                {
                    Setters =
                    {
                        new Setter { Property = Label.TextColorProperty, Value = resources["PrimaryTextColor"] },
                        new Setter { Property = Label.FontSizeProperty, Value = resources["TitleFont"]}
                    }
                };
                resources.Add("TitleLabelPrimaryFont", stylee);
            }

            if (!resources.ContainsKey("TitleLabelSecondaryFont"))
            {
                var stylee = new Style(typeof(Label))
                {
                    Setters =
                    {
                        new Setter { Property = Label.TextColorProperty, Value = resources["SecondaryTextColor"] },
                        new Setter { Property = Label.FontSizeProperty, Value = resources["TitleFont"]}
                    }
                };
                resources.Add("TitleLabelSecondaryFont", stylee);
            }

            if (!resources.ContainsKey("HandleLabelPrimaryFont"))
            {
                var stylee = new Style(typeof(Label))
                {
                    Setters =
                    {
                        new Setter { Property = Label.TextColorProperty, Value = resources["PrimaryTextColor"] },
                        new Setter { Property = Label.FontSizeProperty, Value = resources["HandleFont"]}
                    }
                };
                resources.Add("HandleLabelPrimaryFont", stylee);
            }

            if (!resources.ContainsKey("BodyLabelPrimaryFont"))
            {
                var stylee = new Style(typeof(Label))
                {
                    Setters =
                    {
                        new Setter { Property = Label.TextColorProperty, Value = resources["PrimaryTextColor"] },
                        new Setter { Property = Label.FontSizeProperty, Value = resources["BodyFont"]}
                    }
                };
                resources.Add("BodyLabelPrimaryFont", stylee);
            }

            return resources;
        }
    }
}
