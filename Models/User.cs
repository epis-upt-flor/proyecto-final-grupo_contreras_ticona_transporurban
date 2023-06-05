namespace Project.Models
{
    public class User
    {
        public int Id { get; set; }
        public string TipoUsuario { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public byte? Estado { get; set; }
    }
}