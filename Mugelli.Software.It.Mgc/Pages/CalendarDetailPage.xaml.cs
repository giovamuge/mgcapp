using System;
using System.Collections.Generic;
using Mugelli.Software.It.Mgc.Models;
using Mugelli.Software.It.Mgc.ViewModel;
using Xamarin.Forms;

namespace Mugelli.Software.It.Mgc.Pages
{
    public partial class CalendarDetailPage : ContentPage
    {
        public CalendarDetailPage(Appointment appointment)
        {
            InitializeComponent();

            if (Device.RuntimePlatform == Device.Android)
            {
                NavigationPage.SetHasNavigationBar(this, false);
            }

            var viewModel = BindingContext as CalendarDetailViewModel;
            if (viewModel != null) viewModel.Appointment = appointment;

            AppointmentTitle.Text = appointment.Title;
            AppointmentDate.Text = $"{appointment.Date:dd MMMM yyyy}";
        }
    }
}
