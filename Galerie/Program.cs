﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;


namespace Galerie
{
    class Program
    {
        public static string fichierConservateurs = "Conservateurs.txt";
        public static string fichierArtistes = "Artistes.txt";
        public static string fichierOeuvres = "Oeuvres.txt";

        StreamReader lecteur = new StreamReader(fichierConservateurs); // lecteur StreamReader pour les fichiers
        StreamReader lecteur2 = new StreamReader(fichierArtistes);


        
        public static List<string> oeuvreCode;
        public static List<string> oeuvreTitre;
        public static List<string> oeuvreArtisteCode;
        public static List<double> oeuvreValeur;
        public static List<double> oeuvrePrixVente;
        public static List<string> oeuvreEtat;
        public static List<double> oeuvreValeurVente;
        public static List<double> oeuvreAneeAquisition;

        public static List<string> artisteCode;
        public static List<string> artisteNom;
        public static List<string> artisteConservateurCode;

        public static List<string> conservateurCode;
        public static List<string> conservateurNom;
        public static List<double> conservateurComission;

        public static double comission;
        public static int Cnt;

        static void Main(string[] args)
        {
            oeuvreCode = new List<string>();
            oeuvreTitre = new List<string>();
            oeuvreArtisteCode = new List<string>();
            oeuvreValeur = new List<double>();
            oeuvrePrixVente = new List<double>();
            oeuvreEtat = new List<string>();
            oeuvreValeurVente = new List<double>();
            oeuvreAneeAquisition = new List<double>();

            artisteCode = new List<string>();
            artisteNom = new List<string>();
            artisteConservateurCode = new List<string>();

            conservateurCode = new List<string>();
            conservateurNom = new List<string>();
            conservateurComission = new List<double>();


            comission = (double)0.25;


            // Methode pour ajouter les données des fichiers aux tableaux


            static void LecteurOeuvre()
            {
                string ligne = null;
                string[] oeuvresTxt;
                StreamReader lecteur3 = new StreamReader(fichierOeuvres);

                while ((ligne = lecteur3.ReadLine()) != null)
                {
                    oeuvresTxt = ligne.Split(',');

                    oeuvreCode.Add(oeuvresTxt[0]);
                    oeuvreTitre.Add(oeuvresTxt[1]);
                    oeuvreArtisteCode.Add(oeuvresTxt[2]);
                    oeuvreAneeAquisition.Add(Double.Parse(oeuvresTxt[3]));
                    oeuvreValeur.Add(Double.Parse(oeuvresTxt[4]));
                    oeuvrePrixVente.Add(Double.Parse(oeuvresTxt[5]));
                    oeuvreEtat.Add(oeuvresTxt[6]);
                }
                lecteur3.Close();


            }

            static void LecteurArtiste()
            {
                string ligne = null;
                string[] artisteTxt;
                StreamReader lecteur2 = new StreamReader(fichierArtistes);

                while ((ligne = lecteur2.ReadLine()) != null)
                {
                    artisteTxt = ligne.Split(',');

                    artisteCode.Add(artisteTxt[0]);
                    artisteNom.Add(artisteTxt[1]);
                    artisteConservateurCode.Add(artisteTxt[2]);

                }
                lecteur2.Close();

            }

            static void LecteurConservateur()
            {
                string ligne = null;
                string[] conservateurTxt;
                StreamReader lecteur3 = new StreamReader(fichierConservateurs);

                while ((ligne = lecteur3.ReadLine()) != null)
                {
                    conservateurTxt = ligne.Split(',');

                    conservateurCode.Add(conservateurTxt[0]);
                    conservateurNom.Add(conservateurTxt[1]);
                    conservateurComission.Add(Double.Parse(conservateurTxt[2]));

                }
                lecteur3.Close();

            }



            // Initialiser lecteur

            LecteurOeuvre();

            LecteurArtiste();

            LecteurConservateur();


            // Afficher menu 

            AfficherMenu();
        }

