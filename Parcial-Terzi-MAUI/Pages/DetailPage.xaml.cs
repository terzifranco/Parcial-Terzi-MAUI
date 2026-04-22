using Parcial_Terzi_MAUI.Models;

namespace Parcial_Terzi_MAUI.Pages
{
    //Recibe datos desde la navegacion
    [QueryProperty(nameof(User), "User")]
    public partial class DetailPage : ContentPage
    {
        private Post user;

        //Propiedad que recibe el usuario seleccionado
        public Post User
        {
            get => user;
            set
            {
                user = value;

                if (user != null)
                {
                    //Mostramos los datos en pantalla
                    NameLabel.Text = user.name;
                    EmailLabel.Text = user.email;
                }
            }
        }

        public DetailPage()
        {
            InitializeComponent();
        }
    }
}