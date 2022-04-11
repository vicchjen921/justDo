using JustDo.DTO;
using JustDo.Models;
using JustDo.Services;
using Microsoft.AspNetCore.Mvc;

namespace JustDo.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TasksController : ControllerBase
	{
		private readonly ITaskService _taskService;

		public TasksController(ITaskService taskService)
		{
			_taskService = taskService;
		}

		[HttpPost]
		[Route("add")]
		public AddTaskDTO AddTask(Task input)
		{
			return _taskService.AddTask(input);
		}

		[HttpGet]
		public GetAllTasksDTO GetAllTasks()
		{
			return _taskService.GetAllTasks();
		}

		[HttpPost]
		[Route("update")]
		public UpdateTaskDTO UpdateTask(Task input)
		{
			return _taskService.UpdateTask(input);
		}

		[HttpDelete]
		[Route("remove")]
		public RemoveTaskDTO RemoveTask(int id)
		{
			return _taskService.RemoveTask(id);
		}
	}
}
