namespace ReadAndSaveExcelData.Querys
{
    public class Query
    {
        public static string buscaDadosCarros = "SELECT * FROM tb_carros";

        public static string inserirDadosCarros = "INSERT INTO tb_carros(Placa, Cmt, NumeroPassageiros, Busca) VALUES(@Placa, @Cmt, @NumeroPassageiros, @Busca)";
    }
}
