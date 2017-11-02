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

        public string Text { get; } =
            @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque varius lacus vel odio varius imperdiet. Sed blandit accumsan pellentesque. Aenean eleifend egestas sem at rhoncus. Fusce volutpat egestas est, mollis tristique lacus imperdiet sit amet. Proin pellentesque sed tortor at varius. Nam commodo purus id dignissim volutpat. Sed diam neque, vulputate a blandit ut, efficitur interdum nisl. Donec venenatis, erat vitae commodo vestibulum, massa tortor feugiat ipsum, ultricies pretium quam arcu sed purus. Cras id orci vel dui eleifend dictum. Proin lobortis sapien quam, semper semper dui lacinia sed. Vivamus est urna, feugiat non metus vel, scelerisque iaculis enim. Integer feugiat pharetra nunc at fermentum.

Nullam velit mi, scelerisque id erat sed, feugiat imperdiet nisl. Donec ut lobortis mi, non viverra eros. Etiam congue molestie posuere. Sed id pretium lacus. Nullam lorem nulla, convallis sagittis fringilla id, tincidunt nec dui. Pellentesque ac semper eros. Nulla magna lorem, tristique ornare arcu quis, ullamcorper bibendum ante. Curabitur vel ullamcorper nisi. In ac consectetur lorem. Mauris cursus felis lacus, sit amet tristique tortor rutrum sit amet. Phasellus sit amet ultricies leo, ac blandit elit. Vestibulum dolor ligula, accumsan a velit ac, accumsan lobortis ante. Aenean justo augue, scelerisque sit amet elit sed, iaculis mollis eros.

Curabitur volutpat felis sit amet hendrerit tincidunt. Vestibulum faucibus congue dignissim. Nunc tempus massa eget ex tempus, vel tempor tellus mattis. Curabitur molestie tellus porttitor lacus eleifend euismod. Etiam et pulvinar erat, quis laoreet dolor. In sed augue dui. Nullam accumsan mi vitae nunc bibendum pulvinar. Aenean porttitor non nisi sit amet semper. Sed non diam metus. Mauris porttitor ante vitae lorem pulvinar, eu viverra elit pulvinar. Maecenas quis neque leo. Interdum et malesuada fames ac ante ipsum primis in faucibus. Fusce tempor augue quis nibh auctor, ut rhoncus quam vulputate. Praesent condimentum dui eu magna consequat, a tempus quam cursus. Duis fringilla nisl non odio eleifend, et commodo justo pellentesque.

Duis ut nibh id metus consequat mattis. Pellentesque mattis ex et volutpat lobortis. Mauris varius, nibh non dictum consequat, dui arcu tempus tellus, nec gravida justo odio eget sem. Ut vestibulum sapien ac ante suscipit, a dapibus nulla imperdiet. Nunc egestas vestibulum gravida. Nulla imperdiet luctus egestas. Etiam pretium tempus leo eu hendrerit. In commodo pharetra erat ac consequat. Nunc ullamcorper, enim quis feugiat dapibus, mauris elit luctus nibh, sed tempor orci felis ut risus. Nulla nisi libero, gravida in porta id, fermentum vitae mauris.

