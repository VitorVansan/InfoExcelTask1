using ReadAndSaveExcelData.Model;
using ReadAndSaveExcelData.Repository;
using ReadAndSaveExcelData.Services;

string fileName = System.IO.Directory.GetCurrentDirectory() + "\\Data\\teste-ti-processamento_fornecedor_fora_do_ar.xlsx";

ExcelService service = new ExcelService();
List<Carro> Carros = new List<Carro>();
Repository repository = new Repository();   


Carros = service.buscaDadosExcel(fileName);

repository.inserirDadosCarros(Carros);