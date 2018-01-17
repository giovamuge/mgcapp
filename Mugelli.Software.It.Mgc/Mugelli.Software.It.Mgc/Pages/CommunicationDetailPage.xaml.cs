using System;
using System.Collections.Generic;
using Mugelli.Software.It.Mgc.Models;
using Mugelli.Software.It.Mgc.ViewModel;
using Xamarin.Forms;

namespace Mugelli.Software.It.Mgc.Pages
{
    public partial class CommunicationDetailPage : ContentPage
    {
        public CommunicationDetailPage(Communication communication)
        {
            InitializeComponent();

            var viewModel = BindingContext as CommunicationDetailViewModel;
            if (viewModel != null) viewModel.Communication = communication;
        }
    }
}
