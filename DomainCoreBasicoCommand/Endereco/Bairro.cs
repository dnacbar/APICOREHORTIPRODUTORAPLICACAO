using DominioCoreBasicoCommand;
using System;

namespace DominioCoreBasicoEnderecoCommand
{
    public sealed class Bairro : Entidade
    {
        public Bairro(string strNome)
        {
            DsNome = strNome;
            DtCadastro = DtAtualizacao = DateTime.Now;
        }
        public Municipio Municipio { get; set; }
    }
}
