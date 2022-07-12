using AccessDB.models;
using AccessDB.Repositories;
using System;

class Menu
{
	public Menu()
	{
	}

	public static void MainMenu()
    {
        Console.WriteLine("\n CRUD com MsSql Server\n");
        Console.WriteLine("\nEscolha uma das opções abaixo:\n");
        Console.WriteLine("1 - Listar produtos");
        Console.WriteLine("2 - Cadastrar produto");
        Console.WriteLine("3 - Editar produto");
        Console.WriteLine("4 - Excluir produto");
        Console.WriteLine("0 - Sair da aplicação\n");
    }

    public static void ListProducts()
    {
        Console.Clear();

        Console.WriteLine("Listando todos os produtos");

        ProductRepository product = new ();

        List<Product> allProducts = product.ReadAll();

        if (allProducts.Count == 0)
        {
            Console.WriteLine("Nenhum produto cadastrado.");
            return;
        }
        
            foreach (Product oneProduct in allProducts)
            {
                Console.WriteLine($"[{oneProduct.IdProduct}] {oneProduct.Name} - " +
                                $"{oneProduct.Description} - R$ {oneProduct.Price}");
            }
       
    }

    public static void DeleteProduct() {

        ProductRepository product = new();

        Console.Clear();

        Console.Write("Digite o Id do produto que deseja excluir: ");

        string id = Console.ReadLine();

        var found = product.FindProduct(id);

        if (found != null)
        {
            product.Delete(id);
            return;

        }

        Console.WriteLine("Produto não encontrado");

    }

    public  static void CreateProduct()
    {
        ProductRepository product = new();

        Console.Clear();

        Console.WriteLine("Cadastrar novo produto");
        
        Console.WriteLine("\nDigite o nome do produto:\n");
        var name = Console.ReadLine();

        Console.WriteLine("\nDigite a descrição do produto:\n");
        var description = Console.ReadLine();

        Console.WriteLine("\nDigite o preço do produto:\n");
        var price = Console.ReadLine();

        Product newProduct = new Product()
        { 
            Name = name,
            Description = description,
            Price = Convert.ToDecimal(price),
        };

        product.Create(newProduct); 
    }

    public static void UpdateMenu()
    {

        ProductRepository product = new ();

        Console.Clear();
        Console.WriteLine("Editar produto");
        Console.WriteLine("\nEntre com o código do produto:\n");
        var uId = Console.ReadLine();

        var obj = product.FindProduct(uId);
              

        if (obj is null)
        {
            Console.WriteLine("Produto não encontrado!");
            return;
        }
              

        var uProduct = new Product();

        
            Console.WriteLine($"Nome atual do produto: {obj.Name}");
            Console.Write("Insira o novo nome ou pressione Enter para manter o atual: ");
            var newName = Console.ReadLine();
            uProduct.Name = newName.Length != 0 ? newName : obj.Name;

            Console.WriteLine($"Descrição atual do produto: {obj.Description} ");
            Console.Write("Insira a nova Descrição ou pressione Enter para manter a atual: ");
            var newDescription = Console.ReadLine();
            uProduct.Description = newDescription.Length != 0 ? newDescription : obj.Description;

            Console.WriteLine($"Preço atual do produto: R$ {obj.Price} ");
            Console.Write("Insira o novo Preço ou pressione Enter para manter o atual: ");
            var newPrice = Console.ReadLine();

            uProduct.Price = newPrice.Length != 0 ? Convert.ToDecimal(newPrice)
                : Convert.ToDecimal(obj.Price);
            uProduct.IdProduct = Guid.Parse(uId);
        


        Console.WriteLine($"[{uProduct.IdProduct}] {uProduct.Name} - {uProduct.Description} R$ {uProduct.Price}");

        product.Update(uProduct, uId);

    }
}
