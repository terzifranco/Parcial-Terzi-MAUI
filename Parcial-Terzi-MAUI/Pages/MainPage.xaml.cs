using Parcial_Terzi_MAUI.Models;
using Parcial_Terzi_MAUI.PageModels;

namespace Parcial_Terzi_MAUI.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            //Asignamos el ViewModel a la vista
            BindingContext = new MainViewModel();
        }

        //Metodo que se ejecuta al seleccionar al usuario 
        private async void OnItemSelected(object sender, SelectionChangedEventArgs e)
        {
            //Obtenemos el elemento 
            var item = e.CurrentSelection.FirstOrDefault() as Post;

            if (item == null)
                return;

            //Navegamos a la pantalla de detalle enviando el usuario
            await Shell.Current.GoToAsync(nameof(DetailPage), true, new Dictionary<string, object>
{
    { "User", item }
});
        }
    }
}