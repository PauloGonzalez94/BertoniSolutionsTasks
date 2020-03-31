using BertoniSolutionsTasks.Configurations;
using BertoniSolutionsTasks.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BertoniSolutionsTasks.Repository
{
    class TaskRepository
    {
        SQLiteAsyncConnection conn;
        public string StatusMessage { get; set; }
        public static TaskRepository shared = new TaskRepository();

        public TaskRepository()
        {
            conn = new SQLiteAsyncConnection(Config.dbPath);
            conn.CreateTableAsync<WorkTodo>().Wait();

        }

        public async Task<int> GetLastId()
        {
            try
            {
                var data = await conn.Table<WorkTodo>().OrderByDescending(x => x.Id).FirstOrDefaultAsync();
                return data.Id + 1;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }
            return 0;
        }

        public async Task<bool> AddWorkToDo(WorkTodo data)
        {
            data.Id = await this.GetLastId();
            if (await conn.InsertOrReplaceAsync(data) == 1)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateWorkToDo(WorkTodo data)
        {
            if (await conn.UpdateAsync(data) == 1)
            {
                return true;
            }
            return false;
        }



        public async Task<bool> DeleteWordToDo(WorkTodo data)
        {
            //await conn.DropTableAsync<Casa>();
            //conn.CreateTableAsync<Casa>().Wait();

            if (await conn.DeleteAsync(data) == 1)
            {
                return true;
            }
            return false;
        }

        public async Task<List<WorkTodo>> GetWorkToDo()
        {
            try
            {
                var data = await conn.Table<WorkTodo>().ToListAsync();
                return data;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }
            return new List<WorkTodo>();
        }

        public async Task<WorkTodo> GetWorkToDoFromId(int id)
        {
            try
            {
                var data = await conn.Table<WorkTodo>().Where(x => x.Id == id).FirstOrDefaultAsync();
                return data;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }
            return new WorkTodo();
        }
    }
}
