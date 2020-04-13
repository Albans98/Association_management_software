using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Association_S6
{
    class Demande : I_Asso
    {
        private int id;
        private DateTime date;
        private string description;
        private string statut;
        Bénéficiaire benef;

        #region Propriétés

        public int Identifiant
        {
            get
            {
                return id;
            }
        }

        public DateTime Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public string Statut
        {
            get
            {
                return statut;
            }

            set
            {
                statut = value;
            }
        }

        public Bénéficiaire Benef
        {
            get
            {
                return benef;
            }

            set
            {
                benef = value;
            }
        }

        #endregion

        public Demande(int id)
        {
            this.id = id;
        }

        public Demande(int id, DateTime date, string description, string statut, Bénéficiaire benef)
        {
            this.id = id;
            this.date = date;
            this.description = description;
            this.statut = statut;
            this.benef = benef;
        }

        public override string ToString()
        {
            return "La demande d'id " + id + " a été faite le " + date.ToString() + ".\nLa requête est : " + description + ".\n" +
                   "Le statut est actuellement " + statut + " et le bénéficiaire est " + benef.ToString();
        }

        /// <summary>
        /// Ajoute une nouvelle demande pour l'association
        /// </summary>
        /// <param name="b"></param>
        public void Creation_Demande(Bénéficiaire b)
        {
            this.date = DateTime.Now;
            this.benef = b;
            this.statut = "En attente de Validation";
            this.description = Program.TypeObjets()[1];
            Console.WriteLine();
        }

        /// <summary>
        /// Traite la demande : définit un nouveau statut pour celle-ci
        /// </summary>
        /// <param name="decision"></param>
        public void TraitementDemande(int decision)
        {
            switch (decision)
            {
                case 1:
                    this.statut = "Acceptee, en cours de traitement";
                    break;
                case 2:
                    this.statut = "En attente, aucune don trouve convient à cette demande";
                    break;
            }
        }
    }
}
