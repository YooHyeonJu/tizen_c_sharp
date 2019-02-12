using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TV_animation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void ImageRotate()
        {
            await image.RotateTo(360, 2000);
            await image.ScaleTo(2, 1000);
        }

        async void ImageAnimation()
        {
            await Task.WhenAny<bool>(image.RotateTo(360, 1000), image.ScaleTo(2, 1000));
            await Task.WhenAny<bool>(image.RotateTo(0, 1000), image.ScaleTo(1, 1000));
        }

        private void ButtonClicked(object sender,EventArgs args)
        {
            ImageAnimation();
            //ImageRotate();
            /*
            image.RotateTo(360, 2000);
            image.Rotation = 0;
            */
        }
    }
}