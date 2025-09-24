
class Program
{
    public static void Main()
    {
        List<string> nomes = new List<string>();

        Console.WriteLine("quantidade de nomes que deseja inserir na lista: ");
        int qtd = int.Parse(Console.ReadLine());

        for(int i = 0; i<qtd; i++)
        {
            Console.WriteLine("Digite um nome para a lista: ");
            string nome = Console.ReadLine();
            nomes.Add(nome);
        }

    }
}
