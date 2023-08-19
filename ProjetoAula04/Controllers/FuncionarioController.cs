using ProjetoAula04.Entities;
using ProjetoAula04.Enums;
using ProjetoAula04.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula04.Controllers
{
    public class FuncionarioController
    {
        //método para executar o cadastro do funcionário
        public void CadastrarFuncionario()
        {
            try
            {
                Console.WriteLine("\nCADASTRO DE FUNCIONÁRIO:\n");

                var funcionario = new Funcionario();
                funcionario.Id = Guid.NewGuid();

                Console.Write("NOME DO FUNCIONÁRIO...: ");
                funcionario.Nome = Console.ReadLine();

                Console.Write("CPF...................: ");
                funcionario.Cpf = Console.ReadLine();

                Console.Write("MATRICULA.............: ");
                funcionario.Matricula = Console.ReadLine();

                Console.Write("DATA DE ADMISSÃO......: ");
                funcionario.DataAdmissao = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("(1) ESTÁGIO");
                Console.WriteLine("(2) CLT");
                Console.WriteLine("(3) TERCEIRIZADO");

                Console.Write("TIPO DE CONTRATAÇÃO...: ");
                funcionario.TipoContratacao = (TipoContratacao) int.Parse(Console.ReadLine());

                //gravando no banco de dados
                var funcionarioRepository = new FuncionarioRepository();
                funcionarioRepository.Create(funcionario);

                Console.WriteLine("\nFuncionário cadastrado com sucesso!");
            }
            catch(ArgumentException e)
            {
                Console.WriteLine("\nErro de validação de dados:");
                Console.WriteLine(e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine("\nFalha ao cadastrar: ");
                Console.WriteLine(e.Message);
            }
        }

        //método para executar a atualização do funcionário
        public void AtualizarFuncionario()
        {
            try
            {
                Console.WriteLine("\nATUALIZAÇÃO DE FUNCIONÁRIO:\n");

                Console.Write("ID DO FUNCIONÁRIO.....: ");
                var id = Guid.Parse(Console.ReadLine());

                //consultar o funcionário no banco de dados através do ID
                var funcionarioRepository = new FuncionarioRepository();
                var funcionario = funcionarioRepository.GetById(id);

                //verificar se o funcionário foi encontrado
                if(funcionario != null)
                {
                    Console.Write("NOME DO FUNCIONÁRIO...: ");
                    funcionario.Nome = Console.ReadLine();

                    Console.Write("CPF...................: ");
                    funcionario.Cpf = Console.ReadLine();

                    Console.Write("MATRICULA.............: ");
                    funcionario.Matricula = Console.ReadLine();

                    Console.Write("DATA DE ADMISSÃO......: ");
                    funcionario.DataAdmissao = DateTime.Parse(Console.ReadLine());

                    Console.WriteLine("(1) ESTÁGIO");
                    Console.WriteLine("(2) CLT");
                    Console.WriteLine("(3) TERCEIRIZADO");

                    Console.Write("TIPO DE CONTRATAÇÃO...: ");
                    funcionario.TipoContratacao = (TipoContratacao)int.Parse(Console.ReadLine());

                    //atualizando os dados do funcionário
                    funcionarioRepository.Update(funcionario);

                    Console.WriteLine("\nFuncionário atualizado com sucesso!");
                }
                else
                {
                    Console.WriteLine("\nFuncionário não encontrado.");
                }
            }
            catch(ArgumentException e)
            {
                Console.WriteLine("\nErro de validação de dados:");
                Console.WriteLine(e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine("\nFalha ao cadastrar: ");
                Console.WriteLine(e.Message);
            }
        }

        //método para executar a exclusão do funcionário
        public void ExcluirFuncionario()
        {
            try
            {
                Console.WriteLine("\nEXCLUSÃO DE FUNCIONÁRIO:\n");

                Console.Write("ID DO FUNCIONÁRIO.....: ");
                var id = Guid.Parse(Console.ReadLine());

                //consultar o funcionário no banco de dados através do ID
                var funcionarioRepository = new FuncionarioRepository();
                var funcionario = funcionarioRepository.GetById(id);

                //verificar se o funcionário foi encontrado
                if(funcionario != null)
                {
                    //excluindo o funcionário
                    funcionarioRepository.Delete(funcionario);
                    Console.WriteLine("\nFuncionário excluído com sucesso.");
                }
                else
                {
                    Console.WriteLine("\nFuncionário não encontrado.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nFalha ao cadastrar: ");
                Console.WriteLine(e.Message);
            }
        }

        //método para executar a consulta dos funcionários
        public void ConsultarFuncionarios()
        {
            try
            {
                Console.WriteLine("\nCONSULTA DE FUNCIONÁRIOS:\n");

                //consultando todos os funcionários cadastrados no banco de dados
                var funcionarioRepository = new FuncionarioRepository();
                var funcionarios = funcionarioRepository.GetAll();

                //imprimindo os dados de cada funcionário
                foreach (var item in funcionarios)
                {
                    Console.WriteLine("ID DO FUNCIONÁRIO.....: " + item.Id);
                    Console.WriteLine("NOME..................: " + item.Nome);
                    Console.WriteLine("CPF...................: " + item.Cpf);
                    Console.WriteLine("MATRICULA.............: " + item.Matricula);
                    Console.WriteLine("TIPO DE CONTRATAÇÃO...: " + item.TipoContratacao);
                    Console.WriteLine("DATA DE ADMISSÃO......: " + item.DataAdmissao);
                    Console.WriteLine("...");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\nFalha ao cadastrar: ");
                Console.WriteLine(e.Message);
            }
        }

    }
}
