using System.Collections.Generic;
using System.Net;

namespace ExemploTDD.Domain
{
    public interface IAvaliacaoRepository
    {
        IEnumerable<Avaliacao> ObterAvaliacoesPorAluno(int IdAluno);

        int Add(Avaliacao avaliacao);
    }
}