using SizeMatters.JsonVsYaml.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace SizeMatters.JsonVsYaml
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			var superHeroes = PopulateSuperHeroesWithSampleData(10);

			// Force several collection to be null for testing purposes.
			for (int i = 0; i < superHeroes.Count; i++)
			{
				if (i % 2 == 0) // Empty the Movies collection
					superHeroes[i].Movies.Clear();
				else
				{
					for (int j = 0; j < superHeroes[i].Movies.Count; j++)
					{
						if (j % 2 == 0) // Empty the Lines collection
							superHeroes[i].Movies[j].Lines.Clear();
					}
				}
			}

			SaveData(superHeroes);

			System.Console.ReadKey();
		}

		private static List<SuperHero> PopulateSuperHeroesWithSampleData(int numberOfSetsToPopulate = 1)
		{
			var retVal = new List<SuperHero>();

			for (int i = 0; i < numberOfSetsToPopulate; i++)
			{
				retVal.AddRange(SampleData.GetSuperHeroes());
			}

			foreach (var superHero in retVal)
			{
				superHero.Movies = SampleData.GetRandomNumberOfMovies(min: 0, max: 3);
				foreach (var movie in superHero.Movies)
				{
					movie.Lines = SampleData.GetRandomNumberOfLines(min: 10, max: 1000);
				}
			}

			return retVal;
		}

		private static void SaveData(List<SuperHero> superHeroes)
		{
			FileInfo fiDotNetZip = new FileInfo(Path.Combine(Environment.CurrentDirectory, "dotNetZip.zip"));
			FileInfo fiSystemIoCompression = new FileInfo(Path.Combine(Environment.CurrentDirectory, "systemIoCompression.zip"));

			string optimizedJson = Serializer.ToJson(superHeroes, Serializer.GetSerializerJsonOptimized());
			string optimizedYaml = Serializer.ToYaml(superHeroes, Serializer.GetSerializerYamlOptimized());

			Console.WriteLine($"\n\tOptimized JSON:\t\t{String.Format("{0:#,##0}", optimizedJson.Length)}");
			Console.WriteLine($"\tOptimized YAML:\t\t{String.Format("{0:#,##0}", optimizedYaml.Length)}");

			string unOptimizedJson = Serializer.ToJson(superHeroes, Serializer.GetSerializerJsonUnOptimized());
			string unOptimizedYaml = Serializer.ToYaml(superHeroes, Serializer.GetSerializerYamlUnOptimized());

			Console.WriteLine($"\n\tUnoptimized JSON:\t{String.Format("{0:#,##0}", unOptimizedJson.Length)}");
			Console.WriteLine($"\tUnoptimized YAML:\t{String.Format("{0:#,##0}", unOptimizedYaml.Length)}");

			Serializer.ZipUsingDotNetZip(json: optimizedJson, yaml: optimizedYaml, filePath: fiDotNetZip.FullName);
			Serializer.ZipUsingSystemIO(json: optimizedJson, yaml: optimizedYaml, filePath: fiSystemIoCompression.FullName);

			Console.WriteLine($"\n\tFile Size DotNetZip:\t{String.Format("{0:#,##0}", fiDotNetZip.Length)}");
			Console.WriteLine($"\tSystem.Io.Compression:\t{String.Format("{0:#,##0}", fiSystemIoCompression.Length)}");
		}
	}
}