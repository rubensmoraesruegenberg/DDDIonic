using System;
using System.Collections.Generic;
using YouLearn.Domain.Entities;

namespace YouLearn.Domain.Interfaces.Repositories
{
    public interface IRepositoryVideo    {
        //Se alguém quiser utilizar esse serviço, vai ter que implementar esses métodos.
        void Adicionar(Video video);
        IEnumerable<Video> Listar(string tags);
        IEnumerable<Video> Listar(Guid idPlayList);
        bool ExisteCanalAssociado(Guid id);
        bool ExistePlayListAssociada(Guid idPlaylist);
       
    }
}
