namespace ExemploTDD.Domain
{
    public class Avaliacao
    {
        public int IdAluno { get; private set; }
        public decimal Nota { get; private set; }

        public Avaliacao(int idAluno, decimal nota)
        {
            IdAluno = idAluno;
            Nota = nota;
        }
    }
}