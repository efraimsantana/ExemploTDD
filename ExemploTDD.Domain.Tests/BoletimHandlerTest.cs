using ExemploTDD.Domain.Tests.DataGenerator;
using NSubstitute;
using System.Linq;
using Xunit;

namespace ExemploTDD.Domain.Tests
{
    public class BoletimHandlerTest
    {
        private readonly IAvaliacaoRepository _notaRepository = null;
        private readonly BoletimHandler _boletimHandler = null;
        private readonly AvaliacaoDataGenerator _avaliacaoDataGenerator = null;

        public BoletimHandlerTest()
        {
            _notaRepository = Substitute.For<IAvaliacaoRepository>();
            _boletimHandler = new BoletimHandler(_notaRepository);
            _avaliacaoDataGenerator = new AvaliacaoDataGenerator();
        }

        [Theory]
        [InlineData(1, 7)]
        [InlineData(2, 8.5)]
        public void DeveCalcularMediaAluno(int idAluno, decimal mediaEsperada)
        {
            _notaRepository
                .ObterAvaliacoesPorAluno(Arg.Any<int>())
                .Returns(d => _avaliacaoDataGenerator
                    .ObterAvaliacoes()
                    .Where(x => x.IdAluno == d.Arg<int>()));

            
            var command = new CalculaMediaAlunoCommand(idAluno);
            var media = (decimal)_boletimHandler.Handle(command);

            Assert.Equal(mediaEsperada, media);
        }

        [Fact]
        public void DeveAdicionarAvaliacao()
        {
            _notaRepository
                .Add(Arg.Any<Avaliacao>())
                .ReturnsForAnyArgs(d => d.Arg<Avaliacao>().IdAluno);

            var command = new AddAvaliacaoCommand(10, 8.5M);
            var idAluno = (int)_boletimHandler.Handle(command);

            Assert.Equal(10, idAluno);
        }
    }
}