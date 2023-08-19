using ProjetoAula04.Controllers;

namespace ProjetoAula04
{ 
    public class Program
    {
        //método para executar o projeto..
        public static void Main(string[] args)
        {
            Console.WriteLine("(1) CADASTRAR FUNCIONÁRIOS");
            Console.WriteLine("(2) ATUALIZAR FUNCIONÁRIOS");
            Console.WriteLine("(3) EXCLUIR FUNCIONÁRIOS");
            Console.WriteLine("(4) CONSULTAR FUNCIONÁRIOS");

            Console.Write("\nINFORME A OPÇÂO DESEJADA: ");
            var opcao = int.Parse(Console.ReadLine());

            var funcionarioController = new FuncionarioController();

            switch (opcao)
            {
                case 1: funcionarioController.CadastrarFuncionario(); break;
                case 2: funcionarioController.AtualizarFuncionario(); break;
                case 3: funcionarioController.ExcluirFuncionario(); break;
                case 4: funcionarioController.ConsultarFuncionarios(); break;
            }

            Console.Write("\nDESEJA CONTINUAR? (S,N): ");
            var continuar = Console.ReadLine();

            if(continuar.Equals("S", StringComparison.OrdinalIgnoreCase))
            {
                //limpar a tela do prompt
                Console.Clear();
                //recursividade
                Main(args);
            }
            else
            {
                Console.WriteLine("\nFIM DO PROGRAMA!");
            }
        }
    }
}