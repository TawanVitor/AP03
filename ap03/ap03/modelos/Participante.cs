using System;
using System.Collections.Generic;

namespace AgendaCompromissos.Modelos
{
    public class Participante
    {
        public string Nome { get; private set; }
        private List<Compromisso> _compromissos = new List<Compromisso>();
        
        public IReadOnlyCollection<Compromisso> Compromissos => _compromissos.AsReadOnly();

        public Participante(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome do participante é obrigatório.");
            Nome = nome;
        }

        public void AdicionarCompromisso(Compromisso compromisso)
        {
            if (compromisso == null)
                throw new ArgumentNullException("Compromisso não pode ser nulo.");
            
            if (!_compromissos.Contains(compromisso))
            {
                _compromissos.Add(compromisso);
                compromisso.AdicionarParticipante(this);
            }
        }

        public void RemoverCompromisso(Compromisso compromisso)
        {
            if (compromisso != null && _compromissos.Contains(compromisso))
            {
                _compromissos.Remove(compromisso);
                compromisso.RemoverParticipante(this);
            }
        }

        public override string ToString() => Nome;
    }
}