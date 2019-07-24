using System.Collections.Generic;

namespace ExemploTDD.Domain.Tests.DataGenerator
{
    public class AvaliacaoDataGenerator
    {
        public IEnumerable<Avaliacao> ObterAvaliacoes()
        {
            return new List<Avaliacao>(6)
            {
                new Avaliacao(1, 7),
                new Avaliacao(2, 8),
                new Avaliacao(1, 7),
                new Avaliacao(2, 9),
                new Avaliacao(1, 7),
                new Avaliacao(1, 7)
            };
        }
    }
}