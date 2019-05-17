namespace Livraria.ApplicationCore.Models.Livros.DTOs.Requests
{
    public class LivroRequest
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string CurrentTitle { get; set; }
        public string Editora { get; set; }
        public int AnoPublicacao { get; set; }
        public string Autor { get; set; }
        public int QtdeExemplares { get; set; }
    }
}
