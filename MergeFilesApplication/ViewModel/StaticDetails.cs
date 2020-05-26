using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeFilesApplication.ViewModel
{
    public class StaticDetails
    {
        public static List<string> fileFormats { get; } = new List<string>() { "PDF", "TXT", "DOCX" };      
    }
}
