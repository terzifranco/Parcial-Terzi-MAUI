using System.ComponentModel;
using System.Runtime.CompilerServices;
using Parcial_Terzi_MAUI.Models;

namespace Parcial_Terzi_MAUI.PageModels
{
    public class DetailViewModel : INotifyPropertyChanged
    {
        private Post user;

        public Post User
        {
            get => user;
            set
            {
                user = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(Email));
            }
        }

        public string Name => User?.name;

        public string Email => User?.email;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}