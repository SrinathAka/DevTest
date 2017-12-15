using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using log4net;
using log4net.Config;

namespace FileData
{
    public static class Program
    {
        private static readonly ILog Log;
        private static readonly IFileProcessor FileProcessorPrototype = new FileProcessorPrototype();
        private static readonly IFileProcessor FileProcessor = new FileProcessor(GetValidVersions(),GetValidSizes());

        static Program()
        {
            XmlConfigurator.Configure();
            Log = LogManager.GetLogger(typeof(Program));
        }
        public static void Main(string[] args)
        {
            try
            {
                //Task1 below has started as a prototype and hence been commented 
                //Please uncomment the Task1 region to run the prototype/POC
                #region Task1 Prototype/Proof of Concept
                //if (FileProcessorPrototype.ProcessFile(args))
                //{
                //    Log.Debug("File Processing Completed Successfully");
                //    return;
                //}
                #endregion
                #region Task2 Complete File Processing
                if (FileProcessor.ProcessFile(args))
                {
                    Log.Debug("File Processing Completed Successfully");
                    return;
                }
                #endregion
                Log.Debug("Unable to Process the arguments");
            }
            catch (Exception exception)
            {
                Log.Debug("File Processing Failed");
                Log.Error(exception.Message);
                throw;
            }
            

        }

        #region Private Methods
        private static List<string> GetValidVersions()
        {
            var versions = ConfigurationManager.AppSettings["Versions"].Split(' ');
            return versions.ToList();
        }

        private static List<string> GetValidSizes()
        {
            var sizes = ConfigurationManager.AppSettings["Sizes"].Split(' ');
            return sizes.ToList();
        }

        #endregion
    }
}
