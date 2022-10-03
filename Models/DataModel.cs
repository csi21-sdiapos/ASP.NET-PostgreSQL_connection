namespace pruebaConexionPostgreSQL.Models
{
    public class DataModel
    {
        public List<DataModel> listModel = new List<DataModel>();

        public string name { get; set; }
        public int price { get; set; }
        public string date { get; set; }
        public string email { get; set; }
        public string department { get; set; }

    }
}
