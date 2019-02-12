using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TV_Event
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped += labelClicked;
            ClickableLabel.GestureRecognizers.Add(tapGesture);
        }

        private void labelClicked(object sender, EventArgs args)
        {
            var label = (Label)sender;

            Random generator = new Random();
            int r = generator.Next(0, 255);
            int g = generator.Next(0, 255);
            int b = generator.Next(0, 255);

            label.TextColor = Color.FromRgb(r, g, b);
        }
        

        
        private void ButtonTextClicked(object sender, EventArgs args)
        {
            var button = (Button)sender;

            Random generator = new Random();
            int r = generator.Next(0, 255);
            int g = generator.Next(0, 255);
            int b = generator.Next(0, 255);

            button.TextColor = Color.FromRgb(r, g, b);
            ClickableLabel.TextColor = Color.FromRgb(r, g, b);
        }
        

        /*
        private void buttonClicked(object sender, EventArgs args)
        {
            Random generator = new Random();
            int r = generator.Next(0, 255);
            int g = generator.Next(0, 255);
            int b = generator.Next(0, 255);

            label.TextColor = Color.FromRgb(r, g, b);
        }
        */
    }

}