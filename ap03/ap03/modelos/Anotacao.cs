using System;

namespace AgendaCompromissos.Modelos
{
    public class Anotacao
    {
        public string Texto { get; private set; }
        public DateTime DataCriacao { get; private set; }

        public Anotacao(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                throw new ArgumentException("Texto da anotação é obrigatório.");
            Texto = texto;
            DataCriacao = DateTime.Now;
        }

        public override string ToString()
        {
            return $"[{DataCriacao:dd/MM/yyyy HH:mm}] {Texto}";
        }
    }
}