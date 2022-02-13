using Android.Views;
using Android.Widget;
using System;
using Umami;
using Umami.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly: ExportRenderer(typeof(ExImage), typeof(ExImageRenderer))]
namespace Umami.Droid
{
    internal class ExImageRenderer : ImageRenderer
    {
        private readonly MyGestureListener _listener;
        private readonly GestureDetector _detector;

        [Obsolete]
        public ExImageRenderer()
        {
            _listener = new MyGestureListener();
            _detector = new GestureDetector(_listener);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);

            _listener.ExImage = Element as ExImage;

            GenericMotion += (s, a) => _detector.OnTouchEvent(a.Event);
            Touch += (s, a) => _detector.OnTouchEvent(a.Event);

        }
    }
}