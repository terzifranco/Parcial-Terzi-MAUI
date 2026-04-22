using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.Json;
using System.Windows.Input;

namespace Parcial_Terzi_MAUI.PageModels
{


public class MainViewModel
{
    public ObservableCollection<Post> Posts { get; set; } = new();

    //Mensaje de estado para el usuario 
    public string StatusMessage { get; set; }

    //Comando que ejecuta la carga de usuarios 
    public ICommand LoadDataCommand { get; }

    //Construtor
    public MainViewModel()
    {
        LoadDataCommand = new Command(async () => await LoadData());
    }

    //Metodo que consume la API 
    public async Task LoadData()
    {
        try
        {
            //Se indica que esta cargando
            StatusMessage = "Cargando...";

            //Llamamos a la API
            var client = new HttpClient();
            var response = await client.GetAsync("https://jsonplaceholder.typicode.com/users");

                //Validacaion de errores
                if (!response.IsSuccessStatusCode)
            {
                StatusMessage = $"Error HTTP: {response.StatusCode}";
                return;
            }

            var json = await response.Content.ReadAsStringAsync();
            //Convertimos JSON a objetos 
            var data = JsonSerializer.Deserialize<List<Post>>(json);

            //Limpiamos la lista 
            Posts.Clear();
            //Cargamos los datos 
            foreach (var item in data)
                Posts.Add(item);
                StatusMessage = "Datos cargados";
        }
        catch (HttpRequestException)
        {
            //Error de conexion
            StatusMessage = "Sin conexión a internet";
        }
        catch (Exception)
        {
            //Error general 
            StatusMessage = "Error inesperado";
        }
    }
}

}