Aenean cursus tellus est, nec porta mauris porttitor a. Phasellus fringilla rhoncus lorem, in vulputate ante laoreet sed. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Praesent quis ex rhoncus, tincidunt ex semper, placerat metus. Morbi sed porttitor massa, at pulvinar nisl. Duis pretium ante suscipit ultrices ultrices. Interdum et malesuada fames ac ante ipsum primis in faucibus. In eleifend ultrices leo id tempus. Ut turpis diam, fermentum sed eros id, tincidunt lobortis arcu. Suspendisse ex turpis, placerat eget semper sed, vestibulum a est. Suspendisse rutrum nibh velit, in pulvinar ante cursus et.";

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
                    Text = Text
                    //Text =
                        //@"Il servizio alla mensa della Caritas non si è mai fermato durante l’estate, ma quella di ottobre può comunque considerarsi la giornata di inizio ufficiale per il nuovo anno incontro all’altro. A questo turno hanno partecipato anche alcuni amici del movimento di altre zone d’Italia, che approfittando della loro presenza a Firenze in quel fine settimana hanno scelto di dedicare una mezza giornata ai più bisognosi."
                },
                new News
                {
                    Title = "MGC – Spettacolo Piccolo principe",
                    Subtitle = "Ieri sera il Movimento Giovanile Costruire di Firenze ha messo...",
                    DateCreate = "15/10/2017",
                    HeroImage = "PiccoloPrincipe.jpg",
                    Id = "2",
                    Author = "Andrea Cuminatto",
                    Text = Text
                    //Text =
                        //@"Ieri sera il Movimento Giovanile Costruire di Firenze ha messo in scena lo spettacolo “Viaggio di un Piccolo Principe” presso il Teatrodante Carlo Monni di Campi Bisenzio. Il progetto ha visto coinvolti molti ragazzi del movimento, aiutati e supportati da alcuni membri dell’Ammi. È stato il culmine di un lungo percorso di preparazione iniziato a febbraio. Il fine dello spettacolo è stato quello di raccogliere fondi per supportare la costruzione di una scuola a Ndangane, in Senegal, sulla scia del viaggio missionario al quale alcuno ragazzo di Firenze, insieme ad altri di altre zone d’Italia, hanno partecipato quest’estate. È stato un percorso durante il quale ognuno ha potuto mettere a disposizione i propri talenti e il proprio impegno. Ieri sera lo spettacolo è stato accolto con entusiasmo ed energia. Un grande momento di condivisione ed unità."
                },
                new News
                {
                    Title = "GIOVANISSIMI – Pizzata del 10/06/2017",
                    Subtitle = "Ebbene si ieri sera con la nostra fantastica pizzata si è concluso...",
                    DateCreate = "13/06/2017",
                    HeroImage = "Pizzata.jpg",
                    Id = "3",
                    Author = "Chiara Andrei",
                    Text = Text
                    //Text =
                        //@"Ebbene si ieri sera con la nostra fantastica pizzata si è concluso il nostro percorso giovanissimi! Abbiamo voluto festeggiare questo momento con tanti balli, pizza e risate! Dopo aver giocato a un quiz sulle favole i giovanissimi hanno ascoltato un tema ispirato alla favola di Peter pan, in cui si parlava soprattutto di bimbi sperduti. Il rischio è che durante l’estate ci siano dei giovanissimi e animatori spariscono dimenticandosi del percorso fatto durante l’inverno. Ma non dobbiamo avere paura un altro appuntamento ci aspetta….. IL CAMPEGGIONE ESTIVO! Vi aspettiamo numerosi!!"
                },
                new News
                {
                    Title = "GIOVANISSIMI – Giornata Sportiva 28/05/2017",
                    Subtitle = "Ebbene sì! Come ogni anno abbiamo concluso anche le nostre giornate...",
                    DateCreate = "06/06/2017",
                    HeroImage = "GiornataSportiva.jpg",
                    Id = "4",
                    Author = "Chiara Andrei",
                    Text = Text
                    //Text =
                        //@"Ebbene sì! Come ogni anno abbiamo concluso anche le nostre giornate! In attesa dell’ultima pizzata, l’ultima domenica di maggio abbiamo vissuto un appuntamento all’insegna della compagnia e del divertimento. I ragazzi si sono buttati nella famosissima giornata sportiva! I nostri animatori avevano organizzato un sacco di attività tra cui pallavolo, balli, calcio e chi più ne ha più ne metta. Il tutto contornato da una fantastica merenda!
                        //Ci vediamo alla pizzata!!!!!!
                        //ballo, pallaavvelenata, pallavolo, cammino, 2017"
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