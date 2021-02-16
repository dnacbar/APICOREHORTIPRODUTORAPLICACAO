using HORTICOMMAND.APP.CONVERTER;
using HORTICOMMAND.DOMAIN.INTERFACES.APP;
using APPDTOCOREHORTICOMMAND.SIGNATURE;
using HORTICROSSCUTTINGCORE.EXTENSION;
using HORTICROSSCUTTINGCORE.FILE;
using SERVICECOREHORTICOMMAND.ISERVICE;
using System.IO;
using System.Threading.Tasks;
using HORTICOMMAND.VALIDATION.APPLICATION;

namespace HORTICOMMAND.APP
{
    public class ProducerCommandApp : IProducerCommandApp
    {
        private readonly CreateProducerSignatureValidation _createProducerSignatureValidation;
        private readonly UpdateProducerSignatureValidation _updateProducerSignatureValidation;

        private readonly IProducerDomainService _producerDomainService;

        public ProducerCommandApp(CreateProducerSignatureValidation createProducerSignatureValidation,
                                  UpdateProducerSignatureValidation updateProducerSignatureValidation,
                                  IProducerDomainService producerDomainService)
        {
            _createProducerSignatureValidation = createProducerSignatureValidation;
            _updateProducerSignatureValidation = updateProducerSignatureValidation;
            _producerDomainService = producerDomainService;
        }

        public async Task CreateProducer(IProducerCommandSignature signature)
        {
            _createProducerSignatureValidation.ValidateHorti(signature);

            var producerDomain = signature.ToCreateProducerDomain();
            await _producerDomainService.ProducerServiceCreate(producerDomain);

            Directory.CreateDirectory(Path.Combine(Path.GetPathRoot(Directory.GetCurrentDirectory()), "PRODUCER", producerDomain.IdProducer.ToString()));
        }

        public async Task UpdateProducer(IProducerCommandSignature signature)
        {
            _updateProducerSignatureValidation.ValidateHorti(signature);

            await _producerDomainService.ProducerServiceUpdate(signature.ToUpdateProducerDomain());

            CreateProducerImage(signature);
        }

        private void CreateProducerImage(IProducerCommandSignature signature)
        {
            if (signature.ImageByte == null)
                return;

            if (!Directory.Exists(Path.Combine(Path.GetPathRoot(Directory.GetCurrentDirectory()), "PRODUCER", signature.Id.ToString())))
                return;

            FileIO.CreateImage(Path.Combine(Path.GetPathRoot(Directory.GetCurrentDirectory()), "PRODUCER", signature.Id.ToString(), signature.Id + ".png"), signature.ImageByte);
        }
    }
}
