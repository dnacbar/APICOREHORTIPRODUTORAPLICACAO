using MediatR;
using System;
using System.Collections.Generic;

namespace DominioCoreBasicoCommand
{
    public abstract class Entity
    {
        public Entity() { Id = new Guid(); BoActive = true; }

        public Guid Id { get; set; }
        public bool BoActive { get; protected set; }
        public string DsName { get; protected set; }
        public DateTime DtCreation { get; protected set; }
        public DateTime DtAtualization { get; protected set; }
        public List<INotification> DomainEvents { get; set; }

        /// <summary>
        /// Disable the entity
        /// </summary>
        public void Disable()
        {
            BoActive = false;
            DtAtualization = DateTime.Now;
        }

        //NOTIFICACAO EVENTOS
        public void AddDominioEvent(INotification eventItem)
        {
            DomainEvents = DomainEvents ?? new List<INotification>();
            DomainEvents.Add(eventItem);
        }
        public void RemoveDominioEvent(INotification eventItem)
        {
            if (DomainEvents is null)
                return;
            DomainEvents.Remove(eventItem);
        }
    }
}
