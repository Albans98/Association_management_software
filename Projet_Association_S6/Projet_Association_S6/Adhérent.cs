using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Association_S6
{
    sealed class Adhérent : Personne
    {
        private string prenom;
        private string fonction;

        public Adhérent(int identifiant)
        {
            this.identifiant = identifiant;
        }

        public Adhérent(string prenom, string fonction, int identifiant, string nom, string adresse, string tel)
        {
            this.prenom = prenom;
            this.fonction = fonction;
            this.identifiant = identifiant;
            this.nom = nom;
            this.adresse = adresse;
            this.tel = tel;
        }

        public string Prenom
        {
            get { return prenom; }
        }

        public string Fonction
        {
            get { return fonction; }
            set { fonction = value; }
        }

        public override string ToString()
        {
            return base.ToString() + "Cette personne est adhérente à l'association et elle a pour fonction " + fonction + ".\nSon prénom est " + prenom + ".\n";
        }

        /// <summary>
        /// Fonction de modification des adhérents
        /// </summary>
        public override void Modification()
        {
            Console.Clear();
            Console.WriteLine("__________________________________________________________________________");
            Console.WriteLine(ToString());
            Console.WriteLine("__________________________________________________________________________");
            Console.WriteLine("\nQue voulez vous modifier:\n" +
                "1-Nom\n" + "2-Prenom\n" + "3-Adresse\n" + "4-Numero de Telephone\n" + "5-Fonction\n");
            int choix = Program.SaisirChoix(5);
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
                    Console.WriteLine("\n----------------Modification du Preom----------------");
                    Console.Write("Veuillez ecrire le nouveaux prenom == > ");
                    changement = Console.ReadLine();
                    Console.WriteLine();
                    this.prenom = changement;
                    Console.WriteLine(" Bien Modifier !!");
                    break;
                case 3:
                    Console.WriteLine("\n----------------Modification du Adresse----------------");
                    Console.Write("Veuillez ecrire le nouveaux adresse == > ");
                    changement = Console.ReadLine();
                    Console.WriteLine();
                    this.adresse = changement;
                    Console.WriteLine(" Bien Modifier !!");
                    break;
                case 4:
                    Console.WriteLine("\n----------------Modification du Numero de Telephone----------------");
                    Console.Write("Veuillez ecrire le nouveaux numero de telephone == > ");
                    changement = Console.ReadLine();
                    Console.WriteLine();
                    this.tel = changement;
                    Console.WriteLine(" Bien Modifier !!");
                    break;
                case 5:
                    Console.WriteLine("\n----------------Modification de la Fonction----------------");
                    Console.Write("Veuillez ecrire la nouvelle fonction == > ");
                    changement = Console.ReadLine();
                    Console.WriteLine();
                    this.fonction = changement;
                    Console.WriteLine(" Bien Modifier !!");
                    break;

            }
        }

        /// <summary>
        /// Ajoute un adhérent
        /// </summary>
        public override void Ajouter()
        {
            base.Ajouter();
            Console.Write("Veuilliez saisir le prenom ==>");
            this.prenom = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Veuilliez saisir la fonction ==>");
            this.fonction = Console.ReadLine();
            Console.WriteLine();
        }
    }
}
