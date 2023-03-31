using Flunt.Notifications;

namespace IdentidadeCultural.Compartilhado.Aplicacao.Comum { 

    public interface ICommand
    {
        void Validar();
        bool IsValid { get; }
    }

    public abstract class Command : Notifiable<Notification>, ICommand
    {
        public abstract void Validar();
    }

    public interface IRequest
    {

        void Validar();
        bool IsValid { get; }
    }
    public abstract class Request : Notifiable<Notification>, IRequest
    {

        public abstract void Validar();

    }
}