namespace Livraria.Web.Models.Livros.Responses
{
    public class LivroResponse
    {
        public int id { get; set; }
        public string titulo { get; set; }
        public string editora { get; set; }
        public int anoPublicacao { get; set; }
        public string autor { get; set; }
        public string[] exemplares { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }

        public LivroResponse(bool status, string message)
        {
            this.Status = status;
            this.Message = message;
        }
    }
}
