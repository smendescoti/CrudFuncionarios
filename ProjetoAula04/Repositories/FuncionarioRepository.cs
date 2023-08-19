using Dapper;
using ProjetoAula04.Entities;
using ProjetoAula04.Settings;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula04.Repositories
{
    public class FuncionarioRepository
    {
        //método para gravar um registro de funcionário
        //na tabela do banco de dados..
        public void Create(Funcionario funcionario)
        {
            //escrevendo uma query (comando SQL) para executar
            //um INSERT na tabela de FUNCIONARIO (gravação)
            var query = @"
                    INSERT INTO FUNCIONARIO(ID, NOME, CPF, MATRICULA, DATAADMISSAO, TIPOCONTRATACAO)
                    VALUES(@Id, @Nome, @Cpf, @Matricula, @DataAdmissao, @TipoContratacao)
                ";

            //acessando o banco de dados do SqlServer (abrindo conexão)
            using (var connection = new SqlConnection(SqlServerSettings.GetConnectionString()))
            {
                //executando o comando SQL no banco de dados
                //através da biblioteca do Dapper
                connection.Execute(query, new
                {
                    @Id = funcionario.Id,
                    @Nome = funcionario.Nome,
                    @Cpf = funcionario.Cpf,
                    @Matricula = funcionario.Matricula,
                    @DataAdmissao = funcionario.DataAdmissao,
                    @TipoContratacao = (int)funcionario.TipoContratacao
                });
            }
        }

        //método para atualizar um registro de funcionário
        //na tabela do banco de dados
        public void Update(Funcionario funcionario)
        {
            //abrindo conexão com o banco de dados
            var query = @"
                UPDATE FUNCIONARIO 
                SET
                    NOME = @Nome,
                    CPF = @Cpf,
                    MATRICULA = @Matricula, 
                    DATAADMISSAO = @DataAdmissao,
                    TIPOCONTRATACAO = @TipoContratacao
                WHERE
                    ID = @Id
            ";

            using (var connection = new SqlConnection(SqlServerSettings.GetConnectionString()))
            {
                connection.Execute(query, new
                {
                    @Nome = funcionario.Nome,
                    @Cpf = funcionario.Cpf,
                    @Matricula = funcionario.Matricula,
                    @DataAdmissao = funcionario.DataAdmissao,
                    @TipoContratacao = funcionario.TipoContratacao,
                    @Id = funcionario.Id
                });
            }
        }

        //método para excluir um registro de funcionário
        //na tabela do banco de dados
        public void Delete(Funcionario funcionario)
        {
            var query = @"
                DELETE FROM FUNCIONARIO WHERE ID = @Id
            ";

            using (var connection = new SqlConnection(SqlServerSettings.GetConnectionString()))
            {
                connection.Execute(query, new
                {
                    @Id = funcionario.Id
                });
            }
        }

        //método para consultar todos os funcionários
        //cadastrados no banco de dados
        public List<Funcionario> GetAll()
        {
            var query = @"
                SELECT ID, NOME, CPF, MATRICULA, DATAADMISSAO, TIPOCONTRATACAO
                FROM FUNCIONARIO
                ORDER BY NOME ASC
            ";

            using (var connection = new SqlConnection(SqlServerSettings.GetConnectionString()))
            {
                return connection.Query<Funcionario>(query).ToList();
            }
        }

        //método para consultar 1 funcionário
        //no banco de dados através do ID
        public Funcionario? GetById(Guid id)
        {
            var query = @"
                SELECT ID, NOME, CPF, MATRICULA, DATAADMISSAO, TIPOCONTRATACAO
                FROM FUNCIONARIO
                WHERE ID = @Id
            ";

            using (var connection = new SqlConnection(SqlServerSettings.GetConnectionString()))
            {
                return connection.Query<Funcionario>(query, new { @Id = id }).FirstOrDefault();
            }
        }

    }
}