        public static void AfficherMenu() // Methode pour afficher MENU
        {
            
            Console.WriteLine();
            Console.WriteLine("**********************************************");
            Console.WriteLine("-------------------MENU-----------------------");
            Console.WriteLine("**********************************************");
            Console.WriteLine();
            Console.WriteLine("[1] - Ajouter Conservateur");
            Console.WriteLine("[2] - Ajouter Artiste");
            Console.WriteLine("[3] - Afficher Artistes");
            Console.WriteLine("[4] - Afficher Conservateurs");
            Console.WriteLine("[5] - Ajouter oeuvre d'art");
            Console.WriteLine("[6] - Afficher les oeuvres de la collection");
            Console.WriteLine("[0] - Quitter");
            Console.WriteLine();
            Console.WriteLine("**********************************************");
            Console.WriteLine();


            Console.WriteLine("Entrez le code desirez:");

            string menuCode = "";
            menuCode = Console.ReadLine();

            switch (menuCode)
            {
                case "1":  // - Ajouter Conservateur
                    AjouterConservateur();
                    break;

                case "2":  // - Ajouter Artiste
                    AjouterArtiste();
                    break;

                case "3":  // - Afficher Artistes
                    AfficherArtistes();
                    break;

                case "4":  // - Afficher Conservateurs
                    AfficherConservateurs();
                    break;

                case "5":  // - Ajouter oeuvre d'art
                    AjouterOeuvre();
                    break;

                case "6":  // - Afficher les oeuvres de la collaction
                    RaportOeuvres();
                    break;

                case "0":  // - SAIR
                    break;

                default:
                    Console.WriteLine(" Voulez entrer un code de 1 à 6.");
                    AfficherMenu();
                    break;
            }
        }
        public static void AjouterConservateur()
        {
            // Declaration des variables
            bool valueValid = false;
            string s_conservateurCode = "";
            string s_conservateurNom = "";

            StreamWriter ecriture = new StreamWriter(fichierConservateurs, true);

            // Code du conservateur
            valueValid = false;
            while (valueValid == false)
            {
              bool reponse = false;

                do
                {
                    Console.WriteLine("Saisir le Code du conservateur: (5 caracteres)");
                    s_conservateurCode = Console.ReadLine().ToUpper();

                    string message = ValiderCodeConservateur(s_conservateurCode) ? "Code Valide" : "Le code doit debuter par le caractère \"C\"suivi par quatre caractères numériques";
                    reponse = ValiderCodeConservateur(s_conservateurCode);
                    Console.WriteLine(message);


                } while (!reponse);

                 
                  
               valueValid = true;
                    
      
            }

            // Nom du conservateur
            valueValid = false;
            while (valueValid == false)
            {
                bool reponse = false;
                do
                {
                    Console.WriteLine("Saisir le nom du conservateur:");
                    s_conservateurNom = Console.ReadLine();
                    string message = ValiderNomConservateur(s_conservateurNom) ? "Nom valide!" : " Le nom doit avoir un maximun de 30 caractères alphabétiques, un trait d'union et un ou plusieurs spaces.";
                    Console.WriteLine(message);

                    reponse = ValiderNomConservateur(s_conservateurNom);


                } while (!reponse);
                    valueValid = true;
                
            }



            // Enregistrer conservateur
            conservateurCode.Add(s_conservateurCode);
            conservateurNom.Add(s_conservateurNom);


            ecriture.WriteLine($"{s_conservateurCode},{s_conservateurNom},{0}");
            ecriture.Close();

            Console.WriteLine("Enregistrement fait!");
            AfficherMenu();
        }
        public static void AjouterArtiste()
        {
            // Variables de la methode
            bool valueValid = false;
            string s_artisteCode = "";
            string s_artisteNom = "";
            string s_artisteConservateurCode = "";
            int qtdConservateur = conservateurCode.Count;

            StreamWriter ecriture = new StreamWriter(fichierArtistes, true);

            // se náo tiver conservador cadastrado, sugiro que cadastre um novo ou volte para o menu
            if (qtdConservateur == 0)
            {
                valueValid = false;
                while (valueValid == false)
                {
                    string sAux_MenuConservateur = "";
                    Console.WriteLine("**********************************************");
                    Console.WriteLine("Aucun conservateur enregistré.");
                    Console.WriteLine("Voulez-vous enregistrer un conservateur?");
                    Console.WriteLine("(Y) - OUI");
                    Console.WriteLine("(N) - NOM");
                    Console.WriteLine("**********************************************");

                    sAux_MenuConservateur = Console.ReadLine().ToUpper();
                    switch (sAux_MenuConservateur)
                    {
                        case "Y":
                            valueValid = true;
                            AjouterConservateur();
                            return;

                        case "N":
                            valueValid = true;
                            AfficherMenu();
                            return;

                        default:
                            Console.WriteLine("**********************************************");
                            Console.WriteLine(" Voulez saisir [Y] ou [N]");
                            break;
                    }
                }

            }

            // Code de l'artiste
            valueValid = false;

            while (valueValid == false)
            {
                bool reponse = false;
                do
                {
                   

                    Console.WriteLine("Saisir le Code de l'artiste: Le code doit commencer par le caractère \"A\" suivi par quatre caractères numeriques.");
                    s_artisteCode = Console.ReadLine().ToUpper();


                    string message = ValiderCodeArtiste(s_artisteCode) ? "Code valide!" : " Le code doit debuter par le caractère \"A\" suivi par quatre caractères numeriques.";
                    reponse = ValiderCodeArtiste(s_artisteCode);
                    Console.WriteLine(message);

                } while (!reponse);
            
                    
                    
                 valueValid = true;
                    
               
            }

            // Valider nom de l'artiste
            valueValid = false;
            while (valueValid == false)
            {
                    bool reponse = false;

                    do
                    {
                        Console.WriteLine("Saisir le nom de l'artist:");
                        s_artisteNom = Console.ReadLine();
                        string message = ValiderNomArtiste(s_artisteNom) ? "Nom valide!" : "Le nom doit etre composé de caractères alphabétiques";
                        reponse = ValiderNomArtiste(s_artisteNom);
                        Console.WriteLine(message);


                    } while (!reponse);
                    valueValid = true;
               
            }

            // Choix du conservateur

            valueValid = false;
            while (valueValid == false)
            {
                Console.WriteLine("**********************************************");
                Console.WriteLine("Choisissez un conservateur:");
                for (int i = 0; i < qtdConservateur; i++)
                {
                    Console.WriteLine("[" + conservateurCode[i] + "] - " + conservateurNom[i]);
                }
                Console.WriteLine("**********************************************");

                s_artisteConservateurCode = Console.ReadLine().ToUpper();

                // Verifie string saisi dans la liste de string de codes des conservateurs
                if (conservateurCode.Contains(s_artisteConservateurCode) == true)
                {
                    valueValid = true;
                }
            }

            // Ajouter artiste
            artisteCode.Add(s_artisteCode);
            artisteNom.Add(s_artisteNom);
            artisteConservateurCode.Add(s_artisteConservateurCode);

            ecriture.WriteLine($"{s_artisteCode},{s_artisteNom},{s_artisteConservateurCode}");
            ecriture.Close();

            Console.WriteLine("Enregistrement fait!");
            AfficherMenu();
        }
        public static void AfficherArtistes()
        {
            Console.WriteLine("**********************************************");

            for (int i = 0; i < artisteCode.Count; i++)
            {
                Console.WriteLine("Artiste " + artisteNom[i] + " code " + artisteCode[i]);
                Console.WriteLine(".............................................");


            }

            Console.WriteLine("**********************************************");
            Console.ReadKey();

            AfficherMenu();



        }

