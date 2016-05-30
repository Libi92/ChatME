using System;
using System.IO;
using System.Reflection;

namespace ChatME.DataLayer
{
    /// <summary>
    /// Summary description for WriteToLog.
    /// </summary>
    public class Logger
    {

        public Logger()
        {

        }

        /// <summary>
        /// Writes the error message to the Log file.
        /// 
        /// 1. Creates a logs folder
        /// 2. Creates a log file with current date
        /// 3. Writes the error message to the log file
        /// </summary>
        /// <param name="Namespace">string - Namespace</param>
        /// <param name="Classfile">string - Class from which the error is generated</param>
        /// <param name="Method">string - Method from which the error is generated</param>
        /// <param name="message">string - Error Message</param>
        public static void WriteToLog(string Namespace, string Classfile, string Method, string message)
        {
            StreamWriter objStreamWriter;
            string logPath;

            // Map to Uploads folder
            string folderPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\";
            folderPath = folderPath.Replace("file:\\", "");
            folderPath += "..\\";

            try
            {
                if (!Directory.Exists(folderPath + "Logs")) // Logs folder not found under Uploads folder
                {
                    Directory.CreateDirectory(folderPath + "Logs"); // Create logs folder
                }


                // Log file with current date
                logPath = folderPath + "Logs\\Log " + System.DateTime.Now.Day + "-" + System.DateTime.Now.Month + "-" + System.DateTime.Now.Year + ".txt";

                FileInfo Errorfile = new FileInfo(logPath);

                if (Errorfile.Exists) // Check for existance
                {
                    objStreamWriter = Errorfile.AppendText();

                }
                else
                {
                    objStreamWriter = Errorfile.CreateText();
                }

                // Write the message to log file
                objStreamWriter.WriteLine(System.DateTime.Now.ToString() + " " + " - " + " Namespace : " + Namespace + " ");
                objStreamWriter.WriteLine();
                objStreamWriter.WriteLine("Error Description :- ");
                objStreamWriter.WriteLine();
                objStreamWriter.WriteLine(message);
                objStreamWriter.WriteLine();
                objStreamWriter.WriteLine("Class :- " + Classfile + " : " + Method);
                objStreamWriter.WriteLine();
                objStreamWriter.WriteLine("------------------------------------------------------------------");
                objStreamWriter.WriteLine();
                objStreamWriter.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        public static void WriteTrace(string message, bool includeHr)
        {
            StreamWriter objStreamWriter;
            string logPath;
            string folderPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\";
            folderPath = folderPath.Replace("file:\\", "");
            folderPath += "..\\";

            try
            {
                if (!Directory.Exists(folderPath + "Logs")) // Logs folder not found under Uploads folder
                {
                    Directory.CreateDirectory(folderPath + "Logs"); // Create logs folder
                }

                // Log file with current date
                logPath = folderPath + "Logs\\Trace " + System.DateTime.Now.Month + ".txt";
                FileInfo fileInfo = new FileInfo(logPath);
                if (fileInfo.Exists)
                {
                    objStreamWriter = fileInfo.AppendText();
                }
                else
                {
                    objStreamWriter = fileInfo.CreateText();
                }
                objStreamWriter.WriteLine(message + "   Date=" + DateTime.Now.ToLongDateString() + "  Time=" + DateTime.Now.ToLongTimeString());
                if (includeHr)
                {
                    objStreamWriter.WriteLine("_____________________________________________________________________________");
                    objStreamWriter.WriteLine(" ");
                }
                objStreamWriter.Flush();
                objStreamWriter.Close();
            }
            catch (Exception ex)
            {
                MethodBase currentMethod = MethodBase.GetCurrentMethod();
                Logger.WriteToLog(currentMethod.DeclaringType.Namespace, currentMethod.DeclaringType.Name, currentMethod.Name, ex.ToString());
            }
        }


        /// <summary>
        /// Writes the Page Execution time to the Log file.
        /// 
        /// 1. Creates a logs folder
        /// 2. Creates a log file with current date
        /// 3. Writes the error message to the log file
        /// </summary>
        /// <param name="Namespace">string - Namespace</param>
        /// <param name="Classfile">string - Class from which the error is generated</param>
        /// <param name="Method">string - Method from which the error is generated</param>
        /// <param name="message">string - Error Message</param>
        public static void LogPageExecutionTime(string requestFile, string beginRequestTime, string timeElapsed)
        {
            StreamWriter objStreamWriter;
            string logPath;

            // Map to Uploads folder
            string folderPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\";
            folderPath = folderPath.Replace("file:\\", "");
            folderPath += "..\\";

            try
            {
                if (!Directory.Exists(folderPath + "Logs")) // Logs folder not found under Uploads folder
                {
                    Directory.CreateDirectory(folderPath + "Logs"); // Create logs folder
                }


                // Log file with current date
                logPath = folderPath + "Logs\\PageExecutionTime_" + System.DateTime.Now.Day + "-" + System.DateTime.Now.Month + "-" + System.DateTime.Now.Year + ".txt";

                FileInfo logFile = new FileInfo(logPath);

                if (logFile.Exists) // Check for existance
                {
                    objStreamWriter = logFile.AppendText();

                }
                else
                {
                    objStreamWriter = logFile.CreateText();
                }

                // Write the message to log file
                objStreamWriter.WriteLine(timeElapsed + " \t: " + beginRequestTime + " \t: " + requestFile + " ");
                objStreamWriter.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

    }
}
