using System;
using MySql.Data.MySqlClient;

public class Affichage
{
    public Affichage()
    {
        Console.WriteLine("== Menu principal Liv'in Paris ==");
        Console.WriteLine("Renseigner le mot de passe MySQL :");
        string mdp = Console.ReadLine();
        Clients utilisateurService = new Clients(mdp);
        Cuisinier cuisinierService = new Cuisinier(mdp);

        bool continuer = true;

        while (continuer)
        {
            Console.WriteLine("\nMenu principal :");
            Console.WriteLine("1. Panneau Clients");
            Console.WriteLine("2. Panneau Cuisiniers");
            Console.WriteLine("3. Quitter");
            Console.Write("Choix : ");
            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    // Sous-menu CLIENT
                    bool clientLoop = true;
                    while (clientLoop)
                    {
                        Console.WriteLine("\n== Panneau de Configuration Clients ==");
                        Console.WriteLine("1. Ajouter Client");
                        Console.WriteLine("2. Supprimer Client");
                        Console.WriteLine("3. Modifier Client");
                        Console.WriteLine("4. Lister Clients par ordre alphabétique");
                        Console.WriteLine("5. Lister Clients par rues");
                        Console.WriteLine("6. Lister Clients par montant d'achats cumulés");
                        Console.WriteLine("7. Retour au menu principal");
                        Console.Write("Choix : ");
                        string sousChoix = Console.ReadLine();

                        switch (sousChoix)
                        {
                            case "1":
                                utilisateurService.AjouterClient(); break;
                            case "2":
                                utilisateurService.SupprimerClient(); break;
                            case "3":
                                utilisateurService.ModifierClient(); break;
                            case "4":
                                utilisateurService.ListerClientsParNom(); break;
                            case "5":
                                utilisateurService.ListerClientsParRue(); break;
                            case "6":
                                utilisateurService.ListerClientsParMontant(); break;
                            case "7":
                                clientLoop = false; break;
                            default:
                                Console.WriteLine("Choix invalide dans le panneau client."); break;
                        }
                    }
                    break;

                case "2":
                    bool cuisinierLoop = true;
                    while (cuisinierLoop)
                    {
                        Console.WriteLine("\n== Panneau de Configuration Cuisiniers ==");
                        Console.WriteLine("1. Ajouter Cuisinier");
                        Console.WriteLine("2. Supprimer Cuisinier");
                        Console.WriteLine("3. Modifier Cuisinier");
                        Console.WriteLine("4. Lister Cuisinier");
                        Console.WriteLine("5. Lister les clients servis");
                        Console.WriteLine("6. Lister les plats réalisés par fréquence");
                        Console.WriteLine("7. Afficher le plat du jour");
                        Console.WriteLine("8. Retour au menu principal");
                        Console.Write("Choix : ");
                        string choixCuisinier = Console.ReadLine();

                        switch (choixCuisinier)
                        {
                            case "1":
                                cuisinierService.AjouterCuisinierDepuisConsole();
                                break;

                            case "2":
                                Console.Write("ID du cuisinier à supprimer : ");
                                int idSupp = int.Parse(Console.ReadLine());
                                cuisinierService.SupprimerCuisinier(idSupp);
                                break;

                            case "3":
                                Console.Write("ID du cuisinier à modifier : ");
                                int idModif = int.Parse(Console.ReadLine());
                                Console.Write("Nouveau nom : ");
                                string newNom = Console.ReadLine();
                                cuisinierService.ModifierNomCuisinier(idModif, newNom);
                                break;

                            case "5":
                                Console.Write("ID du cuisinier : ");
                                int idServi = int.Parse(Console.ReadLine());
                                Console.Write("Date minimale (yyyy-mm-jj) ou vide : ");
                                string inputDate = Console.ReadLine();
                                if (DateTime.TryParse(inputDate, out DateTime dateMin))
                                    cuisinierService.ListerClientsServis(idServi, dateMin);
                                else
                                    cuisinierService.ListerClientsServis(idServi);
                                break;

                            case "4":
                                cuisinierService.ListerCuisiniers();
                                break;

                            case "6":
                                Console.Write("ID du cuisinier : ");
                                int idFreq = int.Parse(Console.ReadLine());
                                cuisinierService.ListerPlatsParFrequence(idFreq);
                                break;

                            case "7":
                                Console.Write("ID du cuisinier : ");
                                int idJour = int.Parse(Console.ReadLine());
                                cuisinierService.AfficherPlatDuJour(idJour);
                                break;

                            case "8":
                                cuisinierLoop = false;
                                break;

                            default:
                                Console.WriteLine("Choix invalide.");
                                break;
                        }
                    }
                    break;


                case "3":
                    continuer = false;
                    Console.WriteLine("À bientôt !");
                    break;

                default:
                    Console.WriteLine("Choix invalide.");
                    break;
            }
        }
    }

}
