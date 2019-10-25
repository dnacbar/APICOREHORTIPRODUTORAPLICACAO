using System;
using System.Collections.Generic;
using System.Text;

namespace DominioCoreBasicoContatoCommand
{
    public class Email
    {
        public Email(string strEmail, DateTime datCadastro)
        {
            DsEmail = strEmail;
            DtCadastro = datCadastro;
        }

        public string DsEmail { get; private set; }
        public DateTime DtCadastro { get; private set; }
        

    }
}
