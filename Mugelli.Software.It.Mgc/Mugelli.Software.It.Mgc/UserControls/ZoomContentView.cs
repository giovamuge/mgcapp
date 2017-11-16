using System;
using Xamarin.Forms;
using Mugelli.Software.It.Mgc.Extensions;

namespace Mugelli.Software.It.Mgc.UserControls
{
    public class ZoomContentView : ContentView
    {
        private double _x, _y, _currentScale = 1;

        public EventHandler PanCompleted;

        public ZoomContentView()
        {
            //GestureRecognizers.Add(GetPan());
            GestureRecognizers.Add(GetPinch());
        }

        private PanGestureRecognizer GetPan()
        {
            var pan = new PanGestureRecognizer();
            pan.PanUpdated += (s, e) =>
            {
                switch (e.StatusType)
                {
                    //case GestureStatus.Started:
                    //    Content.TranslationX = _x;
                    //    Content.TranslationY = _y;
                    //    break;
                    //case GestureStatus.Running:
                    //    //needs to not let you pan outside the bounds of the container.
                    //    Content.TranslationX = _x + e.TotalX;
                    //    Content.TranslationY = _y + e.TotalY;
                    //    break;
                    //case GestureStatus.Completed:
                    //    _x = Content.TranslationX;
                    //    _y = Content.TranslationY;
                    //    PanCompleted?.Invoke(s, EventArgs.Empty);
                    //    break;
                    case GestureStatus.Running:
                        // Translate and ensure we don't pan beyond the wrapped user interface element bounds.
                        Content.TranslationX =
                            Math.Max(Math.Min(0, _x + e.TotalX), -Math.Abs(Content.Width - Application.Current.MainPage.Width));
                        Content.TranslationY =
                                   Math.Max(Math.Min(0, _y + e.TotalY), -Math.Abs(Content.Height - Application.Current.MainPage.Height));
                        break;

                    case GestureStatus.Completed:
                        // Store the translation applied during the pan
                        _x = Content.TranslationX;
                        _y = Content.TranslationY;
                        break;
                
                }
            };
            return pan;
        }

        private PinchGestureRecognizer GetPinch()
        {
            var pinch = new PinchGestureRecognizer();

            double xOffset = 0, yOffset = 0, startScale = 1;

            pinch.PinchUpdated += (s, e) =>
            {
                switch (e.Status)
                {
                    case GestureStatus.Started:
                    {
                        startScale = Content.Scale;
                        Content.AnchorX = e.ScaleOrigin.X;
                        Content.AnchorY = e.ScaleOrigin.Y;
                        GestureRecognizers.Add(GetPan());
                    }
                        break;
                    case GestureStatus.Running:
                    {
                        _currentScale += (e.Scale - 1) * startScale;
                        _currentScale = Math.Max(1, _currentScale);

                        var renderedX = Content.X + xOffset;
                        var deltaX = renderedX / Width;
                        var deltaWidth = Width / (Content.Width * startScale);
                        var originX = (e.ScaleOrigin.X - deltaX) * deltaWidth;

                        var renderedY = Content.Y + yOffset;
                        var deltaY = renderedY / Height;
                        var deltaHeight = Height / (Content.Height * startScale);
                        var originY = (e.ScaleOrigin.Y - deltaY) * deltaHeight;

                        var targetX = xOffset - originX * Content.Width * (_currentScale - startScale);
                        var targetY = yOffset - originY * Content.Height * (_currentScale - startScale);

                            Content.TranslationX = targetX.Clamp(-Content.Width * (_currentScale - 1), 0);
                            Content.TranslationY = targetY.Clamp(-Content.Height * (_currentScale - 1), 0);

                        Content.Scale = _currentScale;
                    }
                        break;
                    case GestureStatus.Completed:
                    {
                        xOffset = Content.TranslationX;
                        yOffset = Content.TranslationY;
                    }
                        break;
                }
            };

            return pinch;
        }
    }
}