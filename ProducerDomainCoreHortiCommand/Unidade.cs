using System;
using DominioCoreBasicoCommand;

namespace DominioCoreHortiProdutorCommand
{
    public class Unidade : Entidade
    {
        public Unidade(string strNome)
        {
            DsNome = strNome;
            DtCadastro = DtAtualizacao = DateTime.Now;
        }
    }
}
