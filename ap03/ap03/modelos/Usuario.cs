using System.Collections.Generic;

namespace Modelos
{
    public class Usuario
    {
        public string Nome { get; }

        private readonly List<Compromisso> _compromissos = new();
        public IReadOnlyCollection<Compromisso> Compromissos => _compromissos.AsReadOnly();

        public Usuario(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome do usuário é obrigatório.");

            Nome = nome;
        }

        public void AdicionarCompromisso(Compromisso compromisso)
        {
            if (compromisso == null)
                throw new ArgumentNullException(nameof(compromisso));

            if (!_compromissos.Contains(compromisso))
                _compromissos.Add(compromisso);
        }
    }
}
using System.Collections.Generic;

namespace Modelos
{
    public class Usuario
    {
        public string Nome { get; }

        private readonly List<Compromisso> _compromissos = new();
        public IReadOnlyCollection<Compromisso> Compromissos => _compromissos.AsReadOnly();

        public Usuario(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("O nome do usuário é obrigatório.");

            Nome = nome;
        }

        public void AdicionarCompromisso(Compromisso compromisso)
        {
            if (compromisso == null)
                throw new ArgumentNullException(nameof(compromisso));

            if (!_compromissos.Contains(compromisso))
                _compromissos.Add(compromisso);
        }
    }
}
