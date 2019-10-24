using DominioCoreBasicoCommand;
using System;
using System.Collections.Generic;

namespace DominioCoreBasicoEnderecoCommand
{
    public sealed class Pais : Entidade
    {
        public Pais(string strNome)
        {
            DsNome = strNome;
            DtCadastro = DtAtualizacao = DateTime.Now;
        }

        public IEnumerable<Estado> Estado { get; set; }
    }
}
