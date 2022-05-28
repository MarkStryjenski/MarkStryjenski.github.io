using IronPdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PDFConvertor
{
    // For this PDFConverter to work, first run the FolderGenerator. Once that is done, put the images inside of 'C:\Orders\0931617841_13_05_22', after that run PDFConverter.
    class PDFConvertor
    {
        static void Main(string[] args) // folder name, paid/unpaid, where to store
        {

            //  Temp block of code for debugging  //

            if (args.Length != 0)
            {
                string dir = @"\" + args[0];
                Directory.SetCurrentDirectory(@"C:\Orders" + dir);
            }
            else
            {
                Directory.SetCurrentDirectory(@"C:\Orders\0931617841_13_05_22");
            }

            //  End of temp block   //


            IronPdf.License.LicenseKey = "IRONPDF.STUDENTNHLSTENDENCOM.963-A50434F242-IAJAKP3S7EPMT-HOGLPLPHC5WK-IGCSUEUP4HMY-NJCQKCLLBAGW-SW46OGPN5RS5-UABKG4-TWGEWFF4FUSFUA-DEPLOYMENT.TRIAL-7QNMF6.TRIAL.EXPIRES.03.JUN.2022";
            var ImageFiles = Directory.EnumerateFiles(Directory.GetCurrentDirectory()).Where(f => f.EndsWith(".jpg") || f.EndsWith(".JPG") || f.EndsWith(".jpeg") || f.EndsWith(".jfif"));

            List<string> images = ImageFiles.ToList();

            PdfDocument[] documents = new PdfDocument[images.Count()];

            for (int i = 0; i < images.Count(); i++)
            {
                Console.WriteLine(images[i]);
                documents[i] = ImageToPdfConverter.ImageToPdf(images[i], IronPdf.Imaging.ImageBehavior.FitToPageAndMaintainAspectRatio);
            }

            List<PdfDocument> docsToMerge = new List<PdfDocument>();

            if (File.Exists("parameters.csv"))
            {
                TextReader reader = File.OpenText("parameters.csv");
                string line = reader.ReadLine();
                string[] parameters = line.Split(',');

                foreach (var param in parameters)
                {
                    Console.WriteLine(param);
                }

                for (int i = 0; i < images.Count(); i++)
                {
                    if (parameters.Contains("blank_" + i)) //Format for blank parameter: blank_1
                    {
                        docsToMerge.Add(addBlankPage("blank_" + i, documents));
                    }
                    else
                    {
                        docsToMerge.Add(documents[i]);
                    }
                }

                PdfDocument composite = PdfDocument.Merge(docsToMerge.AsEnumerable<PdfDocument>()).SaveAs(Directory.GetCurrentDirectory() + "/composite.pdf");

            }
            else
            {
                ImageToPdfConverter.ImageToPdf(ImageFiles, IronPdf.Imaging.ImageBehavior.FitToPageAndMaintainAspectRatio).SaveAs(Directory.GetCurrentDirectory() + "/composite.pdf");
            }


        }

        public static PdfDocument addBlankPage(string parameter, PdfDocument[] documents)
        {

            PdfDocument blankPdf = PdfDocument.FromFile(@"C:\Orders\blankPage.pdf");

            string[] parameters = parameter.Split('_');

            int pageNr = Convert.ToInt32(parameters[1]);

            return PdfDocument.Merge(documents[pageNr], blankPdf);

        }
    }
}
