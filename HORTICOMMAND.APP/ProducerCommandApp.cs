using HORTI.CORE.CROSSCUTTING.EXTENSION;
using HORTI.CORE.CROSSCUTTING.FILE;
using HORTICOMMAND.DOMAIN.INTERFACE.APP;
using HORTICOMMAND.DOMAIN.INTERFACE.MODEL.SIGNATURE;
using HORTICOMMAND.DOMAIN.INTERFACE.SERVICE;
using HORTICOMMAND.DOMAIN.MODEL;
using HORTICOMMAND.VALIDATION.APPLICATION;
using System.IO;
using System.Threading.Tasks;

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

            var producerDomain = new Producer(signature);
            await _producerDomainService.ProducerServiceCreate(producerDomain);

            Directory.CreateDirectory(Path.Combine(Path.GetPathRoot(Directory.GetCurrentDirectory()), "PRODUCER", producerDomain.IdProducer.ToString()));
        }

        public async Task UpdateProducer(IProducerCommandSignature signature)
        {
            _updateProducerSignatureValidation.ValidateHorti(signature);

            await _producerDomainService.ProducerServiceUpdate(new Producer(signature));

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
