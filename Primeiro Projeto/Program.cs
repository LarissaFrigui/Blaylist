//Screen Sound 

//O C# é uma linguagem fortemente tipada, ou seja, sempre é necessário declarar muito bem a variavel
//No C# sempre utilizar aspas duplas "" para escrever um texto
//Diferente do JS que o proprio codigo coloca o ; apesar de ser recomendavel ao programador sempre coloca. Nessa linguagem
//é essencial colocar o ponto e virgura. 
//string mensagemDeBoasVindas = "Boas vindas ao Screen Sound ";
//O comando Console.WriteLine é responsavel por apresentar a mensagem informada no console
//Console.WriteLine(mensagemDeBoasVindas);

//Exercicio
//string curso = "Curso de iniciação em linguagem C#";
//Console.WriteLine($"Curso: {curso}" );
//string nome = "Guilherme";
//Console.WriteLine($"Instrutor: {nome} ");
/*Para fazer a apresentação no console de um texto e uma variavel no JS fariamos uma concatenação com o 
 * simbolo de + ou então utilizar a template string.No C# temos a opção de concatenação vem como
 * uma similar à templete string, nela iniciamos com $ colocar o texto entre "" e as variaveis são apresentadas dentro de {}*/

//Criando funções
//Quando a função não tem retorno utilizamos a palavra reservada void

//List<string> listaDosGrupos = new List<string> {"BTS", "BlackPink", "Twice", "BigBang"};

Dictionary<string, List<int>> gruposRegistrados = new Dictionary<string, List<int>>();
gruposRegistrados.Add ("BTS",new List<int> { 10, 9 , 10});
gruposRegistrados.Add("TXT", new List<int>());

void ExibirLogo()
{
    Console.WriteLine(@"

█▄▄ █░░ ▄▀█ █▄█ █░░ █ █▀ ▀█▀
█▄█ █▄▄ █▀█ ░█░ █▄▄ █ ▄█ ░█░
");
    Console.WriteLine("Boas vindas ao Blaylist sua playlist de KPOP ");
}
/*Para as variaveis temos o padrao de iniciar com letra minuscula como visto mensagemDeBoasVindas, 
 * já para declaração de funções iniciamos com letra maiuscula ExibirMensagemDeBoasVindas.*/

void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar um grupo de KPOP");
    Console.WriteLine("Digite 2 para mostrar todos os grupo");
    Console.WriteLine("Digite 3 para avaliar um grupo");
    Console.WriteLine("Digite 4 para exibir a média de um grupo");
    Console.WriteLine("Digite -1 para sair");

    //Quando utilizamos só o Write sem a palavra seguinte Line ele escreve o texto e nao pula uma linha dessa forma o nosso proximo comando 
    //ReadLine estará disponivel na mesma linha do texto. 
    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);
    //O ! que colocamos é responsavel por eliminar a opção da opcaoEscolhida ser um valor nulo, pois nesse caso ela necessariamente precisa ser uma string
    switch (opcaoEscolhidaNumerica)
    {
        case 1: RegistrarGrupos();
            break;
        case 2: MostrarGruposRegistrados();
            break;
        case 3: AvaliarGrupo();
            break;
        case 4: MostrarMediaDoGrupo();
            break;
        case -1: 
            Console.WriteLine("\nObrigada por usar o programa Blaylist, volte sempre!");
            Thread.Sleep(2000);
            break;
        default: Console.WriteLine("Opção inválida, tente novamente");
            break;
    }
}

