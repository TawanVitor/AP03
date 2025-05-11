using System;
using System.Collections.Generic;
using Modelos;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("=== Sistema de Agenda de Compromissos ===\n");

        Console.Write("Digite seu nome completo: ");
        string nomeUsuario = Console.ReadLine();
        Usuario usuario = new Usuario(nomeUsuario);

        Console.WriteLine("\nCadastro de Compromisso:");

        DateTime dataHora;
        while (true)
        {
            Console.Write("Data e hora do compromisso (formato: dd/MM/yyyy HH:mm): ");
            if (DateTime.TryParse(Console.ReadLine(), out dataHora) && dataHora > DateTime.Now)
                break;
            Console.WriteLine("❌ Data e hora inválidas ou no passado.");
        }

        Console.Write("Descrição do compromisso: ");
        string descricao = Console.ReadLine();

        Console.Write("Nome do local: ");
        string nomeLocal = Console.ReadLine();

        int capacidade;
        while (true)
        {
            Console.Write("Capacidade máxima do local: ");
            if (int.TryParse(Console.ReadLine(), out capacidade) && capacidade > 0)
                break;
            Console.WriteLine("❌ Capacidade inválida.");
        }

        Local local = new Local(nomeLocal, capacidade);

        try
        {
            Compromisso compromisso = new Compromisso(dataHora, descricao, usuario, local);
            usuario.AdicionarCompromisso(compromisso);

            // Adicionar participantes
            Console.WriteLine("\nAdicione os participantes (digite ENTER para encerrar):");
            while (true)
            {
                Console.Write("Nome do participante: ");
                string nomeParticipante = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(nomeParticipante)) break;

                try
                {
                    Participante p = new Participante(nomeParticipante);
                    compromisso.AdicionarParticipante(p);
                    Console.WriteLine("✔ Participante adicionado.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ {ex.Message}");
                }
            }

            // Adicionar anotações
            Console.WriteLine("\nAdicione anotações (digite ENTER para encerrar):");
            while (true)
            {
                Console.Write("Texto da anotação: ");
                string texto = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(texto)) break;

                try
                {
                    compromisso.AdicionarAnotacao(texto);
                    Console.WriteLine("✔ Anotação adicionada.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ {ex.Message}");
                }
            }

            // Exibir resumo
            Console.WriteLine("\n=== Compromissos Registrados ===");
            foreach (var c in usuario.Compromissos)
            {
                Console.WriteLine(c);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"❌ Erro ao criar compromisso: {ex.Message}");
        }
    }
}
