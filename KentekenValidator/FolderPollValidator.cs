using KentekenValidator.LicenseValidators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace KentekenValidator
{
	public class FolderPollValidator : List<IValidator>
	{
		private readonly DirectoryInfo _outFolder;
		private readonly DirectoryInfo _inFolder;

		public FolderPollValidator(string inFolder, string outFolder)
		{
			this._inFolder = new DirectoryInfo(inFolder);
			this._outFolder = new DirectoryInfo(outFolder);
		}
		
		public void Start()
		{
			while (true)
			{
				FileInfo infile = GetNextFile(this._inFolder, TimeSpan.FromSeconds(5));

				var resultList = new List<string>();
				foreach (var line in File.ReadLines(infile.FullName))
				{
					var result = this.Any(validator => validator.Validate(line));
					resultList.Add(line + '\t' + result);
				}

				var newName = Path.Combine(_outFolder.FullName, infile.Name);
				infile.MoveTo(newName);
				File.WriteAllLines(newName + ".validated", resultList);
			} 
		}

		private static FileInfo GetNextFile(DirectoryInfo inFolder, TimeSpan waitTime)
		{
			while (!inFolder.EnumerateFiles().Any())
				Thread.Sleep(waitTime);
			return inFolder.EnumerateFiles().FirstOrDefault();
		}
		
	}
}