using System.Collections.Generic;
using log4net;
using ThirdPartyTools;

namespace FileData
{
    public class FileProcessor : IFileProcessor
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(FileProcessor));
        private readonly List<string> _fileVersions;
        private readonly List<string> _fileSizes;
        public FileProcessor(List<string> fileVersions, List<string> fileSizes)
        {
            _fileVersions = fileVersions;
            _fileSizes = fileSizes;
        }
        public bool ProcessFile(string[] args)
        {
            Log.Debug("File Processing Started..");
            if (args.Length != 2) return false;
            if (_fileVersions.Exists(x => x == args[0]))
            {
                Log.Debug("Argument is of type 'Version'");
                var versionDetails = new FileDetails().Version(args[1]);
                Log.Debug($"Version {versionDetails} retrived");
                return true;
            }
            if (!_fileSizes.Exists(x => x == args[0])) return false;
            {
                Log.Debug("Argument is of type 'Size'");
                var sizeDetails = new FileDetails().Size(args[1]);
                Log.Debug($"Size {sizeDetails} retrived");
                return true;
            }
        }
    }
}
