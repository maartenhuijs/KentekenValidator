using System.Text.RegularExpressions;

namespace KentekenValidator.LicenseValidators
{
	public class CurrentCarLicensePlateValidator : RegexLicensePlateValidator
	{
		public CurrentCarLicensePlateValidator()
		{
			SetPattern(@"^[GHJLNPRSTXYZ]{2}-[0-9]{3}-[GHJLNPRSTXYZ]$");
		}
	}

	public abstract class RegexLicensePlateValidator : IValidator
	{
		private string ValidPattern { get; set; }
		public bool Validate(string kenteken) => Regex.IsMatch(kenteken, ValidPattern, RegexOptions.IgnoreCase);
		public void SetPattern(string pattern) => ValidPattern = pattern;
		
	}
	
	public interface IValidator
	{
		bool Validate(string kenteken);
	}

}