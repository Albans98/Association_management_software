using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Association_S6
{
    abstract class Personne : I_Asso
    {
        protected int identifiant;
        protected string nom;
        protected string adresse;
        protected string tel;

        public Personne() { }

        #region Propriétés

        public int Identifiant 
        {
            // L'identifiant n'est pas modifiable
            get { return identifiant; }
        }

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public string Adresse
        {
            get { return adresse; }
            set { adresse = value; }
        }

        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }

        #endregion

        public new virtual string ToString()
        {
            return "La personne de nom " + nom + " a pour identifiant " + identifiant
                   + ".\nElle est située à l'adresse " + adresse + ".\nSon numéro de téléphone est " + tel + ".\n";
        }

        /// <summary>
        /// Méthode abstraite pour modifier les personnes dans les classes filles
        /// </summary>
        public abstract void Modification();

        /// <summary>
        /// Ajoute un don dans la liste
        /// </summary>
        public virtual void Ajouter()
        {
            Console.Write("Veuilliez saisir l'adress ==>");
            this.adresse = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Veuilliez saisir le numero de telephone ==>");
            this.tel = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Veuilliez saisir le nom ==>");
            this.nom = Console.ReadLine();
            Console.WriteLine();
        }
    }
}
