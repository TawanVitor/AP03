using System;
using System.Collections.Generic;

namespace AgendaCompromissos.Modelos
{
    public class Local
    {
        public string Nome { get; private set; }
        public int CapacidadeMaxima { get; private set; }
        private List<Compromisso> _compromissos = new List<Compromisso>();

        public Local(string nome, int capacidadeMaxima)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome do local é obrigatório.");
            if (capacidadeMaxima <= 0)
                throw new ArgumentException("Capacidade deve ser maior que zero.");
            Nome = nome;
            CapacidadeMaxima = capacidadeMaxima;
        }

        public bool ValidarCapacidade(int quantidadeParticipantes)
        {
            return quantidadeParticipantes <= CapacidadeMaxima;
        }

        public void AdicionarCompromisso(Compromisso compromisso)
        {
            if (compromisso != null && !_compromissos.Contains(compromisso))
                _compromissos.Add(compromisso);
        }

        public override string ToString()
        {
            return $"{Nome} (Capacidade: {CapacidadeMaxima})";
        }
    }
}