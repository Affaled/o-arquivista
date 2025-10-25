namespace OArquivista.API.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Autor { get; set; }
        public string? UrlCapa { get; set; }
        public string? Notas { get; set; }
        public int? Rating { get; set; }
    }
}