using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Projet_Association_S6
{
    class Association
    {
        #region Attributs
        private List<Demande> ListDeDemande = new List<Demande>();
        private List<Don_accepté> ListDeDonActuels = new List<Don_accepté>();
        private List<Don> ListDon = new List<Don>();

        private List<Bénéficiaire> ListDeBénéficiaire = new List<Bénéficiaire>();
        private List<Personne_Morale> ListDePersonneMorale = new List<Personne_Morale>();
        private List<Adhérent> ListDeAdhérent = new List<Adhérent>();

        private List<Archive<Don_accepté>> ArchiveDonAccepte = new List< Archive <Don_accepté>> ();
        private List<Archive<Demande>> ArchiveDemande = new List<Archive<Demande>>();
        private List<Archive<Don_Refuse>> ArchiveDonRefuse = new List<Archive<Don_Refuse>>();
        #endregion

        #region Propriétés lecture/écriture
        public List<Demande> ListDeDemande1
        {
            get
            {
                return ListDeDemande;
            }

            set
            {
                ListDeDemande = value;
            }
        }

        public List<Don_accepté> ListDeDonActuels1
        {
            get
            {
                return ListDeDonActuels;
            }

            set
            {
                ListDeDonActuels = value;
            }
        }

        public List<Bénéficiaire> ListDeBénéficiaire1
        {
            get
            {
                return ListDeBénéficiaire;
            }

            set
            {
                ListDeBénéficiaire = value;
            }
        }

        public List<Personne_Morale> ListDePersonneMorale1
        {
            get
            {
                return ListDePersonneMorale;
            }

            set
            {
                ListDePersonneMorale = value;
            }
        }

        public List<Adhérent> ListDeAdhérent1
        {
            get
            {
                return ListDeAdhérent;
            }

            set
            {
                ListDeAdhérent = value;
            }
        }

        public List<Archive<Don_accepté>> ArchiveDonAccepte1
        {
            get
            {
                return ArchiveDonAccepte;
            }

            set
            {
                ArchiveDonAccepte = value;
            }
        }

        public List<Archive<Demande>> ArchiveDemande1
        {
            get
            {
                return ArchiveDemande;
            }

            set
            {
                ArchiveDemande = value;
            }
        }

        public List<Archive<Don_Refuse>> ArchiveDonRefuse1
        {
            get
            {
                return ArchiveDonRefuse;
            }

            set
            {
                ArchiveDonRefuse = value;
            }
        }

        public List<Don> ListDon1 { get { return this.ListDon; } set { ListDon = value; } }
        #endregion

        #region Constructeur de l'association
        /// <summary>
        /// Constructeur de l'association "Mobilier pour tous"
        /// Récupère les informations des fichiers à chaque lancement du programme
        /// </summary>
        public Association()
        {
            Recup_Personnes();
            Recup_Demandes();
            Recup_Archives();
            Recup_Dons_Actuels();
            Recup_Dons();
        }
        #endregion

        #region Calculs de moyenne
        /// <summary>
        /// Moyenne simple du prix des dons
        /// </summary>
        public void moyenne_prix()
        {
            double moyenne = 0;
            for (int i = 0; i < ListDeDonActuels.Count; i++)
            {
                moyenne += ListDeDonActuels[i].Prix;
            }
            moyenne /= ListDeDonActuels.Count;
            Console.WriteLine("La moyenne de prix des dons est de " + moyenne + " euros.");
        }

        /// <summary>
        /// Moyenne simple de l'âge des bénéficiaires
        /// </summary>
        public void moyenne_age_beneficiaires()
        {
            double moyenne = 0;
            for (int i = 0; i < ListDeBénéficiaire.Count; i++)
            {
                moyenne += (DateTime.Now.Year - ListDeBénéficiaire[i].Date_naissance.Year);
            }
            moyenne /= ListDeBénéficiaire.Count;
            Console.WriteLine("La moyenne d'âge des bénéficiaires est : " + moyenne + ".\n");
        }

        /// <summary>
        /// Affiche la moyenne de temps entre la date de réception et la date de retrait des dons dans les zone de stockage
        /// </summary>
        public void affiche_moyenne_duree_retrait()
        {
            TimeSpan moyenne = new TimeSpan();
            for (int i = 0; i < ArchiveDonAccepte.Count; i++)
            {
                moyenne += ArchiveDonAccepte[i].Date - ArchiveDonAccepte[i].Archivee.Date;
            }
            double nb = (double) moyenne.Days / ArchiveDonAccepte.Count;
            Console.WriteLine("Nombre de jours : " + nb);
        }

        #endregion

        #region Fonctions de recherche
        /// <summary>
        /// Recherche d'un bénéficiaire selon son numéro de téléphone en utilisant une délégation
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public Bénéficiaire Recherche_benef_par_tel(string num)
        {
            Bénéficiaire b = ListDeBénéficiaire.Find(x => x.Tel == num);
            return b;
        }

        /// <summary>
        /// Recherche d'un bénéficiaire selon son nom en utilisant une délégation
        /// </summary>
        /// <param name="nom"></param>
        /// <returns></returns>
        public Bénéficiaire Recherche_benef_par_nom(string nom)
        {
            Bénéficiaire b = ListDeBénéficiaire.Find(x => x.Nom == nom);
            return b;
        }

        /// <summary>
        /// Recherche d'un bénéficiaire selon id de téléphone en utilisant une délégation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Bénéficiaire Recherche_benef_par_id(int id)
        {
            Bénéficiaire b = ListDeBénéficiaire.Find(x => x.Identifiant == id);
            return b;
        }

        /// <summary>
        /// Recherche d'un adhérent selon son id en utilisant une délégation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Adhérent Recherche_adherent_par_id(int id)
        {
            Adhérent a = ListDeAdhérent.Find(x => x.Identifiant == id);
            return a;
        }

        /// <summary>
        /// Recherche d'un adhérent selon son nom en utilisant une délégation
        /// </summary>
        /// <param name="nom"></param>
        /// <returns></returns>
        public Adhérent Recherche_adherent_par_nom(string nom)
        {
            Adhérent a = ListDeAdhérent.Find(x => x.Nom == nom);
            return a;
        }

        /// <summary>
        /// Recherche d'une personne morale selon son id en utilisant une délégation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Personne_Morale Recherche_personne_morale_par_id(int id)
        {
            Personne_Morale p = ListDePersonneMorale.Find(x => x.Identifiant == id);
            return p;
        }

        /// <summary>
        /// Recherche d'une personne morale selon son nom en utilisant une délégation
        /// </summary>
        /// <param name="nom"></param>
        /// <returns></returns>
        public Personne_Morale Recherche_personne_morale_par_nom(string nom)
        {
            Personne_Morale p = ListDePersonneMorale.Find(x => x.Nom == nom);
            return p;
        }

        /// <summary>
        /// Fonction qui affiche les informations d'une personne recherchée
        /// </summary>
        /// <param name="choix"></param>
        public void Recherche_personnes(int choix)
        {
            Console.WriteLine("Voulez-vous chercher par nom (1) ou ID (2) ?");
            int recherche = Program.SaisirChoix(2);
            if (recherche == 1)
            {
                switch(choix)
                {
                    case 1:
                        Console.WriteLine("Entrez le nom du bénéficiaire :");
                        string nom = Console.ReadLine();
                        Bénéficiaire b = Recherche_benef_par_nom(nom);
                        if (b != null) Console.WriteLine(b.ToString());
                        else Console.WriteLine("La personne demandée n'existe pas dans la base de données");
                        break;
                    case 2:
                        Console.WriteLine("Entrez le nom de l'adhérent :");
                        string nom1 = Console.ReadLine();
                        Adhérent a = Recherche_adherent_par_nom(nom1);
                        if(a != null) Console.WriteLine(a.ToString());
                        else Console.WriteLine("La personne demandée n'existe pas dans la base de données");
                        break;
                    case 3:
                        Console.WriteLine("Entrez le nom de la personne morale :");
                        string nom2 = Console.ReadLine();
                        Personne_Morale p = Recherche_personne_morale_par_nom(nom2);
                        if (p != null) Console.WriteLine(p.ToString());
                        else Console.WriteLine("La personne demandée n'existe pas dans la base de données");
                        break;
                }
            }
            else
            {
                switch (choix)
                {
                    case 1:
                        Console.WriteLine("Entrez l'id du bénéficiaire :");
                        int id = Program.SaisirChoix(999999);
                        Bénéficiaire b = Recherche_benef_par_id(id);
                        if(b != null) Console.WriteLine(b.ToString());
                        else Console.WriteLine("La personne demandée n'existe pas dans la base de données");
                        break;
                    case 2:
                        Console.WriteLine("Entrez l'id de l'adhérent :");
                        int id1 = Program.SaisirChoix(999999);
                        Adhérent a = Recherche_adherent_par_id(id1);
                        if (a != null) Console.WriteLine(a.ToString());
                        else Console.WriteLine("La personne demandée n'existe pas dans la base de données");
                        break;
                    case 3:
                        Console.WriteLine("Entrez l'id de la personne morale :");
                        int id2 = Program.SaisirChoix(999999);
                        Personne_Morale p = Recherche_personne_morale_par_id(id2);
                        if(p != null) Console.WriteLine(p.ToString());
                        else Console.WriteLine("La personne demandée n'existe pas dans la base de données");
                        break;
                }
            }
        }

        /// <summary>
        /// Recherche un don par id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Don Recherche_don_par_id(int id)
        {
            Don d = ListDon.Find(x => x.Identifiant == id);
            return d;
        }

        /// <summary>
        /// Recherche un don accepté par id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Don_accepté Recherche_don_Accepte_par_id(int id)
        {
            Don_accepté d = ListDeDonActuels.Find(x => x.Identifiant == id);
            return d;
        }

        /// <summary>
        /// Recherche une demande par id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Demande Recherche_Demande_par_id(int id)
        {
            Demande d = ListDeDemande.Find(x => x.Identifiant == id);
            return d;
        }

        #endregion

        #region Affichage informations

        /// <summary>
        /// Affiche dons refusés triés par date
        /// </summary>
        public void affiche_dons_refuses()
        {  
            if(ArchiveDonRefuse.Count>0)
            {
                Comparison<Archive<Don_Refuse>> f = delegate (Archive<Don_Refuse> d1, Archive<Don_Refuse> d2) { return d1.Archivee.Date_refus.CompareTo(d2.Archivee.Date_refus); };
                ArchiveDonRefuse.Sort(f);

                for (int i = 0; i < ArchiveDonRefuse.Count; i++)
                {
                    Console.WriteLine(ArchiveDonRefuse[i].Archivee.ToString());
                }
            }
            else Console.WriteLine("il y a pas de don refuse dans notre base de donnes");
        }

        /// <summary>
        /// Affiche dons en attente de l'asso triés par ID
        /// </summary>
        public void affiche_dons_en_traitement()
        {
            if (ListDon.Count >0)
            {
                Comparison<Don> f = delegate (Don d1, Don d2) { return d1.Identifiant.CompareTo(d2.Identifiant); };
                ListDon.Sort(f);
                Console.WriteLine("Liste de dons en traitement triés par ID :");
                for (int i = 0; i < ListDon.Count; i++)
                {
                    Console.WriteLine(ListDon[i].ToString());
                }
            }
            else Console.WriteLine("il y a pas des don en cours de traitement");
        }

        /// <summary>
        /// Affiche dons archivés qui ont été donnés triés par numéro de bénéficiaire
        /// </summary>
        public void affiche_dons_donnes_vendus()
        {
            if(ArchiveDonAccepte.Count >0)
            {
                Comparison<Archive<Don_accepté>> f = delegate (Archive<Don_accepté> d1, Archive<Don_accepté> d2) { return d1.Archivee.Beneficiaire.Identifiant.CompareTo(d2.Archivee.Beneficiaire.Identifiant); };
                ArchiveDonAccepte.Sort(f);
                for (int i = 0; i < ArchiveDonAccepte.Count; i++)
                {
                    Console.WriteLine(ArchiveDonAccepte[i].Archivee.ToString());
                }
            }
            else Console.WriteLine("il ya pas des don archive ");
        }
        
        /// <summary>
        /// Affiche les dons des entrepôts triés par type
        /// </summary>
        public void affiche_dons_entrepot()
        {
            
            if (ListDeDonActuels.Exists(x=> x.Lieu_stock.Activite.ToUpper() == "ENTREPOT"))
            {
                Comparison<Don_accepté> f = delegate (Don_accepté d1, Don_accepté d2) { return d1.Type.CompareTo(d2.Type); };
                ListDeDonActuels.Sort(f);
                for (int i = 0; i < ListDeDonActuels.Count; i++)
                {
                    if (ListDeDonActuels[i].Lieu_stock != null)
                    {
                        if (ListDeDonActuels[i].Lieu_stock.Activite.ToUpper() == "ENTREPOT") Console.WriteLine(ListDeDonActuels[i].ToString());
                    }
                }
            }
            else Console.WriteLine("il exsite pas des don dans l'entrepot ");
            
        }

        /// <summary>
        /// Affiche les dons des dépôts-vente triés par prix
        /// </summary>
        public void affiche_dons_depot()
        {
            if (ListDeDonActuels.Exists(x => x.Lieu_stock.Activite.ToUpper() == "DEPOT"))
            {
                Comparison<Don_accepté> f = delegate (Don_accepté d1, Don_accepté d2) { return d1.Prix.CompareTo(d2.Prix); };
                ListDeDonActuels.Sort(f);
                for (int i = 0; i < ListDeDonActuels.Count; i++)
                {
                    if (ListDeDonActuels[i].Lieu_stock != null)
                    {
                        if (ListDeDonActuels[i].Lieu_stock.Activite.ToUpper() == "DEPOT") Console.WriteLine(ListDeDonActuels[i].ToString());
                    }
                }
            }
            else Console.WriteLine("il exsite pas des don dans le depot ");
        }

        /// <summary>
        /// Affiche les infos d'uen personne quelconque
        /// </summary>
        /// <param name="choix"></param>
        public void AffichePersonne(int choix)
        {
            switch (choix)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("\t\t1 / Afficher Bénéficiaires  ");
                    Console.WriteLine("_____________________________________________\n");
                    AfficherList<Bénéficiaire>();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("\t\t2 / Afficher Adhérents  ");
                    Console.WriteLine("_____________________________________________\n");
                    AfficherList<Adhérent>();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("\t\t3 / Afficher Personnes Morales  ");
                    Console.WriteLine("_____________________________________________\n");
                    AfficherList<Personne_Morale>();
                    break;
            }
            Console.WriteLine("___________________________________________________________________________________________________");
        }

        /// <summary>
        /// Affichage info archive
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void AfficherArchive<T>()
        {
            switch (typeof(T).Name)
            {
                case "Demande":
                    foreach (Archive<Demande> item in ArchiveDemande)
                    {
                        Console.WriteLine(item.Archivee.ToString());
                    }
                    break;
                case "Don_accepté":
                    foreach (Archive<Don_accepté> item in ArchiveDonAccepte)
                    {
                        Console.WriteLine(item.Archivee.ToString());
                    }
                    break;
                case "Don_Refuse":
                    foreach (Archive<Don_Refuse> item in ArchiveDonRefuse)
                    {
                        Console.WriteLine(item.Archivee.ToString());
                    }
                    break;
            }
        }

        /// <summary>
        /// Affichage info d'une liste
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void AfficherList<T>()
        {
            switch (typeof(T).Name)
            {
                case "Demande":
                    foreach (Demande item in ListDeDemande) { Console.WriteLine(item.ToString()); }
                    break;
                case "Don_accepté":
                    foreach (Don_accepté item in ListDeDonActuels) { Console.WriteLine(item.ToString()); }
                    break;
                case "Don":
                    foreach (Don item in ListDon) { Console.WriteLine(item.ToString()); }
                    break;
                case "Bénéficiaire":
                    foreach (Bénéficiaire item in ListDeBénéficiaire) { Console.WriteLine(item.ToString()); }
                    break;
                case "Adhérent":
                    foreach (Adhérent item in ListDeAdhérent) { Console.WriteLine(item.ToString()); }
                    break;
                case "Personne_Morale":
                    foreach (Personne_Morale item in ListDePersonneMorale) { Console.WriteLine(item.ToString()); }
                    break;
            }
            Console.WriteLine("-------------------------------------------------------------------------------------------");
        }

        #endregion

        #region  Fonctions de modification

        /// <summary>
        /// Modifie les informations d'une personne
        /// </summary>
        /// <param name="choix"></param>
        public void ModificationPersonne(int choix)
        {
            int id;
            switch (choix)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("\t\t3 / Modification Bénéficiaires  ");
                    Console.WriteLine("_____________________________________________\n");

                    Console.Write("veuillez sisir le id du bénéficiaires à modifier ==>");
                    id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();

                    Bénéficiaire b = Recherche_benef_par_id(id);
                    b.Modification();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("\t\t3 / Modification Adhérents  ");
                    Console.WriteLine("_____________________________________________\n");

                    Console.Write("veuillez sisir le id du adhérents à modifier ==>");
                    id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();

                    Adhérent a = Recherche_adherent_par_id(id);
                    a.Modification();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("\t\t3 / Modification Personnes Morales  ");
                    Console.WriteLine("_____________________________________________\n");

                    Console.Write("veuillez sisir le id de la personnes morales à modifier ==>");
                    id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();

                    Personne_Morale pm = Recherche_personne_morale_par_id(id);
                    pm.Modification();
                    break;
            }
        }

        /// <summary>
        /// Supprime une personne
        /// </summary>
        /// <param name="choix"></param>
        public void SupprimePersonne(int choix)
        {
            int id;
            switch (choix)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("\t\t3 / Supprime Bénéficiaires  ");
                    Console.WriteLine("_____________________________________________\n");

                    Console.Write("veuillez sisir le id du bénéficiaires à supprimer ==>");
                    id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();

                    Bénéficiaire b = Recherche_benef_par_id(id);
                    ListDeBénéficiaire.Remove(b);
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("\t\t3 / Supprime Adhérents  ");
                    Console.WriteLine("_____________________________________________\n");

                    Console.Write("veuillez sisir le id du adhérents à supprimer ==>");
                    id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();

                    Adhérent a = Recherche_adherent_par_id(id);
                    ListDeAdhérent.Remove(a);
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("\t\t3 / Supprime Personnes Morales  ");
                    Console.WriteLine("_____________________________________________\n");

                    Console.Write("veuillez sisir le id de la personnes morales à supprimer ==>");
                    id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();

                    Personne_Morale pm = Recherche_personne_morale_par_id(id);
                    ListDePersonneMorale.Remove(pm);

                    break;
            }
        }

        // Fonctions d'ajouts de personnes : chercher le max id et faire + 1
        #endregion
        
        #region Lecture des fichiers
        
        /// <summary>
        /// Fonction de récupération des demandes
        /// </summary>
        public void Recup_Demandes()
        {
            StreamReader flux = null;
            try
            {
                flux = new StreamReader("Demandes.txt");
                string line;
                while ((line = flux.ReadLine()) != null)
                {
                    string[] t = Regex.Split(line, ";");
                    if (t[0] != "")
                    {
                        string[] date = Regex.Split(t[1], "/");
                        Bénéficiaire b = Recherche_benef_par_id(Convert.ToInt32(t[4]));
                        Demande d = new Demande(Convert.ToInt32(t[0]), new DateTime(Convert.ToInt32(date[2]), Convert.ToInt32(date[1]), Convert.ToInt32(date[0])), t[2], t[3], b);
                        ListDeDemande.Add(d);
                    }
                    
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if(flux != null) flux.Close();
            }
        }

        /// <summary>
        /// Fonction de récupération des dons actuellement possédés par l'association
        /// </summary>
        public void Recup_Dons_Actuels()
        {
            StreamReader flux = null;
            try
            {
                flux = new StreamReader("Dons_possédés.txt");
                string line;
                while ((line = flux.ReadLine()) != null)
                {
                    string[] t = Regex.Split(line, ";");
                    if (t[0] != "")
                    {
                        Adhérent gestionnaire = Recherche_adherent_par_id(Convert.ToInt32(t[0]));
                        string[] date = Regex.Split(t[1], "/");
                        Adhérent donateur = Recherche_adherent_par_id(Convert.ToInt32(t[5]));
                        double prix = Convert.ToDouble(t[6]);
                        Don d = new Don(new DateTime(Convert.ToInt32(date[2]), Convert.ToInt32(date[1]), Convert.ToInt32(date[0])), t[2], t[3], donateur, t[4], Convert.ToInt32(t[7]), prix, t[8], Convert.ToInt32(t[9]), Convert.ToInt32(t[10]));
                        if (t[t.Length - 1] == "true")
                        {
                            if (t.Length == 14)
                            {
                                Personne_Morale p = Recherche_personne_morale_par_id(Convert.ToInt32(t[11]));
                                Don_accepté da = new Don_accepté(p, gestionnaire, d);
                                da.Reserver = true;
                                da.Beneficiaire = Recherche_benef_par_id(Convert.ToInt32(t[12]));
                                ListDeDonActuels.Add(da);
                            }
                            else
                            {
                                Don_accepté da = new Don_accepté(gestionnaire, d);
                                ListDeDonActuels.Add(da);
                            }
                        }
                        else
                        {
                            if (t.Length == 12)
                            {
                                Personne_Morale p = Recherche_personne_morale_par_id(Convert.ToInt32(t[11]));
                                Don_accepté da = new Don_accepté(p, gestionnaire, d);
                                ListDeDonActuels.Add(da);
                            }
                            else
                            {
                                Don_accepté da = new Don_accepté(gestionnaire, d);
                                ListDeDonActuels.Add(da);
                            }
                        }
                        d.Dispose();
                    }
                    
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (flux != null) flux.Close();
            }
        }

        /// <summary>
        /// Fonction de récupération des personnes
        /// </summary>
        public void Recup_Personnes()
        {
            StreamReader flux = null;
            int compteur = 0;
            try
            {
                flux = new StreamReader("Personnes.txt");
                string line;
                while ((line = flux.ReadLine()) != null)
                {
                    string[] t = Regex.Split(line, ";");
                    if (t[0] == "STOP") compteur++;
                    else
                    {
                        if (compteur == 0) // Bénéficiaires
                        {
                            string[] date = Regex.Split(t[5], "/");
                            Bénéficiaire b = new Bénéficiaire(t[4], new DateTime(Convert.ToInt32(date[2]), Convert.ToInt32(date[1]), Convert.ToInt32(date[0])), Convert.ToInt32(t[0]), t[1], t[2], t[3]);
                            ListDeBénéficiaire.Add(b);
                        }
                        if (compteur == 1) // Adhérents
                        {
                            Adhérent a = new Adhérent(t[4], t[5], Convert.ToInt32(t[0]), t[1], t[2], t[3]);
                            ListDeAdhérent.Add(a);
                        }
                        if (compteur == 2) // Personnes_Morales
                        {
                            Personne_Morale p = new Personne_Morale(t[1], Convert.ToInt32(t[0]), t[2], t[3], t[4]);
                            ListDePersonneMorale.Add(p);
                        }
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (flux != null) flux.Close();
            }
        }

        /// <summary>
        /// Fonction de récupération des archives
        /// </summary>
        public void Recup_Archives()
        {
            int compteur = 0;
            StreamReader flux = null;
            try
            {
                flux = new StreamReader("Archives.txt");
                string line;
                while ((line = flux.ReadLine()) != null)
                {
                    string[] t = Regex.Split(line, ";");
                    if (t[0] == "STOP") compteur++;
                    else
                    {
                        if (compteur == 0)
                        {
                            Adhérent gestionnaire = Recherche_adherent_par_id(Convert.ToInt32(t[0]));
                            string[] date = Regex.Split(t[1], "/");
                            Adhérent donateur = Recherche_adherent_par_id(Convert.ToInt32(t[5]));
                            double prix = Convert.ToDouble(t[6]);
                            string[] date_archivage = Regex.Split(t[11], "/");
                            Don d = new Don(new DateTime(Convert.ToInt32(date[2]), Convert.ToInt32(date[1]), Convert.ToInt32(date[0])), t[2], t[3], donateur, t[4], Convert.ToInt32(t[7]), prix, t[8], Convert.ToInt32(t[9]), Convert.ToInt32(t[10]));
                            if (t.Length == 15)
                            {
                                Personne_Morale p = Recherche_personne_morale_par_id(Convert.ToInt32(t[13]));
                                Don_accepté da = new Don_accepté(p, gestionnaire, d);
                                da.Beneficiaire = Recherche_benef_par_id(Convert.ToInt32(t[12]));
                                Archive<Don_accepté> ada = new Archive<Don_accepté>(da, Convert.ToInt32(t[14]), new DateTime(Convert.ToInt32(date_archivage[2]), Convert.ToInt32(date_archivage[1]), Convert.ToInt32(date_archivage[0])));
                                ArchiveDonAccepte.Add(ada);
                            }
                            else
                            {
                                Don_accepté da = new Don_accepté(gestionnaire, d);
                                da.Beneficiaire = Recherche_benef_par_id(Convert.ToInt32(t[12]));
                                Archive<Don_accepté> ada = new Archive<Don_accepté>(da, Convert.ToInt32(t[13]), new DateTime(Convert.ToInt32(date_archivage[2]), Convert.ToInt32(date_archivage[1]), Convert.ToInt32(date_archivage[0])));
                                ArchiveDonAccepte.Add(ada);
                            }
                            d.Dispose();
                        }
                        if (compteur == 1)
                        {
                            string[] date = Regex.Split(t[1], "/");
                            string[] date_archivage = Regex.Split(t[6], "/");
                            Bénéficiaire b = Recherche_benef_par_id(Convert.ToInt32(t[4]));
                            Demande d = new Demande(Convert.ToInt32(t[0]), new DateTime(Convert.ToInt32(date[2]), Convert.ToInt32(date[1]), Convert.ToInt32(date[0])), t[2], t[3], b);
                            Archive<Demande> ad = new Archive<Demande>(d, Convert.ToInt32(t[5]), new DateTime(Convert.ToInt32(date_archivage[2]), Convert.ToInt32(date_archivage[1]), Convert.ToInt32(date_archivage[0])));
                            ArchiveDemande.Add(ad);
                        }
                        if (compteur == 2)
                        {
                            string[] date = Regex.Split(t[1], "/");
                            Adhérent donateur = Recherche_adherent_par_id(Convert.ToInt32(t[0]));
                            Don d = new Don(new DateTime(Convert.ToInt32(date[2]), Convert.ToInt32(date[1]), Convert.ToInt32(date[0])), t[2], t[3], donateur, t[4], Convert.ToInt32(t[13]), Convert.ToDouble(t[8]), t[10], Convert.ToInt32(t[11]), Convert.ToInt32(t[12]));
                            string[] date_refus = Regex.Split(t[5], "/");
                            Don_Refuse dr = new Don_Refuse(t[6], new DateTime(Convert.ToInt32(date[2]), Convert.ToInt32(date[1]), Convert.ToInt32(date[0])), d);
                            string[] date_archivage = Regex.Split(t[9], "/");
                            Archive<Don_Refuse> ar = new Archive<Don_Refuse>(dr, Convert.ToInt32(t[7]), new DateTime(Convert.ToInt32(date_archivage[2]), Convert.ToInt32(date_archivage[1]), Convert.ToInt32(date_archivage[0])));
                            ArchiveDonRefuse.Add(ar);
                            d.Dispose();
                        }
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (flux != null) flux.Close();
            }
        }

        /// <summary>
        /// Fonction de récupération des dons en attente
        /// </summary>
        public void Recup_Dons()
        {
            StreamReader flux = null;
            try
            {
                flux = new StreamReader("Dons.txt");
                string line;
                while ((line = flux.ReadLine()) != null)
                {
                    string[] t = Regex.Split(line, ";");
                    if(t[0]!="")
                    {
                        string[] date = Regex.Split(t[0], "/");
                        Adhérent donateur = Recherche_adherent_par_id(Convert.ToInt32(t[3]));
                        double prix = Convert.ToDouble(t[6]);
                        Don d = new Don(new DateTime(Convert.ToInt32(date[2]), Convert.ToInt32(date[1]), Convert.ToInt32(date[0])), t[1], t[2], donateur, t[4], Convert.ToInt32(t[5]), prix, t[7], Convert.ToInt32(t[8]), Convert.ToInt32(t[9]));
                        ListDon.Add(d);
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (flux != null) flux.Close();
            }
        }
        #endregion

        #region Ecriture des fichiers

        /// <summary>
        /// Fonction d'écriture des informations éventuellement modifiées concernant les personnes
        /// </summary>
        public void Ecriture_Personnes()
        {
            StreamWriter flux = null;
            try
            {
                flux = new StreamWriter("Personnes.txt");
                for (int i = 0; i < ListDeBénéficiaire.Count; i++)
                {
                    string date = ListDeBénéficiaire[i].Date_naissance.Day + "/" + ListDeBénéficiaire[i].Date_naissance.Month + "/"
                                  + ListDeBénéficiaire[i].Date_naissance.Year;
                    string data = ListDeBénéficiaire[i].Identifiant + ";" + ListDeBénéficiaire[i].Nom + ";" + ListDeBénéficiaire[i].Adresse
                                  + ";" + ListDeBénéficiaire[i].Tel + ";" + ListDeBénéficiaire[i].Prenom + ";" + date;
                    flux.WriteLine(data);
                }
                flux.WriteLine("STOP");
                for (int i = 0; i < ListDeBénéficiaire.Count; i++)
                {
                    string data = ListDeAdhérent[i].Identifiant + ";" + ListDeAdhérent[i].Nom + ";" + ListDeAdhérent[i].Adresse + ";"
                                  + ListDeAdhérent[i].Tel + ";" + ListDeAdhérent[i].Prenom + ";" + ListDeAdhérent[i].Fonction;
                    flux.WriteLine(data);
                }
                flux.WriteLine("STOP");
                for (int i = 0; i < ListDePersonneMorale.Count; i++)
                {
                    string data = ListDePersonneMorale[i].Identifiant + ";" + ListDePersonneMorale[i].Activite + ";" + ListDePersonneMorale[i].Nom + ";"
                                  + ListDePersonneMorale[i].Adresse + ";" + ListDePersonneMorale[i].Tel;
                    flux.WriteLine(data);
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                flux.Close();
            }
        }

        /// <summary>
        /// Fonction d'écriture des informations éventuellement modifiées concernant les demandes
        /// </summary>
        public void Ecriture_Demandes()
        {
            StreamWriter flux = null;
            try
            {
                string data = "";
                flux = new StreamWriter("Demandes.txt");
                for (int i = 0; i < ListDeDemande.Count; i++)
                {
                    
                    string date = ListDeDemande[i].Date.Day + "/" + ListDeDemande[i].Date.Month + "/" + ListDeDemande[i].Date.Year;
                    data = ListDeDemande[i].Identifiant + ";" + date + ";" + ListDeDemande[i].Description + ";"
                                  + ListDeDemande[i].Statut + ";" + ListDeDemande[i].Benef.Identifiant;
                    flux.WriteLine(data);
                }
                if(ListDeDemande.Count ==0) flux.WriteLine(data);

            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                flux.Close();
            }
        }

        /// <summary>
        /// Fonction d'écriture des informations éventuellement modifiées concernant les dons possédés
        /// </summary>
        public void Ecriture_Dons_Actuels()
        {
            StreamWriter flux = null;
            try
            {
                flux = new StreamWriter("Dons_possédés.txt");
                string data = "";
                for (int i = 0; i < ListDeDonActuels.Count; i++)
                {
                    
                    string date = ListDeDonActuels[i].Date.Day + "/" + ListDeDonActuels[i].Date.Month + "/" + ListDeDonActuels[i].Date.Year;
                     data = ListDeDonActuels[i].Gestionnaire.Identifiant + ";" + date + ";" + ListDeDonActuels[i].Type + ";"
                                  + ListDeDonActuels[i].Reference + ";" + ListDeDonActuels[i].Description + ";" + ListDeDonActuels[i].Donateur.Identifiant + ";"
                                  + ListDeDonActuels[i].Prix + ";" + ListDeDonActuels[i].Identifiant + ";" + ListDeDonActuels[i].Statut + ";"
                                  + ListDeDonActuels[i].Hauteur + ";" + ListDeDonActuels[i].Largeur;
                    if (ListDeDonActuels[i].Lieu_stock != null)
                    {
                        data = data + ";" + ListDeDonActuels[i].Lieu_stock.Identifiant;
                    }
                    if(ListDeDonActuels[i].Reserver == true)
                    {
                        data += ";" + ListDeDonActuels[i].Beneficiaire.Identifiant + ";" + ListDeDonActuels[i].Reserver;
                    }
                    flux.WriteLine(data);
                }
                if (ListDeDonActuels.Count == 0) flux.WriteLine(data);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                flux.Close();
            }
        }

        /// <summary>
        /// Fonction d'écriture des informations éventuellement modifiées concernant les archives
        /// </summary>
        public void Ecriture_Archives()
        {
            StreamWriter flux = null;
            try
            {
                flux = new StreamWriter("Archives.txt");
                for (int i = 0; i < ArchiveDonAccepte.Count; i++)
                {
                    string date = ArchiveDonAccepte[i].Archivee.Date.Day + "/" + ArchiveDonAccepte[i].Archivee.Date.Month + "/"
                                  + ArchiveDonAccepte[i].Archivee.Date.Year;
                    string date_archivage = ArchiveDonAccepte[i].Date.Day + "/" + ArchiveDonAccepte[i].Date.Month + "/"
                                            + ArchiveDonAccepte[i].Date.Year;
                    string data = ArchiveDonAccepte[i].Archivee.Gestionnaire.Identifiant + ";" + date + ";" + ArchiveDonAccepte[i].Archivee.Type + ";"
                                  + ArchiveDonAccepte[i].Archivee.Reference + ";" + ArchiveDonAccepte[i].Archivee.Description + ";"
                                  + ArchiveDonAccepte[i].Archivee.Donateur.Identifiant + ";" + ArchiveDonAccepte[i].Archivee.Prix + ";"
                                  + ArchiveDonAccepte[i].Archivee.Identifiant + ";Donné & Archivé;"
                                  + ArchiveDonAccepte[i].Archivee.Hauteur + ";" + ArchiveDonAccepte[i].Archivee.Largeur + ";"
                                  + date_archivage + ";" + ArchiveDonAccepte[i].Archivee.Beneficiaire.Identifiant + ";";//ecrire benificaire 
                    if (ArchiveDonAccepte[i].Archivee.Lieu_stock == null)
                    {
                        data += ArchiveDonAccepte[i].Identifiant;
                        flux.WriteLine(data);
                    }
                    else
                    {
                        data += ArchiveDonAccepte[i].Archivee.Lieu_stock.Identifiant + ";" + ArchiveDonAccepte[i].Identifiant;
                        flux.WriteLine(data);
                    }
                }
                flux.WriteLine("STOP");
                for (int i = 0; i < ArchiveDemande.Count; i++)
                {
                    string date = ArchiveDemande[i].Archivee.Date.Day + "/" + ArchiveDemande[i].Archivee.Date.Month + "/"
                                  + ArchiveDemande[i].Archivee.Date.Year;
                    string date_archivage = ArchiveDemande[i].Date.Day + "/" + ArchiveDemande[i].Date.Month + "/"
                                  + ArchiveDemande[i].Date.Year;
                    string data = ArchiveDemande[i].Archivee.Identifiant + ";" + date + ";" + ArchiveDemande[i].Archivee.Description + ";"
                                  + ArchiveDemande[i].Archivee.Statut + ";" + ArchiveDemande[i].Archivee.Benef.Identifiant + ";"
                                  + ArchiveDemande[i].Identifiant + ";" + date_archivage;
                    flux.WriteLine(data);
                }
                flux.WriteLine("STOP");
                for (int i = 0; i < ArchiveDonRefuse.Count; i++)
                {
                    string date = ArchiveDonRefuse[i].Archivee.Date.Day + "/" + ArchiveDonRefuse[i].Archivee.Date.Month + "/"
                                  + ArchiveDonRefuse[i].Archivee.Date.Year;
                    string date_refus = ArchiveDonRefuse[i].Archivee.Date_refus.Day + "/" + ArchiveDonRefuse[i].Archivee.Date_refus.Month + "/"
                                  + ArchiveDonRefuse[i].Archivee.Date_refus.Year;
                    string date_archivage = ArchiveDonRefuse[i].Date.Day + "/" + ArchiveDonRefuse[i].Date.Month + "/"
                                  + ArchiveDonRefuse[i].Date.Year;
                    string data = ArchiveDonRefuse[i].Archivee.Donateur.Identifiant + ";" + date + ";" + ArchiveDonRefuse[i].Archivee.Type + ";"
                                  + ArchiveDonRefuse[i].Archivee.Reference + ";" + ArchiveDonRefuse[i].Archivee.Description + ";"
                                  + date_refus + ";" + ArchiveDonRefuse[i].Archivee.Motif + ";" + ArchiveDonRefuse[i].Identifiant + ";"
                                  + ArchiveDonRefuse[i].Archivee.Prix + ";" + date_archivage + ";" + ArchiveDonRefuse[i].Archivee.Statut + ";"
                                  + ArchiveDonRefuse[i].Archivee.Hauteur + ";" + ArchiveDonRefuse[i].Archivee.Largeur + ";" + ArchiveDonRefuse[i].Archivee.Identifiant;
                    flux.WriteLine(data);
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                flux.Close();
            }
        }

        /// <summary>
        /// Fonction d'écriture des dons en attente
        /// </summary>
        public void Ecriture_Dons()
        {
            StreamWriter flux = null;
            try
            {
                string data = "";
                flux = new StreamWriter("Dons.txt");
                for (int i = 0; i < ListDon.Count; i++)
                {
                    
                    string date = ListDon[i].Date.Day + "/" + ListDon[i].Date.Month + "/" + ListDon[i].Date.Year;
                    data = date + ";" + ListDon[i].Type + ";" + ListDon[i].Reference + ";"
                                  + ListDon[i].Donateur.Identifiant + ";" + ListDon[i].Description + ";"
                                  + ListDon[i].Identifiant + ";" + ListDon[i].Prix + ";" + ListDon[i].Statut + ";"
                                  + ListDon[i].Hauteur + ";" + ListDon[i].Largeur;
                    flux.WriteLine(data);
                }
                if(ListDon.Count ==0) flux.WriteLine(data);
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                flux.Close();
            }
        }

        #endregion

        #region Ajout d'éléments

        public void AjouterDon()
        {
            Console.Clear();
            Console.WriteLine("\t\t1 / Création d'un Don  ");
            Console.WriteLine("_____________________________________________\n");
            int id = ListDon.Count + ListDeDonActuels.Count + ArchiveDonAccepte.Count + ArchiveDonRefuse.Count;
            Console.Write("Veuillez saisir l'ID du donateur ==>");
            int id_Adherent = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Don d = new Don(id + 1);
            Adhérent ad = Recherche_adherent_par_id(id_Adherent);
            while (ad == null)
            {
                Console.WriteLine("L'ID du donneur n'existe pas ; \n1/Voulez vous resaisir ? \n2/ Voulez vous ajouter un adhérent  ? ");
                switch (Program.SaisirChoix(2))
                {
                    case 1:
                        Console.Write("Veuillez saisir l'ID de l'adhérent ==>");
                        id_Adherent = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                        ad = Recherche_adherent_par_id(id_Adherent);
                        break;
                    case 2:
                        AjouterPersonne(2);
                        id_Adherent = ListDeBénéficiaire.Last().Identifiant;
                        ad = Recherche_adherent_par_id(id_Adherent);
                        break;
                }
            }
            d.CreationDON(ad);
            ListDon.Add(d);

        }
        public void AjouterDemande()
        {
            Console.Clear();
            Console.WriteLine("\t\t1 / Creation d'un Demande  ");
            Console.WriteLine("_____________________________________________\n");
            int id = ArchiveDemande.Count + ListDeDemande.Count;
            Demande d = new Demande(id + 1);
            Console.Write("Veuilliez saisir de ID du Bénéficiaire ==>");
            int id_Benef = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Bénéficiaire b = Recherche_benef_par_id(id_Benef);
            while (b == null)
            {
                Console.WriteLine("le ID du bénéficiaire n' excite pas ; \n1/Voulez vous resaisir ? \n2/ Voulez vous ajouter un bénéficiaire  ? ");
                switch (Program.SaisirChoix(2))
                {
                    case 1:
                        Console.Write("Veuilliez saisir de ID du Bénéficiaire ==>");
                        id_Benef = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                        b = Recherche_benef_par_id(id_Benef);
                        break;
                    case 2:
                        AjouterPersonne(1);
                        id_Benef = ListDeBénéficiaire.Last().Identifiant;
                        b = Recherche_benef_par_id(id_Benef);
                        break;
                }
            }
            d.Creation_Demande(b);
            ListDeDemande.Add(d);
        }
        public void AjouterPersonne(int choix)
        {
            int id = 0;
            switch (choix)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("\t\t1 / Ajouter Bénéficiaires  ");
                    Console.WriteLine("_____________________________________________\n");
                    if (ListDeBénéficiaire.Count > 0) id = ListDeBénéficiaire.Last().Identifiant;
                    Bénéficiaire b = new Bénéficiaire(id + 1);
                    b.Ajouter();
                    ListDeBénéficiaire.Add(b);
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("\t\t2 / Ajouter Adhérents  ");
                    Console.WriteLine("_____________________________________________\n");
                    if (ListDeAdhérent.Count > 0) id = ListDeAdhérent.Last().Identifiant;
                    Adhérent a = new Adhérent(id + 1);
                    a.Ajouter();
                    ListDeAdhérent.Add(a);
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("\t\t3 / Ajouter Personnes Morales  ");
                    Console.WriteLine("_____________________________________________\n");
                    if (ListDePersonneMorale.Count > 0) id = ListDePersonneMorale.Last().Identifiant;
                    Personne_Morale pm = new Personne_Morale(id + 1);
                    pm.Ajouter();
                    ListDePersonneMorale.Add(pm);
                    break;
            }
        }

        #endregion

        #region Traitement des dons

        /// <summary>
        /// Permet de changer le statut d'un don en accepté ou refusé
        /// </summary>
        public void TraitementDon()
        {
            if(ListDon.Count > 0)
            {
                Adhérent a = null;
                while (a == null)
                {
                    Console.Write("Veuillez saisir Votre id pour traiter ce don ==>");
                    a = Recherche_adherent_par_id(Convert.ToInt32(Console.ReadLine()));
                    Console.WriteLine();
                }
                Don d = null;
                while (d == null)
                {
                    Console.Write("Veuillez saisir le id du don à traiter ==>");
                    d = Recherche_don_par_id(Convert.ToInt32(Console.ReadLine()));
                    Console.WriteLine();
                }
                Console.WriteLine(d);

                Console.WriteLine("Voulez vous [1] Accptee ou [2] Refusee ce don ");
                d.TraitementDon(Program.SaisirChoix(2));
                switch (d.Statut)
                {
                    case "Acceptee":
                        Console.Write("Savez vous le lieu du stockage du don [Y|N] ==>");
                        Don_accepté don_acc;
                        if (Console.ReadLine().ToUpper()[0] == 'Y')
                        {
                            Console.WriteLine("\nVoici la lis des personnes morals ::: ");
                            Console.WriteLine("_______________________________________________________");
                            AfficherList<Personne_Morale>();
                            Console.Write("Veuillez saisir le id de la personne moral qui stock ce don  ==>");
                            int id_PM = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();
                            Personne_Morale p = Recherche_personne_morale_par_id(id_PM);
                            while (p == null)
                            {
                                Console.WriteLine("le ID du Personne_Morale n' excite pas ; \n1/ Voulez vous resaisir ? \n2/ Voulez vous ajouter un Personne_Morale  ? ");
                                switch (Program.SaisirChoix(2))
                                {
                                    case 1:
                                        Console.Write("Veuillez REsaisir le id de la personne moral ==>");
                                        id_PM = Convert.ToInt32(Console.ReadLine());
                                        Console.WriteLine();
                                        p = Recherche_personne_morale_par_id(id_PM);
                                        break;
                                    case 2:
                                        AjouterPersonne(1);
                                        id_PM = ListDeBénéficiaire.Last().Identifiant;
                                        p = Recherche_personne_morale_par_id(id_PM);
                                        break;
                                }
                            }
                            don_acc = new Don_accepté(p, a, d);
                            int id_supp = d.Identifiant;
                            for (int i = 0; i < ListDon.Count; i++)
                            {
                                if (ListDon[i].Identifiant == id_supp)
                                {
                                    ListDon.Remove(ListDon[i]);
                                }
                            }
                        }
                        else
                        {
                            don_acc = new Don_accepté(a, d);
                            int id_supp = d.Identifiant;
                            for (int i = 0; i < ListDon.Count; i++)
                            {
                                if (ListDon[i].Identifiant == id_supp)
                                {
                                    ListDon.Remove(ListDon[i]);
                                }
                            }
                        }
                        Console.WriteLine();
                        ListDeDonActuels.Add(don_acc);
                        break;
                    case "Refusee":
                        Console.Write("Veuillez saisir le motif du refus de ce don \n==>");
                        Archive<Don_Refuse> aDr = new Archive<Don_Refuse>(new Don_Refuse(Console.ReadLine(), d), ArchiveDonRefuse.Count + 1);
                        Console.WriteLine();
                        ArchiveDonRefuse.Add(aDr);
                        int id = d.Identifiant;
                        for (int i = 0; i < ListDon.Count; i++)
                        {
                            if (ListDon[i].Identifiant == id)
                            {
                                ListDon.Remove(ListDon[i]);
                            }
                        }
                        break;
                }
            }
            else Console.WriteLine("il ya aucun don à traiter");
        }

        /// <summary>
        /// Permet de traiter une demande en disant si on a l'objet souhaité dans les stocks
        /// </summary>
        public void TraitementDemande()
        {
            Demande d = null;
            while (d == null)
            {
                Console.Write("Veuillez saisir le id de la demande à traiter ==>");
                d = Recherche_Demande_par_id(Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine();
            }
            Console.WriteLine(d);
            if (ListDeDonActuels.Exists(x => x.Description == d.Description && x.Reserver == false && (x.Statut == "Stocke" || x.Statut == "Acceptee")))
            {
                d.TraitementDemande(1);
                ListDeDonActuels.Find(x => x.Description == d.Description && x.Reserver == false && (x.Statut == "Stocke" || x.Statut == "Acceptee")).Reserver = true;
                ListDeDonActuels.Find(x => x.Description == d.Description && x.Reserver == false && (x.Statut == "Stocke" || x.Statut == "Acceptee")).Beneficiaire = d.Benef;

            }
            else d.TraitementDemande(2);
        }

        /// <summary>
        /// Définit le lieu de stokage d'un don
        /// </summary>
        public void StockageDuDon()
        {
            Don_accepté d = null;
            while (d == null)
            {
                Console.Write("Veuillez saisir le id du don à traiter ==>");
                d = Recherche_don_Accepte_par_id(Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine();
            }
            Console.WriteLine("Le don choisi est ::");
            Console.WriteLine(d);
            Console.Write("Veuillez saisir le id de la personne moral qui stock ce don  ==>");
            int id_PM = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Personne_Morale p = Recherche_personne_morale_par_id(id_PM);
            while (p == null)
            {
                Console.WriteLine("le ID du Personne_Morale n' excite pas ; \n1/ Voulez vous resaisir ? \n2/ Voulez vous ajouter un Personne_Morale  ? ");
                switch (Program.SaisirChoix(2))
                {
                    case 1:
                        Console.Write("Veuillez saisir de ID du Bénéficiaire ==>");
                        id_PM = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();
                        p = Recherche_personne_morale_par_id(id_PM);
                        break;
                    case 2:
                        AjouterPersonne(1);
                        id_PM = ListDeBénéficiaire.Last().Identifiant;
                        p = Recherche_personne_morale_par_id(id_PM);
                        break;
                }
            }
            d.StokageDon(p);
        }

        /// <summary>
        /// Donne le don au bénéficiaire
        /// </summary>
        public void TransfertDuDon()
        {
            Don_accepté d = null;
            while (d == null)
            {
                Console.Write("Veuillez saisir le id du don à traiter ==>");
                d = Recherche_don_Accepte_par_id(Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine();
            }
            Console.WriteLine("Le don choisi est ::");
            Console.WriteLine(d);
            d.Transfert();
            Demande demande= ListDeDemande.Find(x => x.Benef.Identifiant == d.Beneficiaire.Identifiant);
            demande.Statut = "Donne & Archivee";
            ArchiveDemande.Add(new Archive<Demande> (demande,ArchiveDemande.Count+1));
            ListDeDemande.Remove(Recherche_Demande_par_id(demande.Identifiant));
        }

        /// <summary>
        /// Archive un don
        /// </summary>
        public void ArchiveUnDon()
        {
            Don_accepté d = null;
            while (d == null)
            {
                Console.Write("Veuillez saisir le id du don à traiter ==>");
                d = Recherche_don_Accepte_par_id(Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine();
            }
            Console.WriteLine("Le don choisi est ::");
            Console.WriteLine(d);
            d.Archive();
            Archive<Don_accepté> aDr = new Archive<Don_accepté>(d, ArchiveDonAccepte.Count+1);
            ArchiveDonAccepte.Add(aDr);
            int id = d.Identifiant;
            for (int i = 0; i < ListDeDonActuels.Count; i++)
            {
                if (ListDeDonActuels[i].Identifiant == id)
                {
                    ListDeDonActuels.Remove(ListDeDonActuels[i]);
                }
            }
        }

        #endregion
    }
}
