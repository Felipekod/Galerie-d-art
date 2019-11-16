using System;
using System.Collections.Generic;


namespace Galerie
{
    class Program
    {
        public static List<string> oeuvreCode;
        public static List<string> oeuvreTitre;
        public static List<string> oeuvreArtisteCode;
        public static List<double> oeuvreValeur;
        public static List<double> oeuvrePrixVente;
        public static List<string> oeuvreEtat;
        public static List<double> oeuvreValeurVente; // ------------------------------------------------------------------------------------------------------
        public static List<double> oeuvreAneeAquisition; // ------------------------------------------------------------------------------------------------------

        public static List<string> artisteCode;
        public static List<string> artisteNom;
        public static List<string> artisteConservateurCode;

        public static List<string> conservateurCode;
        public static List<string> conservateurNom;
        //public static List<double> conservateurComission;

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
            oeuvreAneeAquisition = new List<double>(); // ------------------------------------------------------------------------------------------------------

            artisteCode = new List<string>();
            artisteNom = new List<string>();
            artisteConservateurCode = new List<string>();

            conservateurCode = new List<string>();
            conservateurNom = new List<string>();
            //conservateurComission = new List<double>();

            comission = (double)0.25;

            // PARA FAZER UMA CARGA INICIAL, DESCOMENTE O CODIGO ABAIXO
            LoremIpsum_Conserveteur(10);
            LoremIpsum_Artist(5);
            LoremIpsum_Oeuvres(50);

            // INICIALIZAR O PROGRAMA MOSTRANDO O MENU PARA O USUÁRIO
            AfficherMenu();
        }

