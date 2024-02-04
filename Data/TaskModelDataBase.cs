using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Model;

namespace Tasks.Data
{
    public class TaskModelDataBase
    {
        SQLiteAsyncConnection Database;

        public TaskModelDataBase()
        {

        }

        async Task Init() 
        {
            if (Database is not null) 
            {
                return;
            }

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var result = await Database.CreateTableAsync<TaskModel>();
        }

        public async Task<List<TaskModel>> getAllTasks()
        {
            await Init();
            return await Database.Table<TaskModel>().ToListAsync();
        }

        public async Task<TaskModel> getTaskById(int taskId)
        {
            await Init();
            return await Database.Table<TaskModel>().Where(t=> t.Id == taskId).FirstOrDefaultAsync();
        }

        public async Task<int> AddOrUpdateTaskModelAsync(TaskModel task) 
        {
            await Init();
            if (task.Id != 0)
            {
                return await Database.UpdateAsync(task);
            }
            else 
            {
                return await Database.InsertAsync(task);
            }
        }

        public async Task<int> removeTask(TaskModel task)
        {
            await Init();
           return await Database.DeleteAsync(task);
        }

    }
}
