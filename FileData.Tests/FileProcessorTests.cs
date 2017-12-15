using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileData.Tests
{
    [TestClass]
   public class FileProcessorTests
    {
        private readonly List<string> _validVersions = new List<string>
            {"-v","--v","/v","--version"};


        
        private readonly List<string> _validSizes = new List<string>
          { "-s", "--s", "/s", "--size" };
        
        private readonly string[] validVersionArgs = new[]
        {
            "-v",
            "C:/test.txt"
        };
        private readonly string[] _inValidVersionArgs = new[]
            {
                "v",
                "C:/test.txt"

            };
        private readonly string[] validSizeArgs = new[]
        {
            "--size",
            "C:/test.txt"
        };
        private readonly string[] _inValidSizeArgs = new[]
            {
                "s",
               "C:/test.txt"
            };
        private  IFileProcessor _fileProcessor;
        [TestInitialize]
        public void TestInitialise()
        {
            _fileProcessor = new FileProcessor(_validVersions, _validSizes);
        }
        [TestMethod]
        public void ensure_all_valid_versions_are_accepted()
        {
            var isValid = _fileProcessor.ProcessFile(validVersionArgs);
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void ensure_all_inValid_versions_return_false()
        {
            Assert.IsFalse(_fileProcessor.ProcessFile(_inValidVersionArgs));
        }

        [TestMethod]
        public void ensure_all_valid_sizes_are_accepted()
        {
            var isValid = _fileProcessor.ProcessFile(validSizeArgs);
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void ensure_all_inValid_sizes_return_false()
        {
            Assert.IsFalse(_fileProcessor.ProcessFile(_inValidSizeArgs));
        }
    }
}
