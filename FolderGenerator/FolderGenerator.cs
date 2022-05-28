using System;
using System.IO;

namespace FolderGenerator
{
    class FolderGenerator
    {
        static void Main(string[] args)
        {

            Directory.SetCurrentDirectory(@"C:\Orders");

            string folderName;

            if (args.Length != 0)
            {
                folderName = @"\" + args[0];
            }
            else
            {
                folderName = @"\0931617841_13_05_22";
            }


            if (Directory.Exists(Directory.GetCurrentDirectory() + folderName))
            {
                Console.WriteLine("That path exists already.");
                return;
            }
            else
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + folderName);
                Console.WriteLine(folderName.Substring(1) + " directory has been created.");
            }

            //Delete functionality//

            //Directory.Delete(Directory.GetCurrentDirectory() + folderName);

            //End of delete//

            
        }
    }
}
