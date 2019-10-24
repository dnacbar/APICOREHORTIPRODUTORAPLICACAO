using MediatR;
using System;
using System.Collections.Generic;

namespace DominioCoreBasicoCommand
{
    public abstract class Entidade
    {
        public Entidade() { Id = new Guid(); BoAtivo = true; }

        public Guid Id { get; private set; }
        public bool BoAtivo { get; protected set; }
        public string DsNome { get; protected set; }
        public DateTime DtCadastro { get; protected set; }
        public DateTime DtAtualizacao { get; protected set; }
        public List<INotification> DominioEvents { get; private set; }

        /// <summary>
        /// Desativar entidade.
        /// </summary>
        public void Desativar()
        {
            BoAtivo = false;
            DtAtualizacao = DateTime.Now;
        }

        //NOTIFICACAO EVENTOS
        public void AddDominioEvent(INotification eventItem)
        {
            DominioEvents = DominioEvents ?? new List<INotification>();
            DominioEvents.Add(eventItem);
        }
        public void RemoveDominioEvent(INotification eventItem)
        {
            if (DominioEvents is null)
                return;
            DominioEvents.Remove(eventItem);
        }
    }
}
