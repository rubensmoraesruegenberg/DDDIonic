using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Text;
using YouLearn.Domain.ValueObjects;
using YouLearn.Domain.Extensions;

namespace YouLearn.Domain.Entities
{
    public class Usuario:EntitieBase
    {
        //Teve que colocar esse construtor vázio, devido ao erro que estava dando no migration
        //Erro:
        //No suitable constructor found for entity type 'Usuario'. The following parameters could not be bound to properties of the entity: 'email', 'nome', 'email'.
        //Resposta para o erro:
        //No EF Core, você tem duas saídas:1ª criar um construtor protegido sem parâmetros, 
        //2ª tirar os tipos complexos do construtor existente. (nesse caso não dá pois eu utilizo esses construtores.)
        protected Usuario()
        {

        }
        //Gerar multiplos construtores

        //Esse construtor serve só para nome e Email
        public Usuario(Email email, string senha)
        {
            Email = email;
            Senha = senha;

            //Criptografa senha
            Senha = Senha.ConvertToMD5();

            AddNotifications(email);
        }

        public Usuario(Nome nome, Email email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;

            ValidarSenha();

            //AddNotifications(email);
        }

        private void ValidarSenha()
        {
            new AddNotifications<Usuario>(this).IfNullOrInvalidLength(x => x.Senha, 3, 5);

            Senha = Senha.ConvertToMD5(); //Não precisa colocar o parametro, pois como foi criado com o this se sabe que é uma extensão da string.
        }

        public Nome Nome { get; private set; }
        public Email Email { get; private set; }
        public string Senha { get; private set; }
    }
}
