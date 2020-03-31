using System;
using System.Collections.Generic;
using System.Text;

namespace BertoniSolutionsTasks.Interfaces
{
    public interface IFileAccessHelper
    {
        string GetLocalFilePath();
        string GetLocalFilePath(string fileName);
    }
}
