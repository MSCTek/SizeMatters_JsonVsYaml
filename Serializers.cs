using Newtonsoft.Json;
using SizeMatters.JsonVsYaml.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SizeMatters.JsonVsYaml
{
	public class Serializer
	{
		public static JsonSerializerSettings GetSerializerJsonOptimized()
		{
			return new JsonSerializerSettings()
			{
				Formatting = Formatting.None,
				ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
				NullValueHandling = NullValueHandling.Ignore,
				ContractResolver = IgnoreEmptyEnumerableContractResolver.Instance,
			};
		}

		public static JsonSerializerSettings GetSerializerJsonUnOptimized()
		{
			return new JsonSerializerSettings()
			{
				Formatting = Formatting.None,
				ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
				// NullValueHandling = NullValueHandling.Ignore,
				// ContractResolver = IgnoreEmptyEnumerableContractResolver.Instance,
			};
		}

		public static YamlDotNet.Serialization.ISerializer GetSerializerYamlOptimized()
		{
			return new YamlDotNet.Serialization.SerializerBuilder()
				.WithNamingConvention(new YamlDotNet.Serialization.NamingConventions.CamelCaseNamingConvention())
				.WithEmissionPhaseObjectGraphVisitor(args => new YamlIEnumerableSkipEmptyObjectGraphVisitor(args.InnerVisitor, args.TypeConverters, args.NestedObjectSerializer))
				.Build();
		}

		public static YamlDotNet.Serialization.ISerializer GetSerializerYamlUnOptimized()
		{
			return new YamlDotNet.Serialization.SerializerBuilder()
				.WithNamingConvention(new YamlDotNet.Serialization.NamingConventions.CamelCaseNamingConvention())
				// .WithEmissionPhaseObjectGraphVisitor(args => new YamlIEnumerableSkipEmptyObjectGraphVisitor(args.InnerVisitor, args.TypeConverters, args.NestedObjectSerializer))
				.Build();
		}

		public static string ToJson(object model, JsonSerializerSettings serializerSettings)
		{
			string json;

			json = JsonConvert.SerializeObject(model, serializerSettings);

			return json;
		}

		public static string ToYaml(object model, YamlDotNet.Serialization.ISerializer serializer)
		{
			string yaml;

			using (var memStream = new MemoryStream())
			{
				using (var streamWriter = new StreamWriter(memStream))
				{
					serializer.Serialize(streamWriter, model);
					streamWriter.Flush();
					// Convert stream to string
					memStream.Seek(0, SeekOrigin.Begin);
					StreamReader reader = new StreamReader(memStream);
					yaml = reader.ReadToEnd();
				}
			}

			return yaml;
		}

		/// <summary>
		/// Zips a string into a zipped byte array.
		/// </summary>
		/// <param name="textToZip">The text to be zipped.</param>
		/// <returns>byte[] representing a zipped stream</returns>
		public static void ZipUsingDotNetZip(string json, string yaml, string filePath)
		{
			using (Ionic.Zip.ZipFile zip = new Ionic.Zip.ZipFile())
			{
				zip.AddEntry("Superheroes.json", json);
				zip.AddEntry("Superheroes.yaml", yaml);
				zip.Save(filePath);
			}
		}

		/// <summary>
		/// Zips a string into a zipped byte array.
		/// </summary>
		/// <param name="textToZip">The text to be zipped.</param>
		/// <returns>byte[] representing a zipped stream</returns>
		public static void ZipUsingSystemIO(string json, string yaml, string filePath)
		{
			byte[] outputBuffer;

			using (var memoryStream = new MemoryStream())
			{
				using (var zipArchive = new System.IO.Compression.ZipArchive(memoryStream, System.IO.Compression.ZipArchiveMode.Create, true))
				{
					var jsonFile = zipArchive.CreateEntry("Superheroes.json");
					using (var jsonStream = jsonFile.Open())
					{
						using (var streamWriter = new StreamWriter(jsonStream))
						{
							streamWriter.Write(json);
						}
					}

					var yamlFile = zipArchive.CreateEntry("Superheroes.yaml");
					using (var yamlStream = yamlFile.Open())
					{
						using (var streamWriter = new StreamWriter(yamlStream))
						{
							streamWriter.Write(yaml);
						}
					}
				}

				outputBuffer = memoryStream.ToArray();
			}

			File.WriteAllBytes(filePath, outputBuffer);
		}
	}
}