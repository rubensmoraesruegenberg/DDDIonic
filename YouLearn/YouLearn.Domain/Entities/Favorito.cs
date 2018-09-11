using System;

namespace YouLearn.Domain.Entities
{
    public class Favorito: EntitieBase
    {
        protected Favorito()
        {

        }
        public Usuario Usario { get; set; }
        public Video Video { get; set; }
    }
}
