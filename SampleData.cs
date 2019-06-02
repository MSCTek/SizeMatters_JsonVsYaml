using SizeMatters.JsonVsYaml.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SizeMatters.JsonVsYaml
{
	public static class SampleData
	{
		private static Random _random = new Random(DateTime.Now.Millisecond);

		public static List<string> GetRandomNumberOfLines(int min = 0, int max = 1000)
		{
			var retVal = new List<string>();
			int randomNumber = _random.Next(min, max);

			for (int i = 0; i < randomNumber; i++)
			{
				retVal.Add($"Sample Movie Line: {i}");
			}

			return retVal;
		}

		public static List<Movie> GetRandomNumberOfMovies(int min = 0, int max = 3)
		{
			var retVal = new List<Movie>();
			int randomNumber = _random.Next(min, max);

			for (int i = 0; i < randomNumber; i++)
			{
				retVal.Add(new Movie()
				{
					Id = Guid.NewGuid(),
					Name = $"Sample Movie: {i}"
				});
			}

			return retVal;
		}

		public static List<SuperHero> GetSuperHeroes()
		{
			var retVal = new List<SuperHero>();

			retVal.Add(new SuperHero()
			{
				Eyes = "Blue",
				Hair = "Black",
				Id = new Guid("E45CA654-C183-4D8C-A3EC-32B8D6EB5C16"),
				Name = "Batman",
				Sex = "Male"
			});

			retVal.Add(new SuperHero()
			{
				Eyes = "Blue",
				Hair = "Black",
				Id = new Guid("A953B6E3-63C1-43DA-88E0-E37CE45B0AC3"),
				Name = "Wonder Woman",
				Sex = "Female"
			});

			retVal.Add(new SuperHero()
			{
				Eyes = "",
				Hair = "",
				Id = new Guid("B4F5C3C4-BAEF-4609-B1EC-5E43F3D9F1E9"),
				Name = "",
				Sex = ""
			});

			retVal.Add(new SuperHero()
			{
				Eyes = "Blue",
				Hair = "Blonde",
				Id = new Guid("679EBB77-69F2-451A-A34C-7FD6A522B92F"),
				Name = "Aquaman",
				Sex = "Male"
			});

			retVal.Add(new SuperHero()
			{
				Eyes = "Blue",
				Hair = "Black",
				Id = new Guid("8044BACD-8C64-42E6-9E99-2422BC4A64DD"),
				Name = "Lois Lane",
				Sex = "Female"
			});

			retVal.Add(new SuperHero()
			{
				Eyes = "Green",
				Hair = "Green",
				Id = new Guid("ED89E202-6DB3-4C30-991B-DA80D94A3B53"),
				Name = "Beast Boy",
				Sex = "Male"
			});

			retVal.Add(new SuperHero()
			{
				Eyes = "Blue",
				Hair = "Black",
				Id = new Guid("F22F056D-59FD-4EB1-8F04-2818DCE1B840"),
				Name = "Catwoman",
				Sex = "Female"
			});

			retVal.Add(new SuperHero()
			{
				Eyes = "Green",
				Hair = "Red",
				Id = new Guid("9176EE16-B5AF-47FE-A4F5-C110782FC56A"),
				Name = "Flash",
				Sex = "Male"
			});

			retVal.Add(new SuperHero()
			{
				Eyes = "Blue",
				Hair = "Black",
				Id = new Guid("9176EE16-B5AF-47FE-A4F5-C110782FC56A"),
				Name = "Starfire",
				Sex = "Female"
			});

			return retVal;
		}
	}
}