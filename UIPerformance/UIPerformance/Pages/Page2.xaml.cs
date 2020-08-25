using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UIPerformance.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        public string Time { get; set; }

        Stopwatch stopwatch;

        public Page2()
        {
            InitializeComponent();

            stopwatch = new Stopwatch();
            stopwatch.Start();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            for (int i = 1; i <= 10; i++)
            {
                Label label = new Label();
                label.Text = "Label " + i;

                Device.BeginInvokeOnMainThread(() =>
                {
                    MainStacklayout.Children.Add(label);
                });
            }

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