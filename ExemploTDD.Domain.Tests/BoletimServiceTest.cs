using ExemploTDD.Domain.Tests.DataGenerator;
using NSubstitute;
using System.Linq;
using Xunit;

namespace ExemploTDD.Domain.Tests
{
    public class BoletimServiceTest
    {
        private readonly IAvaliacaoRepository _notaRepository = null;
        private readonly AvaliacaoDataGenerator _avaliacaoDataGenerator = null;

        public BoletimServiceTest()
        {
            _notaRepository = Substitute.For<IAvaliacaoRepository>();
            _avaliacaoDataGenerator = new AvaliacaoDataGenerator();
        }

        [Theory]
        [InlineData(1, 7)]
        [InlineData(2, 8.5)]
        public void DeveCalcularMediaAluno(int idAluno, decimal mediaEsperada)
        {
            //Range
            _notaRepository
                .ObterAvaliacoesPorAluno(Arg.Any<int>())
                .Returns(d => _avaliacaoDataGenerator
                    .ObterAvaliacoes()
                    .Where(x => x.IdAluno == d.Arg<int>()));

            var boletimHandler = new BoletimHandler(_notaRepository);

            //Act
            var command = new CalculaMediaAlunoCommand(idAluno);
            var media = (decimal)boletimHandler.Handle(command);

            //Assert
            Assert.Equal(mediaEsperada, media);
        }
    }
}