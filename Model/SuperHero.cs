using System;
using System.Collections.Generic;
using System.Text;

namespace SizeMatters.JsonVsYaml.Model
{
	public class SuperHero
	{
		public string Eyes { get; set; }
		public string Hair { get; set; }
		public Guid Id { get; set; } = new Guid();
		public List<Movie> Movies { get; set; } = new List<Movie>();
		public string Name { get; set; }
		public string Sex { get; set; }
		public List<string> ZDummyEmptyCollection0 { get; set; } = new List<string>();
		public List<string> ZDummyEmptyCollection1 { get; set; } = new List<string>();
		public List<string> ZDummyEmptyCollection2 { get; set; } = new List<string>();
		public List<string> ZDummyEmptyCollection3 { get; set; } = new List<string>();
		public List<string> ZDummyEmptyCollection4 { get; set; } = new List<string>();
		public List<string> ZDummyEmptyCollection5 { get; set; } = new List<string>();
		public List<string> ZDummyEmptyCollection6 { get; set; } = new List<string>();
		public List<string> ZDummyEmptyCollection7 { get; set; } = new List<string>();
		public List<string> ZDummyEmptyCollection8 { get; set; } = new List<string>();
		public List<string> ZDummyEmptyCollection9 { get; set; } = new List<string>();
	}
}