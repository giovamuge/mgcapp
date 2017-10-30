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

        public Page News { get; set; }
        public Page Communications { get; set; }
        public Page Calendar { get; set; }

        public List<Page> Childrens { get; set; }
        
        public RootViewModel()
        {
            Title = "MGC";
            TitleCommunications = "Communicazioni";
            TitleCalendar = "Calendario";
            TitleNews = "Notizie";

            Communications = new CommunicationsPage();
            Calendar = new CalendarPage();
            News = new NewsPage();

            Childrens = new List<Page>
            {
                News,
                Calendar,
                Communications
            };
        }
        
    }
}