using System;
using System.Diagnostics.Tracing;

namespace Dopamina
{
    class Macaco
    {
        // Atributos / Propriedades
        public string Name { get; private set; }
        public int NivelDopamina { get; private set; } = 0;
        // Variáveis internas de controle (totalmente privadas)
        private bool TemExperiencia = false;
        private bool Gatilho = false;

        // Construtor
        public Macaco(string nameDoMacaco)
        {
            Name = nameDoMacaco;
        }

        // Métodos (Comportamentos)
        public void VerLuz()
        {

            Gatilho = true;

            //Se já sabe, fica feliz antecipadamente ao ver a luz(OBA Suco!)
            if (TemExperiencia == true)
            {
                NivelDopamina += 50;
            }

        }
        public void BeberSuco()
        {
            // Se NÃO sabe (surpresa), fica feliz ao beber
            if (!TemExperiencia)
            {
                NivelDopamina += 50;
                TemExperiencia = true;
            }

        }
        public void ChecarFrustracao()
        {

            Console.WriteLine($"\n[INVESTIGAÇÃO] Checando Frustração...");
            Console.WriteLine($"Estado atual -> TemExperiencia: {TemExperiencia} | Gatilho: {Gatilho}");
            Console.WriteLine($"Dopamina ANTES da conta: {NivelDopamina}");
            if (TemExperiencia && Gatilho)
            {
                // AQUI É O PONTO CRÍTICO: Confira se tem o sinal de MENOS (-) antes do 70
                int valorCalculado = NivelDopamina - 70;
                Console.WriteLine($"Conta feita: {NivelDopamina} - 70 = {valorCalculado}");

                NivelDopamina = Math.Max(0, valorCalculado);
                Console.WriteLine("--> Resultado: APLICADO!");
            }
            else
            {
                Console.WriteLine("--> IGNORADO: O macaco não caiu no IF.");
                if (!TemExperiencia) Console.WriteLine("    (Motivo: Ele não tem experiência)");
                if (!Gatilho) Console.WriteLine("    (Motivo: O Gatilho está desligado)");
            }

            Console.WriteLine($"Dopamina FINAL: {NivelDopamina}\n");


        }

        public static void Main(string[] args) 
        {
            var macaco = new Macaco("George");
            //  ----Dia 1 (Nivel normal de dopamina 50) ----

            Console.WriteLine("Nivel inicial de Doapamina: "+macaco.NivelDopamina);
            Console.WriteLine("--- DIA 1: Aprendendo ---");
            macaco.VerLuz();
            macaco.BeberSuco();
            macaco.ExibirEstado();

            //    ----DiagnosticCounter 2 (O macaco já aprendeu!)---
            Console.WriteLine("\n--- DIA 2: Decepção 1 ---");
            macaco.Dormir();
            macaco.VerLuz();
            macaco.BeberSuco();
            macaco.ExibirEstado();

            //    ----DiagnosticCounter 3 Checar Frustracao por não ganhar suco)---
            Console.WriteLine("\n--- DIA 3: Decepção 2 ---");
            macaco.Dormir();
            macaco.VerLuz();
            macaco.ChecarFrustracao();
            macaco.ExibirEstado();

            // Decepção 3 (O Teste da Trava!)
            Console.WriteLine("\n--- DIA 4: O Teste Final (Vai dar negativo?) ---");
            Console.WriteLine("\n--- INICIANDO SEQUÊNCIA DE FRUSTRAÇÃO (5 DIAS) ---");

            // Repete o bloco de código 2 vezes
            for (int i = 1; i <= 2; i++)
            {
                Console.WriteLine($"\nRodada {i}:");
                macaco.Dormir();
                macaco.VerLuz();         // Sobe +50 (esperança)
                macaco.ChecarFrustracao(); // Desce -70 (realidade)
                macaco.ExibirEstado();
            }

        }

        public void Dormir()
        {
            Gatilho = false;
            Console.WriteLine($"... {Name} Foi dormir e esqueceu a luz anterior...");
        }
        public void ExibirEstado()
        {
            Console.WriteLine($"\n--- Satatus do Macaco : {Name} ---");
            Console.WriteLine($"Dopamina: {NivelDopamina}");
            Console.WriteLine($"Ele tem experiencia? {(TemExperiencia ? "Sim" : "Não")}");
        }

    }
}