        public static void AfficherConservateurs()

        {
            Console.WriteLine();
            Console.WriteLine("**********************************************");
            for (int i = 0; i < conservateurCode.Count; i++)
            {
                Console.WriteLine("Conservateur " + conservateurNom[i] + " code " + conservateurCode[i]);
                Console.WriteLine(".............................................");


            }
            Console.WriteLine("**********************************************");
            Console.WriteLine();
            Console.ReadKey();


            AfficherMenu();



        }

        public static void AjouterOeuvre()
        {
            // Variables
            bool valueValid = false;
            string s_oeuvreCode = "";
            string s_oeuvreTitre = "";
            string s_oeuvreArtisteCode = "";
            double d_oeuvreValeur = 0;
            double d_oeuvreAneeAquisition = 0;
            string s_oeuvreEtat = "";
            int qtdArtist = artisteCode.Count;

            StreamWriter ecriture = new StreamWriter(fichierOeuvres, true);


            // S'il y a pas d'artiste enregistré, le logiciel sugère d'en ajouter un.
            if (qtdArtist == 0)
            {
                valueValid = false;
                while (valueValid == false)
                {
                    string sAux_MenuArtiste = "";
                    Console.WriteLine("**********************************************");
                    Console.WriteLine("Aucun artiste enregistré.");
                    Console.WriteLine("Desirez-vous ajouter un artiste?");
                    Console.WriteLine("(Y) - Oui");
                    Console.WriteLine("(N) - Nom");
                    Console.WriteLine("**********************************************");

                    sAux_MenuArtiste = Console.ReadLine().ToUpper();
                    switch (sAux_MenuArtiste)
                    {
                        case "Y":
                            valueValid = true;
                            AjouterArtiste();
                            return;

                        case "N":
                            valueValid = true;
                            AfficherMenu();
                            return;

                        default:
                            Console.WriteLine("**********************************************");
                            Console.WriteLine("Voulez saisir [Y] ou [N]");
                            break;
                    }
                }

            }

            // Code d'oeuvre
            valueValid = false;
            while (valueValid == false)
            {

                bool reponse = false;

                do
                {

                    Console.WriteLine("Saisir le Code de l'ouvre: (5 caractères)");
                    s_oeuvreCode = Console.ReadLine().ToUpper();
                    string message = ValiderCodeOeuvre(s_oeuvreCode) ? "Code valide!" : "Le code doit debuter par le caractère \"O\" suivi par quatre caractères numeriques.";
                    Console.WriteLine(message);
                    reponse = ValiderCodeOeuvre(s_oeuvreCode);

                } while (!reponse);
                
                        valueValid = true;
                
            }


            // Afficher et ajourter artiste
            valueValid = false;
            while (valueValid == false)
            {
                Console.WriteLine("**********************************************");
                Console.WriteLine("Choisissez un artiste:");
                for (int i = 0; i < qtdArtist; i++)
                {
                    Console.WriteLine("[" + artisteCode[i] + "] - " + artisteNom[i]);
                }
                Console.WriteLine("**********************************************");

                s_oeuvreArtisteCode = Console.ReadLine().ToUpper();

                // Verifie string saisi dans la liste de string
                if (artisteCode.Contains(s_oeuvreArtisteCode) == true)
                {
                    valueValid = true;
                }
            }
            // Tittre d'oeuvre
            valueValid = false;
            while (valueValid == false)
            {

                bool reponse = false;

                do
                {


                    Console.WriteLine("Saisir le titre de l'oeuvre:");
                    s_oeuvreTitre = Console.ReadLine();
                    string message = ValiderTitreOeuvre(s_oeuvreTitre) ? "Titre valide!" : "Le titre doit être composé d'un maximun de 40 caractères alphabetiques.";
                    Console.WriteLine(message);
                    reponse = ValiderTitreOeuvre(s_oeuvreTitre);


                } while (!reponse);
                
                
                    valueValid = true;
                
            }

            // Valeur estimé de l'oeuvre
            valueValid = false;
            while (valueValid == false)
            {
                Console.WriteLine("Saisir le valeur estimé de l'oeuvre:");
                string s_oeuvreValeur = Console.ReadLine().Replace(",",".");

                
                    if (Double.TryParse(s_oeuvreValeur, out d_oeuvreValeur) == true)
                    {
                        if (d_oeuvreValeur > 0)
                        {
                            valueValid = true;
                        }
                    }
                
            }

            // Anée d'aquisition
            valueValid = false;
            while (valueValid == false)
            {
                Console.WriteLine("Saisir l'anée d'aquisition de l'oeuvre:");
                string s_oeuvreAneeAquisition = Console.ReadLine();

                if (s_oeuvreAneeAquisition.Length == 4)
                {
                    if (double.TryParse(s_oeuvreAneeAquisition, out d_oeuvreAneeAquisition) == true)
                    {
                        if (d_oeuvreAneeAquisition > 1990)
                        {
                            valueValid = true;
                        }
                    }
                }
            }

            // Status de l'oeuvre
            valueValid = false;
            while (valueValid == false)
            {
                Console.WriteLine("Saisir le Etat de l'ouvre:");
                Console.WriteLine("[N] - Entreposé");
                Console.WriteLine("[E] - Exposé");
                s_oeuvreEtat = Console.ReadLine().ToUpper();

                switch (s_oeuvreEtat)
                {
                    case "N":
                    case "E":
                        valueValid = true;
                        break;
                    default:

                        Console.WriteLine("Voulez saisir \"E\" ou \"N\"");
                        break;
                }
            }

            // Ajouter l'oeuvre
            oeuvreCode.Add(s_oeuvreCode);
            oeuvreTitre.Add(s_oeuvreTitre);
            oeuvreArtisteCode.Add(s_oeuvreArtisteCode);
            oeuvreValeur.Add(d_oeuvreValeur);
            oeuvreAneeAquisition.Add(d_oeuvreAneeAquisition);
            oeuvreEtat.Add(s_oeuvreEtat);
            oeuvreValeurVente.Add(0);
            oeuvrePrixVente.Add(0);

            ecriture.WriteLine($"{s_oeuvreCode},{s_oeuvreTitre},{s_oeuvreArtisteCode},{d_oeuvreAneeAquisition},{d_oeuvreValeur},{0},{s_oeuvreEtat}");
            ecriture.Close();

            Console.WriteLine("Enregistrement fait!");
            AfficherMenu();
        }
        
