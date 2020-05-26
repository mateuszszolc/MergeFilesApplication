using OpenXmlPowerTools;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeFilesApplication.ViewModel
{
    public class MergeHelper
    {
        public static double ConvertBytesToMegabytes(double fileSize)
        {
            fileSize *= 0.000001;

            return fileSize;
        }

        public static void AddByteArrayOfEachFile(List<string> source, ref List<byte[]> outcome)
        {
            for(int i = 0; i < source.Count; i++)
            {
                outcome.Add(File.ReadAllBytes(source[i]));
            }
        }

        public static byte[] MergePdfs(List<byte[]> pdfs)
        {
            List<PdfDocument> pdfDocuments = new List<PdfDocument>();

            foreach(var pdf in pdfs)
            {
                pdfDocuments.Add(PdfReader.Open(new MemoryStream(pdf), PdfDocumentOpenMode.Import));
            }

            using(PdfDocument outcomePdf = new PdfDocument())
            {
                for(int i = 0; i < pdfDocuments.Count; i++)
                {
                    foreach(PdfPage page in pdfDocuments[i].Pages)
                    {
                        outcomePdf.AddPage(page);
                    }
                }

                MemoryStream memoryStream = new MemoryStream();
                outcomePdf.Save(memoryStream, false);
                byte[] pdfDocumentToByteArray = memoryStream.ToArray();

                return pdfDocumentToByteArray;
            }
        }

        public static void TxtMerge(string path, List<string> txtFiles)
        {
            var outcome = txtFiles.SelectMany(f => File.ReadAllLines(Path.Combine(string.Empty, f))).ToList();

            using(TextWriter textWriter = new StreamWriter(path))
            {
                foreach(var line in outcome)
                {
                    textWriter.WriteLine(line);
                }
                
            }
        }
        
        public static byte[] DocxMerge(List<byte[]> docxs)
        {
            List<Source> sources = new List<Source>();
            foreach(var docx in docxs)
            {
                sources.Add(new Source(new WmlDocument(string.Empty, docx), false));
            }

            WmlDocument mergedDocx = DocumentBuilder.BuildDocument(sources);
            return mergedDocx.DocumentByteArray;
        }

    }
}
