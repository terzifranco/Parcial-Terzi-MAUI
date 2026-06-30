using Parcial_Terzi_MAUI.Models;
using Parcial_Terzi_MAUI.PageModels;

namespace Parcial_Terzi_MAUI.Pages
{
    [QueryProperty(nameof(User), "User")]
    public partial class DetailPage : ContentPage
    {
        private readonly DetailViewModel viewModel;

        public DetailPage()
        {
            InitializeComponent();

            viewModel = new DetailViewModel();
            BindingContext = viewModel;
        }

        public Post User
        {
            set
            {
                viewModel.User = value;
            }
        }
    }
}