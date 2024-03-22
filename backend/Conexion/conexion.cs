namespace Escuela.Conexion
{
    public class conexion
    {
        private string conexionstring = string.Empty;

        public conexion()
        {
            var constructor = new ConfigurationBuilder().SetBasePath
                (Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            conexionstring = constructor.GetSection("ConnectionStrings:ConexionSQL").Value;
        }


        public string cadenaSQL()
        {
            return conexionstring;
        }
    }
}
