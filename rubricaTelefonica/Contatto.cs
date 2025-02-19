﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace rubricaTelefonica
{
    class Contatto : Rubrica
    {
        private int id;
        private string nome;
        private string cognome;
        private string numero;
        private string? email;

        public int Id { get => this.id;  }
        public string Nome { get => this.nome; }
        public string Cognome { get => this.cognome; }
        public string Numero { get => this.numero; }
        public string Email { get => this.email; }


        public Contatto() { }

        public Contatto(string nome, string cognome, string numero)
        {
            this.nome = nome;
            this.cognome = cognome;
            this.numero = numero;
        }

        public Contatto(string nome, string cognome, string numero, string email)
        {
            this.nome = nome;
            this.cognome = cognome;
            this.numero = numero;
            this.email = email;
        }
        public Contatto(int id, string nome, string cognome, string numero, string email)
        {
            this.id = id;
            this.nome = nome;
            this.cognome = cognome;
            this.numero = numero;
            this.email = email;
        }

        public new void AggiungiContatto()
        {
            SetID();
            SetNomeCognome(1);
            SetNomeCognome(2);
            AggiungiNumero();
            AggiungiEmail();
            
        }
        public void ModificaContatto()
        {
            Console.WriteLine("Cosa vuoi modificare?");
            Console.WriteLine("1. Nome\n2. Cognome\n3. Numero\n4. Email");

            int ans = int.Parse(Console.ReadLine());
            
            switch (ans)
            {
                case 1:
                    SetNomeCognome(1);
                    break;
                case 2:
                    SetNomeCognome(2);
                    break;
                case 3:
                    AggiungiNumero();
                    break;
                case 4:
                    AggiungiEmail();
                    break;
                default:
                    Console.WriteLine("Inserisci un'operazione disponibile");
                    break;
            }

        }


        private void SetID()
        {
            // path in cui si trova il file che contiene l'ultimo id selezionato
            string path = "C:\\CODE\\rubricaTelefonica\\rubrica.txt";
            //string path = "/Users/ale/Desktop/rubricaTelefonica/rubricaTelefonica/id.txt";
            // stringa che contiene l'ultimo id
            string line = "0";

            try
            {
                line = File.ReadLines(path).Last();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            var valori = line.Split(';');
            int id = int.Parse(valori[0]);
            this.id = id + 1;
        }
        private void SetNomeCognome(int val)
        {
            string court = val == 1 ? "nome" : "cognome";
            string? nome;
            bool flag = false;
            do
            {
                if (flag) Console.WriteLine($"Inserisci il {court}");
                else flag = true;

                Console.Write($"Inserisci il {court} del contatto: ");
                nome = Console.ReadLine();

            } while (nome == null);
            if (val == 1) this.nome = nome.Trim();
            else this.cognome = nome.Trim();
        }
        private void AggiungiNumero()
        {
            string? num;
            bool flag = false;
            do
            {
                if (flag) Console.WriteLine("Inserisci un numero di telefono valido! ");
                else flag = true;

                Console.Write("Inserisci il numero di telefono +39 ");
                num = Console.ReadLine();

            } while (num == null || num.Length != 10);
            
            this.numero = num.Trim();

        }
        private void AggiungiEmail()
        {
            string? email;
            Console.Write("Inserisci l'e-mail del contatto (premi invio per saltare questo passaggio) ");
            email = Console.ReadLine();
            if (string.IsNullOrEmpty(email)) this.email = null;
            else this.email = email.Trim();
                
            
        }

    }
}
