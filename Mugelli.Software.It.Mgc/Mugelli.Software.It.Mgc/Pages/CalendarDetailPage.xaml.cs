using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mugelli.Software.It.Mgc.Models;
using Mugelli.Software.It.Mgc.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mugelli.Software.It.Mgc.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CalendarDetailPage : ContentPage
	{
		public CalendarDetailPage (Appointment appointment)
		{
			InitializeComponent ();

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