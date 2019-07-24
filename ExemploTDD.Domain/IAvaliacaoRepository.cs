using System.Collections.Generic;

namespace ExemploTDD.Domain
{
    public interface IAvaliacaoRepository
    {
        IEnumerable<Avaliacao> ObterAvaliacoesPorAluno(int IdAluno);
    }
}