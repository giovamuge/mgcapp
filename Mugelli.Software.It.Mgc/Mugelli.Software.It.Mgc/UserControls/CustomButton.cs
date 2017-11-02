using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mugelli.Software.It.Mgc.UserControls
{
    public class CustomButton : Button
    {
        public CustomButton()
        {
            const int animationTime = 100;
            Clicked += async(sender, e) =>
            {
                var btn = (CustomButton)sender;
                await btn.ScaleTo(1.2, animationTime);
                await btn.ScaleTo(1, animationTime);
                //btn.ScaleTo(1, animationTime);
            };
}
    }
}
