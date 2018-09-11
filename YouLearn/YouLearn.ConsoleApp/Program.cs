using System;
using YouLearn.Domain.Arguments.Usuario;
using YouLearn.Domain.Services;

namespace YouLearn.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        { 
            //preenche objeto request
            AdicionarUsuarioRequest request = new AdicionarUsuarioRequest()
            {
                PrimeiroNome = "Ru",
                UltimoNome = "Moraes Ruegenberg",
                EmaiNome = "r@g.com",
                Senha = "12"
            };

            //Chama o serviço de usuario e manda adicionar o objeto.
            var response = new ServiceUsuario().AdicionarUsuario(request);
            Console.ReadKey();
        }
    }
}
