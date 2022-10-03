using Microsoft.AspNetCore.Mvc;
using pruebaConexionPostgreSQL.Models;
using System.Diagnostics;

namespace pruebaConexionPostgreSQL.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        public IConfiguration server;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeController(IConfiguration server)
        {
            this.server = server;
        }

        public IActionResult Index()
        {
            DataModel list = new DataModel(); // creamos una lista del tipo de la clase modelo de nuestros datos

            string sql = "SELECT name, email, department FROM users"; // query de los campos que nos interesa obtener para mostrarlos
            Conexion cn = new Conexion(sql, this.server); // creamos un objeto del tipo de nuestra clase Conexion

            if (cn.data.HasRows) // si la BBDD contiene filas (datos)
            {
                while (cn.data.Read()) // mientras haya datos por leer...
                {
                    list.listModel.Add // ...añadimos a la lista...
                        (
                            new DataModel // un objeto por cada fila de datos que haya en la BBDD
                            {
                                name = cn.data[0].ToString(),
                                email = cn.data[1].ToString(),
                                department = cn.data[2].ToString(),
                            }
                        );
                }
            }

            cn.Close(); // siempre se debe cerrar la conexión al terminar de usar la BBDD
            
            /*
            list.listModel.Add
                (
                    new DataModel 
                    { 
                        name = "potato",
                        price = 100
                    }
                );

            list.listModel.Add
                (
                    new DataModel
                    {
                        name = "apple",
                        price = 50
                    }
                );

            list.listModel.Add
                (
                    new DataModel
                    {
                        name = "banana",
                        price = 10
                    }
                );
            */

            List<DataModel> model = list.listModel.ToList();

            return View(model);
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}