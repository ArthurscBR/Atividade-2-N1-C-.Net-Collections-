using System.Linq;

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
    
    public static void dicionario()
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

        bool removed = ages.Remove("Joao");
        Console.WriteLine($"Joao foi removido do dicionario? {removed}");

        Console.WriteLine("Exibindo chave e valor: ");
        foreach(KeyValuePair<string, int> pair in ages)
        {
            Console.WriteLine($"{pair.Key} : {pair.Value}");
        }

        foreach(var (nome, age) in ages)
        {
            Console.WriteLine($"{nome} : {age}");
        }

    }

    static void Main()
    {
        //Filtragem 
        List<int> numbers = new List<int>() {1,2,3,4,5,6,7,8,9,10};
        Console.WriteLine("Numeros pares: ");
        var even = numbers.Where(n=>n%2==0);
        foreach(var item in even)
        {
            Console.Write($"{item}, ");
        }
        Console.WriteLine("\nNumeros maiores que 5: ");
        var greaterThanFive = numbers.Where(n => n > 5);
        foreach(var item in greaterThanFive)
        {
            Console.Write($"{item}, ");
        }

        //Tranformação  
        var doubled = numbers.Select(n => n * 2);

        Console.WriteLine("\nNumeros multiplicados por 2: ");
        foreach(var item in doubled)
        {
            Console.Write($"{item}, ");
        }

        var numberObjects = numbers.Select(n => new {Value = n, IsEven = n % 2 == 0 });        
        Console.WriteLine("\nNumeros pares ou não: ");
        foreach (var item in numberObjects)
        {
            Console.WriteLine($"{item.Value} : {item.IsEven}");
        }

        //Ordenação
        var ascending = numbers.OrderBy(n => n);
        var descending = numbers.OrderByDescending(n => n);
        Console.WriteLine("Ondenando numero da lista de forma decrescente: ");
        foreach(var item in descending)
        {
            Console.WriteLine(item);
        }

        var complex = numbers.OrderBy(n => n % 3).ThenByDescending(n => n);
        Console.WriteLine("Ordenando numeros com base no modulo da divisão por 3: ");
        foreach (var item in complex)
        {
            Console.WriteLine(item);
        }

        //Agregação
        int sum = numbers.Sum();
        Console.WriteLine($"somas do numeros da lista: {sum}");
        int min = numbers.Min();
        Console.WriteLine($"Menor numero presente na lista: {min}");
        int max = numbers.Max();
        Console.WriteLine($"Maior numero presente na lista: {max}");
        double average = numbers.Average();
        Console.WriteLine($"Media dos numeros presentes na lista: {average}");
        int product = numbers.Aggregate((a, b) => a * b);
        Console.WriteLine($"Media dos numeros presentes na lista: {product}");

        // Quantificadores 
        bool allEven = numbers.All(n => n % 2 == 0);
        Console.WriteLine($"Retornando se todos os numeros da lista são pares (true or false) {allEven}");
        bool anyEven = numbers.Any(n => n % 2 == 0);
        Console.WriteLine($"Retornando se pelo menos um dos numeros da lista é par (true or false) {anyEven}");
        bool contains = numbers.Contains(7);
        Console.WriteLine($"Retornando se a lista possui o numero 7 (true or false) {contains}");

        // Partição 
        var firtThree = numbers.Take(3);
        foreach(var item in firtThree)
        {
            Console.WriteLine(item);
        } 

        var skipFirstThree = numbers.Skip(3);
        foreach(var item in skipFirstThree)
        {
            Console.WriteLine(item);
        } 

        var takeLast = numbers.TakeLast(2);
        
        foreach(var item in takeLast)
        {
            Console.WriteLine(item);
        } 

        var skipLast  = numbers.SkipLast(2);
        foreach(var item in skipLast)
        {
            Console.WriteLine(item);
        } 

        // Operações de elemento 

        var first = numbers.First();
        Console.WriteLine($"primeiro numero da lista: {first}");

        var firstEven = numbers.First(n => n % 2 == 0);
        Console.WriteLine($"primeiro numero da lista a cumprir a condição: {firstEven}");

        var lastOdd = numbers.Last(n => n % 2 != 0);
        Console.WriteLine($"ultimo numero da lista a cumprir a condição: {lastOdd}");

        int single = numbers.Where(n => n == 5).Single();
        Console.WriteLine($"um numero da lista que cumpra a condição: {single}");

        

    }
}