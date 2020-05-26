using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeFilesApplication.ViewModel
{
    class MergeException : Exception
    {
        public override string Message { get; } = "Merge Exception: There are too much files added, Limit: 20 files";
    }
}
