using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Association_S6
{
    sealed class Don_accepté : Don
    {
        private Personne_Morale lieu_stockage;
        private Adhérent gestionnaire; // Adhérent qui s'est occupé de la gestion du don
        Bénéficiaire beneficiaire;
        bool reserver = false;

        #region Propriétés + Constructeur 
        public Don_accepté(Personne_Morale lieu_stockage, Adhérent gestionnaire, Don d)
        {
            this.lieu_stockage = lieu_stockage;
            this.gestionnaire = gestionnaire;
            this.date = d.Date;
            this.type = d.Type;
            this.reference = d.Reference;
            this.donateur = d.Donateur;
            this.description = d.Description;
            this.identifiant= d.Identifiant;
            this.hauteur = d.Hauteur;
            this.largeur = d.Largeur;
            this.prix = d.Prix;
            this.beneficiaire = null;
            this.reserver = false;
            if (lieu_stockage == null) this.statut = "Acceptee";
            else this.statut = "Stocke";
        }

        public Don_accepté (Adhérent gestionnaire, Don d):this(null, gestionnaire,d)
        {
        }

        public Personne_Morale Changer_Lieu_stockage
        {
            set { lieu_stockage = value; }
        }

        public Adhérent Gestionnaire
        {
            get { return gestionnaire; }
        }

        public Personne_Morale Lieu_stock
        {
            get { return lieu_stockage; }
        }

        public string Lieu_stockage
        {
            get
            {
                string s = "Le don est  stocke ";
                if (lieu_stockage != null) s += "au " + this.lieu_stockage.Activite;
                else s += "chez le donneur";
                return s;
            }
        }

        public bool Reserver
        {
            get { return this.reserver; }
            set { this.reserver = value; }
        }

        public Bénéficiaire Beneficiaire
        {
            get { return this.beneficiaire; }
            set { this.beneficiaire = value; }
        }

        #endregion

        public override string ToString()
        {
            if (lieu_stockage != null)
            {
                return base.ToString() + "Ce don est stocké dans le lieu suivant :\n" + lieu_stockage.ToString()
                   + "La personne qui s'est occupée de la gestion du dossier est l'adhérent décrit comme suit :\n" + gestionnaire.ToString();
            }
            else
            {
                return base.ToString() + "Ce don est stocké dans le lieu suivant : chez l'adhérent ou dans l'association.\n"
                   + "La personne qui s'est occupée de la gestion du dossier est l'adhérent décrit comme suit :\n" + gestionnaire.ToString();
            }
        }

        /// <summary>
        /// Définit le lieu de stockage d'un don
        /// </summary>
        /// <param name="lieuStockage"></param>
        public void StokageDon(Personne_Morale lieuStockage)
        {
            if (this.statut == "Stocke")
            {
                Console.WriteLine("Votre objet est deja stocke au " + this.lieu_stockage.Activite);
                Console.Write("Voulez vous changer son lieu de stockage [Y|N] ==>");
                if (Console.ReadLine().ToUpper()[0] == 'Y')
                {
                    this.lieu_stockage = lieuStockage;
                }
            }
            else
            {
                this.statut = "Stocke";
                this.lieu_stockage = lieuStockage;
            }
            
        }

        /// <summary>
        /// Donne le don au bénéficiaire
        /// </summary>
        public void Transfert()
        {
            if (reserver)
            {
                Console.WriteLine(Lieu_stockage);
                Console.WriteLine("un mail ete envoye pour le transfert ");
                this.statut = "Donne";
            }
            else
            {
                Console.WriteLine("le don choisi n'etait pas associe a une demande");
            }
        }

        /// <summary>
        /// Modifie le statut du don en 'Archivé'
        /// </summary>
        public void Archive() { this.statut = "Donné & Archivé"; }
    }
}
