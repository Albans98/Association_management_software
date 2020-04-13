using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Association_S6
{
    sealed class Don_Refuse : Don
    {
        private DateTime date_refus;
        private string motif;

        public Don_Refuse(string motif, Don d):this(motif, DateTime.Now, d) { }

        public Don_Refuse(string motif, DateTime date, Don d)
        {
            this.motif = motif;
            this.date_refus = date;
            this.date = d.Date;
            this.type = d.Type;
            this.reference = d.Reference;
            this.donateur = d.Donateur;
            this.description = d.Description;
            this.identifiant = d.Identifiant;
            this.prix = d.Prix;
            this.statut = "Refusé & Archivé";
        }

        public DateTime Date_refus
        {
            get { return date_refus; }
        }

        public string Motif
        {
            get { return motif; }
        }

        public override string ToString()
        {
            return base.ToString() + "Ce don a été refusé le " + date_refus.ToString() + " pour le motif suivant : " + motif + ".\n";
        }

    }
}
