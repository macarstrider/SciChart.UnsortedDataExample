using Android.App;
using Android.Widget;
using Android.OS;
using System;
using System.Linq;

namespace UnsortedData.Droid
{
    [Activity(Label = "UnsortedData", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.myButton);

            button.Click += delegate { button.Text = $"{count++} clicks!"; };


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

            var ds = new SciChart.Charting.Model.DataSeries.XyDataSeries<DateTime, double> { SeriesName = "TEST" };
            ds.Append(xVals, yVals);
        }
    }
}

