using Npgsql;

namespace pruebaConexionPostgreSQL
{
    public class Conexion
    {

        // ATRIBUTOS
        public Server server;
        private string sql;
        public NpgsqlDataReader data;
        

        // CONSTRUCTORES
        public Conexion(string sql, IConfiguration server)
        {
            this.sql = sql;
            this.server = new Server(server);
            NpgsqlCommand query = new NpgsqlCommand(this.sql, this.server.conn);
            data = query.ExecuteReader();
        }


        // MÉTODOS
        public void Close()
        {
            this.server.conn.Close();
        }
    }


    // con esta "mini-clase", creamos efectivamente una conexión llamando a los parámetros de acceso a nuestra BBDD del archivo appsettings.json
    public class Server
    {

        // ATRIBUTOS
        public NpgsqlConnection conn;


        // CONSTRUCTORES
        public Server(IConfiguration server)
        {
            string connectionString = String.Format
                (
                    server.GetSection("ConnectionStrings").GetSection("MyServer").Value // con esto accedemos al appsettings.json --> "ConnectionStrings" --> "MyServer"
                );

            conn = new NpgsqlConnection(connectionString);
            conn.Open();
        }
    }
}