        public static void AfficherMenu()
        {
            /*Escrever o menu*/
            Console.WriteLine("**********************************************");
            Console.WriteLine("*MENU*");
            Console.WriteLine("**********************************************");
            Console.WriteLine("**********************************************");
            Console.WriteLine("[1] - Ajouter Conservateur");
            Console.WriteLine("[2] - Ajouter Artiste");
            Console.WriteLine("[3] - Afficher Artistes");
            Console.WriteLine("[4] - Ajouter oeuvre d'art");
            Console.WriteLine("[5] - Trouver oeuvre d'art");
            Console.WriteLine("[6] - Vendre oeuvre d'art");
            Console.WriteLine("[7] - Rapport sur les oeuvres de la collection");
            Console.WriteLine("[0] - Sair");
            Console.WriteLine("**********************************************");

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

                case "4":  // - Ajouter oeuvre d'art
                    AjouterOeuvre();
                    break;

                case "5":  // - Trouver oeuvre d'art
                    TrouverOeuvre();
                    break;

                case "6":  // - Vendre oeuvre d'art
                    VendreOeuvre();
                    break;

                case "7":  // - Rapport sur les oeuvres de la collaction
                    RaportOeuvres();
                    break;

                case "0":  // - SAIR
                    break;

                default:
                    Console.WriteLine(" Voulez entrer un code de 1 à 7.");
                    AfficherMenu();
                    break;
            }
        }
        public static void AjouterConservateur()
        {
            // DECLARAÇÃO DE VARIÁVEIS
            bool valueValid = false;
            string s_conservateurCode = "";
            string s_conservateurNom = "";
            //double d_conservateurComission = 0;

            // CODIGO DO CONSERVADOR
            valueValid = false;
            while (valueValid == false)
            {
                Console.WriteLine("Saisir le Code de l'conservateur: (5 caracts)");
                s_conservateurCode = Console.ReadLine().ToUpper();
                if (s_conservateurCode.Length == 5)
                {
                    // para cada string na coleção, verifica se contem a string informada
                    bool auxExist1 = false;
                    foreach (string item in conservateurCode) // ONDE FOI DECLARADA A VARIAVEL ITEM? ---------------------------------------------------------------------------------------------------------------------------
                    {
                        if (item == s_conservateurCode)
                        {
                            auxExist1 = true;
                            break;
                        }
                    }
                    if (auxExist1 == false)
                    {
                        valueValid = true;
                    }
                }
            }

            // NOME DO CONSERVADOR
            valueValid = false;
            while (valueValid == false)
            {
                Console.WriteLine("Saisir le nom du conservateur:");
                s_conservateurNom = Console.ReadLine();
                if (s_conservateurNom.Length > 0 && s_conservateurNom.Length <= 40)
                {
                    valueValid = true;
                }
            }



            // ADICIONANDO O ARTISTA
            conservateurCode.Add(s_conservateurCode);
            conservateurNom.Add(s_conservateurNom);
            //conservateurComission.Add(d_conservateurComission);

            Console.WriteLine("cadastro feito com sucesso!");
            AfficherMenu();
        }
        public static void AjouterArtiste()
        {
            // DECLARAÇÃO DE VARIÁVEIS
            bool valueValid = false;
            string s_artisteCode = "";
            string s_artisteNom = "";
            string s_artisteConservateurCode = "";
            int qtdConservateur = conservateurCode.Count;

            // se náo tiver conservador cadastrado, sugiro que cadastre um novo ou volte para o menu
            if (qtdConservateur == 0)
            {
                valueValid = false;
                while (valueValid == false)
                {
                    string sAux_MenuConservateur = "";
                    Console.WriteLine("**********************************************");
                    Console.WriteLine("Nenhum conservador cadastrado.");
                    Console.WriteLine("Você deseja cadastrar um conservador agora?");
                    Console.WriteLine("(Y) - Yes");
                    Console.WriteLine("(N) - No");
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
                            Console.WriteLine("Digite [Y] ou [N]");
                            break;
                    }
                }

            }

            // CODIGO DO ARTISTA
            valueValid = false;
            while (valueValid == false)
            {
                Console.WriteLine("Saisir le Code de l'artiste: (5 caracteres)");
                s_artisteCode = Console.ReadLine().ToUpper();
                if (s_artisteCode.Length == 5)
                {
                    // para cada string na coleção, verifica se contem a string informada
                    bool auxExist1 = false;
                    foreach (string item in artisteCode)
                    {
                        if (item == s_artisteCode)
                        {
                            auxExist1 = true;
                            break;
                        }
                    }
                    if (auxExist1 == false)
                    {
                        valueValid = true;
                    }
                }
            }

            // NOME DO ARTISTA
            valueValid = false;
            while (valueValid == false)
            {
                Console.WriteLine("Saisir le nom de l'artist:");
                s_artisteNom = Console.ReadLine();
                if (s_artisteNom.Length > 0 && s_artisteNom.Length <= 40)
                {
                    valueValid = true;
                }
            }

            // CODIGO DO CONSERVATEUR
            valueValid = false;
            while (valueValid == false)
            {
                Console.WriteLine("**********************************************");
                Console.WriteLine("ESCOLHA UM CONSERVADOR");
                for (int i = 0; i < qtdConservateur; i++)
                {
                    Console.WriteLine("[" + conservateurCode[i] + "] - " + conservateurNom[i]);
                }
                Console.WriteLine("**********************************************");

                s_artisteConservateurCode = Console.ReadLine().ToUpper();

                // verifica se não contem a string informada em uma coleção de string (lista de string)
                if (conservateurCode.Contains(s_artisteConservateurCode) == true)
                {
                    valueValid = true;
                }
            }

            // ADICIONANDO O ARTISTA
            artisteCode.Add(s_artisteCode);
            artisteNom.Add(s_artisteNom);
            artisteConservateurCode.Add(s_artisteConservateurCode);

            Console.WriteLine("cadastro feito com sucesso!");
            AfficherMenu();
        }
        public static void AfficherArtistes()
        {

            for (int i = 0; i < artisteCode.Count; i++)
            {
                Console.WriteLine("Artiste " + artisteNom[i] + " code " + artisteCode[i]);


            }

            AfficherMenu();



        }
        public static void AjouterOeuvre()
        {
            // DECLARAÇÃO DE VARIÁVEIS
            bool valueValid = false;
            string s_oeuvreCode = "";
            string s_oeuvreTitre = "";
            string s_oeuvreArtisteCode = "";
            double d_oeuvreValeur = 0;
            double d_oeuvreAneeAquisition = 0;
            string s_oeuvreEtat = "";
            int qtdArtist = artisteCode.Count;


            // se náo tiver artista cadastrado, sugiro que cadastre um novo ou volte para o menu
            if (qtdArtist == 0)
            {
                valueValid = false;
                while (valueValid == false)
                {
                    string sAux_MenuArtiste = "";
                    Console.WriteLine("**********************************************");
                    Console.WriteLine("Nenhum artista cadastrado.");
                    Console.WriteLine("Você deseja cadastras um artista agora?");
                    Console.WriteLine("(Y) - Yes");
                    Console.WriteLine("(N) - No");
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
                            Console.WriteLine("Digite [Y] ou [N]");
                            break;
                    }
                }

            }

            // CODIGO DA OBRA
            valueValid = false;
            while (valueValid == false)
            {
                Console.WriteLine("Saisir le Code de l'ouvre: (5 caracts)");
                s_oeuvreCode = Console.ReadLine().ToUpper();
                if (s_oeuvreCode.Length == 5)
                {
                    // verifica se não contem a string informada em uma coleção de string (lista de string)
                    if (oeuvreCode.Contains(s_oeuvreCode) == false)
                    {
                        valueValid = true;
                    }
                }
            }


            // LISTAR E ADICIONAR ARTISTA
            valueValid = false;
            while (valueValid == false)
            {
                Console.WriteLine("**********************************************");
                Console.WriteLine("ESCOLHA UM ARTISTA");
                for (int i = 0; i < qtdArtist; i++)
                {
                    Console.WriteLine("[" + artisteCode[i] + "] - " + artisteNom[i]);
                }
                Console.WriteLine("**********************************************");

                s_oeuvreArtisteCode = Console.ReadLine().ToUpper();

                // verifica se não contem a string informada em uma coleção de string (lista de string)
                if (artisteCode.Contains(s_oeuvreArtisteCode) == true)
                {
                    valueValid = true;
                }
            }
            // TITULO DA OBRA
            valueValid = false;
            while (valueValid == false)
            {
                Console.WriteLine("Saisir le titre de l'ouvre:");
                s_oeuvreTitre = Console.ReadLine();
                if (s_oeuvreTitre.Length > 0 && s_oeuvreTitre.Length <= 40)
                {
                    valueValid = true;
                }
            }

            // VALOR DA OBRA
            valueValid = false;
            while (valueValid == false)
            {
                Console.WriteLine("Saisir le valeur estimé de l'ouvre:");
                string s_oeuvreValeur = Console.ReadLine();

                if (s_oeuvreValeur.Length > 0)
                {
                    if (Double.TryParse(s_oeuvreValeur, out d_oeuvreValeur) == true)
                    {
                        if (d_oeuvreValeur > 0)
                        {
                            valueValid = true;
                        }
                    }
                }
            }

            // ANO DA  AQUISICAO DA OBRA ---- FELIPE modificado para ANO  ----------------------------------------------------------------------------------
            valueValid = false;
            while (valueValid == false)
            {
                Console.WriteLine("Saisir l'anee d'aquisition de l'ouvre:");
                string s_oeuvreAneeAquisition = Console.ReadLine();

                if (s_oeuvreAneeAquisition.Length == 4)
                {
                    if (double.TryParse(s_oeuvreAneeAquisition, out d_oeuvreAneeAquisition) == true)
                    {
                        if (d_oeuvreAneeAquisition > 2010)
                        {
                            valueValid = true;
                        }
                    }
                }
            }

            // STATUS DA OBRA
            valueValid = false;
            while (valueValid == false)
            {
                Console.WriteLine("Saisir le Etat de l'ouvre:");
                Console.WriteLine("[N] - Entreposé");
                Console.WriteLine("[E] - Exposé");
                s_oeuvreEtat = Console.ReadLine();

                switch (s_oeuvreEtat)
                {
                    case "N":
                    case "E":
                        valueValid = true;
                        break;
                    default:
                        break;
                }
            }

            // ADICIONANDO A OBRA
            oeuvreCode.Add(s_oeuvreCode);
            oeuvreTitre.Add(s_oeuvreTitre);
            oeuvreArtisteCode.Add(s_oeuvreArtisteCode);
            oeuvreValeur.Add(d_oeuvreValeur);
            oeuvreAneeAquisition.Add(d_oeuvreAneeAquisition); //-----------------------------------------------------------------------------------------------------------------------------------------
            oeuvreEtat.Add(s_oeuvreEtat);
            oeuvreValeurVente.Add(0);
            oeuvrePrixVente.Add(0);

            Console.WriteLine("cadastro feito com sucesso!");
            AfficherMenu();
        }
        public static void TrouverOeuvre() // --------------------------------------------------------------------------------------------------------------------------------------------------------------
        {
            Console.WriteLine("Saisir le code d'art recherché");
            string artRecherche = Console.ReadLine();

            if (artRecherche.Length == 5)
            {
                while ((Cnt < oeuvreCode.Count) && (artRecherche != oeuvreCode[Cnt]))
                {
                    Cnt = Cnt + 1;
                }

                if (Cnt > oeuvreCode.Count)
                {
                    Console.WriteLine("Le code d'art n'a pas été trouvé");
                }

                else
                {
                    Console.WriteLine("L'art " + oeuvreCode[Cnt] + " de l'artiste " + artisteNom[Cnt] + " a un valeur estimé de " + oeuvreValeur[Cnt] + " pirocas " + "son état actuel est " + oeuvreEtat[Cnt]);
                    Console.WriteLine();
                    Console.WriteLine(" NIVEL DE IMATURIDADE: > 8000 ");
                }
            }

            AfficherMenu();
        }
        public static void VendreOeuvre() // ----------------------------------------------------------------------------------------------------
        {
            // declaração de variaveis 
            string codeVendre = "";
            int Cnt2 = 0;
            double prixVente = 0;

            Console.WriteLine("Saisir le code d'oeuvre à vendre");
            codeVendre = Console.ReadLine();

            while ((Cnt2 < oeuvreCode.Count) && (codeVendre != oeuvreCode[Cnt2]))
            {
                Cnt2 = Cnt2 + 1;
            }
            if (Cnt2 > oeuvreCode.Count)
            {
                Console.WriteLine("Le code d'art n'a pas été trouvé");
            }
            else // aprender metodo tryParse para não dar erro de imput invalido----------------------------------------------------------------------
            {
                Console.WriteLine("Saisir le valeur de vente " + "Minimun de:" + "$" + oeuvreValeur[Cnt2]);

                prixVente = double.Parse(Console.ReadLine());
                if (prixVente <= oeuvreValeur[Cnt2])
                {
                    Console.WriteLine("le prix minimun doit etre superieur à " + oeuvreValeur[Cnt2]); ;
                }
                else
                {
                    oeuvreEtat[Cnt2] = "V";
                    oeuvreValeurVente[Cnt2] = prixVente;

                    Console.WriteLine("La commition pour cette vente au " + conservateurNom[Cnt2] + "Sera de " + oeuvrePrixVente[Cnt2] * comission);

                    // adicionar total de comission ---------------------------------------------------

                    //string artisteCode = oeuvreArtisteCode[Cnt2];
                    int iContArtiste = 0;
                    while ((iContArtiste < artisteCode.Count) && (oeuvreArtisteCode[Cnt2] != artisteCode[iContArtiste]))
                    {
                        iContArtiste = iContArtiste + 1;
                    }
                    string s_conservateurCode = artisteConservateurCode[iContArtiste];

                    List<string> aux_artisteCode = new List<string>();
                    for (int i = 0; i < artisteCode.Count; i++)
                    {
                        if (artisteConservateurCode[i] == s_conservateurCode)
                        {
                            aux_artisteCode.Add(artisteCode[i]);
                        }
                    }

                    double ValeurTotal = 0;
                    double ValeurTotalComission = 0;
                    for (int i = 0; i < oeuvreArtisteCode.Count; i++)
                    {
                        if (aux_artisteCode.Contains(oeuvreArtisteCode[i]) && oeuvreEtat[i] == "V")
                        {
                            ValeurTotal = ValeurTotal + oeuvrePrixVente[i];
                        }
                    }

                    ValeurTotalComission = ValeurTotal * comission;
                }
            }

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

                        Console.WriteLine("----------------------------------------------");
                        Console.WriteLine("");
                    }
                }

                Console.WriteLine("**********************************************");
                Console.WriteLine("");
            }

            AfficherMenu();
        }

        public static void LoremIpsum_Conserveteur(int qtd)
        {
            for (int i = 1; i <= qtd; i++)
            {
                conservateurCode.Add("C." + i.ToString().PadLeft(3, '0'));
                conservateurNom.Add("Conservateur " + i.ToString());
            }
        }
        public static void LoremIpsum_Artist(int qtd)
        {
            int qtdConservateur = conservateurCode.Count;
            if (qtdConservateur > 0)
            {
                int iRnd;
                for (int i = 1; i <= qtd; i++)
                {
                    artisteCode.Add("A." + i.ToString().PadLeft(3, '0'));
                    artisteNom.Add("Artiste " + i.ToString());
                    iRnd = (new Random().Next(0, qtdConservateur)) + 1;
                    artisteConservateurCode.Add("C." + iRnd.ToString().PadLeft(3, '0'));
                }
            }
        }
        public static void LoremIpsum_Oeuvres(int qtd)
        {
            int qtdArtiste = artisteCode.Count;
            if (qtdArtiste > 0)
            {
                int iRnd;
                for (int i = 1; i <= qtd; i++)
                {
                    oeuvreCode.Add("O." + i.ToString().PadLeft(3, '0'));
                    oeuvreTitre.Add("Oeuvre " + i.ToString());
                    oeuvreValeur.Add(1000 * i * (1 - (i / 100)));
                    oeuvrePrixVente.Add(0);
                    oeuvreEtat.Add("N");
                    oeuvreValeurVente.Add(0);
                    oeuvreAneeAquisition.Add(2000 + i);
                    iRnd = (new Random().Next(0, qtdArtiste)) + 1;
                    oeuvreArtisteCode.Add("A." + iRnd.ToString().PadLeft(3, '0'));
                }
            }
        }
    }
}
