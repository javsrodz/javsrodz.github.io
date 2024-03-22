namespace Escuela.Models
{
    public class mUsuario
    {
        public string user { get; set; }

        public string password { get; set; }
    }


    public class mNuevoUsuario
    {
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string correo { get; set; }
        public string contrasena { get; set; }
        public string puesto { get; set; }
        public int rol { get; set; }
    }
}
