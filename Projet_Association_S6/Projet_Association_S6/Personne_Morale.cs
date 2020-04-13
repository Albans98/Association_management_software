using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Association_S6
{
    sealed class Personne_Morale : Personne
    {
        private string activite;

        // Constructeur pour créer une personne morale depuis le programme
        public Personne_Morale(int identifiant)
        {
            this.identifiant = identifiant;
        }

        public Personne_Morale(string activite, int identifiant, string nom, string adresse, string tel)
        {
            this.activite = activite;
            this.identifiant = identifiant;
            this.nom = nom;
            this.adresse = adresse;
            this.tel = tel;
        }

        public string Activite
        {
            get { return activite; }
        }

        /// <summary>
        /// Modifie une personne morale
        /// </summary>
        public override void Modification()
        {
            Console.Clear();
            Console.WriteLine("__________________________________________________________________________");
            Console.WriteLine(ToString());
            Console.WriteLine("__________________________________________________________________________");
            Console.WriteLine("\nQue voulez vous modifier:\n" +
                "1-Nom\n" + "2-Adresse\n" + "3-Numero de Telephone\n" + "\n");
            int choix = Program.SaisirChoix(3);
            string changement;
            switch (choix)
            {
                case 1:
                    Console.WriteLine("\n----------------Modification du Nom----------------");
                    Console.Write("Veuillez ecrire le nouveaux nom == > ");
                    changement = Console.ReadLine();
                    Console.WriteLine();
                    this.nom = changement;
                    Console.WriteLine(" Bien Modifier !!");
                    break;
                case 2:
                    Console.WriteLine("\n----------------Modification du Adresse----------------");
                    Console.Write("Veuillez ecrire le nouveaux adresse == > ");
                    changement = Console.ReadLine();
                    Console.WriteLine();
                    this.adresse = changement;
                    Console.WriteLine(" Bien Modifier !!");
                    break;
                case 3:
                    Console.WriteLine("\n----------------Modification du Numero de Telephone----------------");
                    Console.Write("Veuillez ecrire le nouveaux numero de telephone == > ");
                    changement = Console.ReadLine();
                    Console.WriteLine();
                    this.tel = changement;
                    Console.WriteLine(" Bien Modifier !!");
                    break;

            }
        }

        public override string ToString()
        {
            return base.ToString() + "C'est une personne morale de type d'activité suivant : " + activite + ".\n";
        }

        /// <summary>
        /// Ajoute une personne morale aux relations de l'association
        /// </summary>
        public override void Ajouter()
        {
            base.Ajouter();
            Console.Write("Veuilliez saisir l' activite ==>");
            this.activite = Console.ReadLine();
            Console.WriteLine();
        }
    }
}
