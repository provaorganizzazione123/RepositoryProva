using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class TodoItem
    {
        /* Classe per l'istanziamento delle funzioni CRUD */

        // Propietà:
        // ID -> Chiave univoca a DB
        // Name -> Nome descrittivo delle funzioni
        // IsComplete -> Booleana di controllo esecuzione della funzione

        public int ID { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }

    }
}
