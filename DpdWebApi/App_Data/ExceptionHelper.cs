using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace drug
{
    /// <summary>
    /// Summary description for ExceptionHelper
    /// </summary>


    // Create our own utility for exceptions
    public sealed class ExceptionHelper
    {
        // All methods are static, so this can be private
        private ExceptionHelper()
        { }

        // Log an Exception
        public static void LogException(Exception exc, string source)
        {
            string logFile = string.Empty;
            try
            {
                // filePath usually comes from the App.config file. I've written the value explicitly here for demo purposes.
                var filePath = HttpContext.Current.Server.MapPath("/logs");
                // Append a backslash if one is not present at the end of the file path.
                if (!filePath.EndsWith("\\"))
                {
                    filePath += "\\";
                }
                // Create the path if it doesn't exist.
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                logFile = string.Format("{0}{1:yyyyMMdd}.txt", filePath, DateTime.Now);

                if (!File.Exists(logFile)) //No File? Create
                {
                    FileStream fs = File.Create(logFile);
                    fs.Close();
                }

                // Open the log file for append and write the log
                using (System.IO.StreamWriter sw = new StreamWriter(logFile, true))
                {
                    sw.WriteLine("********** {0} **********", DateTime.Now.ToLongTimeString().ToString());
                    if (exc.InnerException != null)
                    {
                        sw.Write("Inner Exception Type: ");
                        sw.WriteLine(exc.InnerException.GetType().ToString());
                        sw.Write("Inner Exception: ");
                        sw.WriteLine(exc.InnerException.Message);
                        sw.Write("Inner Source: ");
                        sw.WriteLine(exc.InnerException.Source);
                        if (exc.InnerException.StackTrace != null)
                        {
                            sw.WriteLine("Inner Stack Trace: ");
                            sw.WriteLine(exc.InnerException.StackTrace);
                        }
                    }
                    sw.Write("Exception Type: ");
                    sw.WriteLine(exc.GetType().ToString());
                    sw.WriteLine("Exception: " + exc.Message);
                    sw.WriteLine("Source: " + source);
                    sw.WriteLine("Stack Trace: ");
                    if (exc.StackTrace != null)
                    {
                        sw.WriteLine(exc.StackTrace);
                        sw.WriteLine();
                    }

                    sw.Close();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
