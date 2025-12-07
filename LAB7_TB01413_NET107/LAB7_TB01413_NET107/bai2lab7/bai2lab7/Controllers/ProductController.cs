using Lab7Bai2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;  


namespace Lab7Bai2.Controllers
{
    public class ProductController : Controller
    {
        private readonly string _connStr;

        public ProductController(IConfiguration configuration)
        {
            _connStr = configuration.GetConnectionString("MyDb");
        }

        public IActionResult Index()
        {
            var list = new List<Product>();

            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                string sql = "SELECT * FROM Products";
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();

                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    list.Add(new Product
                    {
                        Id = (int)rd["Id"],
                        Name = rd["Name"].ToString(),
                        Price = (decimal)rd["Price"],
                        ImageUrl = rd["ImageUrl"].ToString(),
                        Description = rd["Description"].ToString()
                    });
                }
            }

            return View(list);
        }

        public IActionResult Details(int id)
        {
            Product? p = null;

            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                string sql = "SELECT * FROM Products WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();

                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    p = new Product
                    {
                        Id = (int)rd["Id"],
                        Name = rd["Name"].ToString(),
                        Price = (decimal)rd["Price"],
                        ImageUrl = rd["ImageUrl"].ToString(),
                        Description = rd["Description"].ToString()
                    };
                }
            }

            if (p == null) return NotFound();

            return View(p);
        }
    }
}
