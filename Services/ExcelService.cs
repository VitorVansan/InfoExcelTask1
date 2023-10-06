using Dapper;
using ReadAndSaveExcelData.Model;
using MySql.Data.MySqlClient;
using ClosedXML.Excel;
using System.Text.Json;
using DocumentFormat.OpenXml.Office2013.Excel;
using ClosedXML;

namespace ReadAndSaveExcelData.Services
{
    public class ExcelService
    {
        public ExcelService(){}

        public List<Carro> buscaDadosExcel(string fileName)
        {
            List<Carro> lista = new List<Carro>();

            if (File.Exists(fileName))
            {
                var workbook = new XLWorkbook(fileName);
                var rowsUsed = workbook.Worksheet(1).RowsUsed();

                foreach (var dataRow in rowsUsed)
                {
                    if (dataRow.RowNumber() > 1)
                    {
                        var carro = new Carro();

                        carro.Placa = dataRow.Cell(1).Value.ToString();

                        carro.Cmt = double.TryParse(dataRow.Cell(2).Value.ToString(), out double cmtT) ? cmtT : null;

                        carro.NumeroPassageiros = int.TryParse(dataRow.Cell(3).Value.ToString(), out int numeroPassageiros) ? numeroPassageiros : null;

                        carro.Busca = int.TryParse(dataRow.Cell(4).Value.ToString(), out int busca) ? busca : null;

                        lista.Add(carro);
                    }
                }
            }
            else
            {
                Console.WriteLine("Erro ao localiza arquivo:" + fileName);
            }

            return lista;
        }

        
    }
}
