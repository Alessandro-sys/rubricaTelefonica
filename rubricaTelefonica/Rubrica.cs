using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using Microsoft.VisualBasic;

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
        public virtual void ModificaContatti(int idContatto)
        {
            //string path = "/Users/ale/Desktop/rubricaTelefonica/rubricaTelefonica/rubrica.txt";
            string path = "C:\\CODE\\rubricaTelefonica\\rubrica.txt";
            
            var contatti = new List<Contatto>();

            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);

                foreach (string line in lines)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        var valori = line.Split(";");
                        if (valori.Length == 5)
                        {
                            int id = int.Parse(valori[0]);
                            string email = String.IsNullOrEmpty(valori[4]) ? "" : valori[4];
                            Contatto contatto = new Contatto(id, valori[1], valori[2], valori[3], email);
                            
                            contatti.Add(contatto);
                        }


                    }
                }

                var selezione = contatti
                    .Where(x => x.Id == idContatto)
                    .Select(x => x)
                    .FirstOrDefault();


                // se la selezione non è vuota
                if (selezione != null)
                { 
                    string oldName = selezione.Nome;
                    // avvia modifica contatto con la selezione trovata
                    selezione.ModificaContatto();


                    Console.WriteLine($"{selezione.Id}, {selezione.Nome}, {selezione.Cognome}, {selezione.Numero}, {selezione.Email}");
                   
                    try
                    {
                        // se il file non esiste
                        if (!File.Exists(path))
                        {
                            File.Create(path).Dispose();
                        }

                        using (StreamWriter sw = new StreamWriter(path))
                        {
                            // per ogni elemento nel dictionary contatti
                            foreach (var elemento in contatti)
                            {
                                string email = String.IsNullOrEmpty(elemento.Email) ? "" : elemento.Email;
                                string informazioni = $"{elemento.Id};{elemento.Nome};{elemento.Cognome};{elemento.Numero};{email}";
                                Console.WriteLine(informazioni);
                                sw.WriteLine(informazioni);
                            }
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
        }
        public virtual void EliminaContatti(int idContatto)
        {
            //string path = "/Users/ale/Desktop/rubricaTelefonica/rubricaTelefonica/rubrica.txt";
            string path = "C:\\CODE\\rubricaTelefonica\\rubrica.txt";

            var contatti = new List<Contatto>();

            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);

                foreach (string line in lines)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        var valori = line.Split(";");
                        if (valori.Length == 5)
                        {
                            int id = int.Parse(valori[0]);
                            string email = String.IsNullOrEmpty(valori[4]) ? "" : valori[4];
                            Contatto contatto = new Contatto(id, valori[1], valori[2], valori[3], email);

                            contatti.Add(contatto);
                        }


                    }
                }

                var selezione = contatti
                    .Where(x => x.Id == idContatto)
                    .Select(x => x)
                    .FirstOrDefault();


                // se la selezione non è vuota
                if (selezione != null)
                {
                    
                    Console.WriteLine("Eliminare il contatto? [y,n]");
                    string ans = Console.ReadLine();
                    if (ans == "y")
                    {
                        int indiceContatto = contatti.IndexOf(selezione);
                        contatti.RemoveAt(indiceContatto);
                        try
                        {
                            if (!File.Exists(path))
                            {
                                File.Create(path).Dispose();
                            }
                            using (StreamWriter sw = new StreamWriter(path))
                            {
                                foreach (var elemento in contatti)
                                {
                                    string email = String.IsNullOrEmpty(elemento.Email) ? "" : elemento.Email;
                                    string informazioni = $"{elemento.Id};{elemento.Nome};{elemento.Cognome};{elemento.Numero};{email}";
                                    Console.WriteLine(informazioni);
                                    sw.WriteLine(informazioni);
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Exception: " + e.Message);
                        }
                        finally
                        {
                            Console.WriteLine("Dati eliminati correttamente");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Contatto non trovato");

                }
            }
        }
    }
}
