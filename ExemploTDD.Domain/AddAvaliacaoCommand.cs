using ExemploTDD.Domain.Commands;

namespace ExemploTDD.Domain
{
    public class AddAvaliacaoCommand : ICommand
    {
        public int IdAluno { get; private set; }
        public decimal Nota { get; private set; }

        public AddAvaliacaoCommand(int idAluno, decimal nota)
        {
            IdAluno = idAluno;
            Nota = nota;
        }
    }
}