using FinancialManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCsvParser;
using TinyCsvParser.Mapping;

namespace FinancialManager.FileProcessor
{
    public class CsvBillMapping : CsvMapping<Bill>
    {
        public CsvBillMapping()
        {
            //MapProperty(0, x => x.Description);
            //MapProperty(1, x => x.Type);
            //MapProperty(2, x => x.DueDate);
            //MapProperty(3, x => x.BillingValue);
            //MapProperty(4, x => x.PaymentDate);
            //MapProperty(5, x => x.AmountPayed);
        }

        public IEnumerable<Bill> ParseFile(string filePath, Dictionary<string, int> fieldsPattern)
        {
            var results = new List<Bill>();

            MapProperties(fieldsPattern);

            CsvParserOptions csvParserOptions = new CsvParserOptions(true, ',');
            var csvParser = new CsvParser<Bill>(csvParserOptions, this);
            var records = csvParser.ReadFromFile(filePath, Encoding.UTF8);

            foreach (var record in records)
            {
                results.Add(record.Result);
            }

            return results;
        }

        private void MapProperties(Dictionary<string, int> fieldsPattern)
        {
            foreach (var fieldPattern in fieldsPattern)
            {
                MapProperty(fieldPattern.Value, x => x.GetType().GetProperty(fieldPattern.Key));
            }
        }
    }
}
