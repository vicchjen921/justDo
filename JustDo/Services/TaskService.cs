using JustDo.DAL;
using JustDo.DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace JustDo.Services
{
	public class TaskService : ITaskService
	{
		private readonly TasksManager _taskManager;

		public TaskService(IConfiguration config) 
		{
			if (_taskManager == null)
				_taskManager = new TasksManager(config);
		}

		AddTaskDTO ITaskService.AddTask(Models.Task task)
		{
			var taskDTO = new AddTaskDTO();
			try
			{
				_taskManager.AddTask(task.Name, task.Description, task.DueDateTime.Value, task.Priority);
			}
			catch(Exception)
			{
				taskDTO.Errors = new List<string>();
				taskDTO.Errors.Add("Something went wrong. Please try again later.");
			}
			return taskDTO;
		}

		GetAllTasksDTO ITaskService.GetAllTasks()
		{
			var taskDTO = new GetAllTasksDTO();
			try
			{
				var tasks = _taskManager.GetAllTasks();
				taskDTO.Tasks = tasks;				
			}
			catch (Exception)
			{
				taskDTO.Errors = new List<string>();
				taskDTO.Errors.Add("Something went wrong. Please try again later.");
			}
			return taskDTO;
		}

		RemoveTaskDTO ITaskService.RemoveTask(int id)
		{
			var taskDTO = new RemoveTaskDTO();
			try
			{
				_taskManager.RemoveTask(id);
			}
			catch (Exception)
			{
				taskDTO.Errors = new List<string>();
				taskDTO.Errors.Add("Something went wrong. Please try again later.");
			}
			return taskDTO;
		}

		UpdateTaskDTO ITaskService.UpdateTask(Models.Task task)
		{
			var taskDTO = new UpdateTaskDTO();
			try
			{
				if(task.Id < 0)
				{
					taskDTO.Errors.Add("Incorrect task Id provided");
					return taskDTO;
				}
				_taskManager.UpdateTask(task.Id, task.Name, task.Description, task.DueDateTime, task.Priority);
			}
			catch (Exception)
			{
				taskDTO.Errors = new List<string>();
				taskDTO.Errors.Add("Something went wrong. Please try again later.");
			}
			return taskDTO;
		}
	}
}
