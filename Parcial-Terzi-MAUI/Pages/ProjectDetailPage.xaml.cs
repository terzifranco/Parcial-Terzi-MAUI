using Parcial_Terzi_MAUI.Models;

namespace Parcial_Terzi_MAUI.Pages
{
    public partial class ProjectDetailPage : ContentPage
    {
        public ProjectDetailPage(ProjectDetailPageModel model)
        {
            InitializeComponent();

            BindingContext = model;
        }
    }
}
