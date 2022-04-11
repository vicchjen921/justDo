using JustDo.Models;
using System.Collections.Generic;

namespace JustDo.DTO
{
	public class ApiBaseDTO
	{
		public List<string> Errors { get; set; }
	}

	public class AddTaskDTO : ApiBaseDTO { }

	public class UpdateTaskDTO : ApiBaseDTO { }

	public class RemoveTaskDTO : ApiBaseDTO { }

	public class GetAllTasksDTO : ApiBaseDTO {
		public List<Task> Tasks { get; set; }
	}
}
