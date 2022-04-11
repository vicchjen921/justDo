using System;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace JustDo.DAL
{
	public class TasksManager : DALBase
	{
        public TasksManager(IConfiguration config) : base(config) {}

        public void AddTask(string name, string description, DateTime dueDateTime, int priority)
        {
            var selectCommand = (SqlCommand)null; 
            try
            {
                using (selectCommand = new SqlCommand(StoredProcedures.AddTask, this.Connection))
                {
                    selectCommand.CommandType = CommandType.StoredProcedure;
                    selectCommand.Parameters.Add(newParam("pName", name, SqlDbType.NVarChar));
                    selectCommand.Parameters.Add(newParam("pDescription", description, SqlDbType.Text));
                    selectCommand.Parameters.Add(newParam("pDueDateTime", dueDateTime, SqlDbType.DateTime));
                    selectCommand.Parameters.Add(newParam("pPriority", priority, SqlDbType.Int));
					OpenConnection();
					selectCommand.ExecuteNonQuery();
                }
            }
			finally
            {
                if (selectCommand != null)
                {
                    selectCommand.Dispose();
				}
                CloseConnection();
            }
        }

        public void UpdateTask(int id, string name, string description, DateTime? dueDateTime, int priority)
        {
            var selectCommand = (SqlCommand)null;
            try
            {
                using (selectCommand = new SqlCommand(StoredProcedures.UpdateTask, this.Connection))
                {
                    selectCommand.CommandType = CommandType.StoredProcedure;
                    selectCommand.Parameters.Add(newParam("pId", id, SqlDbType.BigInt));
                    selectCommand.Parameters.Add(newParam("pName", name, SqlDbType.NVarChar));
                    selectCommand.Parameters.Add(newParam("pDescription", description, SqlDbType.Text));
                    if(dueDateTime.HasValue)
                    selectCommand.Parameters.Add(newParam("pDueDateTime", dueDateTime.Value, SqlDbType.DateTime));
                    selectCommand.Parameters.Add(newParam("pPriority", priority, SqlDbType.Int));
                    OpenConnection();
                    selectCommand.ExecuteNonQuery();
                }
            }
            finally
            {
                if (selectCommand != null)
                {
                    selectCommand.Dispose();
                }
                CloseConnection();
            }
        }

        public void RemoveTask(int id)
        {
            var selectCommand = (SqlCommand)null;
            try
            {
                using (selectCommand = new SqlCommand(StoredProcedures.RemoveTask, this.Connection))
                {
                    selectCommand.CommandType = CommandType.StoredProcedure;
                    selectCommand.Parameters.Add(newParam("pId", id, SqlDbType.BigInt));
                    OpenConnection();
                    selectCommand.ExecuteNonQuery();
                }
            }
            finally
            {
                if (selectCommand != null)
                {
                    selectCommand.Dispose();
                }
                CloseConnection();
            }
        }

        public List<Models.Task> GetAllTasks()
        {
            var selectCommand = (SqlCommand)null;
            var tasks = new List<Models.Task>();
            var sqlDataReader = (IDataReader)null;
            try
            {
                using (selectCommand = new SqlCommand(StoredProcedures.GetAllTasks, this.Connection))
                {
                    selectCommand.CommandType = CommandType.StoredProcedure;
                    OpenConnection();
                    using (sqlDataReader = selectCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            var currentItem = new Models.Task();

                            currentItem.Id = Convert.ToInt32(sqlDataReader["Id"]);
                            currentItem.Name = sqlDataReader["Name"].ToString();
                            currentItem.Description = sqlDataReader["Description"].ToString();
                            currentItem.DueDateTime = Convert.ToDateTime(sqlDataReader["DueDatetime"]);
                            currentItem.Priority = Convert.ToInt32(sqlDataReader["Priority"]);

                            tasks.Add(currentItem);
                        }
                    }
                }
            }
            finally
            {
                if (selectCommand != null)
                {
                    selectCommand.Dispose();
                }
                CloseConnection();
            }
            return tasks;
        }
    }
}
