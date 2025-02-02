using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.CompilerServices;

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
                int id = GetIdAndIncrease();
                // stringa formattata che contiene le informazioni
                string informazioni = $"{id};{contatto.Nome};{contatto.Cognome};{contatto.Numero};{contatto.Email}";
                try
                {
                    //string path = "C:\\Users\\chiar\\Code\\rubricaTelefonica\\rubricaTelefonica\\rubrica.txt";
                    string path = "/Users/ale/Desktop/rubricaTelefonica/rubricaTelefonica/rubrica.txt";

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


        private int GetIdAndIncrease()
        {
            // path in cui si trova il file che contiene l'ultimo id selezionato
            //string path = "C:\\Users\\chiar\\Code\\rubricaTelefonica\\rubricaTelefonica\\id.txt";
            string path = "/Users/ale/Desktop/rubricaTelefonica/rubricaTelefonica/id.txt";
            // stringa che contiene l'ultimo id
            string line = "0";
            
            try
            {
                StreamReader sr = new StreamReader(path);
                // legge l'unica riga e la salva nella variabile line
                line = sr.ReadLine();

                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            // trasforma quello che trova in int
            int id = int.Parse(line);
            // aumenta l'id di 1
            id+=1;
            // salva l'id aumentato di 1 nel file, sovrascrivendolo
            try
            {
                if (!File.Exists(path))
                {
                    File.Create(path).Dispose();
                }

                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine(id);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            //ritorna l'id
            return id;
        }
    }

    
}
