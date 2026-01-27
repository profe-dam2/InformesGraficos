using System;
using System.Threading.Tasks;
using Avalonia.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InformesGraficos.Models;
using InformesGraficos.Services;

namespace InformesGraficos.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private N8NService n8nService=new();
    [ObservableProperty] private DateTimeOffset fecha1= new(DateTime.Now);
    [ObservableProperty] private DateTimeOffset fecha2= new(DateTime.Now);
    [ObservableProperty] private string url;
    [ObservableProperty] private AvaloniaList<string>? listaDispositivos=new();
    [ObservableProperty] private AvaloniaList<string>? listaUsuarios=new();
    [ObservableProperty] private AvaloniaList<string>? listaTitulos=new();
    [ObservableProperty] private AvaloniaList<Categorias>? listaCategorias = new();
    [ObservableProperty] private string filtro = string.Empty;
    
    [RelayCommand]
    public async Task ObtenerCategoriasFiltradasAsync()
    {
        if (!String.IsNullOrEmpty(Filtro))
        {
            ListaCategorias = await n8nService.ObtenerCategoriasFiltradas(Filtro);
        }
        
    }

    [RelayCommand]
    public async Task MostarPDFCategoriasAsync(Categorias categoria)
    {
        Url = "http://localhost:10000/reports/getCategoria/" + categoria.Id;
    }
    
    [RelayCommand]
    public async Task CargarDesplegablesAsync()
    {
        ListaDispositivos = await n8nService.ObtenerDispositivos();
        ListaUsuarios = await n8nService.ObtenerUsuarios();
        ListaTitulos = await n8nService.ObtenerTitulos();
    }

    [RelayCommand]
    public async Task MostarPDFDispositivosAsync(string dispositivo)
    {
        Url = "http://localhost:10000/reports/getSeries1/" + dispositivo;
    }
    
    [RelayCommand]
    public async Task MostarPDFDispositivoUsuarioAsync(string usuario)
    {
        Url = "http://localhost:10000/reports/getSeries2/" + usuario;
    }
    
    [RelayCommand]
    public async Task MostarPDFPorTituloAsync(string titulo)
    {
        Url = "http://localhost:10000/reports/getSeries3/" + 
              Fecha1.ToString("yyyy-MM-dd") + "/" + 
              Fecha2.ToString("yyyy-MM-dd") + "/" + 
              titulo;
        Console.WriteLine(Url);
        
    }
    

    
}