using System;
using System.Net.Http;
using System.Threading.Tasks;
using Avalonia.Collections;
using InformesGraficos.Models;
using Newtonsoft.Json;

namespace InformesGraficos.Services;

public class N8NService
{
    private HttpClient client;

    public N8NService()
    {
        client = new HttpClient();
        client.BaseAddress = new Uri("http://localhost:5678/webhook/");
    }
    
    public async Task<AvaloniaList<string>?> ObtenerDispositivos()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "dispositivos");
        var response = await client.SendAsync(request);
        var listaString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<AvaloniaList<string>>(listaString);
    }
    
    public async Task<AvaloniaList<string>?> ObtenerUsuarios()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "usuarios-streaming");
        var response = await client.SendAsync(request);
        var listaString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<AvaloniaList<string>>(listaString);
    }
    
    public async Task<AvaloniaList<string>?> ObtenerTitulos()
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "titulos");
        var response = await client.SendAsync(request);
        var listaString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<AvaloniaList<string>>(listaString);
    }
    
    public async Task<AvaloniaList<Categorias>?> ObtenerCategoriasFiltradas(string filtro)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, "45b37d18-3c3f-463c-a4c4-3a46d6af325b/categorias/"+filtro);
        var response = await client.SendAsync(request);
        var listaString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<AvaloniaList<Categorias>>(listaString);
    } 
}