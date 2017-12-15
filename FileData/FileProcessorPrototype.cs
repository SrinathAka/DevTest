using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdPartyTools;

namespace FileData
{
   public class FileProcessorPrototype : IFileProcessor
    {
        public FileProcessorPrototype() { }
        public  bool ProcessFile(string[] args)
        {
            if (args.Length != 2) return false;
            if (args[0] != "-v") return false;
            var fileDetails = new FileDetails().Version(args[1]);
            Console.WriteLine(fileDetails);
            Console.ReadLine();
            return true;
        }
    }
}
