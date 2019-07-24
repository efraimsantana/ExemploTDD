namespace ExemploTDD.Domain.Commands
{
    public interface ICommandHandler<T> where T : ICommand
    {
        object Handle(T command);
    }
}