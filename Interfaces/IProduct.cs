using AccessDB.models;


namespace AccessDB.Interfaces
{
    internal interface IProduct
    {
        List<Product> ReadAll();
        void Create(Product product);
        void Update(Product product, string Id);

        void Delete(string idProduct);
    }
}
