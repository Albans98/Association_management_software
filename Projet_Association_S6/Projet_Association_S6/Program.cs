using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Association_S6
{
    public class Program
    {
        /// <summary>
        /// Fonction de saisie d'un choix à la console pour le menu
        /// </summary>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int SaisirChoix(int max)
        {
            int choix;
            int min = 1;
            while (!int.TryParse(Console.ReadLine(), out choix) || choix < min || choix > max)
            {
                Console.WriteLine("Veuillez entrer un entier valide :");
            }
            return choix;
        }

        /// <summary>
        /// Fonction permettant de retourner en arrière ou quitter le logiciel
        /// Attention, l'enregistrement des fichiers ne se fait que si l'utilisateur clique sur 'quitter'
        /// </summary>
        /// <returns></returns>
        static List<bool> RetounerQuitterMenu()
        {
            Console.WriteLine("\nClick sur un button pour Continuer ....");
            Console.ReadKey();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            List<bool> res = new List<bool>() { false, true };
            Console.WriteLine("\n\n1] Retourner \n" +
                                    "2] Menu Principal\n" +
                                    "3] Quitter\n");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            
            int choix = SaisirChoix(3);
            switch (choix)
            {
                case 1:
                    res[0] = true;
                    break;
                case 2:
                    res[1] = true;
                    break;
                case 3:
                    res[1] = false;
                    break;
            }
            
            return res;
        }

        public static List<string> TypeObjets()
        {
            List<string> Mobilier_Chambre = new List<string>() { "Matelas", "Chevet", "Armoire", "Lit" };
            List<string> Mobilier_SalleOUCuisine = new List<string>() { "Table Cuisine Rectangulaire", "Table Cuisine Carree", "Table Cuisine Ronde", "Table Salon, Rectangulaire", "Table Salon Carree", "Table Salon Ronde", "Chaise", "Canape", "Fauteuil" };
            List<string> Electro_ménager = new List<string>() { "Cuisiniere", "Refrigerateur", "Lave-linge", "Lave-vaisselle" };
            List<string> Vaisselle = new List<string>() { "Couverts", "Assiettes" };
            Dictionary<string, List<string>> ListType = new Dictionary<string, List<string>>()
            {
                {"Mobilier Chambre" ,Mobilier_Chambre },
                {"Mobilier Salle/Cuisine" ,Mobilier_SalleOUCuisine },
                {"Electro-ménager" ,Electro_ménager },
                {"Vaisselle" ,Vaisselle }
            };
            Console.WriteLine("---------------------------------");
            Console.WriteLine("[1] Mobilier Chambre");
            Console.WriteLine("[2] Mobilier Salle/Cuisine");
            Console.WriteLine("[3] Electro-ménager");
            Console.WriteLine("[4] Vaisselle");
            Console.Write("Veuilleiz choisir le type souhaitee \n\t==>");
            int choix1 = SaisirChoix(4);
            int i = 1;
            int choix2 = -1;
            List<string> res = new List<string>();
            switch (choix1)
            {
                case 1:
                    res.Add("Mobilier Chambre");
                    Console.WriteLine("----Mobilier Chambre------");
                    Mobilier_Chambre.ForEach(x => Console.WriteLine(" \t [" + (i++) + "] " + x));
                    Console.WriteLine("---------------------------------");
                    Console.Write("Veuilleiz choisir le type souhaitee \n\t==>");
                    choix2 = SaisirChoix(Mobilier_Chambre.Count);
                    break;
                case 2:
                    res.Add("Mobilier Salle/Cuisine");
                    Console.WriteLine("------ Mobilier Salle/Cuisine------");
                    Mobilier_SalleOUCuisine.ForEach(x => Console.WriteLine("[" + (i++) + "] " + x + "  "));
                    Console.WriteLine("---------------------------------");
                    Console.Write("Veuilleiz choisir le type souhaitee \n\t==>");
                    choix2 = SaisirChoix(Mobilier_SalleOUCuisine.Count);
                    break;
                case 3:
                    res.Add("Electro-menager");
                    Console.WriteLine("------ Electro-ménager------");
                    Electro_ménager.ForEach(x => Console.WriteLine(" \t [" + (i++) + "] " + x));
                    Console.WriteLine("---------------------------------");
                    Console.Write("Veuilleiz choisir le type souhaitee \n\t==>");
                    choix2 = SaisirChoix(Electro_ménager.Count);
                    break;
                case 4:
                    res.Add("Vaisselle");
                    Console.WriteLine("------Vaisselle------");
                    Vaisselle.ForEach(x => Console.WriteLine(" \t [" + (i++) + "] " + x));
                    Console.WriteLine("---------------------------------");
                    Console.Write("Veuilleiz choisir le type souhaitee \n\t==>");
                    choix2 = SaisirChoix(Vaisselle.Count);
                    break;
            }
            res.Add(ListType[res[0]][choix2 - 1]);
            return res;
        }

        static void Main(string[] args)
        {

            Association mobilier_pour_tous = new Association();
            Console.WriteLine("_______________________________________________________________________________________________________");
            Console.WriteLine(" \n\t\t Bienvenue dans ce logiciel de gestion de l'association 'Mobilier pour tous' ! \t\t");
            Console.WriteLine("_______________________________________________________________________________________________________\n");
            Console.WriteLine();

            #region Menu principal

            bool continuer = true;
            while (continuer)
            {
                Console.WriteLine("------------MENU------------\n");
                Console.WriteLine("1 / Module Personne \n" +
                                  "2 / Module Don \n" +
                                  "3 / Module Demande\n" +
                                  "4 / Module Tris\n" +
                                  "5 / Module Statistiques \n");
                int choix01 = SaisirChoix(5);
                int choix02 = -1;
                List<bool> b ;
                bool retournerNivaux1 = true;
                switch (choix01)
                {
                    case 1:
                        #region Module Personne
                        while (retournerNivaux1)
                        {
                            Console.Clear();
                            Console.WriteLine("\t\t1 / Module Personne ");
                            Console.WriteLine("_____________________________________________\n");
                            Console.WriteLine("1] Recherche des personnes\n" +
                                              "2] Modification des personnes \n" +
                                              "3] Suppression des personnes \n" +
                                              "4] Afficher des personnes \n" +
                                              "5] Ajouter des personnes" +
                                              "\n\n6]Menu Principal\n" +
                                                  "7]Quitter\n");
                            choix02 = SaisirChoix(7);
                            int choix03 = -1;
                            retournerNivaux1 = false;
                            bool retournerNivaux2 = true;
                            switch (choix02)
                            {
                                #region case 1
                                case 1:
                                    while (retournerNivaux2)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("\t\t1 / Recherche des Personnes ");
                                        Console.WriteLine("_____________________________________________\n");
                                        Console.WriteLine("1] Recherche Bénéficiaires \n" +
                                                          "2] Recherche Adhérents\n" +
                                                          "3] Recherche Personnes Morales \n" +
                                                            "\n\n\n4] Retourner \n" +
                                                                  "5] Menu Principal\n" +
                                                                  "6] Quitter\n");
                                        choix03 = SaisirChoix(6);
                                        retournerNivaux2 = false;
                                        if (choix03 < 4)
                                        {
                                            mobilier_pour_tous.Recherche_personnes(choix03);
                                            b = RetounerQuitterMenu();
                                            retournerNivaux2 = b[0];//a changer retouner Niveau2
                                            continuer = b[1];
                                            b.Clear();
                                        }
                                        else
                                        {
                                            switch (choix03)
                                            {
                                                case 4:
                                                    retournerNivaux1 = true;
                                                    break;
                                                case 5:
                                                    continuer = true;
                                                    break;
                                                case 6:
                                                    continuer = false;
                                                    break;
                                            }
                                        }
                                    }

                                    break;
                                #endregion
                                #region case 2
                                case 2:
                                    while (retournerNivaux2)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("\t\t2 / Modification des Personnes  ");
                                        Console.WriteLine("_____________________________________________\n");
                                        Console.WriteLine("1] Modification Bénéficiaires \n" +
                                                          "2] Modification Adhérents\n" +
                                                          "3] Modification Personnes Morales \n" +
                                                            "\n\n\n4] Retourner \n" +
                                                                  "5] Menu Principal\n" +
                                                                  "6] Quitter\n");
                                        choix03 = SaisirChoix(6);
                                        retournerNivaux2 = false;
                                        if (choix03 < 4)
                                        {
                                            mobilier_pour_tous.ModificationPersonne(choix03);
                                            b = RetounerQuitterMenu();
                                            retournerNivaux2 = b[0];
                                            continuer = b[1];
                                            b.Clear();
                                        }
                                        else
                                        {
                                            switch (choix03)
                                            {
                                                case 4:
                                                    retournerNivaux1 = true;
                                                    break;
                                                case 5:
                                                    continuer = true;
                                                    break;
                                                case 6:
                                                    continuer = false;
                                                    break;
                                            }
                                        }
                                    }
                                    break;
                                #endregion
                                #region case 3
                                case 3:
                                    while (retournerNivaux2)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("\t\t3 / Suppresion des Personnes ");
                                        Console.WriteLine("_____________________________________________\n");
                                        Console.WriteLine("1] Suppresion Bénéficiaires \n" +
                                                          "2] Suppresion Adhérents\n" +
                                                          "3] Suppresion Personnes Morales \n" +
                                                            "\n\n\n4] Retourner \n" +
                                                                  "5] Menu Principal\n" +
                                                                  "6] Quitter\n");
                                        choix03 = SaisirChoix(6);
                                        retournerNivaux2 = false;
                                        if (choix03 < 4)
                                        {
                                            mobilier_pour_tous.SupprimePersonne(choix03);
                                            b = RetounerQuitterMenu();
                                            retournerNivaux1 = b[0];
                                            continuer = b[1];
                                            b.Clear();
                                        }
                                        else
                                        {
                                            switch (choix03)
                                            {
                                                case 4:
                                                    retournerNivaux1 = true;
                                                    break;
                                                case 5:
                                                    continuer = true;
                                                    break;
                                                case 6:
                                                    continuer = false;
                                                    break;
                                            }
                                        }
                                    }
                                    break;
                                #endregion
                                #region case 4
                                case 4:
                                    while (retournerNivaux2)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("\t\t1 / Afficher des Personnes ");
                                        Console.WriteLine("_____________________________________________\n");
                                        Console.WriteLine("1] Afficher Bénéficiaires \n" +
                                                          "2] Afficher Adhérents\n" +
                                                          "3] Afficher Personnes Morales \n" +
                                                            "\n\n\n4] Retourner \n" +
                                                                  "5] Menu Principal\n" +
                                                                  "6] Quitter\n");
                                        choix03 = SaisirChoix(6);
                                        retournerNivaux2 = false;
                                        if (choix03 < 4)
                                        {
                                            mobilier_pour_tous.AffichePersonne(choix03);
                                            b = RetounerQuitterMenu();
                                            retournerNivaux1 = b[0];
                                            continuer = b[1];
                                            b.Clear();
                                        }
                                        else
                                        {
                                            switch (choix03)
                                            {
                                                case 4:
                                                    retournerNivaux1 = true;
                                                    break;
                                                case 5:
                                                    continuer = true;
                                                    break;
                                                case 6:
                                                    continuer = false;
                                                    break;
                                            }
                                        }
                                    }
                                    break;
                                #endregion
                                #region case 5
                                case 5:
                                    while (retournerNivaux2)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("\t\t1 / Ajouter des Personnes ");
                                        Console.WriteLine("_____________________________________________\n");
                                        Console.WriteLine("1] Ajouter Bénéficiaires \n" +
                                                          "2] Ajouter Adhérents\n" +
                                                          "3] Ajouter Personnes Morales \n" +
                                                            "\n\n\n4] Retourner \n" +
                                                                  "5] Menu Principal\n" +
                                                                  "6] Quitter\n");
                                        choix03 = SaisirChoix(6);
                                        retournerNivaux2 = false;
                                        if (choix03 < 4)
                                        {
                                            mobilier_pour_tous.AjouterPersonne(choix03);
                                            b = RetounerQuitterMenu();
                                            retournerNivaux1 = b[0];
                                            continuer = b[1];
                                            b.Clear();
                                        }
                                        else
                                        {
                                            switch (choix03)
                                            {
                                                case 4:
                                                    retournerNivaux1 = true;
                                                    break;
                                                case 5:
                                                    continuer = true;
                                                    break;
                                                case 6:
                                                    continuer = false;
                                                    break;
                                            }
                                        }
                                    }
                                    break;
                                #endregion
                                case 6:
                                    continuer = true;
                                    break;
                                case 7:
                                    continuer = false;
                                    break;
                            }
                        }
                        #endregion
                        break;
                    case 2:
                        #region Module Don
                        while (retournerNivaux1)
                        {
                            Console.Clear();
                            Console.WriteLine("\t\t2 / Module Don ");
                            Console.WriteLine("_____________________________________________\n");
                            Console.WriteLine("1] Creation d'un don\n" +
                                              "2] Traitement d’un don \n" +
                                              "3] Stockage d’un don \n" +
                                              "4] Transfert du don au bénéficiaire \n" +
                                              "5] Archive d’un don\n" +
                                              "\n\n6]Menu Principal\n" +
                                                  "7]Quitter\n");
                            choix02 = SaisirChoix(6);
                           
                            retournerNivaux1 = false;
                            switch (choix02)
                            {
                                case 1:
                                    Console.Clear();
                                    Console.WriteLine("\t\t1 / Creation d'un don ");
                                    Console.WriteLine("_____________________________________________\n");
                                    mobilier_pour_tous.AjouterDon();
                                    b = RetounerQuitterMenu();
                                    retournerNivaux1 = b[0];
                                    continuer = b[1];
                                    b.Clear();
                                    break;
                                case 2:
                                    Console.Clear();
                                    Console.WriteLine("\t\t2 / Traitement d’un don  ");
                                    Console.WriteLine("_____________________________________________\n");
                                    mobilier_pour_tous.AfficherList<Don>();
                                    mobilier_pour_tous.TraitementDon();
                                    b = RetounerQuitterMenu();
                                    retournerNivaux1 = b[0];
                                    continuer = b[1];
                                    b.Clear();
                                    break;
                                case 3:
                                    Console.Clear();
                                    Console.WriteLine("\t\t3 / Stockage d’un don  ");
                                    Console.WriteLine("_____________________________________________\n");
                                    mobilier_pour_tous.AfficherList<Don_accepté>();
                                    mobilier_pour_tous.StockageDuDon();
                                    b = RetounerQuitterMenu();
                                    retournerNivaux1 = b[0];
                                    continuer = b[1];
                                    b.Clear();
                                    break;
                                case 4:
                                    Console.Clear();
                                    Console.WriteLine("\t\t4 / Transfert du don au bénéficiaire  ");
                                    Console.WriteLine("_____________________________________________\n");
                                    mobilier_pour_tous.AfficherList<Don_accepté>();
                                    mobilier_pour_tous.TransfertDuDon();
                                    b = RetounerQuitterMenu();
                                    retournerNivaux1 = b[0];
                                    continuer = b[1];
                                    b.Clear();
                                    break;
                                case 5:
                                    Console.Clear();
                                    Console.WriteLine("\t\t4 / Archive d’un don  ");
                                    Console.WriteLine("_____________________________________________\n");
                                    mobilier_pour_tous.AfficherList<Don_accepté>();
                                    mobilier_pour_tous.ArchiveUnDon();
                                    b = RetounerQuitterMenu();
                                    retournerNivaux1 = b[0];
                                    continuer = b[1];
                                    b.Clear();
                                    break;
                                case 6:
                                    continuer = true;
                                    break;
                                case 7:
                                    continuer = false;
                                    break;
                            }
                        }
                        #endregion
                        break;
                    case 3:
                        #region Module Demande
                        while (retournerNivaux1)
                        {
                            Console.Clear();
                            Console.WriteLine("\t\t3 / Module Demande ");
                            Console.WriteLine("_____________________________________________\n");
                            Console.WriteLine("1] Creation d'une demande\n" +
                                              "2] Traitement d'une demande\n" +
                                              "3] Affiche la list des demandes\n" +
                                              "4] Affiche l'archive des demandes\n" +
                                              "\n\n5]Menu Principal\n" +
                                                  "6]Quitter\n");
                            choix02 = SaisirChoix(6);

                            retournerNivaux1 = false;
                            switch (choix02)
                            {
                                case 1:
                                    Console.Clear();
                                    Console.WriteLine("\t\t1 / Creation d'une demande ");
                                    Console.WriteLine("_____________________________________________\n");
                                    mobilier_pour_tous.AjouterDemande();
                                    b = RetounerQuitterMenu();
                                    retournerNivaux1 = b[0];
                                    continuer = b[1];
                                    b.Clear();
                                    break;
                                case 2:
                                    Console.Clear();
                                    Console.WriteLine("\t\t2 / Traitement d'une demande  ");
                                    Console.WriteLine("_____________________________________________\n");
                                    mobilier_pour_tous.TraitementDemande();
                                    b = RetounerQuitterMenu();
                                    retournerNivaux1 = b[0];
                                    continuer = b[1];
                                    b.Clear();
                                    break;
                                case 3:
                                    Console.Clear();
                                    Console.WriteLine("\t\t3 / Affiche la list des demandes  ");
                                    Console.WriteLine("_____________________________________________\n");
                                    mobilier_pour_tous.AfficherList<Demande>();
                                    b = RetounerQuitterMenu();
                                    retournerNivaux1 = b[0];
                                    continuer = b[1];
                                    b.Clear();
                                    break;
                                case 4:
                                    Console.Clear();
                                    Console.WriteLine("\t\t4 / Affiche l'archive des demandes  ");
                                    Console.WriteLine("_____________________________________________\n");
                                    mobilier_pour_tous.AfficherArchive<Demande>();
                                    b = RetounerQuitterMenu();
                                    retournerNivaux1 = b[0];
                                    continuer = b[1];
                                    b.Clear();
                                    break;
                                case 5:
                                    continuer = true;
                                    break;
                                case 6:
                                    continuer = false;
                                    break;
                            }
                        }
                        #endregion
                        break;
                    case 4:
                        #region Module Tris
                        while (retournerNivaux1)
                        {
                            Console.Clear();
                            Console.WriteLine("\t\t4 / Module Tris ");
                            Console.WriteLine("_____________________________________________\n");
                            Console.WriteLine("1] Lister les dons refusés \n" +
                                              "2] Lister les dons en traitement (accepté ou stocké) \n" +
                                              "3] Lister les dons vendus/donnés \n" +
                                              "4] Lister les dons stockés par entrepôt\n" +
                                              "5] Lister les dons par dépôt-vente\n" +
                                              "\n\n6]Menu Principal\n" +
                                                  "7]Quitter\n");
                            choix02 = SaisirChoix(7);

                            retournerNivaux1 = false;
                            switch (choix02)
                            {
                                case 1:
                                    Console.Clear();
                                    Console.WriteLine("\t\t1 / Lister les dons refusés ");
                                    Console.WriteLine("_____________________________________________\n");

                                    mobilier_pour_tous.affiche_dons_refuses();

                                    b = RetounerQuitterMenu();
                                    retournerNivaux1 = b[0];
                                    continuer = b[1];
                                    b.Clear();
                                    break;
                                case 2:
                                    Console.Clear();
                                    Console.WriteLine("\t\t2 / Lister les dons en traitement (accepté ou stocké) ");
                                    Console.WriteLine("_____________________________________________\n");

                                    mobilier_pour_tous.affiche_dons_en_traitement();

                                    b = RetounerQuitterMenu();
                                    retournerNivaux1 = b[0];
                                    continuer = b[1];
                                    b.Clear();
                                    break;
                                case 3:
                                    Console.Clear();
                                    Console.WriteLine("\t\t3 / Lister les dons vendus/donnés  ");
                                    Console.WriteLine("_____________________________________________\n");

                                    mobilier_pour_tous.affiche_dons_donnes_vendus();

                                    b = RetounerQuitterMenu();
                                    retournerNivaux1 = b[0];
                                    continuer = b[1];
                                    b.Clear();
                                    break;
                                case 4:
                                    Console.Clear();
                                    Console.WriteLine("\t\t4 / Lister les dons stockés par entrepôt  ");
                                    Console.WriteLine("_____________________________________________\n");

                                    mobilier_pour_tous.affiche_dons_entrepot();

                                    b = RetounerQuitterMenu();
                                    retournerNivaux1 = b[0];
                                    continuer = b[1];
                                    b.Clear();
                                    break;
                                case 5:
                                    Console.Clear();
                                    Console.WriteLine("\t\t5 / Lister les dons par dépôt-vente ");
                                    Console.WriteLine("_____________________________________________\n");

                                    mobilier_pour_tous.affiche_dons_depot();

                                    b = RetounerQuitterMenu();
                                    retournerNivaux1 = b[0];
                                    continuer = b[1];
                                    b.Clear();
                                    break;
                                case 6:
                                    continuer = true;
                                    break;
                                case 7:
                                    continuer = false;
                                    break;
                            }
                        }
                        #endregion
                        break;
                    case 5:
                        #region Module Statistique
                        while (retournerNivaux1)
                        {
                            Console.Clear();
                            Console.WriteLine("\t\t5 / Module Statistique ");
                            Console.WriteLine("_____________________________________________\n");
                            Console.WriteLine(" 1] Moyenne de temps entre la date de réception et la date de retrait des dons dans les zone de stockage\n" +
                                              " 2] Moyenne de prix des objets dans les dépôts-ventes \n" +
                                              " 3] Moyenne d’âge des bénéficiaires \n" +
                                              " 4] Nombre de propositions de dons reçues\n" +
                                              " 5] Nombre d'adhérents\n" +
                                              " 6] Nombre de bénéficiaires\n" +
                                              " 7] Nombre de propositions de dons refusés\n" +
                                              "\n\n8] Menu Principal\n" +
                                                  "9] Quitter\n");
                            choix02 = SaisirChoix(9);

                            retournerNivaux1 = false;
                            switch (choix02)
                            {
                                case 1:
                                    Console.Clear();
                                    Console.WriteLine("\t\t1 / la moyenne de temps entre la date de réception et la date de retrait des dons dans les zone de stockage ");
                                    Console.WriteLine("_____________________________________________\n");

                                    mobilier_pour_tous.affiche_moyenne_duree_retrait();

                                    b = RetounerQuitterMenu();
                                    retournerNivaux1 = b[0];
                                    continuer = b[1];
                                    b.Clear();
                                    break;
                                case 2:
                                    Console.Clear();
                                    Console.WriteLine("\t\t2 / la moyenne de prix des objets dans les dépôts-ventes  ");
                                    Console.WriteLine("_____________________________________________\n");

                                    mobilier_pour_tous.moyenne_prix();

                                    b = RetounerQuitterMenu();
                                    retournerNivaux1 = b[0];
                                    continuer = b[1];
                                    b.Clear();
                                    break;
                                case 3:
                                    Console.Clear();
                                    Console.WriteLine("\t\t3 / la moyenne d’âge des bénéficiaires   ");
                                    Console.WriteLine("_____________________________________________\n");

                                    mobilier_pour_tous.moyenne_age_beneficiaires();

                                    b = RetounerQuitterMenu();
                                    retournerNivaux1 = b[0];
                                    continuer = b[1];
                                    b.Clear();
                                    break;

                                case 4:
                                    Console.Clear();
                                    Console.WriteLine("\t\t 4 / Nombre de propositions de dons reçues");
                                    Console.WriteLine("_____________________________________________\n");
                                    int max = mobilier_pour_tous.ListDon1.Count + mobilier_pour_tous.ListDeDonActuels1.Count 
                                              + mobilier_pour_tous.ArchiveDonAccepte1.Count + mobilier_pour_tous.ArchiveDonRefuse1.Count;
                                    Console.WriteLine("Il y a eu en tout " + max + " dons pour l'association !");
                                    b = RetounerQuitterMenu();
                                    retournerNivaux1 = b[0];
                                    continuer = b[1];
                                    b.Clear();
                                    break;

                                case 5:
                                    Console.Clear();
                                    Console.WriteLine("\t\t 5 / Nombre d'adhérents");
                                    Console.WriteLine("_____________________________________________\n");
                                    int nb_donateurs = mobilier_pour_tous.ListDeAdhérent1.Count;
                                    Console.WriteLine("Il y a un total de " + nb_donateurs + " adhérents dans l'association !");
                                    b = RetounerQuitterMenu();
                                    retournerNivaux1 = b[0];
                                    continuer = b[1];
                                    b.Clear();
                                    break;

                                case 6:
                                    Console.Clear();
                                    Console.WriteLine("\t\t 6 / Nombre de bénéficiaires");
                                    Console.WriteLine("_____________________________________________\n");
                                    int nb_benef = mobilier_pour_tous.ListDeBénéficiaire1.Count;
                                    Console.WriteLine("Il y a un total de " + nb_benef + " bénéficiaires de l'association !");
                                    b = RetounerQuitterMenu();
                                    retournerNivaux1 = b[0];
                                    continuer = b[1];
                                    b.Clear();
                                    break;

                                case 7:
                                    Console.Clear();
                                    Console.WriteLine("\t\t 7 / Nombre de propositions de dons refusés");
                                    Console.WriteLine("_____________________________________________\n");
                                    int max_refus = mobilier_pour_tous.ArchiveDonRefuse1[mobilier_pour_tous.ArchiveDonRefuse1.Count - 1].Identifiant;
                                    Console.WriteLine("Il y a eu un total de " + max_refus + " dons refusés.");

                                    b = RetounerQuitterMenu();
                                    retournerNivaux1 = b[0];
                                    continuer = b[1];
                                    b.Clear();
                                    break;

                                case 8:
                                    continuer = true;
                                    break;
                                case 9:
                                    continuer = false;
                                    break;
                            }
                        }
                        #endregion
                        break;
                }
                Console.Clear();

            }
            #endregion

            #region Ecriture des fichiers et fermeture du programme

            mobilier_pour_tous.Ecriture_Archives();
            mobilier_pour_tous.Ecriture_Demandes();
            mobilier_pour_tous.Ecriture_Dons_Actuels();
            mobilier_pour_tous.Ecriture_Personnes();
            mobilier_pour_tous.Ecriture_Dons();
            Console.WriteLine("Fin du programme...");
            Console.WriteLine("A la prochaine fois");
            System.Threading.Thread.Sleep(2500);

            #endregion
        }
    }
}
