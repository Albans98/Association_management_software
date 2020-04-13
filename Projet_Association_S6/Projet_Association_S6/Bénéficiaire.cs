using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Association_S6
{
    sealed class Bénéficiaire : Personne
    {
        private string prenom;
        private DateTime date_naissance;

        public Bénéficiaire(string prenom, DateTime date_naissance, int identifiant, string nom, string adresse, string tel)
        {
            this.prenom = prenom;
            this.date_naissance = date_naissance;
            this.identifiant = identifiant;
            this.nom = nom;
            this.adresse = adresse;
            this.tel = tel;
        }

        public Bénéficiaire(int identifiant)
        {
            this.identifiant = identifiant;
        }

        public string Prenom
        {
            get { return prenom; }
            set { prenom = value; }
        }

        public DateTime Date_naissance
        {
            get { return date_naissance; }
        }

        public override string ToString()
        {
            return base.ToString() + "Cette personne est bénéficiaire de l'association et a pour prénom " + prenom
                   + ".\nElle est née le " + date_naissance.ToString() + ".\n";
        }

        /// <summary>
        /// Fonction de modification des bénéficiaires
        /// </summary>
        public override void Modification()
        {
            Console.Clear();
            Console.WriteLine("__________________________________________________________________________");
            Console.WriteLine(ToString());
            Console.WriteLine("__________________________________________________________________________");
            Console.WriteLine("\nQue voulez vous modifier:\n" +
                "1-Nom\n" + "2-Prenom\n" + "3-Adresse\n" + "4-Numero de Telephone\n" + "5-Date de Naissance\n");
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
                    Console.WriteLine("\n----------------Modification de la Date de Naissance ----------------");
                    Console.WriteLine("Veuillez ecrire la nouvelle date de naissance == > ");
                    Console.Write("\t\tLe jour ==>");
                    int jour = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    Console.Write("\t\tLe Mois ==>");
                    int mois = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    Console.Write("\t\tL'Année ==>");
                    int annee = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();

                    this.date_naissance = new DateTime(annee, mois, jour);

                    Console.WriteLine(" Bien Modifier !!");
                    break;

            }
        }

        /// <summary>
        /// Ajoute un bénéficiaire de l'association
        /// </summary>
        public override void Ajouter()
        {
            base.Ajouter();
            Console.Write("Veuilliez saisir le prenom ==>");
            this.prenom = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Veuillez ecrire la date de naissance == > ");
            Console.Write("\t\tLe jour ==>");
            int jour = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.Write("\t\tLe Mois ==>");
            int mois = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.Write("\t\tL'Année ==>");
            int annee = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            this.date_naissance = new DateTime(annee, mois, jour);

        }
    }
}
