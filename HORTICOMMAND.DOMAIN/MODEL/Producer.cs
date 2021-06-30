using HORTI.CORE.CROSSCUTTING.ENUM;
using HORTI.CORE.CROSSCUTTING.VALUEOBJECT;
using HORTICOMMAND.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using System;

namespace HORTICOMMAND.DOMAIN.MODEL
{
    public class Producer
    {
        public Producer() { }

        public Producer(IProducerCommandSignature signature, EnumCultureInfo cultureInfo = EnumCultureInfo.Brazilian)
        {
            CultureInfo = cultureInfo;
            IdProducer = signature.Id.GetValueOrDefault();
            DsProducer = signature.Producer;
            DsAddress = signature.Address;
            DsComplement = signature.Complement;
            DsDescription = signature.Description;
            DsEmail = signature.Email;
            DsFantasyname = signature.FantasyName;
            DsNumber = signature.Number;
            DsPhone = signature.Phone;
            IdCity = signature.City;
            IdDistrict = signature.District;
            DsZip = signature.Zip;
            DsFederalInscription = signature.FederalInscription;
            DsStateInscription = signature.StateInscription;
            DsMunicipalInscription = signature.MunicipalInscription;
        }

        public Guid IdProducer { get; set; }
        public string DsProducer { get; set; }
        public string DsFantasyname { get; set; }
        public int? IdCity { get; set; }
        public Guid? IdDistrict { get; set; }
        public string DsZip { get; set; }
        public string DsAddress { get; set; }
        public string DsNumber { get; set; }
        public string DsComplement { get; set; }
        public string DsFederalInscription { get; set; }
        public string DsStateInscription { get; set; }
        public string DsMunicipalInscription { get; set; }
        public string DsDescription { get; set; }
        public string DsEmail { get; set; }
        public string DsPhone { get; set; }

        public virtual City IdCityNavigation { get; set; }
        public virtual District IdDistrictNavigation { get; set; }

        public PhoneObject PhoneObject => new PhoneObject(DsPhone, CultureInfo);
        public EmailObject EmailObject => new EmailObject(DsEmail);
        public DocumentObject FederalDocument => new DocumentObject(DsFederalInscription, CultureInfo);

        private EnumCultureInfo CultureInfo { get; set; }
    }
}
