-- MySQL dump 10.13  Distrib 8.0.40, for Win64 (x86_64)
--
-- Host: localhost    Database: livinparis
-- ------------------------------------------------------
-- Server version	8.0.40

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `commandes`
--

DROP TABLE IF EXISTS `commandes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `commandes` (
  `id_commande` int NOT NULL AUTO_INCREMENT,
  `id_client` int NOT NULL,
  `date_commande` timestamp NULL DEFAULT NULL,
  `total` decimal(10,2) DEFAULT NULL,
  `statut` enum('En cours','Livrée','Annulée') DEFAULT NULL,
  PRIMARY KEY (`id_commande`),
  KEY `id_client` (`id_client`),
  CONSTRAINT `commandes_ibfk_1` FOREIGN KEY (`id_client`) REFERENCES `utilisateurs` (`id_utilisateur`)
) ENGINE=InnoDB AUTO_INCREMENT=61 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `commandes`
--

LOCK TABLES `commandes` WRITE;
/*!40000 ALTER TABLE `commandes` DISABLE KEYS */;
INSERT INTO `commandes` VALUES (1,13,'2025-03-20 23:00:00',27.53,'En cours'),(2,13,'2025-03-15 23:00:00',33.29,'Livrée'),(3,48,'2025-03-19 23:00:00',50.33,'Livrée'),(4,42,'2025-03-13 23:00:00',29.11,'En cours'),(5,35,'2025-03-08 23:00:00',26.08,'Annulée'),(6,38,'2025-03-31 22:00:00',47.23,'En cours'),(7,36,'2025-03-21 23:00:00',59.93,'En cours'),(8,16,'2025-03-05 23:00:00',31.63,'En cours'),(9,9,'2025-03-30 22:00:00',55.04,'Annulée'),(10,18,'2025-03-11 23:00:00',16.98,'Livrée'),(11,9,'2025-03-09 23:00:00',18.39,'Annulée'),(12,6,'2025-03-10 23:00:00',28.87,'En cours'),(13,16,'2025-03-04 23:00:00',53.91,'En cours'),(14,48,'2025-03-19 23:00:00',46.56,'Livrée'),(15,48,'2025-03-08 23:00:00',54.21,'En cours'),(16,37,'2025-03-13 23:00:00',37.92,'Annulée'),(17,25,'2025-03-30 22:00:00',42.28,'Annulée'),(18,3,'2025-03-27 23:00:00',38.40,'Annulée'),(19,40,'2025-03-16 23:00:00',28.30,'En cours'),(20,24,'2025-03-29 23:00:00',39.66,'En cours'),(21,48,'2025-03-19 23:00:00',55.55,'Annulée'),(22,38,'2025-03-21 23:00:00',28.97,'En cours'),(23,26,'2025-03-18 23:00:00',33.65,'Annulée'),(24,9,'2025-03-10 23:00:00',35.54,'Livrée'),(25,46,'2025-03-09 23:00:00',26.13,'Annulée'),(26,20,'2025-03-21 23:00:00',55.19,'En cours'),(27,8,'2025-03-28 23:00:00',33.67,'Livrée'),(28,25,'2025-03-29 23:00:00',39.22,'Annulée'),(29,24,'2025-03-13 23:00:00',41.64,'Annulée'),(30,18,'2025-03-19 23:00:00',32.06,'En cours'),(31,13,'2025-03-20 23:00:00',27.53,'En cours'),(32,13,'2025-03-15 23:00:00',33.29,'Livrée'),(33,48,'2025-03-19 23:00:00',50.33,'Livrée'),(34,42,'2025-03-13 23:00:00',29.11,'En cours'),(35,35,'2025-03-08 23:00:00',26.08,'Annulée'),(36,38,'2025-03-31 22:00:00',47.23,'En cours'),(37,36,'2025-03-21 23:00:00',59.93,'En cours'),(38,16,'2025-03-05 23:00:00',31.63,'En cours'),(39,9,'2025-03-30 22:00:00',55.04,'Annulée'),(40,18,'2025-03-11 23:00:00',16.98,'Livrée'),(41,9,'2025-03-09 23:00:00',18.39,'Annulée'),(42,6,'2025-03-10 23:00:00',28.87,'En cours'),(43,16,'2025-03-04 23:00:00',53.91,'En cours'),(44,48,'2025-03-19 23:00:00',46.56,'Livrée'),(45,48,'2025-03-08 23:00:00',54.21,'En cours'),(46,37,'2025-03-13 23:00:00',37.92,'Annulée'),(47,25,'2025-03-30 22:00:00',42.28,'Annulée'),(48,3,'2025-03-27 23:00:00',38.40,'Annulée'),(49,40,'2025-03-16 23:00:00',28.30,'En cours'),(50,24,'2025-03-29 23:00:00',39.66,'En cours'),(51,48,'2025-03-19 23:00:00',55.55,'Annulée'),(52,38,'2025-03-21 23:00:00',28.97,'En cours'),(53,26,'2025-03-18 23:00:00',33.65,'Annulée'),(54,9,'2025-03-10 23:00:00',35.54,'Livrée'),(55,46,'2025-03-09 23:00:00',26.13,'Annulée'),(56,20,'2025-03-21 23:00:00',55.19,'En cours'),(57,8,'2025-03-28 23:00:00',33.67,'Livrée'),(58,25,'2025-03-29 23:00:00',39.22,'Annulée'),(59,24,'2025-03-13 23:00:00',41.64,'Annulée'),(60,18,'2025-03-19 23:00:00',32.06,'En cours');
/*!40000 ALTER TABLE `commandes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `lignes_commande`
--

