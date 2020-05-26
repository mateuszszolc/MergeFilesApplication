using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeFilesApplication.ViewModel
{
    class FileNameException : Exception
    {
        public override string Message { get; } = "File with the same name has already been added";
    }
}