        public static void RaportOeuvres()
        {
            for (int i = 0; i < artisteCode.Count; i++)
            {
                Console.WriteLine("**********************************************");
                Console.WriteLine("[" + artisteCode[i] + "]: " + artisteNom[i]);
                Console.WriteLine("**********************************************");
                Console.WriteLine("Oeuvres:");

                for (int j = 0; j < oeuvreCode.Count; j++)
                {
                    if (oeuvreArtisteCode[j] == artisteCode[i])
                    {
                        Console.WriteLine("----------------------------------------------");
                        Console.WriteLine("#: " + oeuvreCode[j]);
                        Console.WriteLine("Titre: " + oeuvreTitre[j]);
                        Console.WriteLine("Valeur: " + oeuvreValeur[j].ToString("C"));
                        if (oeuvreEtat[j] == "V")
                        {
                            Console.WriteLine("Valeur de vente: " + oeuvreValeurVente[j].ToString("C"));
                        }

                        Console.WriteLine("");
                    }
                }
                Console.WriteLine("");
            }

            Console.ReadKey();

            AfficherMenu();
        }

        static bool ValiderCodeArtiste(string s_artisteCode)
        {
            bool valueValid = false;

            while (valueValid == false)
            {

                // Pour chaque string dans la collection, verifie si contien le string saisi
                bool auxExist1 = false;
            foreach (string item in artisteCode)
            {
                if (item == s_artisteCode)
                {
                    auxExist1 = true;
                    Console.WriteLine("Ce code est déjà utilisé par un autre artiste, voulez saisir un code unique.");
                    return false;
                }
            }
            if (auxExist1 == false)
            {
                valueValid = true;
            }

        }
        Regex myRegex = new Regex(@"^[A]{1}[0-9]{4}$");
            return myRegex.IsMatch(s_artisteCode);

        }



