using FinancialManager.FileProcessor;
using FinancialManager.Models.Enums;
using FinancialManager.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FinancialManager.Services
{
    public class FileService: IFileService
    {
        private readonly IBillService _billService;
        private readonly ISupplierService _supplierService;
        private readonly ISupplierFilePatternService _supplierFilePatternService;
        private readonly ILogger<FileService> _logger;

        public FileService(
            IBillService billService,
            ISupplierService supplierService,
            ISupplierFilePatternService supplierFilePatternService,
            ILogger<FileService> logger)
        {
            _billService = billService;
            _supplierService = supplierService;
            _supplierFilePatternService = supplierFilePatternService;
            _logger = logger;
        }

        public async Task ProcessFile(string path)
        {
            try
            {
                if (!ValidateFile(path)) return;
                
                var fileName = Path.GetFileName(path);
                var fileExtensionString = Path.GetExtension(path);
                var fileExtension = (FileExtension)Enum.Parse(typeof(FileExtension), fileExtensionString);
                var supplier = _supplierService.FindByDocument(fileName);
                if (supplier == null)
                {
                    var message = "Fornecedor não encontrado";
                    _logger.LogError(message);

                    throw new Exception(message);
                }

                var filePattern = _supplierFilePatternService.GetSupplierFilePattern(supplier.Id, fileExtension);
                if (filePattern == null)
                {
                    var message = $"Padrão de arquivo {fileExtensionString} não cadastrado para o fornecedor {supplier.Id}";
                    _logger.LogError(message);

                    throw new Exception(message);
                }

                switch (fileExtension)
                {
                    case FileExtension.xls:
                        // TODO
                        break;
                    case FileExtension.csv:
                        await ProcessCsvFile(path, filePattern);
                        break;
                    case FileExtension.xml:
                        // TODO
                        break;
                    case FileExtension.pdf:
                        // TODO
                        break;
                    case FileExtension.json:
                        // TODO
                        break;
                    default:
                        break;
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro no processamento do arquivo");

                throw ex;
            }
        }

        private bool ValidateFile(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                var message = "Arquivo inválido";
                _logger.LogError(message);

                // TODO: create specific exception type
                throw new Exception(message);
            }

            if (!File.Exists(path))
            {
                var message = "Arquivo inexistente";
                _logger.LogError(message);

                throw new Exception(message);
            }

            var fileExtension = Path.GetExtension(path);
            if (string.IsNullOrEmpty(fileExtension) ||
                !Enum.IsDefined(typeof(FileExtension), fileExtension.ToLowerInvariant()))
            {
                var message = "Formato de arquivo inválido ou não suportado";
                _logger.LogError(message);

                throw new Exception(message);
            }

            return true;
        }

        public async Task ProcessCsvFile(string filePath, Dictionary<string, int> fieldsPattern)
        {
            // use third party solutions to small files
            // TODO: implement and substitute to FileReader to process larger files
            await Task.Run(() =>
            {
                var csvBillMapping = new CsvBillMapping();
                var bills = csvBillMapping.ParseFile(filePath, fieldsPattern);

                _billService.AddRange(bills);
            });
        }
    }
}
