using System;
using KentekenValidator.LicenseValidators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KentekenValidator.unittest
{
	[TestClass]
	public class WhenValidatingCurrentCarLicensePlate
	{
		private readonly CurrentCarLicensePlateValidator currentCarLicensePlateValidator;

		public WhenValidatingCurrentCarLicensePlate()
		{
			currentCarLicensePlateValidator = new CurrentCarLicensePlateValidator();
		}

		[TestMethod]
		public void NormalShapedWillPass()
		{
			Assert.IsTrue(currentCarLicensePlateValidator.Validate("XX-000-X"));
		}

		[TestMethod]
		public void CaseIsNotImportant()
		{
			Assert.IsTrue(currentCarLicensePlateValidator.Validate("xx-000-x"));
		}

		[TestMethod]
		public void PlateWithoutDashesFail()
		{
			Assert.IsFalse(currentCarLicensePlateValidator.Validate("XX 000 X"));
		}

		[TestMethod]
		public void InvalidCharactersFailAccordingly()
		{
			Assert.IsFalse(currentCarLicensePlateValidator.Validate("AA-000-A"));
		}

		[TestMethod]
		public void UnicodeCharactersFailAccordingly()
		{
			Assert.IsFalse(currentCarLicensePlateValidator.Validate("ÁÁ-000-Á"));
		}

		[TestMethod]
		public void InvalidPatternFailsAccordingly()
		{
			Assert.IsFalse(currentCarLicensePlateValidator.Validate("00-XXX-0"));
		}


	}
}

