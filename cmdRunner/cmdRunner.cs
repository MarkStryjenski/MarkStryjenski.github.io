using System;
using System.Diagnostics;
using System.IO;

namespace cmdRunner
{
    class cmdRunner
    {

        static string folderName = "demo";

        static void Main(string[] args)
        {
            
            string dirFolderGen = @"C:\Users\vlad_ataman\source\repos\WhatsUpPDF\FolderGenerator\bin\Debug\net5.0";

            string dirPdfConv = @"C:\Users\vlad_ataman\source\repos\WhatsUpPDF\PDFConvertor\bin\Debug\net5.0";

            Process procGen = Process.Start(dirFolderGen + @"\FolderGenerator.exe", folderName);

            Console.WriteLine(procGen.Id);

            Process procConv = Process.Start(dirPdfConv + @"\PDFConvertor.exe", folderName);

            Console.WriteLine(procConv.Id);
        }
    }
}
