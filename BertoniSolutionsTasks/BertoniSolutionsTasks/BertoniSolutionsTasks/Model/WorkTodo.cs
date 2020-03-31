using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BertoniSolutionsTasks.Model
{
    [Table("WorkTodo")]
    public class WorkTodo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public bool Done { get; set; }
        public string Activity { get; set; }
    }
}
