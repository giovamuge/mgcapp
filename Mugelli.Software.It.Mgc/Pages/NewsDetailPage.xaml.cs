using System;
using System.Collections.Generic;
using Mugelli.Software.It.Mgc.Models;
using Mugelli.Software.It.Mgc.ViewModel;
using Xamarin.Forms;

namespace Mugelli.Software.It.Mgc.Pages
{
    public partial class NewsDetailPage : ContentPage
    {
        private double _currentScale;
        private double _imageHeight;

        private double _startScale;
        private double _xOffset;
        private double _yOffset;

        public NewsDetailPage(FeedRssItem news)
        {
            InitializeComponent();

            if (Device.RuntimePlatform == Device.Android)
            {
                NavigationPage.SetHasNavigationBar(this, false);
            }

            var viewModel = BindingContext as NewsDetailViewModel;
            if (viewModel != null) viewModel.Article = news;


            ScrollCustom.Scrolled += (sender, e) => Parallax();
            Parallax();
        }


        private void Parallax()
        {
            if (_imageHeight <= 0)
                _imageHeight = HeroImage.Height;

            var y = ScrollCustom.ScrollY * .4;
            if (y >= 0)
            {
                //Move the Image's Y coordinate a fraction of the ScrollView's Y position
                HeroImage.Scale = 1;
                HeroImage.TranslationY = y;
            }
            else
            {
                //Calculate a scale that equalizes the height vs scroll
                var newHeight = _imageHeight + ScrollCustom.ScrollY * -1;
                HeroImage.Scale = newHeight / _imageHeight;
                HeroImage.TranslationY = ScrollCustom.ScrollY / 2;
            }
        }

        private void OnPinchUpdated(object sender, PinchGestureUpdatedEventArgs e)
        {
            if (e.Status == GestureStatus.Started)
            {
                // Store the current scale factor applied to the wrapped user interface element,
                // and zero the components for the center point of the translate transform.
                _startScale = Content.Scale;
                Content.AnchorX = 0;
                Content.AnchorY = 0;
            }
            if (e.Status == GestureStatus.Running)
            {
                // Calculate the scale factor to be applied.
                _currentScale += (e.Scale - 1) * _startScale;
                _currentScale = Math.Max(1, _currentScale);

                // The ScaleOrigin is in relative coordinates to the wrapped user interface element,
                // so get the X pixel coordinate.
                var renderedX = Content.X + _xOffset;
                var deltaX = renderedX / Width;
                var deltaWidth = Width / (Content.Width * _startScale);
                var originX = (e.ScaleOrigin.X - deltaX) * deltaWidth;

                // The ScaleOrigin is in relative coordinates to the wrapped user interface element,
                // so get the Y pixel coordinate.
                var renderedY = Content.Y + _yOffset;
                var deltaY = renderedY / Height;
                var deltaHeight = Height / (Content.Height * _startScale);
                var originY = (e.ScaleOrigin.Y - deltaY) * deltaHeight;

                // Calculate the transformed element pixel coordinates.
                var targetX = _xOffset - originX * Content.Width * (_currentScale - _startScale);
                var targetY = _yOffset - originY * Content.Height * (_currentScale - _startScale);

                // Apply translation based on the change in origin.
                //Content.TranslationX = targetX.Clamp(-Content.Width * (_currentScale - 1), 0);
                //Content.TranslationY = targetY.Clamp(-Content.Height * (_currentScale - 1), 0);

                // Apply scale factor.
                Content.Scale = _currentScale;
            }
            if (e.Status == GestureStatus.Completed)
            {
                // Store the translation delta's of the wrapped user interface element.
                _xOffset = Content.TranslationX;
                _yOffset = Content.TranslationY;
            }
        }
    }
}