void TituloDasOpcoes(string nomeDaOpcao)
{
    int quantidadeDeLetras = nomeDaOpcao.Length;
    string asteriscos = string.Empty.PadLeft((quantidadeDeLetras), '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(nomeDaOpcao);
    Console.WriteLine(asteriscos + "\n");
}

void RegistrarGrupos()
{
    Console.Clear(); //resposavel por limpar o console
    TituloDasOpcoes("Registro do Grupo");
    Console.Write("Digite o nome do grupo que deseja registrar: ");
    string nomeDoGrupo = Console.ReadLine()!;
    //listaDosGrupos.Add(nomeDoGrupo); forma com que adicionamos um elemento dentro de uma lista 
    gruposRegistrados.Add(nomeDoGrupo, new List<int>()); // forma de adicionar uma elemento chave dentro de um dicionario
    /*O elemento adicionado foi o nome do grupo, o segundo elemento presente dentro do parenteses do Add se refere 
     aos valores do dicionario, como estamos fazendo só um registro não entrará nenhum valor novo por isso e criado 
    uma lista para esses futuros valores nova e vazia*/
    Console.WriteLine("O grupo de K-pop " + nomeDoGrupo + " foi registrado com sucesso!");
    Thread.Sleep(2000); //responsavel por fazer a carregamento demorar um pouco nesse caso 2s 
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void MostrarGruposRegistrados()
{
    Console.Clear();
    TituloDasOpcoes("Lista de grupos registrados");
    int i = 1;
    foreach(string grupos in gruposRegistrados.Keys)
    {
        Console.WriteLine(i + "° Grupo: " + grupos);
        i++;
    }
    /* Estrutura for classica
    for(int i = 0; i < gruposRegistrados.Keys.Count; i++)
    {
        Console.WriteLine((i+1) + "° Grupo: "+ gruposRegistrados[i]);
    }*/

    Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void AvaliarGrupo()
{
    Console.Clear();
    TituloDasOpcoes("Avaliar grupo");
    Console.Write("Digite o nome do grupo que deseja avaliar: ");
    string grupoParaAvaliação = Console.ReadLine()!;
    if (gruposRegistrados.ContainsKey(grupoParaAvaliação))
    {
        Console.Write("Qual é a nota para o grupo " + grupoParaAvaliação + "? ");
        int nota = int.Parse(Console.ReadLine());
        gruposRegistrados[grupoParaAvaliação].Add(nota);
        Thread.Sleep(1000);
        Console.WriteLine("A nota " + nota + " foi registrada com sucesso para o grupo " + grupoParaAvaliação);
        Thread.Sleep(2500);
        Console.Clear();
        ExibirOpcoesDoMenu();   
    }
    else
    {
        Console.WriteLine("\nO grupo " + grupoParaAvaliação + " ainda não foi registrado.\nVolte ao menu principal e registre para fazer sua avaliação.");
        Thread.Sleep(2000);
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
}

void MostrarMediaDoGrupo()
{
    Console.Clear();
    TituloDasOpcoes("Media do Grupo");
    Console.Write("Informe o grupo que deseja ver a média: ");
    string grupoParaMedia = Console.ReadLine()!;
    if (gruposRegistrados.ContainsKey(grupoParaMedia))
    {
        int elementosNaLista = gruposRegistrados[grupoParaMedia].Count;
        if (elementosNaLista > 0)
        {
            /*int somaParaMedia = 0;
            List<int> listaParaMedia = gruposRegistrados[grupoParaMedia];
            for (int i = 0; i < elementosNaLista; i++)
            {
                somaParaMedia = somaParaMedia + listaParaMedia[i];
            }
            float mediaDoGrupo = (float)somaParaMedia / elementosNaLista;
            Console.WriteLine("\nA média para o grupo " + grupoParaMedia + " é de " + mediaDoGrupo.ToString("F2"));*/
            List<int> listaParaMedia = gruposRegistrados[grupoParaMedia];
            Console.WriteLine("\nA média para o grupo " + grupoParaMedia + " é de " + listaParaMedia.Average().ToString("F2"));
            //o comando Average ja pega uma lista e apresenta a media dela 
            Thread.Sleep(2000);
            Console.Clear();
            ExibirOpcoesDoMenu();
        }
        else
        {
            Console.WriteLine("\nO grupo " + grupoParaMedia + " já está registrado, porém ainda não recebeu nenhuma avaliação");
            Thread.Sleep(2000);
            Console.Clear();
            ExibirOpcoesDoMenu();
        }
    }
    else
    {
        Console.WriteLine("\nO grupo informado ainda não foi registrado");
        Thread.Sleep(2000);
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
}
ExibirOpcoesDoMenu();

//List<string> grupos = new List<string>{ "BTS", "BlackPink", "BigBang" };
//Console.WriteLine(grupos[0]);

/*Para a declaração de uma lista é necessario declará-la colocando o tipo, seu nome e posteriormente atribruindo
 * que aquilo é uma nova lista. 
Quando declaramos uma string colocamos string nomeDaString = "Valor da string", a utilização de List<string> é a forma de 
declarar que aquilo que entrará é do tipo lista e que será de strings, para uma lista de numeros utilizariamos List<int> 
ou então qualquer variação de tipos.*/