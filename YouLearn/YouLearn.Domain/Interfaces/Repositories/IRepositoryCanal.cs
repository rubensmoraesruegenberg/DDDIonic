using System;
using System.Collections.Generic;
using YouLearn.Domain.Entities;

namespace YouLearn.Domain.Interfaces.Repositories
{
    public interface IRepositoryCanal
    {
        //Se alguém quiser utilizar esse serviço, vai ter que implementar esses métodos.
        IEnumerable<Canal> Listar(Guid idUsuario);
        Canal Obter(Guid IdCanal);
        Canal Adicionar(Canal canal);
        void Excluir(Canal canal);
    }
}
