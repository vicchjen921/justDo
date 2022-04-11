using System;

namespace JustDo.Models
{
	public class Task
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime? DueDateTime { get; set; }
		public int Priority { get; set; }
	}
}
