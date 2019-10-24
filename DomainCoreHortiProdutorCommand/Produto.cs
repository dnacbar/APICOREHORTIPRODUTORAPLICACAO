using System;
using DominioCoreBasicoCommand;

namespace DominioCoreHortiProdutorCommand
{
    public sealed class Produto : Entidade
    {
        public Produto(string strNome, decimal decValor)
        {
            DsNome = strNome;
            NmValor = decValor;
            DtCadastro = DtAtualizacao = DateTime.Now;
        }

        public decimal NmValor { get; private set; }
        public short? NmDesconto { get; private set; }
        public DateTime? DtDesconto { get; private set; }
        public Guid? IdUnidade { get; private set; }
        public bool BoEstoque { get; private set; }
    }
}
