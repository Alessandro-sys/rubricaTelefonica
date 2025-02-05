using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;

namespace rubricaTelefonica
{
    class Rubrica
    {   
        public virtual void AggiungiContatto()
        {
            // crea un nuovo oggetto contatto
            Contatto contatto = new Contatto();
            
            // avvia la creazione di un contatto
            contatto.AggiungiContatto();
            
            // recap delle informazioni del contatto - richiesta di conferma
            Console.Write($"Le informazioni inserite sono: {contatto.Nome};{contatto.Cognome};{contatto.Numero};{contatto.Email}. \nVuoi aggiungere il contatto? [y/n]");
            string ans = Console.ReadLine().ToLower();
            // attesa risposta [y/n]
            while (ans != "y" && ans != "n")
            {
                Console.Write("Inserisci una risposta valida \nVuoi aggiungere il contatto? [y/n]");
                ans = Console.ReadLine().ToLower();
            }
            
            // se ottengo conferma per caricare il file
            if (ans == "y")
            {
                // stringa formattata che contiene le informazioni
                string informazioni = $"{contatto.Id};{contatto.Nome};{contatto.Cognome};{contatto.Numero};{contatto.Email}";
                try
                {
                    string path = "C:\\CODE\\rubricaTelefonica\\rubrica.txt";
                    //string path = "/Users/ale/Desktop/rubricaTelefonica/rubricaTelefonica/rubrica.txt";

                    if (!File.Exists(path))
                    {
                        File.Create(path).Dispose();
                    }
                    using (StreamWriter sw = new StreamWriter(path, true))
                    {
                        sw.WriteLine(informazioni);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
                finally
                {
                    Console.WriteLine("Dati inseriti correttamente");
                }
            }
        }
        public virtual void LeggiContatti()
        {
            //string path = "/Users/ale/Desktop/rubricaTelefonica/rubricaTelefonica/rubrica.txt";
            string path = "C:\\CODE\\rubricaTelefonica\\rubrica.txt";
            var contatti = new Dictionary<int, Dictionary<string, string>>();

            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);
                Console.WriteLine("ID  |  Nome  |  Cognome  |  Numero  |  Email");

                foreach (string line in lines)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        var valori = line.Split(";");
                        if (valori.Length == 5)
                        {
                            int id = int.Parse(valori[0]);

                            Console.Write($"{valori[0]}; {valori[1]}; {valori[2]};{valori[3]}");


                            if (!String.IsNullOrEmpty(valori[4])) Console.WriteLine($"; {valori[4]}");
                            else Console.WriteLine(";");
                        }
                    }
                }
            }
        }
        public virtual void ModificaContatti()
        {
            //string path = "/Users/ale/Desktop/rubricaTelefonica/rubricaTelefonica/rubrica.txt";
            string path = "C:\\Users\\chiar\\Code\\rubricaTelefonica\\rubricaTelefonica\\rubrica.txt";
            var contatti = new Dictionary<int, Dictionary<string, string>>();

            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);

                foreach (string line in lines)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        var valori = line.Split(";");
                        if (valori.Length >= 4)
                        {
                            int id = int.Parse(valori[0]);
                            var contatto = new Dictionary<string, string>
                            {
                                ["nome"] = valori[1],
                                ["cognome"] = valori[2],
                                ["numero"] = valori[3]
                            };
                            if (valori.Length > 4)
                            {
                                contatto["email"] = valori[4];
                            }
                            contatti[id] = contatto;
                        }


                    }
                }
                Console.WriteLine("ID  |  Nome  |  Cognome  |  Numero  |  Email");
                foreach (var contatto in contatti)
                {
                    Console.Write($"{contatto.Key}; ");
                    foreach (var elemento in contatto.Value)
                    {
                        if(!String.IsNullOrEmpty(elemento.Value)) Console.Write($"{elemento.Value}; ");
                    }
                    Console.WriteLine();

                }
            }
        }


    }

    
}
