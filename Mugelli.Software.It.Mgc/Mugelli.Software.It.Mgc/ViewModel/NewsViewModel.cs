using System.Collections.Generic;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Mugelli.Software.It.Mgc.Helper;
using Mugelli.Software.It.Mgc.Models;
using Mugelli.Software.It.Mgc.Navigations;
using Mugelli.Software.It.Mgc.Stacks;
using Xamarin.Forms;

namespace Mugelli.Software.It.Mgc.ViewModel
{
    public class NewsViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public NewsViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NewsList = new List<News>
            {
                new News
                {
                    Title = "INCONTRO ALL’ALTRO – Mensa Caritas 16/10/2017",
                    Subtitle = "Il servizio alla mensa della Caritas non si è mai fermato...",
                    DateCreate = "30/10/2017",
                    HeroImage = "MensaCaritas.jpg",
                    Id = "1",
                    Author = "Matteo Foschini",
                    Text =
                        @"Il servizio alla mensa della Caritas non si è mai fermato durante l’estate, ma quella di ottobre può comunque considerarsi la giornata di inizio ufficiale per il nuovo anno incontro all’altro. A questo turno hanno partecipato anche alcuni amici del movimento di altre zone d’Italia, che approfittando della loro presenza a Firenze in quel fine settimana hanno scelto di dedicare una mezza giornata ai più bisognosi."
                },
                new News
                {
                    Title = "MGC – Spettacolo Piccolo principe",
                    Subtitle = "Ieri sera il Movimento Giovanile Costruire di Firenze ha messo...",
                    DateCreate = "15/10/2017",
                    HeroImage = "PiccoloPrincipe.jpg",
                    Id = "2",
                    Author = "Andrea Cuminatto",
                    Text =
                        @"Ieri sera il Movimento Giovanile Costruire di Firenze ha messo in scena lo spettacolo “Viaggio di un Piccolo Principe” presso il Teatrodante Carlo Monni di Campi Bisenzio. Il progetto ha visto coinvolti molti ragazzi del movimento, aiutati e supportati da alcuni membri dell’Ammi. È stato il culmine di un lungo percorso di preparazione iniziato a febbraio. Il fine dello spettacolo è stato quello di raccogliere fondi per supportare la costruzione di una scuola a Ndangane, in Senegal, sulla scia del viaggio missionario al quale alcuno ragazzo di Firenze, insieme ad altri di altre zone d’Italia, hanno partecipato quest’estate. È stato un percorso durante il quale ognuno ha potuto mettere a disposizione i propri talenti e il proprio impegno. Ieri sera lo spettacolo è stato accolto con entusiasmo ed energia. Un grande momento di condivisione ed unità."
                },
                new News
                {
                    Title = "GIOVANISSIMI – Pizzata del 10/06/2017",
                    Subtitle = "Ebbene si ieri sera con la nostra fantastica pizzata si è concluso...",
                    DateCreate = "13/06/2017",
                    HeroImage = "Pizzata.jpg",
                    Id = "3",
                    Author = "Chiara Andrei",
                    Text =
                        @"Ebbene si ieri sera con la nostra fantastica pizzata si è concluso il nostro percorso giovanissimi! Abbiamo voluto festeggiare questo momento con tanti balli, pizza e risate! Dopo aver giocato a un quiz sulle favole i giovanissimi hanno ascoltato un tema ispirato alla favola di Peter pan, in cui si parlava soprattutto di bimbi sperduti. Il rischio è che durante l’estate ci siano dei giovanissimi e animatori spariscono dimenticandosi del percorso fatto durante l’inverno. Ma non dobbiamo avere paura un altro appuntamento ci aspetta….. IL CAMPEGGIONE ESTIVO! Vi aspettiamo numerosi!!"
                },
                new News
                {
                    Title = "GIOVANISSIMI – Giornata Sportiva 28/05/2017",
                    Subtitle = "Ebbene sì! Come ogni anno abbiamo concluso anche le nostre giornate...",
                    DateCreate = "06/06/2017",
                    HeroImage = "GiornataSportiva.jpg",
                    Id = "4",
                    Author = "Chiara Andrei",
                    Text =
                        @"Ebbene sì! Come ogni anno abbiamo concluso anche le nostre giornate! In attesa dell’ultima pizzata, l’ultima domenica di maggio abbiamo vissuto un appuntamento all’insegna della compagnia e del divertimento. I ragazzi si sono buttati nella famosissima giornata sportiva! I nostri animatori avevano organizzato un sacco di attività tra cui pallavolo, balli, calcio e chi più ne ha più ne metta. Il tutto contornato da una fantastica merenda!
                        Ci vediamo alla pizzata!!!!!!
                        ballo, pallaavvelenata, pallavolo, cammino, 2017"
                }
            };

            ReadArticleCommand = new RelayCommand<News>(OnReadArticle);
        }

        public string Title { get; set; } = "News";
        public string Icon { get; set; } = OnPlatformHelper.IconOniOS("News_50px.png");
        public List<News> NewsList { get; set; }

        public ICommand ReadArticleCommand { get; set; }

        private void OnReadArticle(News news)
        {
            _navigationService.NavigateTo(PageStacks.NewsDetailPage, news);
        }
    }
}