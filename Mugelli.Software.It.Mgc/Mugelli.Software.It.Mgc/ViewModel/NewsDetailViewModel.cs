using System.Collections.Generic;
using GalaSoft.MvvmLight;
using Mugelli.Software.It.Mgc.Models;

namespace Mugelli.Software.It.Mgc.ViewModel
{
    public class NewsDetailViewModel : ViewModelBase
    {   
        public NewsDetail Article { get; set; }

        public NewsDetailViewModel()
        {
            Article = new NewsDetail
            {
                DateCreate = "30/10/2017",
                Image = "MensaCaritas.jpg",
                Text = @"Il servizio alla mensa della Caritas non si è mai fermato durante l’estate, ma quella di ottobre può comunque considerarsi la giornata di inizio ufficiale per il nuovo anno incontro all’altro. A questo turno hanno partecipato anche alcuni amici del movimento di altre zone d’Italia, che approfittando della loro presenza a Firenze in quel fine settimana hanno scelto di dedicare una mezza giornata ai più bisognosi.",
                Title = "INCONTRO ALL’ALTRO – Mensa Caritas 16/10/2017"
            };
        }
    }
}