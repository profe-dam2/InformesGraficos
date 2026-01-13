using System.Threading.Tasks;
using Avalonia.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InformesGraficos.Services;

namespace InformesGraficos.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    private N8NService n8nService=new();
    
    [ObservableProperty] private string url;
    [ObservableProperty] private AvaloniaList<string> listaDispositivos=new();

    [RelayCommand]
    public async Task CargarDispositivos()
    {
        ListaDispositivos = await n8nService.ObtenerDispositivos();
    }

    [RelayCommand]
    public async Task MostarPDFDispositivos(string dispositivo)
    {
        Url = "http://localhost:10000/reports/getSeries1/" + dispositivo;
    }
    
}