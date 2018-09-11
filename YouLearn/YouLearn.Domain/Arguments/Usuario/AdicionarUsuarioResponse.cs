using System;
using System.Collections.Generic;
using System.Text;

namespace YouLearn.Domain.Arguments.Usuario
{
    public class AdicionarUsuarioResponse
    {
        //Usar construto é bom que quando se dá o new já se passa os parametros 
        //para criar e á par usar o tdd conforme ensinado no curso de TDD.
        public AdicionarUsuarioResponse(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
