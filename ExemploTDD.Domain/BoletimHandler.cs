using System.Linq;
using ExemploTDD.Domain.Commands;

namespace ExemploTDD.Domain
{
    public class BoletimHandler : ICommandHandler<CalculaMediaAlunoCommand>
    {
        private readonly IAvaliacaoRepository _notaRepository;

        public BoletimHandler(IAvaliacaoRepository notaRepository)
        {
            _notaRepository = notaRepository;
        }
       
        public object Handle(CalculaMediaAlunoCommand command)
        {
            var notas = _notaRepository.ObterAvaliacoesPorAluno(command.IdAluno);
            return notas.Average(x => x.Nota);
        }
    }
}