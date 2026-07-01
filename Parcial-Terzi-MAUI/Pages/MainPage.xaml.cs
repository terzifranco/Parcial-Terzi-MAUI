using Parcial_Terzi_MAUI.Models;
using Parcial_Terzi_MAUI.PageModels;
using Microsoft.Maui.Devices;
using System.Collections.ObjectModel;

namespace Parcial_Terzi_MAUI.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

        // Selección de item → navegación a detalle
        private async void OnItemSelected(object sender, SelectionChangedEventArgs e)
        {
            var item = e.CurrentSelection.FirstOrDefault() as Post;

            if (item == null)
                return;

            await Shell.Current.GoToAsync(nameof(DetailPage), true, new Dictionary<string, object>
            {
                { "User", item }
            });
        }

        // SENSOR: Vibración
        private void OnVibrateClicked(object sender, EventArgs e)
        {
            try
            {
                Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(300));
            }
            catch
            {
                // El dispositivo puede no soportarlo
            }
        }
    }
}