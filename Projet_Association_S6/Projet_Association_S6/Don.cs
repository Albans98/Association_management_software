using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Association_S6
{
    class Don : I_Asso, IDisposable
    {
        #region Attributs
        protected int identifiant;
        protected DateTime date;
        protected string type;
        protected string reference;
        protected Adhérent donateur;
        protected string description;
        protected double prix;
        protected string statut;
        protected int hauteur = 0;
        protected int largeur = 0;
        #endregion

        #region Constructeurs
        public Don() { }
        public Don(int id) { this.identifiant = id; }

        public Don(DateTime date, string type, string reference, Adhérent donateur, string description, int id, double prix, string statut, int hauteur, int largeur)
        {
            this.date = date;
            this.type = type;
            this.reference = reference;
            this.donateur = donateur;
            this.description = description;
            this.identifiant = id;
            this.prix = prix;
            this.statut = statut;
            this.hauteur = hauteur;
            this.largeur = largeur;
        }

        #endregion

        #region Propriétés
        public DateTime Date
        {
            get { return date; }
        }

        public string Type
        {
            get { return type; }
        }

        public string Reference
        {
            get { return reference; }
        }

        public Adhérent Donateur
        {
            get { return donateur; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public double Prix
        {
            get { return prix; }
            set { prix = value; }
        }

        public int Identifiant
        {
            get { return identifiant; }
        }

        public string Statut { get { return this.statut; } }

        public int Hauteur
        {
            get { return this.hauteur; }
        }

        public int Largeur
        {
            get { return this.largeur; }
        }
        #endregion

        public override string ToString()
        {
            return "- - DON - -\nUn don de type " + type + " et de référence " + reference + " a été fait le " + date.ToString()
                   + ".\nLe donateur est :\n" + donateur.ToString() + "\nVoici la description du produit :\n" + description + ".\nPrix : "
                   + prix + ".\nDimensions : " + hauteur + "x" + largeur + ".\nID du don : " + identifiant + ".\n";
        }

        /// <summary>
        /// Affiche sous forme de liste
        /// </summary>
        /// <returns></returns>
        public string AfficheENList()
        {
            return String.Format(" {0} | {1} | {2} | {3} ==> {4} | {5} | ", identifiant, date.ToString(), reference, type, description, donateur.ToString());
        }

        /// <summary>
        /// Créer un don
        /// </summary>
        /// <param name="d"></param>
        public void CreationDON(Adhérent d)
        {
            
            this.date = DateTime.Now;
            this.donateur = d;
            this.statut = "En attende";
            Console.Write("Veuillez saisir la reference de votre object ==>");
            this.reference = Console.ReadLine();
            Console.WriteLine();
            List<string> TypeETDescription = Program.TypeObjets();
            this.type = TypeETDescription[0];
            this.description = TypeETDescription[1];
            TypeETDescription.Clear();
            if (type != "Vaisselle")
            {
                Console.Write("Votre " + this.description + " est de hauteur ==>");
                this.hauteur = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                Console.Write("Votre " + this.description + " est de largeur ==>");
                this.largeur = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
            }
            Console.Write("Veuillez saisir le prix de votre objet ==>");
            this.prix = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

        }

        /// <summary>
        /// Modifie le statut du don
        /// </summary>
        /// <param name="decision"></param>
        public void TraitementDon(int decision)
        {
            switch (decision)
            {
                case 1:
                    this.statut = "Acceptee";
                    break;
                case 2:
                    this.statut = "Refusee";
                    break;
            }
        }
        /// <summary>
        /// utiliser pour effacer les doublant 
        /// </summary>
        #region IDisposable 
        private bool disposedValue = false; // Pour détecter les appels redondants

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: supprimer l'état managé (objets managés).


                }

                // TODO: libérer les ressources non managées (objets non managés) et remplacer un finaliseur ci-dessous.
                // TODO: définir les champs de grande taille avec la valeur Null.

                disposedValue = true;
            }
        }

        // TODO: remplacer un finaliseur seulement si la fonction Dispose(bool disposing) ci-dessus a du code pour libérer les ressources non managées.
        ~Don()
        {
            Dispose(false);
        }

        // Ce code est ajouté pour implémenter correctement le modèle supprimable.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
