using System;
using System.Linq;

namespace DominioCoreBasicoContatoCommand
{
    public class Telefone
    {
        public Telefone(string strTelefone, DateTime datCadastro, Guid idPessoaTelefone)
        {
            DsTelefone = strTelefone;
            DtCadastro = datCadastro;
            IdPessoaTelefone = idPessoaTelefone;
        }

        public string DsTelefone { get; private set; }
        public DateTime DtCadastro { get; private set; }
        public Guid IdPessoaTelefone { get; private set; }

        private bool ValidarTamanho() => DsTelefone.Length == 10 || DsTelefone.Length == 11 ? true : false;
        private bool ValidarNumero()
        {
            if (!ValidarTamanho())
                return false;

            foreach (var c in DsTelefone)
            {
                if (!char.IsNumber(c))
                    return false;
            }
            return true;
        }
        public bool ValidarTelefone() => ValidarNumero() ? true : false;
    }
}
