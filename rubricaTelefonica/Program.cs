using System;

namespace rubricaTelefonica
{
    class Program
    {
        static void Main(string[] args)
        {
            Rubrica rubrica = new Rubrica();
            Console.WriteLine("Benvenuto nella tua rubrica telefonica");
            bool flag = true;
            while (flag){
                Console.WriteLine("Cosa vuoi fare?");
                Console.WriteLine("1. Aggiungi contatto\n2. Leggi contatti\n3. Modifica contatto\n4. Esci");
                int ans = int.Parse(Console.ReadLine());
                Console.WriteLine();
                switch (ans)
                {
                    case 1:
                        rubrica.AggiungiContatto();
                        break;
                    case 2:
                        rubrica.LeggiContatti();
                        break;
                    case 3:
                        Console.WriteLine("Inserisci l'id del contatto che vuoi modificare");
                        int id = int.Parse(Console.ReadLine());
                        rubrica.ModificaContatti(id);
                        break;
                    case 4:
                        flag = false;
                        Environment.Exit(0);
                        break;
                }
                Console.WriteLine("\n\n");
            }
            
        }
    }
}