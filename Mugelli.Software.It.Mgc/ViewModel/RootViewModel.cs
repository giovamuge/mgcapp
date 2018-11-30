using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Mugelli.Software.It.Mgc.Commons;
using Mugelli.Software.It.Mgc.Helpers;
using Mugelli.Software.It.Mgc.Models;
using Mugelli.Software.It.Mgc.Navigations;
using Mugelli.Software.It.Mgc.Pages;
using Mugelli.Software.It.Mgc.Services;
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
        private readonly IPayloadService _payloadService;

        public RootViewModel(INavigationService navigationService, IPayloadService payloadService)
        {
            _navigationService = navigationService;
            _payloadService = payloadService;

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
                    BarBackgroundColor = (Color)Application.Current.Resources["MgcColor"];
                    BarTextColor = (Color)Application.Current.Resources["GrayUltraLight"];

                    listpages = new List<Page>
                    {
                        News,
                        Calendar,
                        Communications
                    };

                    listpages.Add(new InfoPage());
                    break;
                case Device.iOS:
                    BarTextColor = (Color)Application.Current.Resources["MgcColor"];


                    var toolbarinformation = new ToolbarItem
                    {
                        Icon = "information.png",
                        Command = new RelayCommand(() =>
                        {
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

            // Controlla e inizializza payload della notifica
            //Task.Run(InitializePayload);
        }

        public async Task InitializePayload()
        {
            if (string.IsNullOrEmpty(Settings.PayloadType) || string.IsNullOrEmpty(Settings.PayloadId))
            {
                return;
            }

            switch (Settings.PayloadType)
            {
                case ConstantCommon.AdvertisingMessage:
                    var advert = await FirebaseRestHelper.Instance.GetAdvertising(Settings.PayloadId);
                    ResetPayload();
                    await _navigationService.PushModal(PageStacks.CommunicationDetailPage, advert);
                    break;
                case ConstantCommon.NewsgMessage:
                    var news = await FirebaseRestHelper.Instance.GetSingleNews(Settings.PayloadId);
                    ResetPayload();
                    await _navigationService.PushModal(PageStacks.NewsDetailPage, news);
                    break;
                case ConstantCommon.CalendarMessage:
                    ResetPayload();
                    await _navigationService.PushModal(PageStacks.CalendarDetailPage, new Appointment());
                    break;
            }
        }

        private static void ResetPayload()
        {
            Settings.PayloadId = string.Empty;
            Settings.PayloadType = string.Empty;
        }
    }
}