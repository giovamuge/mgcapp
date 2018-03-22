using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using GalaSoft.MvvmLight;
using Mugelli.Software.It.Mgc.Pages;
using Xamarin.Forms;

namespace Mugelli.Software.It.Mgc.ViewModel
{
    public class RootViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public string Title { get; set; }
        public string TitleNews { get; set; }
        public string TitleCommunications { get; set; }
        public string TitleCalendar { get; set; }
        public string TitleInfo { get; set; }

        public Page News { get; set; }
        public Page Communications { get; set; }
        public Page Calendar { get; set; }

        public Color BarBackgroundColor { get; set; }
        public Color BarTextColor { get; set; } 

        public List<Page> Childrens { get; set; }
        
        public RootViewModel()
        {
            Title = "MGC";
            TitleCommunications = "Communicazioni";
            TitleCalendar = "Calendar";
            TitleNews = "Notizie";
            TitleInfo = "Info";

            Communications = new CommunicationsPage();
            Calendar = new CalendarPage();
            News = new NewsPage();

            Childrens = new List<Page>
            {
                News,
                Calendar,
                Communications
            };

            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    BarBackgroundColor = (Color) Application.Current.Resources["MgcColor"];
                    BarTextColor = (Color) Application.Current.Resources["GrayUltraLight"];

                    Childrens.Add(new InfoPage());
                    break;
                case Device.iOS:
                    BarTextColor = (Color)Application.Current.Resources["MgcColor"];
                    break;
            }
        }
        
    }
}