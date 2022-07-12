using AccessDB.Interfaces;
using AccessDB.models;
using System.Data;
using System.Data.SqlClient;

namespace AccessDB.Repositories
{
    internal class ProductRepository : IProduct
    {
        //private readonly string stringConnection = "Data source=DESKTOP-H81L0KE\\SQLEXPRESS; " +
          //  "initial catalog=Catalog; integrated secure=true";

        private readonly string stringConnection = "Data source=DESKTOP-H81L0KE\\SQLEXPRESS; initial catalog=Catalog; integrated security=true;";
        public void Create(Product product)
        {
            using (SqlConnection con = new(stringConnection))
            {
                string query = "INSERT INTO Producs (IdProduct, Name, Description, Price) VALUES (@IdProduct, @Name, @Description, @Price)";
                using (SqlCommand sql = new SqlCommand(query, con))
                {
                    sql.Parameters.AddWithValue("@IdProduct", product.IdProduct);
                    sql.Parameters.AddWithValue("@Name", product.Name);
                    sql.Parameters.AddWithValue("@Description", product.Description);
                    sql.Parameters.AddWithValue("@Price", product.Price);

                    con.Open();
                    sql.ExecuteNonQuery();
                }
                
            }
        }

        public void Delete(string idProduct)
        {
            using (SqlConnection con = new(stringConnection))
            {
                string query = "DELETE FROM Producs WHERE IdProduct=@IdProduct";

                using (SqlCommand sql = new(query, con))
                {
                    sql.Parameters.AddWithValue("@idProduct", idProduct);

                    con.Open();

                   int ret =  sql.ExecuteNonQuery();

                    Console.WriteLine($"Produto Id: {idProduct} excluído com sucesso."); 
                }

            }
        }

        public List<Product> ReadAll()
        {
            List<Product> listProducts = new();

            using (SqlConnection con = new SqlConnection(stringConnection))
            {
                string querySelecAll = "SELECT * FROM Producs";
                con.Open();
                SqlDataReader rdr;

                using (SqlCommand cmd = new(querySelecAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        Product product = new()
                        {
                           

                            Name = rdr[1].ToString(),

                            Description = rdr[2].ToString(),

                            Price = Convert.ToDecimal(rdr[3])
                        };

                        listProducts.Add(product);
                    }
                }
                               
            }

            return listProducts;
        }

        public Product FindProduct(string idProduct)
        {
            Product product = new();
            using (SqlConnection con = new(stringConnection))
            {
                string query = $"SELECT * FROM Producs WHERE IdProduct=@IdProduct";
                using (SqlCommand sql = new(query, con))
                {
                    sql.Parameters.AddWithValue("@IdProduct", idProduct);
                    con.Open();
                    SqlDataReader obj = sql.ExecuteReader();
                    if (obj.HasRows)
                    {
                        while (obj.Read())
                        {
                            product.Name = obj.GetString("Name");
                            product.Description = obj.GetString("Description");
                            product.Price = obj.GetDecimal("Price");
                        }

                    }
                    else
                    {
                        product = null;
                    }
                                        
                }
            }

            return product;
        
        }

        public void Update(Product product, string Id)
        {
            using (SqlConnection con = new(stringConnection))
            {
             string query = "UPDATE Producs SET Name=@Name, Description=@Description, Price=@Price WHERE IdProduct=@IdProduct;";
                using (SqlCommand sql = new(query, con))
                {
                    sql.Parameters.AddWithValue("@IdProduct", Id);
                    sql.Parameters.AddWithValue("@Name", product.Name);
                    sql.Parameters.AddWithValue("@Description", product.Description);
                    sql.Parameters.AddWithValue("@Price", product.Price);

                    con.Open();
                    sql.ExecuteNonQuery();
                }
            }
        }
    }
}
