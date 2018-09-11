using prmToolkit.NotificationPattern;
using System;

namespace YouLearn.Domain.Entities
{
    public abstract class EntitieBase : Notifiable
    {
        public EntitieBase()
        {
            Id = Guid.NewGuid();
        }
        public virtual Guid Id { get; set; }
    }
}
