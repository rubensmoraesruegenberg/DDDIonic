using System;
using YouLearn.Domain.Entities;

namespace YouLearn.Domain.Arguments.Usuario
{
    public class AutenticarResponse
    {
        public Guid Id { get; set; }
        public string PrimeiroNome { get; set; }

        public static explicit operator AutenticarResponse(Entities.Usuario entidade)
        {
            return new AutenticarResponse()
            {
                Id = entidade.Id,
                PrimeiroNome = entidade.Nome.PrimeiroNome
            };
        }
    }
}
