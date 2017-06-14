using System.Configuration;
using KentekenValidator.LicenseValidators;

namespace KentekenValidator
{
	class Program
	{
		static void Main(string[] args)
		{
			var inFolder = args.Length > 0 ? args[0] : ConfigurationManager.AppSettings["InFolder"];
			var outFolder = args.Length > 1 ? args[1] : ConfigurationManager.AppSettings["OutFolder"];

			var folderPollValidator = new FolderPollValidator(inFolder, outFolder);
			folderPollValidator.Add(new CurrentCarLicensePlateValidator());
			folderPollValidator.Start();
		}
	}
}
