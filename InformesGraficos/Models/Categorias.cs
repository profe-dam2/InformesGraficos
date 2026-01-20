using Newtonsoft.Json;

namespace InformesGraficos.Models;

public class Categorias
{
    [JsonProperty("id_categoria", DefaultValueHandling = DefaultValueHandling.Ignore)]
    public int Id { get; set; }
    
    [JsonProperty("nombre")]
    public string Nombre { get; set; }

    public override string ToString()
    {
        return Nombre;
    }
}