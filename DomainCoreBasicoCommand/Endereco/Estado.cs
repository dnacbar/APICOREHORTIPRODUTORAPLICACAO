using DominioCoreBasicoCommand;
using System;
using System.Collections.Generic;

namespace DominioCoreBasicoEnderecoCommand
{
    public sealed class Estado : Entidade
    {
        public Estado(string strNome, string strUf)
        {
            DsNome = strNome;
            DsUf = strUf;
            DtCadastro = DtAtualizacao = DateTime.Now;
        }
        public Guid IdPais { get; private set; }
        public string DsUf { get; private set; }

        public Pais Pais { get; set; }
        public IEnumerable<Municipio> Municipio { get; set; }
    }
}
