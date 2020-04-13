using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Association_S6
{
    class Archive<T> : I_Asso
    {
        private int id;
        private T archivee;
        DateTime date;

        public Archive(T archivee, int id, DateTime date)
        {
            this.id = id; 
            this.archivee = archivee;
            this.date = date;
        }

        public Archive(T archivee, int id)
        {
            this.id = id;
            this.archivee = archivee;
            this.date = DateTime.Now;
        }

        public DateTime Date
        {
            get { return this.date; }
        }

        public int Identifiant
        {
            get { return id; }
        }

        public T Archivee
        {
            get { return archivee; }
        }
    }
}
