using CommunityToolkit.Mvvm.Input;
using Parcial_Terzi_MAUI.Models;

namespace Parcial_Terzi_MAUI.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}