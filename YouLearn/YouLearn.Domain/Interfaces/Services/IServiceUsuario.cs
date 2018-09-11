using YouLearn.Domain.Arguments.Usuario;
using YouLearn.Domain.Interfaces.Services.Base;

namespace YouLearn.Domain.Interfaces.Services
{
    public interface IServiceUsuario:IServiceBase
    {
        //void AdicionarUsuario(string primeiroNome, string ultimoNome, string email, string senha);

        //Criar um objeto complexo para passar parametros
        //Um padrão para nomenclatura de objetos é utilizar para argumentos de resposta se usa resposne, e para argumentos de saída o Request.

        //O bom de utilizar dessa maneira, é que já se passa um objeto complexo que já vai aceitando novos parametros,
        //E o response já traz a resposta do que se precisa.
        AdicionarUsuarioResponse AdicionarUsuario(AdicionarUsuarioRequest request);
        AutenticarResponse Autenticar(AutenticarRequest request);
    }
}