DROP TABLE IF EXISTS `lignes_commande`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `lignes_commande` (
  `id_ligne` int NOT NULL AUTO_INCREMENT,
  `id_commande` int NOT NULL,
  `id_plat` int NOT NULL,
  `quantite` int NOT NULL,
  `prix_unitaire` decimal(10,2) NOT NULL,
  `date_livraison` date NOT NULL,
  `adresse_livraison` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id_ligne`),
  KEY `id_commande` (`id_commande`),
  KEY `id_plat` (`id_plat`),
  CONSTRAINT `lignes_commande_ibfk_1` FOREIGN KEY (`id_commande`) REFERENCES `commandes` (`id_commande`),
  CONSTRAINT `lignes_commande_ibfk_2` FOREIGN KEY (`id_plat`) REFERENCES `plats` (`id_plat`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lignes_commande`
--

LOCK TABLES `lignes_commande` WRITE;
/*!40000 ALTER TABLE `lignes_commande` DISABLE KEYS */;
/*!40000 ALTER TABLE `lignes_commande` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `livraisons`
--

DROP TABLE IF EXISTS `livraisons`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `livraisons` (
  `id_livraison` int NOT NULL AUTO_INCREMENT,
  `id_commande` int NOT NULL,
  `id_cuisinier` int NOT NULL,
  `adresse_depart` varchar(255) NOT NULL,
  `adresse_arrivee` varchar(255) NOT NULL,
  `date_livraison` date NOT NULL,
  `distance_km` decimal(5,2) DEFAULT NULL,
  `statut` enum('En attente','En cours','Livrée') DEFAULT NULL,
  PRIMARY KEY (`id_livraison`),
  KEY `id_commande` (`id_commande`),
  KEY `id_cuisinier` (`id_cuisinier`),
  CONSTRAINT `livraisons_ibfk_1` FOREIGN KEY (`id_commande`) REFERENCES `commandes` (`id_commande`),
  CONSTRAINT `livraisons_ibfk_2` FOREIGN KEY (`id_cuisinier`) REFERENCES `utilisateurs` (`id_utilisateur`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `livraisons`
--

LOCK TABLES `livraisons` WRITE;
/*!40000 ALTER TABLE `livraisons` DISABLE KEYS */;
/*!40000 ALTER TABLE `livraisons` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `plats`
--

DROP TABLE IF EXISTS `plats`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `plats` (
  `id_plat` int NOT NULL AUTO_INCREMENT,
  `id_cuisinier` int NOT NULL,
  `nom_plat` varchar(150) NOT NULL,
  `type_plat` enum('Entrée','Plat','Dessert') NOT NULL,
  `nombre_personnes` int NOT NULL,
  `date_fabrication` date NOT NULL,
  `date_peremption` date NOT NULL,
  `prix_par_personne` decimal(6,2) NOT NULL,
  `nationalite` varchar(100) DEFAULT NULL,
  `regime_alimentaire` varchar(255) DEFAULT NULL,
  `ingredients` varchar(255) DEFAULT NULL,
  `photo` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id_plat`),
  KEY `id_cuisinier` (`id_cuisinier`),
  CONSTRAINT `plats_ibfk_1` FOREIGN KEY (`id_cuisinier`) REFERENCES `utilisateurs` (`id_utilisateur`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `plats`
--

LOCK TABLES `plats` WRITE;
/*!40000 ALTER TABLE `plats` DISABLE KEYS */;
/*!40000 ALTER TABLE `plats` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `transactions`
--

DROP TABLE IF EXISTS `transactions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `transactions` (
  `id_transaction` int NOT NULL AUTO_INCREMENT,
  `id_commande` int NOT NULL,
  `montant` decimal(10,2) NOT NULL,
  `mode_paiement` enum('Carte bancaire','PayPal','Espèces') NOT NULL,
  `date_transaction` timestamp NULL DEFAULT NULL,
  `statut` enum('Effectuée','Annulée') DEFAULT NULL,
  PRIMARY KEY (`id_transaction`),
  KEY `id_commande` (`id_commande`),
  CONSTRAINT `transactions_ibfk_1` FOREIGN KEY (`id_commande`) REFERENCES `commandes` (`id_commande`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transactions`
--

LOCK TABLES `transactions` WRITE;
/*!40000 ALTER TABLE `transactions` DISABLE KEYS */;
INSERT INTO `transactions` VALUES (1,1,27.53,'Carte bancaire','2025-03-20 23:00:00','Effectuée'),(2,2,33.29,'PayPal','2025-03-15 23:00:00','Annulée'),(3,3,50.33,'Espèces','2025-03-19 23:00:00','Effectuée'),(4,4,29.11,'PayPal','2025-03-13 23:00:00','Effectuée'),(5,5,26.08,'PayPal','2025-03-08 23:00:00','Effectuée'),(6,6,47.23,'Carte bancaire','2025-03-31 22:00:00','Annulée'),(7,7,59.93,'PayPal','2025-03-21 23:00:00','Effectuée'),(8,8,31.63,'Carte bancaire','2025-03-05 23:00:00','Annulée'),(9,9,55.04,'Carte bancaire','2025-03-30 22:00:00','Annulée'),(10,10,16.98,'Espèces','2025-03-11 23:00:00','Effectuée'),(11,11,18.39,'PayPal','2025-03-09 23:00:00','Effectuée'),(12,12,28.87,'Espèces','2025-03-10 23:00:00','Effectuée'),(13,13,53.91,'PayPal','2025-03-04 23:00:00','Effectuée'),(14,14,46.56,'PayPal','2025-03-19 23:00:00','Annulée'),(15,15,54.21,'PayPal','2025-03-08 23:00:00','Annulée'),(16,16,37.92,'Espèces','2025-03-13 23:00:00','Annulée'),(17,17,42.28,'Espèces','2025-03-30 22:00:00','Annulée'),(18,18,38.40,'PayPal','2025-03-27 23:00:00','Annulée'),(19,19,28.30,'Espèces','2025-03-16 23:00:00','Annulée'),(20,20,39.66,'Espèces','2025-03-29 23:00:00','Annulée'),(21,21,55.55,'Carte bancaire','2025-03-19 23:00:00','Effectuée'),(22,22,28.97,'Espèces','2025-03-21 23:00:00','Effectuée'),(23,23,33.65,'Carte bancaire','2025-03-18 23:00:00','Effectuée'),(24,24,35.54,'PayPal','2025-03-10 23:00:00','Annulée'),(25,25,26.13,'PayPal','2025-03-09 23:00:00','Annulée'),(26,26,55.19,'Espèces','2025-03-21 23:00:00','Effectuée'),(27,27,33.67,'PayPal','2025-03-28 23:00:00','Annulée'),(28,28,39.22,'Carte bancaire','2025-03-29 23:00:00','Effectuée'),(29,29,41.64,'Carte bancaire','2025-03-13 23:00:00','Effectuée'),(30,30,32.06,'PayPal','2025-03-19 23:00:00','Effectuée');
/*!40000 ALTER TABLE `transactions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `utilisateurs`
--

DROP TABLE IF EXISTS `utilisateurs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `utilisateurs` (
  `id_utilisateur` int NOT NULL AUTO_INCREMENT,
  `nom` varchar(55) NOT NULL,
  `prenom` varchar(55) NOT NULL,
  `adresse` varchar(100) NOT NULL,
  `metro_proche` varchar(100) DEFAULT NULL,
  `telephone` varchar(20) DEFAULT NULL,
  `email` varchar(150) NOT NULL,
  `mdp` varchar(255) NOT NULL,
  `est_client` tinyint(1) DEFAULT '0',
  `est_cuisinier` tinyint(1) DEFAULT '0',
  `date_insciption` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id_utilisateur`),
  UNIQUE KEY `email` (`email`),
  UNIQUE KEY `telephone` (`telephone`),
  CONSTRAINT `utilisateurs_chk_1` CHECK ((length(`mdp`) > 6))
) ENGINE=InnoDB AUTO_INCREMENT=151 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `utilisateurs`
--

LOCK TABLES `utilisateurs` WRITE;
/*!40000 ALTER TABLE `utilisateurs` DISABLE KEYS */;
INSERT INTO `utilisateurs` VALUES (1,'Guillou','Marine','905, rue de Nicolas, 75013 Paris','Lecoq','+33805290965','duboiseugene@bouygtel.fr','T$8FXcq+zN',0,1,'2025-04-04 13:24:58'),(2,'Lévêque','Thierry','93, chemin Christelle Pereira, 75005 Paris','Navarro','0451401051','dianeroger@remy.fr','16UgrLJ!$f',0,1,'2025-04-04 13:24:58'),(3,'Poulain','Victor','51, avenue de Evrard, 75005 Paris','Riou','0496969155','sylviemaillet@club-internet.fr',')(91CPIv)1',1,0,'2025-04-04 13:24:58'),(4,'Joly','Julien','19, rue Claire Dufour, 75019 Paris','Leclercq','0188767677','morenoantoine@klein.net','(giF((jy4m',0,1,'2025-04-04 13:24:58'),(5,'Lamy','François','14, chemin Adèle Fernandez, 75019 Paris','Navarro','+33(0)803395962','sylvieleclerc@colas.org',')98Fksm_hI',0,1,'2025-04-04 13:24:58'),(6,'Rodrigues','Michèle','86, boulevard Lefort, 75012 Paris','Royer','0267116845','lmillet@voila.fr','YdXkHxno+1',1,1,'2025-04-04 13:24:58'),(7,'Le Goff','Maggie','rue Toussaint, 75017 Paris','Jacques','+33(0)112770632','robertmorin@live.com','s0Lvd5ae%1',0,1,'2025-04-04 13:24:58'),(8,'Bazin','Capucine','chemin Mathieu, 75003 Paris','Briand','+33171361115','guillaume62@laposte.net','X@83huaK4S',1,1,'2025-04-04 13:24:58'),(9,'Marty','Aurélie','53, rue de Menard, 75005 Paris','Lenoir','0204389836','dupuisclemence@ifrance.com','@3yzv)puFP',1,0,'2025-04-04 13:24:58'),(10,'Mercier','Alexandre','10, boulevard Sébastien Techer, 75020 Paris','Mendès','0266188924','edouard83@regnier.com','%&6LXXgh(e',1,0,'2025-04-04 13:24:58'),(11,'Barbe','Diane','62, chemin Peron, 75013 Paris','Lemaire','+33(0)156481491','xgros@gmail.com','*j9b(Flp!$',0,1,'2025-04-04 13:24:58'),(12,'Lenoir','Suzanne','63, avenue Fouquet, 75017 Paris','Julien','0119518023','dmuller@becker.org','12RoYMVO^2',0,1,'2025-04-04 13:24:58'),(13,'Lejeune','André','650, avenue Gallet, 75018 Paris','Petitjean','0313836702','bertrandnicolas@wanadoo.fr','&*)m&5Ox57',1,1,'2025-04-04 13:24:58'),(14,'Rey','Denis','29, rue Gaillard, 75018 Paris','Lebreton','0556185374','dominique11@free.fr','_34_exWwAm',0,1,'2025-04-04 13:24:58'),(15,'Berthelot','Océane','81, rue Rivière, 75011 Paris','Richard','+33(0)332365199','simonchristophe@sfr.fr','&o_7vZeKfO',1,0,'2025-04-04 13:24:58'),(16,'Lemoine','Robert','12, boulevard de Chauvet, 75014 Paris','Moulin','0276870146','pbourgeois@lombard.fr','jDTB8PWr+5',1,0,'2025-04-04 13:24:58'),(17,'Rey','Hugues','rue Da Costa, 75001 Paris','Joubert','+33(0)339652239','jeanne05@laposte.net',')0Z%WpNCX3',0,1,'2025-04-04 13:24:58'),(18,'Fischer','Guy','chemin de Legrand, 75017 Paris','Besson','0191545226','jerome89@live.com','Am)9wFGzx$',1,1,'2025-04-04 13:24:58'),(19,'Mahe','Guy','4, chemin Jacques Bousquet, 75010 Paris','Blanc','0570433154','rousseaualice@peron.fr','#6nkPm4Ll#',1,1,'2025-04-04 13:24:58'),(20,'Legrand','Zacharie','22, rue de Maillot, 75012 Paris','Valentin','0606296201','laurentlejeune@bouygtel.fr','_4Jh%!&mYN',1,1,'2025-04-04 13:24:58'),(21,'Diaz','Stéphane','rue Thibault Chauvin, 75020 Paris','Georges','0804186256','carolinebertrand@bouygtel.fr','*T+d*bIh74',0,1,'2025-04-04 13:24:58'),(22,'Baudry','Noël','71, rue de Gaudin, 75016 Paris','Masse','+33117223320','normandbernadette@sfr.fr','Bil&TSTQ_2',1,1,'2025-04-04 13:24:58'),(23,'Legros','Henri','299, boulevard Valette, 75012 Paris','Roussel','0285646799','giraudrobert@ifrance.com','d#r9Thuv@m',0,1,'2025-04-04 13:24:58'),(24,'Lucas','Théophile','55, avenue de Texier, 75008 Paris','Imbert','+33(0)537367850','langloismathilde@dufour.com','6L3e8GPb)#',1,1,'2025-04-04 13:24:58'),(25,'Reynaud','Jacqueline','35, rue Roland Leroy, 75019 Paris','Collin','+33(0)329333346','reynaudgilles@brunel.org','ZJFDWwcm)4',1,1,'2025-04-04 13:24:58'),(26,'Léger','Marianne','rue Yves Baron, 75016 Paris','Riou','0444432830','maggie20@tiscali.fr','G#4UNm4R%t',1,1,'2025-04-04 13:24:58'),(27,'Descamps','Frédérique','81, chemin Pages, 75005 Paris','Vaillant','+33351353465','isabelle47@yahoo.fr','UXM0(UsIq*',0,1,'2025-04-04 13:24:58'),(28,'Albert','Guy','81, rue Thomas Couturier, 75018 Paris','Boyer','+33(0)174329271','bcouturier@gilbert.fr','2&0BBrcY6d',1,0,'2025-04-04 13:24:58'),(29,'Jacob','Constance','22, chemin Charpentier, 75017 Paris','Pineau','0562575326','mauricepetitjean@lecomte.com','k5ZjYVWu@$',0,1,'2025-04-04 13:24:58'),(30,'Fleury','Christelle','13, avenue Margaud Roussel, 75007 Paris','Dupré','0199261891','gautiercolette@sfr.fr',')3EI+StiNY',1,0,'2025-04-04 13:24:58'),(31,'Gérard','Éric','2, rue Cécile Collet, 75013 Paris','Aubry','0501204556','thierrybenjamin@dos.com','^5OD(HtndN',0,1,'2025-04-04 13:24:58'),(32,'Leroux','François','879, boulevard Gillet, 75015 Paris','Merle','0690277167','bertinmarcelle@richard.net','_XQfNbZ+q5',0,1,'2025-04-04 13:24:58'),(33,'Lelièvre','Dominique','81, rue Vincent Lopes, 75004 Paris','Girard','+33686631779','didiercaroline@dbmail.com','@H#7nXxurT',1,1,'2025-04-04 13:24:58'),(34,'De Sousa','Vincent','697, avenue de Noël, 75003 Paris','Pereira','+33605548851','clemencejoly@gautier.org','uHGjf*Id)3',0,1,'2025-04-04 13:24:58'),(35,'Didier','Aimé','9, boulevard Christine Grégoire, 75001 Paris','Valette','+33392216995','sraynaud@orange.fr','L)I6Kjdpe%',1,1,'2025-04-04 13:24:58'),(36,'Maillet','Gilles','98, chemin de Lacombe, 75001 Paris','Ferreira','0687996846','laurentalex@vincent.net','6od2J#v*%g',1,1,'2025-04-04 13:24:58'),(37,'Jacquot','Margot','avenue Arnaude Pottier, 75008 Paris','Bouvier','+33(0)304397359','theodorepons@normand.com','+87+D!Mm#8',1,1,'2025-04-04 13:24:58'),(38,'Baudry','Emmanuelle','6, rue de Gonzalez, 75011 Paris','Dijoux','+33(0)482688615','margaudremy@alves.org','z$y!9QpXXw',1,1,'2025-04-04 13:24:58'),(39,'Gimenez','Monique','9, boulevard Suzanne Grégoire, 75009 Paris','Cohen','0800435811','toussaintchristophe@leconte.fr','r3Rmwc@f@^',0,1,'2025-04-04 13:24:58'),(40,'Bruneau','Valentine','76, avenue Aurore Gomes, 75007 Paris','Durand','0118091901','charpentiersimone@club-internet.fr',')G1#Jyhko9',1,0,'2025-04-04 13:24:58'),(41,'Lenoir','Frédérique','1, boulevard Godard, 75008 Paris','Carlier','+33(0)543536822','laetitiafleury@noel.com','^(67UUEr59',0,1,'2025-04-04 13:24:58'),(42,'Lebreton','Vincent','39, boulevard de Marchal, 75014 Paris','Gomes','0320533645','christiane77@becker.org','8&8nr2fY*D',1,1,'2025-04-04 13:24:58'),(43,'Lecoq','Jeanne','9, boulevard Élodie Georges, 75004 Paris','Guibert','+33156394278','gmarchal@dupre.com','(waOgfE42%',0,1,'2025-04-04 13:24:58'),(44,'Alves','Amélie','10, chemin de Henry, 75012 Paris','Fischer','0149892665','alexandria38@benard.fr','P*07ZTaEf(',0,1,'2025-04-04 13:24:58'),(45,'Leduc','Margot','33, avenue de Simon, 75014 Paris','Berger','+33(0)229922809','brunraymond@blondel.com','Lz+04Ckg1a',0,1,'2025-04-04 13:24:58'),(46,'Godard','Jeanne','avenue Collin, 75002 Paris','Payet','+33(0)603886291','mbonneau@rossi.com','sR!vc7Ved@',1,1,'2025-04-04 13:24:58'),(47,'Traore','Patricia','316, avenue Pauline Rey, 75013 Paris','Perez','0298643009','malletmarcelle@lagarde.fr','V72TXNHu@T',0,1,'2025-04-04 13:24:58'),(48,'Fleury','Thibault','36, rue de Letellier, 75004 Paris','Rolland','0421386589','ameliebousquet@robin.fr',')F6CuHacx%',1,1,'2025-04-04 13:24:58'),(49,'Descamps','Suzanne','13, boulevard de Blondel, 75007 Paris','Rocher','+33692053021','qbenard@ifrance.com','@eu9fTGqm&',0,1,'2025-04-04 13:24:58'),(50,'Thomas','Raymond','28, rue de Gaudin, 75005 Paris','Cousin','0518489476','oliviemaillot@tele2.fr','N_G7SdaIER',0,1,'2025-04-04 13:24:58');
/*!40000 ALTER TABLE `utilisateurs` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-04-04 16:40:58
