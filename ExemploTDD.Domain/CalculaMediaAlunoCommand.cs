using ExemploTDD.Domain.Commands;

namespace ExemploTDD.Domain
{
    public class CalculaMediaAlunoCommand : ICommand
    {
        public int IdAluno { get; private set; }

        public CalculaMediaAlunoCommand(int idAluno)
        {
            IdAluno = idAluno;
        }
    }
}