﻿using System;
using Xamarin.Forms;
using Mugelli.Software.It.Mgc.Extensions;

namespace Mugelli.Software.It.Mgc.UserControls
{
    public class ZoomContentView : ContentView
    {
        //private const double MIN_SCALE = 1;
        //private const double MAX_SCALE = 4;
        //private const double OVERSHOOT = 0.15;
        //private double StartScale;
        //private double LastX, LastY;

        //private PanGestureRecognizer pan;

        //private bool _isZooming;

        public static readonly BindableProperty IsZoomingProperty =
            BindableProperty.CreateAttached("IsZomming", typeof(bool), typeof(ZoomContentView), defaultBindingMode: BindingMode.TwoWay, propertyChanging: OnZoomChanging, defaultValue: true);

        public bool IsZooming
        {
            get { return (bool)GetValue(IsZoomingProperty); }
            set { SetValue(IsZoomingProperty, value); }
        }

        private static void OnZoomChanging(BindableObject bindable, object oldValue, object newValue)
        {
            //scrivere zoom 
        }

        //public EventHandler PanCompleted;

        private const double MIN_SCALE = 1;
        private const double MAX_SCALE = 4;
        private double startScale, currentScale;
        private double startX, startY;
        private double xOffset, yOffset;

        public ZoomContentView()
        {            
            var pinchGesture = new PinchGestureRecognizer();
            pinchGesture.PinchUpdated += OnPinchUpdated;
            GestureRecognizers.Add(pinchGesture);

            var pan = new PanGestureRecognizer();            
            pan.PanUpdated += OnPanUpdated;
            GestureRecognizers.Add(pan);

            TapGestureRecognizer tap = new TapGestureRecognizer { NumberOfTapsRequired = 2 };
            tap.Tapped += OnTapped;
            GestureRecognizers.Add(tap);

            Scale = MIN_SCALE;
            TranslationX = TranslationY = 0;
            AnchorX = AnchorY = 0;
        }

        private void OnTapped(object sender, EventArgs e)
        {
            if (Content.Scale > MIN_SCALE)
            {
                RestoreScaleValues();
                IsZooming = false;
            }
            else
            {
                Content.AnchorX = Content.AnchorY = 0.5;
                Content.ScaleTo(MAX_SCALE, 250, Easing.CubicInOut);
                IsZooming = true;
            }
        }
        void RestoreScaleValues()
        {
            Content.ScaleTo(MIN_SCALE, 250, Easing.CubicInOut);
            Content.TranslateTo(0.5, 0.5, 250, Easing.CubicInOut);

            currentScale = 1;

            Content.TranslationX = 0.5;
            Content.TranslationY = 0.5;

            xOffset = Content.TranslationX;
            yOffset = Content.TranslationY;
        }

        void OnPinchUpdated(object sender, PinchGestureUpdatedEventArgs e)
        {
            if (e.Status == GestureStatus.Started)
            {
                startScale = Content.Scale;
                Content.AnchorX = 0;
                Content.AnchorY = 0;
                IsZooming = false;
            }
            if (e.Status == GestureStatus.Running)
            {
                // Calculate the scale factor to be applied.
                currentScale += (e.Scale - 1) * startScale;
                currentScale = Math.Max(1, currentScale);

                // The ScaleOrigin is in relative coordinates to the wrapped user interface element,
                // so get the X pixel coordinate.
                double renderedX = Content.X + xOffset;
                double deltaX = renderedX / Width;
                double deltaWidth = Width / (Content.Width * startScale);
                double originX = (e.ScaleOrigin.X - deltaX) * deltaWidth;

                // The ScaleOrigin is in relative coordinates to the wrapped user interface element,
                // so get the Y pixel coordinate.
                double renderedY = Content.Y + yOffset;
                double deltaY = renderedY / Height;
                double deltaHeight = Height / (Content.Height * startScale);
                double originY = (e.ScaleOrigin.Y - deltaY) * deltaHeight;

                // Calculate the transformed element pixel coordinates.
                double targetX = xOffset - (originX * Content.Width) * (currentScale - startScale);
                double targetY = yOffset - (originY * Content.Height) * (currentScale - startScale);

                // Apply translation based on the change in origin.
                Content.TranslationX = targetX.Clamp(-Content.Width * (currentScale - 1), 0);
                Content.TranslationY = targetY.Clamp(-Content.Height * (currentScale - 1), 0);

                // Apply scale factor.
                Content.Scale = currentScale;
            }
            if (e.Status == GestureStatus.Completed)
            {
                // Store the translation delta's of the wrapped user interface element.
                xOffset = Content.TranslationX;
                yOffset = Content.TranslationY;
            }
        }

        double maxTranslationX, maxTranslationY;

        void OnPanUpdated(object sender, PanUpdatedEventArgs e)
        {

            switch (e.StatusType)
            {
                case GestureStatus.Started:
                    startX = e.TotalX;
                    startY = e.TotalY;
                    Content.AnchorX = 0;
                    Content.AnchorY = 0;
                    break;

                case GestureStatus.Running:
                    maxTranslationX = Content.Scale * Content.Width - Content.Width;
                    Content.TranslationX = Math.Min(0, Math.Max(-maxTranslationX, xOffset + e.TotalX - startX));

                    maxTranslationY = Content.Scale * Content.Height - Content.Height;
                    Content.TranslationY = Math.Min(0, Math.Max(-maxTranslationY, yOffset + e.TotalY - startY));

                    //IsZooming = !((Content.TranslationX < 0 ? maxTranslationX + Content.TranslationX : maxTranslationX - Content.TranslationX).Equals(0) || Content.TranslationX.Equals(0));

                    break;

                case GestureStatus.Completed:
                    xOffset = Content.TranslationX;
                    yOffset = Content.TranslationY;

                    IsZooming = !((Content.TranslationX < 0 ? maxTranslationX + Content.TranslationX : maxTranslationX - Content.TranslationX).Equals(0) || Content.TranslationX.Equals(0));

                    break;                   
            }
        }

        protected override void OnParentSet()
        {
            Content.TranslationX = Content.TranslationY = 0;
            base.OnParentSet();
        }
    }
}