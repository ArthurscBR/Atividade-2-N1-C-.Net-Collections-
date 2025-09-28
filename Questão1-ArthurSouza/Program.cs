
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

    public static void vizualizar(List<string> lista)
    {
        Console.WriteLine("selecione uma das opções:\n1. Vizualizar todos os elementos da lista.\n2. Vizualizar um elemento em especifico.");
        var op = int.Parse(Console.ReadLine());
        switch(op)
        {
            case 1:
                lista.ForEach(item=>{Console.WriteLine(item);});
                break;
            case 2:
                Console.WriteLine("Digite o elemento que deseja procurar: ");
                var elemento = Console.ReadLine();
                bool flag = false;
                lista.ForEach(item => 
                {   
                   if (item.ToLower().Contains(elemento.ToLower()))
                   {
                    Console.WriteLine(item);
                    flag = true;
                   }
                });
                if(!flag)
                {
                    Console.WriteLine("Nenhum elemento correspondente encontrado");
                }
                break;

            default: 
                Console.WriteLine("Opção inválida!");
                break;
        }
    } 

    public static void remove(List<string> lista)
    {
        Console.WriteLine("selecione uma das opções:\n1. Remover todos os elementos da lista.\n2. Remover um elemento em especifico.");
        int op = int.Parse(Console.ReadLine());
        switch(op){
            case 1:
                lista.Clear();
                break;
            case 2:
                Console.WriteLine("Digite o elememto que deseja remover: ");

                var elememto = Console.ReadLine();
                
                for(int i = 0; i<lista.Count; i++){
                    
                    if(lista[i].ToLower().Equals(elememto.ToLower()))
                    {
                        lista.Remove(lista[i]);
                    }
                }

                break;
        default:
                break;
        }
    }

    public static int indice(List<string> lista, string item)
    {
        return lista.IndexOf(item);
    } 

    public static void adiciona_dic(Dictionary<string, int> dict)
    {
        Console.WriteLine("Digite seu nome: ");
        var nome = Console.ReadLine();
        Console.WriteLine("Digite sua idade: ");
        var idade = int.Parse(Console.ReadLine());
        
        dict.Add(nome, idade);
    }


    public static void lista()
    {
        List<string> nomes = new List<string>() {"Arthur","Heitor"};
       
        
        adiciona(nomes);
        vizualizar(nomes);
        remove(nomes);
        vizualizar(nomes);
        Console.WriteLine($"Indice que armazena 'Arthur': {indice(nomes, "Arthur")}");
        
    }
    
    static void Main()
    {
         Dictionary<string, int> ages = new Dictionary<string, int>() 
        {
            {"Maria", 30}
        };
        //adiciona_dic(ages);
        ages["Maria"] = 40;
        ages.Add("Jose", 25);
        ages.Add("Alice", 30);

        int aliceAge = ages["Alice"];
        Console.WriteLine($"Alice tem {aliceAge} anos"); 

        bool sucess = ages.TryGetValue("Jose", out int idadeJose);
        Console.WriteLine($"Idede de Jose: {idadeJose}");

        bool containsKey = ages.ContainsKey("Maria");
        Console.WriteLine($"O dicionario ages contem a chave 'Maria'? {containsKey}");


    }
}