        static bool ValiderCodeOeuvre(string s_oeuvreCode)
        {
            bool valueValid = false;

            while (valueValid == false)
            {

                // Pour chaque string dans la collection, verifie si contien le string saisi
                bool auxExist1 = false;
                foreach (string item in oeuvreCode)
                {
                    if (item == s_oeuvreCode)
                    {
                        auxExist1 = true;
                        Console.WriteLine("Ce code est déjà utilisé par une autre oeuvre, voulez saisir un code unique.");
                        return false;
                    }
                }
                if (auxExist1 == false)
                {
                    valueValid = true;
                }

            }
            Regex myRegex = new Regex(@"^[O]{1}[0-9]{4}$");
            return myRegex.IsMatch(s_oeuvreCode);

        }

        static bool ValiderCodeConservateur(string s_conservateurCode)
        {
            bool valueValid = false;
            while (valueValid == false)
            {

                // Verifie si string saisi contient dans le tableau
                bool auxExist1 = false;
                foreach (string item in conservateurCode)
                {
                    if (item == s_conservateurCode)
                    {

                        auxExist1 = true;

                        Console.WriteLine("Ce code a été déjà utilisé par un autre conservateur.");

                        return false;
                        
                    }
                }
                if (auxExist1 == false)
                {
                    
                    valueValid = true;
                }

            }


            Regex myRegex = new Regex(@"^[C]{1}[0-9]{4}$");
            return myRegex.IsMatch(s_conservateurCode);

        }

