using System;
using System.Linq;
using SciChart.iOS.Charting;
using UIKit;

namespace UnsortedData.iOS
{
    public partial class ViewController : UIViewController
    {
        int count = 1;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.
            Button.AccessibilityIdentifier = "myButton";
            Button.TouchUpInside += delegate
            {
                var title = string.Format("{0} clicks!", count++);
                Button.SetTitle(title, UIControlState.Normal);
            };

            var seed = new DateTime(2015, 1, 1);
            var xVals = Enumerable
                .Range(0, 10000)
                .Select(i => seed + TimeSpan.FromHours(i + 0.55 + 0.45 * Math.Sin(i)))
                .ToList();
            var yVals = Enumerable
                .Range(0, 10000)
                .Select(i => (double)i)
                .Select(x => Math.PI * Math.Cos(0.1 * x) * Math.Sin(x))
                .ToList();

            for (int i = 0; i < xVals.Count - 1; ++i)
            {
                System.Diagnostics.Debug.Assert(xVals[i + 1] > xVals[i]);
            }

            var ds = new XyDataSeries<DateTime, double> { SeriesName = "TEST" };
            ds.Append(xVals, yVals);

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.		
        }
    }
}