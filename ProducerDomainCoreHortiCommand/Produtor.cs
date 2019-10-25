using System;
using System.Collections.Generic;
using DominioCoreBasicoCommand;
using DominioCoreBasicoContatoCommand;

namespace DominioCoreHortiProdutorCommand
{
    public sealed class Produtor : Entidade
    {
        public Produtor(string strNome, DateTime datNascimento, Guid? idBairro = null, string strNomeFantasia = null,
                        string strCep = null, string strLogradouro = null, string strNumero = null,
                        string strComplemento = null, string strInscFederal = null, string strInscEstadual = null,
                        string strInscMunicipal = null, byte[] bytImage = null)
        {
            DsNome = strNome;
            DtNascimento = datNascimento;
            IdBairro = idBairro;
            DsNomeFantasia = strNomeFantasia;
            DsCep = strCep;
            DsLogradouro = strLogradouro;
            DsNumero = strNumero;
            DsComplemento = strComplemento;
            DsInscricaoFederal = strInscFederal;
            DsInscricaoEstadual = strInscEstadual;
            DsInscricaoMunicipal = strInscMunicipal;
            ImgLogo = bytImage;
            DtCadastro = DtAtualizacao = DateTime.Now;
        }

        public string DsNomeFantasia { get; private set; }
        public Guid? IdBairro { get; private set; }
        public string DsCep { get; private set; }
        public string DsLogradouro { get; private set; }
        public string DsNumero { get; private set; }
        public string DsComplemento { get; private set; }
        public string DsInscricaoFederal { get; private set; }
        public string DsInscricaoEstadual { get; private set; }
        public string DsInscricaoMunicipal { get; private set; }
        public string DsDescricao { get; private set; }
        public IEnumerable<Telefone> LstTelefone { get; private set; }
        public IEnumerable<Email> LstEmail { get; private set; }
        public DateTime DtNascimento { get; private set; }
        public byte[] ImgLogo { get; private set; }
        public IEnumerable<byte[]> LstImagemProduto { get; private set; }
        public IEnumerable<Produto> LstProduto { get; private set; }

        /// <summary>
        /// Atualiza status de ativa e data atualizacao
        /// </summary>
        /// <param name="datAtualizacao"></param>
        /// <param name="bolAtiva"></param>
        public void AtualizarEntidade(string strNomeFantasia, string strDescricao, bool bolAtiva = true)
        {
            DsNomeFantasia = strNomeFantasia;
            DsDescricao = strDescricao;
            BoAtivo = bolAtiva;
            DtAtualizacao = DateTime.Now;
        }

        public void CarregarTelefone(Telefone telefone)
        {

        }
    }
}
