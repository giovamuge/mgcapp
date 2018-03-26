using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Mugelli.Software.It.Mgc.Navigations;
using Mugelli.Software.It.Mgc.Pages;
using Mugelli.Software.It.Mgc.Stacks;
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

        private readonly INavigationService _navigationService;

        public RootViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            Title = "MGC";
            TitleCommunications = "Communicazioni";
            TitleCalendar = "Calendar";
            TitleNews = "Notizie";
            TitleInfo = "Info";

            Communications = new CommunicationsPage();
            Calendar = new CalendarPage();
            News = new NewsPage();

            var listpages = new List<Page>();

            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    BarBackgroundColor = (Color) Application.Current.Resources["MgcColor"];
                    BarTextColor = (Color) Application.Current.Resources["GrayUltraLight"];

                    listpages = new List<Page>
                    {
                        News,
                        Calendar,
                        Communications,
                        new InfoPage()
                    };

                    //Childrens.Add(new InfoPage());
                    break;
                case Device.iOS:
                    BarTextColor = (Color)Application.Current.Resources["MgcColor"];


                    var toolbarinformation = new ToolbarItem
                    {
                        Icon = "information.png",
                        Command = new RelayCommand(() => {
                            _navigationService.PushModal(ModalStacks.InfoModal, null);
                        }),
                        Priority = 0,
                        Order = ToolbarItemOrder.Primary
                    };

                    Communications.ToolbarItems.Add(toolbarinformation);
                    Calendar.ToolbarItems.Add(toolbarinformation);
                    News.ToolbarItems.Add(toolbarinformation);

                    listpages = new List<Page>
                    {
                        News,
                        Calendar,
                        Communications
                    };
                    break;
            }

            Childrens = listpages;
        }
        
    }
}