﻿using System.Runtime.CompilerServices;
using System.Diagnostics;
using System;
using MySql.Data.MySqlClient;
using TEST_Projet_Livin_Paris;

namespace ProjetGraphe///Raphael_LEROY_TURMEL_Thomas_LIOTIER_Loan_LU_CHI_VANG
{
    public class Program
    {
        static void Main(string[] args)
        {

            /// utile uniquement pour l'affichage en console
            string file1 = "MetroParisUTF8 feuille 1.txt";
            string file2 = "Métro paris UTF8 feuille2 v2.txt";            
            Graphe<Station> PlanMétro = new Graphe<Station>(file1, file2);
            List<Station> ListeDeStation = new List<Station>();
            foreach (Noeud<Station> Noeud in PlanMétro.DictionnaireDeNoeuds.Values)
            {
                ListeDeStation.Add(Noeud.element);
            }
            string LibelleStart = "Porte Maillot";
            string LibelleEnd = "Saint-Fargeau";
            List<string> CheminStation = new List<string>();
            foreach(Station station in PlanMétro.PCC(LibelleStart, LibelleEnd))
            {
                CheminStation.Add(station.LibelleStation);
            }
            PlanMétro.DictionnaireDeNoeuds.TryGetValue(1, out var node);
            ///GraphViewModel<Station> Graphe = new GraphViewModel<Station>(ListeDeStation, PlanMétro.MatriceAdjacence, PlanMétro,CheminStation);

            ///ici l'affichage sous sa prmeière version en console  
            ///new Affichage();
            /// ci dessou l'affichage en verison finale (Windows forms)
            Application.Run(new FormConnexion());

        }
    }
}