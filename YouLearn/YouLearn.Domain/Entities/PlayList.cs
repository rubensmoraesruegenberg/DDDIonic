using prmToolkit.NotificationPattern;
using YouLearn.Domain.Enums;

namespace YouLearn.Domain.Entities
{
    public class PlayList: EntitieBase
    {
        protected PlayList()
        {

        }
        public PlayList(Usuario usuario, string nome)
        {
            Usuario = usuario;
            Nome = nome;

            new AddNotifications<PlayList>(this).IfNullOrInvalidLength(x => x.Nome, 2, 100);
            AddNotifications(usuario);
        }

        public Usuario Usuario { get; private set; }
        public string Nome { get; private set; }
        public EnumStatus Status { get; private set; }
    }
}
