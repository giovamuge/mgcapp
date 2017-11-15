using System;
using System.Collections.Generic;
using Mugelli.Software.It.Mgc.Extensions;
using Mugelli.Software.It.Mgc.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mugelli.Software.It.Mgc.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GalleryImagePage : ContentPage
    {
        private double _currentScale = 1;
        private int originalHeight;
        private int originalWidth;
        private double startScale;
        private double xOffset;
        private double yOffset;

        public GalleryImagePage(List<string> param)
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            var viewModel = (ImageGalleryViewModel) BindingContext;
            viewModel.Images = param;
        }

        public int ScreenWidth { get; private set; }
        public int ScreenHeight { get; private set; }

        private void OnPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            var s = (ContentView) sender;

            // do not allow pan if the image is in its intial size
            if (_currentScale == 1)
                return;

            switch (e.StatusType)
            {
                case GestureStatus.Running:
                    double xTrans = xOffset + e.TotalX, yTrans = yOffset + e.TotalY;
                    // do not allow verical scorlling unless the image size is bigger than the screen
                    s.Content.TranslateTo(xTrans, yTrans, 0, Easing.Linear);
                    break;

                case GestureStatus.Completed:
                    // Store the translation applied during the pan
                    xOffset = s.Content.TranslationX;
                    yOffset = s.Content.TranslationY;

                    // center the image if the width of the image is smaller than the screen width
                    if (originalWidth * _currentScale < ScreenWidth && ScreenWidth > ScreenHeight)
                        xOffset = (ScreenWidth - originalWidth * _currentScale) / 2 - s.Content.X;
                    else
                        xOffset = Math.Max(Math.Min(0, xOffset),
                            -Math.Abs(originalWidth * _currentScale - ScreenWidth));

                    // center the image if the height of the image is smaller than the screen height
                    if (originalHeight * _currentScale < ScreenHeight && ScreenHeight > ScreenWidth)
                        yOffset = (ScreenHeight - originalHeight * _currentScale) / 2 - s.Content.Y;
                    else
                        //yOffset = System.Math.Max(System.Math.Min((originalHeight - (ScreenHeight)) / 2, yOffset), -System.Math.Abs((originalHeight * currentScale - ScreenHeight - (originalHeight - ScreenHeight) / 2)) + (NavBar.Height + App.StatusBarHeight));
                        yOffset = Math.Max(Math.Min((originalHeight - ScreenHeight) / 2, yOffset),
                            -Math.Abs(originalHeight * _currentScale - ScreenHeight -
                                      (originalHeight - ScreenHeight) / 2));

                    // bounce the image back to inside the bounds
                    s.Content.TranslateTo(xOffset, yOffset, 500, Easing.BounceOut);
                    break;
            }
        }

        private void OnPinchUpdated(object sender, PinchGestureUpdatedEventArgs e)
        {
            var s = (ContentView) sender;

            if (e.Status == GestureStatus.Started)
            {
                // Store the current scale factor applied to the wrapped user interface element,
                // and zero the components for the center point of the translate transform.
                startScale = s.Content.Scale;

                s.Content.AnchorX = 0;
                s.Content.AnchorY = 0;
            }
            if (e.Status == GestureStatus.Running)
            {
                // Calculate the scale factor to be applied.
                _currentScale += (e.Scale - 1) * startScale;
                _currentScale = Math.Max(1, _currentScale);
                _currentScale = Math.Min(_currentScale, 5);

                //scaleLabel.Text = "Scale: " + currentScale.ToString ();

                // The ScaleOrigin is in relative coordinates to the wrapped user interface element,
                // so get the X pixel coordinate.
                var renderedX = s.Content.X + xOffset;
                var deltaX = renderedX / App.ScreenWidth;
                var deltaWidth = App.ScreenWidth / (s.Content.Width * startScale);
                var originX = (e.ScaleOrigin.X - deltaX) * deltaWidth;

                // The ScaleOrigin is in relative coordinates to the wrapped user interface element,
                // so get the Y pixel coordinate.
                var renderedY = s.Content.Y + yOffset;

                var deltaY = renderedY / App.ScreenHeight;
                var deltaHeight = App.ScreenHeight / (s.Content.Height * startScale);
                var originY = (e.ScaleOrigin.Y - deltaY) * deltaHeight;

                // Calculate the transformed element pixel coordinates.
                var targetX = xOffset - originX * s.Content.Width * (_currentScale - startScale);
                var targetY = yOffset - originY * s.Content.Height * (_currentScale - startScale);

                // Apply translation based on the change in origin.
                var transX = targetX.Clamp(-s.Content.Width * (_currentScale - 1), 0);
                var transY = targetY.Clamp(-s.Content.Height * (_currentScale - 1), 0);


                s.Content.TranslateTo(transX, transY, 0, Easing.Linear);
                // Apply scale factor.
                s.Content.Scale = _currentScale;
            }
            if (e.Status == GestureStatus.Completed)
            {
                // Store the translation applied during the pan
                xOffset = s.Content.TranslationX;
                yOffset = s.Content.TranslationY;

                // center the image if the width of the image is smaller than the screen width
                if (originalWidth * _currentScale < ScreenWidth && ScreenWidth > ScreenHeight)
                    xOffset = (ScreenWidth - originalWidth * _currentScale) / 2 - s.Content.X;
                else
                    xOffset = Math.Max(Math.Min(0, xOffset), -Math.Abs(originalWidth * _currentScale - ScreenWidth));

                // center the image if the height of the image is smaller than the screen height
                if (originalHeight * _currentScale < ScreenHeight && ScreenHeight > ScreenWidth)
                    yOffset = (ScreenHeight - originalHeight * _currentScale) / 2 - s.Content.Y;
                else
                    yOffset = Math.Max(Math.Min((originalHeight - ScreenHeight) / 2, yOffset),
                        -Math.Abs(originalHeight * _currentScale - ScreenHeight - (originalHeight - ScreenHeight) / 2));

                // bounce the image back to inside the bounds
                s.Content.TranslateTo(xOffset, yOffset, 500, Easing.BounceOut);
            }
        }

        //protected override void OnSizeAllocated(double width, double height)
        //{
        //    base.OnSizeAllocated(width, height); //must be called

        //    if (width != -1 && (ScreenWidth != width || ScreenHeight != height))
        //    {
        //        ResetLayout(width, height);

        //        originalWidth = initialLoad ?
        //            ImageWidth >= 960 ?
        //                App.ScreenWidth > 320
        //                    ? 768
        //                    : 320
        //                : ImageWidth / 3
        //            : imageContainer.Content.Width / imageContainer.Content.Scale;

        //        var normalizedHeight = ImageWidth >= 960 ?
        //            App.ScreenWidth > 320 ? ImageHeight / (ImageWidth / 768)
        //                : ImageHeight / (ImageWidth / 320)
        //            : ImageHeight / 3;

        //        originalHeight = initialLoad ?
        //            normalizedHeight : (imageContainer.Content.Height / imageContainer.Content.Scale);

        //        ScreenWidth = width;
        //        ScreenHeight = height;

        //        xOffset = imageContainer.TranslationX;
        //        yOffset = imageContainer.TranslationY;

        //        _currentScale = imageContainer.Scale;

        //        if (initialLoad)
        //            initialLoad = false;
        //    }
        //}
    }
}