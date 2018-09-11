using System;
using System.Collections.Generic;
using YouLearn.Domain.Entities;

namespace YouLearn.Domain.Interfaces.Repositories
{
    public interface IRepositoryPlayList
    {
        //Se alguém quiser utilizar esse serviço, vai ter que implementar esses métodos.
        IEnumerable<PlayList> Listar(Guid idUsuario);
        PlayList Obter(Guid IdPlayList);
        PlayList Adicionar(PlayList playList);
        void Excluir(PlayList playList);
    }
}
