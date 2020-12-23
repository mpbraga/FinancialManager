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
            await (Task.Run(() => // Run tasks to proccess multiple files async
            {
                using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (BufferedStream bs = new BufferedStream(fs))
                using (StreamReader sr = new StreamReader(bs)) // use StreamReader for performance
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        // TODO implement conversion to process large files
                        // Process lines and save, dont return lists or it will run out of memory
                    }
                }
            }));
        }
    }
}
