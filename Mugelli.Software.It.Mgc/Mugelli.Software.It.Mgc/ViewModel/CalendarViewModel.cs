using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using Mugelli.Software.It.Mgc.Helper;
using Mugelli.Software.It.Mgc.Models;

namespace Mugelli.Software.It.Mgc.ViewModel
{
    public class CalendarViewModel : ViewModelBase
    {
        public CalendarViewModel()
        {
            Appointments = new List<Appointment>
            {
                new Appointment
                {
                    Date = DateTime.Now,
                    Location = "Fiesole, Casa Oblata",
                    Title = "Giornata Famiglia Obliata"
                },
                new Appointment
                {
                    Location = "Casellina",
                    Title = "Giornata Giovanissimi",
                    Date = DateTime.Now
                }
            };
        }

        public string Title { get; set; } = "Calendario";
        public string Icon { get; set; } = OnPlatformHelper.IconOniOS("Calendar_50px.png");

        public List<Appointment> Appointments { get; set; }
    }
}