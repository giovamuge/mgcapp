using System;
using Mugelli.Software.It.Mgc.MessagingCenters;
using Xamarin.Forms;

namespace Mugelli.Software.It.Mgc.Droid.MessagingCenters
{
    public static class PayloadDroidMessage
    {
        public static void Subscribe(MainActivity app) 
        {
            MessagingCenter.Subscribe<PayloadMessage>(app, nameof(PayloadMessage), (sender) => {});
        }

        public static void Send(PayloadMessage sender)
        {
            MessagingCenter.Send(sender, nameof(PayloadMessage));
        }
    }
}
