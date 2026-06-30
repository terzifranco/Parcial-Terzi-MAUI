using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Windows.Input;
using Parcial_Terzi_MAUI.Models;

namespace Parcial_Terzi_MAUI.PageModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        // Lista de usuarios que se muestra en la pantalla
        public ObservableCollection<Post> Posts { get; set; } = new();

        // Campo privado
        private string statusMessage;

        // Mensaje de estado que se actualiza automáticamente en la interfaz
        public string StatusMessage
        {
            get => statusMessage;
            set
            {
                if (statusMessage != value)
                {
                    statusMessage = value;
                    OnPropertyChanged();
                }
            }
        }

        // Comando que ejecuta la carga de usuarios
        public ICommand LoadDataCommand { get; }

        // Constructor
        public MainViewModel()
        {
            LoadDataCommand = new Command(async () => await LoadData());
        }

        // Método que consume la API
        public async Task LoadData()
        {
            try
            {
                // Se indica que está cargando
                StatusMessage = "Cargando...";

                // Llamamos a la API
                var client = new HttpClient();
                var response = await client.GetAsync("https://jsonplaceholder.typicode.com/users");

                // Validación de errores HTTP
                if (!response.IsSuccessStatusCode)
                {
                    StatusMessage = $"Error HTTP: {response.StatusCode}";
                    return;
                }

                var json = await response.Content.ReadAsStringAsync();

                // Convertimos el JSON a objetos
                var data = JsonSerializer.Deserialize<List<Post>>(json);

                // Limpiamos la lista
                Posts.Clear();

                // Cargamos los datos obtenidos
                if (data != null)
                {
                    foreach (var item in data)
                    {
                        Posts.Add(item);
                    }
                }

                StatusMessage = "Datos cargados";
            }
            catch (HttpRequestException)
            {
                // Error de conexión
                StatusMessage = "Sin conexión a internet";
            }
            catch (Exception)
            {
                // Error general
                StatusMessage = "Error inesperado";
            }
        }

        // Evento utilizado por el Data Binding
        public event PropertyChangedEventHandler? PropertyChanged;

        // Método que notifica a la interfaz cuando cambia una propiedad
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}