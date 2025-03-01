using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetGraphe;
using System;
using System.Collections.Generic;

namespace ProjetGraphe.Tests
{
    [TestClass]
    public class NoeudTests
    {
        [TestMethod]
        public void Noeud_Creation_SansRelations()
        {
            Noeud noeud = new Noeud(1);
            Assert.AreEqual(1, noeud.Noeud_Id);
            Assert.AreEqual(0, noeud.Relations.Count);
        }

        [TestMethod]
        public void Noeud_AjoutRelations()
        {
            Noeud noeud1 = new Noeud(1);
            Noeud noeud2 = new Noeud(2);
            noeud1.Relations.Add(noeud2);
            Assert.AreEqual(1, noeud1.Relations.Count);
            Assert.AreEqual(2, noeud1.Relations[0].Noeud_Id);
        }
    }

    [TestClass]
    public class LienTests
    {
        [TestMethod]
        public void Lien_Creation()
        {
            Noeud noeudA = new Noeud(1);
            Noeud noeudB = new Noeud(2);
            Lien lien = new Lien(noeudA, noeudB);
            Assert.IsNotNull(lien);
        }
    }

    [TestClass]
    public class GrapheTests
    {
        [TestMethod]
        public void Graphe_Creation()
        {
            Graphe graphe = new Graphe("TestGraphe", "soc-karate.mtx");
            Assert.IsNotNull(graphe);
        }

        [TestMethod]
        public void Graphe_AjoutRelationMatrix()
        {
            Graphe graphe = new Graphe("TestGraphe", "soc-karate.mtx");
            graphe.AddRelationMatrix(1, 2);
            Assert.AreEqual(1, graphe.Matrix[0, 1]);
            Assert.AreEqual(1, graphe.Matrix[1, 0]);
        }

        [TestMethod]
        public void Graphe_ParcoursEnLargeur()
        {
            Graphe graphe = new Graphe("TestGraphe", "soc-karate.mtx");
            Noeud startNode = graphe.GetGraphe[0];

            using (var sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);
                graphe.ParcoursEnLargeur(startNode);
                string result = sw.ToString();
                Assert.IsTrue(result.Contains("Parcours en largeur d'abord du graphe"));
            }
        }

        [TestMethod]
        public void Graphe_ParcoursEnProfondeur()
        {
            Graphe graphe = new Graphe("TestGraphe", "soc-karate.mtx");
            Noeud startNode = graphe.GetGraphe[0];

            using (var sw = new System.IO.StringWriter())
            {
                Console.SetOut(sw);
                graphe.ParcoursEnProfondeur(startNode);
                string result = sw.ToString();
                Assert.IsTrue(result.Contains("Parcours en profondeur d'abord du graphe"));
            }
        }
    }
}