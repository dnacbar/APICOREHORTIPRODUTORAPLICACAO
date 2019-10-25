using DominioCoreBasicoCommand;
using System;
using System.Collections.Generic;

namespace DominioCoreBasicoEnderecoCommand
{
    public sealed class Municipio : Entidade
    {
        public Municipio(string strNome, string strMunicipio)
        {
            DsNome = strNome;
            CdMunicipio = strMunicipio;
            DtCadastro = DtAtualizacao = DateTime.Now;
        }
        public string CdMunicipio { get; private set; }

        public Estado Estado { get; set; }
        public IEnumerable<Bairro> Bairro { get; set; }
    }
}
