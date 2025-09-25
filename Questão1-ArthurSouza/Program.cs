
class Program
{
    public static void adiciona(List<string> lista)
    {
        Console.WriteLine("quantidade de nomes que deseja inserir na lista: ");
        int qtd = int.Parse(Console.ReadLine());

        for(int i = 0; i<qtd; i++)
        {
            Console.WriteLine("Digite um nome para a lista: ");
            string nome = Console.ReadLine();
            lista.Add(nome);
        }
    }

    public static void adiciona_varios(List<string> lista)
    {
        Console.WriteLine("quantidade de nomes que deseja inserir na lista: ");
        int qtd = int.Parse(Console.ReadLine());
        string[] adicionaveis = new string[qtd];      
        for(int i = 0; i<qtd; i++)
        {
            Console.WriteLine("Digite um nome para a lista: ");
            string nome = Console.ReadLine();
            adicionaveis[i] = nome;
        }

        lista.AddRange(adicionaveis);
    }

    static void Main()
    {
        List<string> nomes = new List<string>() {"Arthur","Heitor"};
        //adiciona(nomes);
        adiciona_varios(nomes);
        nomes.ForEach(item=>{Console.WriteLine(item);});
    }
}
