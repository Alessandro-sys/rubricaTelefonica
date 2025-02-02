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
        static private int id;

        

        public virtual void AggiungiContatto()
        {
            Contatto contatto = new Contatto();
            
            contatto.AggiungiContatto();
            
            
            Console.Write($"Le informazioni inserite sono: {contatto.Nome};{contatto.Cognome};{contatto.Numero};{contatto.Email}. \nVuoi aggiungere il contatto? [y/n]");
            string ans = Console.ReadLine().ToLower();
            while (ans != "y" && ans != "n")
            {
                Console.Write("Inserisci una risposta valida \nVuoi aggiungere il contatto? [y/n]");
                ans = Console.ReadLine().ToLower();
            }
            
            if (ans == "y")
            {
                Rubrica.id++;
                string informazioni = $"{Rubrica.id};{contatto.Nome};{contatto.Cognome};{contatto.Numero};{contatto.Email}";
                try
                {
                    string path = "C:\\Users\\chiar\\Code\\rubricaTelefonica\\rubricaTelefonica\\rubrica.txt";


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
                    Console.WriteLine("Executing finally block.");
                }

                try
                {
                    string path = "C:\\Users\\chiar\\Code\\rubricaTelefonica\\rubricaTelefonica\\id.txt";


                    if (!File.Exists(path))
                    {
                        File.Create(path).Dispose();
                    }

                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        sw.WriteLine(Rubrica.id);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
                finally
                {
                    Console.WriteLine("Executing finally block.");
                }
            }
        }


        private int GetId()
        {
            string path = "C:\\Users\\chiar\\Code\\rubricaTelefonica\\rubricaTelefonica\\id.txt";
            string line = "0";
            try
            {
                StreamReader sr = new StreamReader(path);
                
                line = sr.ReadLine();
                Console.WriteLine(line);

                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
            int id = int.Parse(line);
            return id;
        }
    }

    
}
