using HORTI.CORE.CROSSCUTTING.ENUM;
using HORTI.CORE.CROSSCUTTING.EXTENSION;

namespace HORTI.CORE.CROSSCUTTING.VALUEOBJECT
{
    public sealed class DocumentObject
	{
		public DocumentObject(string documentObject,  EnumCultureInfo cultureInfo = EnumCultureInfo.Brazilian)
		{
			Document = documentObject?.Trim();
			CultureInfo = cultureInfo;
		}

		public string Document { get; private set; }
		public bool JuridicDocument => VerifyJuridicDocument();
		public bool IsValid()
		{
			if (CultureInfo == EnumCultureInfo.Brazilian)
				return ValidateBrazilianDocument();

			return false;
		}

		private EnumCultureInfo CultureInfo { get; set; }

		private bool ValidateBrazilianDocument()
		{
			if (Document.IsOnlyNumber())
				return false;

			return JuridicDocument ? BrazilianJuridicDocument(Document) : BrazilianPhysicDocument(Document);
		}

		private bool VerifyJuridicDocument()
		{
			if (CultureInfo == EnumCultureInfo.Brazilian)
				return Document.Length == 14;

			return false;
		}

		private bool BrazilianPhysicDocument(string document)
		{
			int[] validator1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] validator2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

			int sumDocument, restOfDivision;
			string documentDigit, tempDocument;

			if (document.Length != 11)
				return false;

			tempDocument = document.Substring(0, 9);
			sumDocument = 0;

			for (int i = 0; i < 9; i++)
				sumDocument += int.Parse(tempDocument[i].ToString()) * validator1[i];

			restOfDivision = sumDocument % 11;

			if (restOfDivision < 2)
				restOfDivision = 0;
			else
				restOfDivision = 11 - restOfDivision;

			documentDigit = restOfDivision.ToString();
			tempDocument += documentDigit;

			sumDocument = 0;

			for (int i = 0; i < 10; i++)
				sumDocument += int.Parse(tempDocument[i].ToString()) * validator2[i];

			restOfDivision = sumDocument % 11;

			if (restOfDivision < 2)
				restOfDivision = 0;
			else
				restOfDivision = 11 - restOfDivision;

			documentDigit += restOfDivision.ToString();

			return document.EndsWith(documentDigit);
		}

		private bool BrazilianJuridicDocument(string document)
		{
			int[] validator1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] validator2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

			int sumDocument, restOfDivision;
			string digitDocument, tempDocument;

			if (document.Length != 14)
				return false;

			tempDocument = document.Substring(0, 12);
			sumDocument = 0;

			for (int i = 0; i < 12; i++)
				sumDocument += int.Parse(tempDocument[i].ToString()) * validator1[i];

			restOfDivision = (sumDocument % 11);

			if (restOfDivision < 2)
				restOfDivision = 0;
			else
				restOfDivision = 11 - restOfDivision;

			digitDocument = restOfDivision.ToString();

			tempDocument += digitDocument;

			sumDocument = 0;

			for (int i = 0; i < 13; i++)
				sumDocument += int.Parse(tempDocument[i].ToString()) * validator2[i];

			restOfDivision = (sumDocument % 11);

			if (restOfDivision < 2)
				restOfDivision = 0;
			else
				restOfDivision = 11 - restOfDivision;

			digitDocument += restOfDivision.ToString();

			return document.EndsWith(digitDocument);
		}
	}
}
