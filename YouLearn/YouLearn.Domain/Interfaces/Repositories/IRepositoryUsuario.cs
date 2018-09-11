using System;
using YouLearn.Domain.Entities;

namespace YouLearn.Domain.Interfaces.Repositories
{
    public interface IRepositoryUsuario
    {
        //Se alguém quiser utilizar esse serviço, vai ter que implementar esses métodos.
        Usuario Obter(string emai, string senha);
        Usuario Obter(Guid id);
        void Salvar(Usuario usuario);
        bool Existe(string email); 
    }
}
