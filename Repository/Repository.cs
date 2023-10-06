using Dapper;
using MySql.Data.MySqlClient;
using ReadAndSaveExcelData.Model;
using ReadAndSaveExcelData.Querys;

namespace ReadAndSaveExcelData.Repository
{
    public class Repository
    {
        const string connectionString = "server=127.0.0.1;uid=root;pwd=admin;database=infocardata";

        public Repository() { }

        public List<Carro> buscarCarros()
        {

            using (var conn = new MySqlConnection(connectionString))
            {
                var carro = conn.Query<Carro>(Query.buscaDadosCarros).ToList();

                return carro;
            }
        }

        public void inserirDadosCarros(List<Carro> listaCarros)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                foreach (var item in listaCarros)
                {
                    var result = conn.Execute(Query.inserirDadosCarros, new
                    {
                        Placa = item.Placa,
                        Cmt = item.Cmt,
                        NumeroPassageiros = item.NumeroPassageiros,
                        Busca = item.Busca
                    });

                    if (result == 0)
                    {
                        Console.WriteLine("Erro ao inserir item: " + item);

                    }
                }

            }
        }
    }
}
