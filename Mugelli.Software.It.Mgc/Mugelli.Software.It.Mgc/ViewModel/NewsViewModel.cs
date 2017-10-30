using System;
using System.Collections.Generic;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Mugelli.Software.It.Mgc.Models;
using Xamarin.Forms;

namespace Mugelli.Software.It.Mgc.ViewModel
{
    public class NewsViewModel : ViewModelBase
    {
        public string Title { get; set; } = "News";
        public string Icon { get; set; } = "News_50px.png";
        public List<News> NewsList { get; set; }

        public ICommand ReadArticleCommand { get; set; }

        public NewsViewModel()
        {
            NewsList = new List<News>
            {
                new News
                {
                    Title = "INCONTRO ALL’ALTRO – Mensa Caritas 16/10/2017",
                    Subtitle = "Il servizio alla mensa della Caritas non si è mai fermato...",
                    DateCreate = "30/10/2017",
                    HeroImage = "MensaCaritas.jpg"
                },
                new News
                {
                    Title = "MGC – Spettacolo Piccolo principe",
                    Subtitle = "Ieri sera il Movimento Giovanile Costruire di Firenze ha messo...",
                    DateCreate = "15/10/2017",
                    HeroImage = "PiccoloPrincipe.jpg"
                },
                new News
                {
                    Title = "GIOVANISSIMI – Pizzata del 10/06/2017",
                    Subtitle = "Ebbene si ieri sera con la nostra fantastica pizzata si è concluso...",
                    DateCreate = "13/06/2017",
                    HeroImage = "Pizzata.jpg"
                },
                new News
                {
                    Title = "GIOVANISSIMI – Giornata Sportiva 28/05/2017",
                    Subtitle = "Ebbene sì! Come ogni anno abbiamo concluso anche le nostre giornate...",
                    DateCreate = "06/06/2017",
                    HeroImage = "GiornataSportiva.jpg"
                }
            };

            ReadArticleCommand = new RelayCommand(OnReadArticle);
        }

        private static void OnReadArticle()
        {
            
        }
    }
}