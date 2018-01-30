using System;
using Xamarin.Forms;
using Mugelli.Software.It.Mgc.Extensions;

namespace Mugelli.Software.It.Mgc.UserControls
{
    public class ZoomContentView : ContentView
    {
        private const double MIN_SCALE = 1;
        private const double MAX_SCALE = 4;
        private const double OVERSHOOT = 0.15;
        private double StartScale;
        private double LastX, LastY;

        private PanGestureRecognizer pan;

        //private bool _isZooming;

        public static readonly BindableProperty IsZoomingProperty =
            BindableProperty.CreateAttached("IsZomming", typeof(bool), typeof(ZoomContentView), defaultBindingMode: BindingMode.TwoWay, propertyChanging: OnZoomChanging, defaultValue: false);

        public bool IsZooming
        {
            get { return (bool)GetValue(IsZoomingProperty); }
            set { SetValue(IsZoomingProperty, value); }
        }

        private static void OnZoomChanging(BindableObject bindable, object oldValue, object newValue)
        {
            //scrivere zoom 
        }

        public EventHandler PanCompleted;

        public ZoomContentView()
        {
            var pinch = new PinchGestureRecognizer();
            pinch.PinchUpdated += OnPinchUpdated;
            GestureRecognizers.Add(pinch);

            pan = new PanGestureRecognizer();
            pan.PanUpdated += OnPanUpdated;
            //GestureRecognizers.Add(pan);

            var tap = new TapGestureRecognizer { NumberOfTapsRequired = 2 };
            tap.Tapped += OnTapped;
            GestureRecognizers.Add(tap);

            Scale = MIN_SCALE;
            TranslationX = TranslationY = 0;
            AnchorX = AnchorY = 0;
        }

        protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
        {
            Scale = MIN_SCALE;
            TranslationX = TranslationY = 0;
            AnchorX = AnchorY = 0;
            return base.OnMeasure(widthConstraint, heightConstraint);
        }

        private void OnTapped(object sender, EventArgs e)
        {
            //if (Scale > MIN_SCALE)
            //{
            //    this.ScaleTo(MIN_SCALE, 250, Easing.CubicInOut);
            //    this.TranslateTo(0, 0, 250, Easing.CubicInOut);

            //    if (GestureRecognizers.IndexOf(pan) < 0)
            //    {
            //        GestureRecognizers.Add(pan);
            //        IsZooming = true;
            //    }
            //}
            //else
            //{
            //    AnchorX = AnchorY = 0.5; //TODO tapped position
            //    this.ScaleTo(MAX_SCALE, 250, Easing.CubicInOut);

            //    if (GestureRecognizers.IndexOf(pan) > -1)
            //    {
            //        GestureRecognizers.Remove(pan);
            //        IsZooming = false;
            //    }
            //}
        }

        private void OnPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            if (Scale > MIN_SCALE)
                switch (e.StatusType)
                {
                    case GestureStatus.Started:
                        LastX = TranslationX;
                        LastY = TranslationY;
                        break;
                    case GestureStatus.Running:
                        TranslationX = Clamp(LastX + e.TotalX * Scale, -Width / 2, Width / 2);
                        TranslationY = Clamp(LastY + e.TotalY * Scale, -Height / 2, Height / 2);
                        break;
                }
        }

        private void OnPinchUpdated(object sender, PinchGestureUpdatedEventArgs e)
        {
            switch (e.Status)
            {
                case GestureStatus.Started:
                    StartScale = Scale;
                    AnchorX = e.ScaleOrigin.X;
                    AnchorY = e.ScaleOrigin.Y;
                    break;
                case GestureStatus.Running:
                    double current = Scale + (e.Scale - 1) * StartScale;
                    Scale = Clamp(current, MIN_SCALE * (1 - OVERSHOOT), MAX_SCALE * (1 + OVERSHOOT));
                    break;
                case GestureStatus.Completed:
                    if(Scale > MIN_SCALE) 
                    {
                        if (GestureRecognizers.IndexOf(pan) < 0)
                        {
                            GestureRecognizers.Add(pan);
                            IsZooming = true;
                        }
                    } 
                    else 
                    {   
                        if (GestureRecognizers.IndexOf(pan) > -1)
                        {
                            GestureRecognizers.Remove(pan);
                            IsZooming = false;
                        }
                    }

                    if (Scale > MAX_SCALE) 
                        this.ScaleTo(MAX_SCALE, 250, Easing.SpringOut);
                    else if (Scale < MIN_SCALE)
                        this.ScaleTo(MIN_SCALE, 250, Easing.SpringOut);
            
                    break;
            }
        }

        private T Clamp<T>(T value, T minimum, T maximum) where T : IComparable
        {
            if (value.CompareTo(minimum) < 0)
                return minimum;
            else if (value.CompareTo(maximum) > 0)
                return maximum;
            else
                return value;
        }
    }
}