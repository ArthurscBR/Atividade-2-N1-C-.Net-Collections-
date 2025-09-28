

class Program
{
    public static void adicionar_filme(List<Dictionary<string, object>> filmes)
    {
        Dictionary<string, object> filme = new Dictionary<string, object>();

        Console.WriteLine("Digite o titulo do filme: ");
        filme["titulo"] = Console.ReadLine();
        Console.WriteLine("Digite o genero do filme: ");
        filme["genero"] = Console.ReadLine();
        Console.WriteLine("Digite o pais do filme: ");
        filme["pais"] = Console.ReadLine();
        Console.WriteLine("Digite o ano do filme: ");
        filme["ano"] = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite o nomes dos artistas do filme: ");
        string artistasInput = Console.ReadLine();
        List<string> artistas = new List<string>(artistasInput.Split(','));

        filme["artistas"] = artistas;

        filmes.Add(filme);
    }

    public static void visulizar_filme(Dictionary<string, object> filme)
    {
        Console.WriteLine($"-----------------------------------------------------");
        Console.WriteLine($"titulo: {filme["titulo"]}");
        Console.WriteLine($"genero: {filme["genero"]}");
        Console.WriteLine($"pais: {filme["pais"]}");
        Console.WriteLine($"ano: {filme["ano"]}");
        Console.WriteLine("Artistas: " + string.Join(", ", (List<string>)filme["artistas"]));
        Console.WriteLine($"-----------------------------------------------------");
    }

    public static void lista_filmes(List<Dictionary<string, object>> filmes)
    {
        foreach (var item in filmes)
        {
            visulizar_filme(item);
        }
    }


    public static void pesquisar_filme(List<Dictionary<string, object>> filmes, string titulo)
    {
        var encontrado = filmes.Find(f => 
            f["titulo"].ToString().Equals(titulo, StringComparison.OrdinalIgnoreCase));

        if (encontrado != null)
        {
            Console.WriteLine("Filme encontrado:");
            visulizar_filme(encontrado);
        }
        else
        {
            Console.WriteLine("Filme não encontrado.");
        }
    }

    public static void Main()
    {
        List<Dictionary<string, object>> filmes = new List<Dictionary<string, object>>();

        adicionar_filme(filmes);
        lista_filmes(filmes);

        Console.WriteLine("Digite um titulo para pesquisar: ");
        string busca = Console.ReadLine();
        pesquisar_filme(filmes, busca);
    }
}
