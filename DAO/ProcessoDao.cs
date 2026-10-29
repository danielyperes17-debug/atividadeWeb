
using AppWebExemplo.Configs;
using AppWebExemplo.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace AppWebExemplo.DAO
{
    public class ProcessoDAO
    {
        private readonly Conexao _conexao;

        public ProcessoDAO(Conexao conexao)
        {
            _conexao = conexao;
        }

        // Lista todos os processos
        public List<Processo> Listar()
        {
            var lista = new List<Processo>();

            using var con = _conexao.GetConnection();

            const string sql = @"
                SELECT id_pro, numero_pro, data_pro,
                       interessado_pro, assunto_pro,
                       descricao_pro, situacao_pro
                FROM processos";

            using var comando = new MySqlCommand(sql, con);
            using var leitor = comando.ExecuteReader();

            while (leitor.Read())
            {
                var processo = new Processo
                {
                    Id = leitor.GetInt32("id_pro"),
                    Numero = leitor.GetString("numero_pro"),
                    Data = leitor.IsDBNull(leitor.GetOrdinal("data_pro"))
                        ? null
                        : DateOnly.FromDateTime(
                            leitor.GetDateTime("data_pro")),
                    Interessado = leitor.GetString("interessado_pro"),
                    Assunto = leitor.GetString("assunto_pro"),
                    Descricao = leitor.IsDBNull(
                        leitor.GetOrdinal("descricao_pro"))
                        ? string.Empty
                        : leitor.GetString("descricao_pro"),
                    Situacao = leitor.GetString("situacao_pro")
                };

                lista.Add(processo);
            }

            return lista;
        }

        // Insere um novo processo
        public void Inserir(Processo processo)
        {
            if (processo.Data == null)
            {
                throw new ArgumentException(
                    "A data do processo é obrigatória.");
            }

            using var con = _conexao.GetConnection();

            const string sql = @"
                INSERT INTO processos
                (numero_pro, data_pro, interessado_pro,
                 assunto_pro, descricao_pro, situacao_pro)
                VALUES
                (@numero, @data, @interessado,
                 @assunto, @descricao, @situacao)";

            using var comando = new MySqlCommand(sql, con);

            comando.Parameters.AddWithValue("@numero", processo.Numero);
            comando.Parameters.AddWithValue(
                "@data", processo.Data.Value.ToDateTime(TimeOnly.MinValue));
            comando.Parameters.AddWithValue(
                "@interessado", processo.Interessado);
            comando.Parameters.AddWithValue("@assunto", processo.Assunto);
            comando.Parameters.AddWithValue(
                "@descricao", processo.Descricao ?? string.Empty);
            comando.Parameters.AddWithValue("@situacao", processo.Situacao);

            comando.ExecuteNonQuery();
        }

        // Busca um processo pelo ID
        public Processo? ObterPorId(int id)
        {
            using var con = _conexao.GetConnection();

            const string sql = @"
                SELECT id_pro, numero_pro, data_pro,
                       interessado_pro, assunto_pro,
                       descricao_pro, situacao_pro
                FROM processos
                WHERE id_pro = @id";

            using var comando = new MySqlCommand(sql, con);
            comando.Parameters.AddWithValue("@id", id);

            using var leitor = comando.ExecuteReader();

            if (!leitor.Read())
            {
                return null;
            }

            return new Processo
            {
                Id = leitor.GetInt32("id_pro"),
                Numero = leitor.GetString("numero_pro"),
                Data = leitor.IsDBNull(leitor.GetOrdinal("data_pro"))
                    ? null
                    : DateOnly.FromDateTime(
                        leitor.GetDateTime("data_pro")),
                Interessado = leitor.GetString("interessado_pro"),
                Assunto = leitor.GetString("assunto_pro"),
                Descricao = leitor.IsDBNull(
                    leitor.GetOrdinal("descricao_pro"))
                    ? string.Empty
                    : leitor.GetString("descricao_pro"),
                Situacao = leitor.GetString("situacao_pro")
            };
        }

        // Atualiza um processo existente
        public void Atualizar(Processo processo)
        {
            if (processo.Data == null)
            {
                throw new ArgumentException(
                    "A data do processo é obrigatória.");
            }

            using var con = _conexao.GetConnection();

            const string sql = @"
                UPDATE processos
                SET numero_pro = @numero,
                    data_pro = @data,
                    interessado_pro = @interessado,
                    assunto_pro = @assunto,
                    descricao_pro = @descricao,
                    situacao_pro = @situacao
                WHERE id_pro = @id";

            using var comando = new MySqlCommand(sql, con);

            comando.Parameters.AddWithValue("@numero", processo.Numero);
            comando.Parameters.AddWithValue(
                "@data", processo.Data.Value.ToDateTime(TimeOnly.MinValue));
            comando.Parameters.AddWithValue(
                "@interessado", processo.Interessado);
            comando.Parameters.AddWithValue("@assunto", processo.Assunto);
            comando.Parameters.AddWithValue(
                "@descricao", processo.Descricao ?? string.Empty);
            comando.Parameters.AddWithValue("@situacao", processo.Situacao);
            comando.Parameters.AddWithValue("@id", processo.Id);

            comando.ExecuteNonQuery();
        }

        // Exclui um processo pelo ID
        public void Excluir(int id)
        {
            using var con = _conexao.GetConnection();

            const string sql =
                "DELETE FROM processos WHERE id_pro = @id";

            using var comando = new MySqlCommand(sql, con);

            comando.Parameters.AddWithValue("@id", id);

            comando.ExecuteNonQuery();
        }
    }
}
