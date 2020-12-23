using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManager.FileProcessor
{
    public class FileReader
    {
        public async Task ProcessFileAsync(string path)
        {
            await (Task.Run(() =>
            {
                using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (BufferedStream bs = new BufferedStream(fs))
                using (StreamReader sr = new StreamReader(bs))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        // TODO implement conversion to process large files
                    }
                }
            }));
        }
    }
}
