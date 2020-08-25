using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UIPerformance.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public string Time { get; set; }

        Stopwatch stopwatch;

        public Page1()
        {
            InitializeComponent();

            stopwatch = new Stopwatch();
            stopwatch.Start();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            stopwatch.Stop();
            Time = string.Format("Render 10 labels in {0} ms", stopwatch.ElapsedMilliseconds);

            var data = new
            {
                Time
            };
            BindingContext = data;
        }
    }
}