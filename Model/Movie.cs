using System;
using System.Collections.Generic;
using System.Text;

namespace SizeMatters.JsonVsYaml.Model
{
	public class Movie
	{
		public Guid Id { get; set; } = new Guid();
		public List<string> Lines { get; set; }
		public string Name { get; set; }
	}
}