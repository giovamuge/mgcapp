﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Mugelli.Software.It.Mgc.Helper;
using Mugelli.Software.It.Mgc.Models;
using Mugelli.Software.It.Mgc.Models.Types;
using Mugelli.Software.It.Mgc.Navigations;
using Mugelli.Software.It.Mgc.Services;
using Mugelli.Software.It.Mgc.Stacks;

namespace Mugelli.Software.It.Mgc.ViewModel
{
    public class CalendarViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public CalendarViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;


            //Appointments = new List<Appointment>
            //{
            //    new Appointment
            //    {
            //        Date = DateTime.Now,
            //        Location = "Fiesole, Casa Oblata",
            //        Title = "Giornata Famiglia Obliata",
            //        Type = EventType.Ammi,
            //        TimeLine = TimeLineAppointmentTest
            //    },
            //    new Appointment
            //    {
            //        Location = "Casellina",
            //        Title = "Giornata Giovanissimi",
            //        Date = DateTime.Now,
            //        Type = EventType.Giovanissimi,
            //        TimeLine = TimeLineAppointmentTest
            //    },
            //    new Appointment
            //    {
            //        Location = "Fiesole",
            //        Title = "Giornata MGC",
            //        Date = DateTime.Now,
            //        Type = EventType.Mgc,
            //        TimeLine = TimeLineAppointmentTest
            //    }
            //};
            
            AppointmentsGroupped = new List<List<Appointment>>
            {
                Appointments,
                Appointments,
                Appointments
            };

            ShowAppointmentCommand = new RelayCommand<Appointment>(OnShowAppointment);
            RefreshCommand = new RelayCommand(OnRefresh);

            OnRefresh();
        }

        public ICommand RefreshCommand { get; set; }

        public string Title { get; set; } = "Calendario";
        public string Icon { get; set; } = OnPlatformHelper.IconOniOS("Calendar_50px.png");

        public List<Appointment> Appointments { get; set; }
        public List<List<Appointment>> AppointmentsGroupped { get; set; }
        public ICommand ShowAppointmentCommand { get; set; }

        private List<TimeLineAppointment> TimeLineAppointmentTest { get; set;  }

        //private List<TimeLineAppointment> TimeLineAppointmentTest { get; } = new List<TimeLineAppointment>
        //{
        //    new TimeLineAppointment
        //    {
        //        Time = "9:45",
        //        Information = "In attesa di iniziare",
        //        Name = "Arrivi e accoglienza"
        //    },
        //    new TimeLineAppointment
        //    {
        //        Time = "10:15",
        //        Information = "Preghiera tutti insieme a seguire tema",
        //        Name = "Preghiera"
        //    },
        //    new TimeLineAppointment
        //    {
        //        Time = "11:15",
        //        Information = "In attesa di iniziare",
        //        Name = "Condivisione"
        //    },
        //    new TimeLineAppointment
        //    {
        //        Time = "12:30",
        //        Information = "In attesa di iniziare",
        //        Name = "Pausa e preparazione"
        //    },
        //    new TimeLineAppointment
        //    {
        //        Time = "13:00",
        //        Information = "In attesa di iniziare",
        //        Name = "Pranzo"
        //    },
        //    new TimeLineAppointment
        //    {
        //        Time = "14:30",
        //        Information = "In attesa di iniziare",
        //        Name = "Tempo libero di conoscenza"
        //    },
        //    new TimeLineAppointment
        //    {
        //        Time = "15:30",
        //        Information = "In attesa di iniziare",
        //        Name = "Aggiornamenti"
        //    },
        //    new TimeLineAppointment
        //    {
        //        Time = "16:30",
        //        Information = "Pausa",
        //        Name = "Arrivi e accoglienza"
        //    },
        //    new TimeLineAppointment
        //    {
        //        Time = "17:00",
        //        Information = "Salutiamoci",
        //        Name = "Messa e saluti"
        //    }
        //};

        private void OnRefresh()
        {
            IsRefreshing = true;
            Task.Factory.StartNew(async () =>
            {
                var calendars = await FirebaseRestHelper.Instance.GetCalendar();
                Appointments = calendars;
                IsRefreshing = false;
            });
        }

        public bool IsRefreshing { get; set; }

        private void OnShowAppointment(Appointment appointment)
        {
            _navigationService.NavigateTo(PageStacks.CalendarDetailPage, appointment);
        }
    }
}