using BertoniSolutionsTasks.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BertoniSolutionsTasks.Configurations
{
    class Config
    {
        public static string DBname = "database.db3";
        public static string dbPath = DependencyService.Get<IFileAccessHelper>().GetLocalFilePath(Config.DBname);
    }
}