        static bool ValiderNomArtiste(string s_artisteNom)
        {
            if (s_artisteNom.Length > 0 && s_artisteNom.Length <= 40)
            {
                Regex myRegex = new Regex(@"^(([A-Z]{1}[a-z]*){1})([\-]([A-Z]{1}[a-z]*))?([ ]([A-Z]{1}[a-z]*))*$");
                return myRegex.IsMatch(s_artisteNom);
            }

            else
            {
                Console.WriteLine("Le nom saisi doit contenir au maximun 40 caractères.");
                return false;
            }
        }

        static bool ValiderTitreOeuvre(string s_titreOeuvre)
        {
            if (s_titreOeuvre.Length > 0 && s_titreOeuvre.Length <= 40)
            {
                Regex myRegex = new Regex(@"^(([A-Z]{1}[a-z]*){1})([\-]([A-Z]{1}[a-z]*))?([ ]([A-Z]{1}[a-z]*))*$");
                return myRegex.IsMatch(s_titreOeuvre);
            }

            else
            {
                Console.WriteLine("Le titre saisi doit contenir au maximun 40 caractères.");
                return false;
            }
        }

        static bool ValiderNomConservateur(string s_conservateurNom)
        {
            if (s_conservateurNom.Length > 0 && s_conservateurNom.Length <= 30)
            {
                Regex myRegex = new Regex(@"^(([A-Z]{1}[a-z]*){1})([\-]([A-Z]{1}[a-z]*))?([ ]([A-Z]{1}[a-z]*))*$");
                return myRegex.IsMatch(s_conservateurNom);
            }

            else
            {
                Console.WriteLine("Le nom saisi doit contenir au maximun 30 caractères alphabétiques: ");
                return false;
            }
        }




    }
}
