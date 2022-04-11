using JustDo.DTO;
using JustDo.Models;

namespace JustDo.Services
{
	public interface ITaskService
	{		
		GetAllTasksDTO GetAllTasks();
		AddTaskDTO AddTask(Task task);
		UpdateTaskDTO UpdateTask(Task task);
		RemoveTaskDTO RemoveTask(int id);
	}
}
