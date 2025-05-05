-- MySQL dump 10.13  Distrib 8.0.41, for Win64 (x86_64)
--
-- Host: localhost    Database: livinparis
-- ------------------------------------------------------
-- Server version	9.2.0

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
  `metro` varchar(55) NOT NULL,
  `statut` enum('En cours','Livrée','Annulée') DEFAULT NULL,
  PRIMARY KEY (`id_commande`),
  KEY `id_client` (`id_client`),
  CONSTRAINT `commandes_ibfk_1` FOREIGN KEY (`id_client`) REFERENCES `utilisateurs` (`id_utilisateur`)
) ENGINE=InnoDB AUTO_INCREMENT=36 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `commandes`
--

LOCK TABLES `commandes` WRITE;
/*!40000 ALTER TABLE `commandes` DISABLE KEYS */;
INSERT INTO `commandes` VALUES (1,13,'2025-03-20 23:00:00',27.53,'Nation','En cours'),(2,13,'2025-03-15 23:00:00',33.29,'République','Livrée'),(3,48,'2025-03-19 23:00:00',50.33,'Bastille','Livrée'),(4,42,'2025-03-13 23:00:00',29.11,'Châtelet','En cours'),(5,35,'2025-03-08 23:00:00',26.08,'Montparnasse','Annulée'),(6,38,'2025-03-31 22:00:00',47.23,'Gare de Lyon','En cours'),(7,36,'2025-03-21 23:00:00',59.93,'Odéon','En cours'),(8,16,'2025-03-05 23:00:00',31.63,'Pyrénées','En cours'),(9,9,'2025-03-30 22:00:00',55.04,'Belleville','Annulée'),(10,18,'2025-03-11 23:00:00',16.98,'Anvers','Livrée'),(11,9,'2025-03-09 23:00:00',18.39,'Voltaire','Annulée'),(12,6,'2025-03-10 23:00:00',28.87,'Saint-Lazare','En cours'),(13,16,'2025-03-04 23:00:00',53.91,'Denfert-Rochereau','En cours'),(14,48,'2025-03-19 23:00:00',46.56,'Pigalle','Livrée'),(15,48,'2025-03-08 23:00:00',54.21,'Alésia','En cours'),(16,37,'2025-03-13 23:00:00',37.92,'Cambronne','Annulée'),(17,25,'2025-03-30 22:00:00',42.28,'Porte Maillot','Annulée'),(18,3,'2025-03-27 23:00:00',38.40,'Laumière','Annulée'),(19,40,'2025-03-16 23:00:00',28.30,'Concorde','En cours'),(20,24,'2025-03-29 23:00:00',39.66,'Tolbiac','En cours'),(21,48,'2025-03-19 23:00:00',55.55,'Nation','Annulée'),(22,38,'2025-03-21 23:00:00',28.97,'Ranelagh','En cours'),(23,26,'2025-03-18 23:00:00',33.65,'Charonne','Annulée'),(24,9,'2025-03-10 23:00:00',35.54,'Simplon','Livrée'),(25,46,'2025-03-09 23:00:00',26.13,'Porte de Clignancourt','Annulée'),(26,20,'2025-03-21 23:00:00',55.19,'Strasbourg - Saint-Denis','En cours'),(27,8,'2025-03-28 23:00:00',33.67,'Quai de la Rapée','Livrée'),(28,25,'2025-03-29 23:00:00',39.22,'Château Rouge','Annulée'),(29,24,'2025-03-13 23:00:00',41.64,'Corvisart','Annulée'),(30,18,'2025-03-19 23:00:00',32.06,'Richelieu-Drouot','En cours'),(31,52,'2025-05-05 18:41:23',19.98,'Nation','En cours'),(32,52,'2025-05-05 18:43:04',9.99,'Nation','En cours'),(33,52,'2025-05-05 18:45:21',9.99,'Nation','En cours'),(34,52,'2025-05-05 18:46:20',9.99,'Metro','En cours'),(35,52,'2025-05-05 18:46:30',9.99,'Nation','En cours');
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
) ENGINE=InnoDB AUTO_INCREMENT=60 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `lignes_commande`
--

LOCK TABLES `lignes_commande` WRITE;
/*!40000 ALTER TABLE `lignes_commande` DISABLE KEYS */;
INSERT INTO `lignes_commande` VALUES (1,1,8,3,5.98,'2025-03-22','67, rue Henriette Royer, 37333 Leclerc'),(2,2,7,1,6.65,'2025-03-17','252, rue Labbé, 90807 Legendre'),(3,3,9,3,12.18,'2025-03-21','37, chemin de Chauvin, 92086 GimenezVille'),(4,3,4,2,7.18,'2025-03-21','27, boulevard de Jacques, 00369 Sainte Agnès-la-Forêt'),(5,4,8,3,14.19,'2025-03-15','67, rue Colette Lamy, 65564 Arnaud-les-Bains'),(6,4,1,3,5.80,'2025-03-15','chemin de Huet, 63227 Saint Astrid'),(7,4,2,3,5.68,'2025-03-15','885, chemin Gabrielle Duhamel, 61203 Ollivier'),(8,5,10,1,9.19,'2025-03-11','64, boulevard Frédérique Boucher, 06159 Verdier'),(9,6,7,1,11.72,'2025-04-03','95, avenue Édouard Weber, 72256 Masse-sur-Lebon'),(10,6,8,2,14.29,'2025-04-02','chemin Dumas, 54496 Hebert'),(11,7,9,1,10.06,'2025-03-23','12, rue Peltier, 13261 Saint ChristelleVille'),(12,8,9,3,8.03,'2025-03-07','2, boulevard Honoré Clément, 43347 Payet'),(13,8,9,2,14.32,'2025-03-07','chemin Germain, 78487 Rocher'),(14,9,3,2,7.82,'2025-04-01','779, boulevard de Ruiz, 78317 Poulain'),(15,9,6,1,11.87,'2025-04-02','14, boulevard Thierry, 54780 Faivredan'),(16,9,9,2,7.51,'2025-04-01','chemin Jeannine Grondin, 85368 Delaunay-sur-Mer'),(17,10,5,1,12.41,'2025-03-14','24, rue Diane Salmon, 48463 Saint Grégoire-la-Forêt'),(18,11,9,1,13.35,'2025-03-11','84, chemin Moreau, 08021 Royer'),(19,12,4,3,7.50,'2025-03-12','4, rue Garcia, 35647 Barthelemy'),(20,12,6,3,13.84,'2025-03-13','3, chemin Diallo, 18723 Weber'),(21,13,1,1,12.37,'2025-03-07','86, rue Philippe, 18376 Breton'),(22,13,7,3,13.64,'2025-03-06','9, rue de Fleury, 43503 Saint Lucenec'),(23,14,8,1,7.00,'2025-03-22','29, rue Alain Dupont, 92513 Didier'),(24,15,4,2,8.28,'2025-03-10','1, rue Martine Regnier, 27358 Navarro'),(25,16,6,1,6.15,'2025-03-16','35, rue Claire Munoz, 84873 Lemoine-sur-Devaux'),(26,16,3,3,14.63,'2025-03-16','94, rue Laporte, 74485 Martinnec'),(27,16,1,1,10.97,'2025-03-16','chemin de Diallo, 51863 Normanddan'),(28,17,7,3,6.90,'2025-04-01','75, chemin de Masson, 81022 Saint Franck'),(29,18,4,2,9.31,'2025-03-30','boulevard Clerc, 78994 Sainte Matthieu'),(30,18,10,2,11.63,'2025-03-29','avenue Chevalier, 05865 Sainte Éléonore'),(31,18,5,3,8.09,'2025-03-30','5, rue Paul, 13863 Laine'),(32,19,7,3,14.40,'2025-03-18','661, avenue de Boutin, 12286 Marques-les-Bains'),(33,20,5,1,9.30,'2025-04-01','68, avenue Paulette Couturier, 59398 Mallet'),(34,20,8,2,9.42,'2025-03-31','77, rue Jacquet, 82404 Benoit'),(35,21,2,2,10.15,'2025-03-22','98, boulevard de Masse, 10752 Aubry'),(36,22,1,1,7.45,'2025-03-24','24, avenue de Colas, 15727 Gauthier-sur-Valentin'),(37,23,4,3,11.96,'2025-03-21','161, chemin Thérèse Gay, 13906 Sainte Édith'),(38,23,7,1,6.48,'2025-03-20','692, rue de Brunet, 67998 Saint Aurore-la-Forêt'),(39,23,2,2,7.19,'2025-03-21','25, boulevard Noémi Girard, 41686 Ledoux'),(40,24,9,3,10.95,'2025-03-13','77, boulevard de Pierre, 31465 Blanc-sur-Marie'),(41,24,10,3,13.92,'2025-03-13','45, chemin Jeannine Bègue, 42597 Rodrigues-sur-Besnard'),(42,24,9,2,13.97,'2025-03-13','35, rue de Marie, 39240 Lemonnier'),(43,25,9,2,11.27,'2025-03-12','60, boulevard Lecomte, 88487 Chauveau-sur-Blanchard'),(44,25,8,1,12.14,'2025-03-11','580, rue Jacquet, 94070 Sainte Margaud-la-Forêt'),(45,26,3,1,8.83,'2025-03-23','avenue Nicolas Gillet, 57981 Philippe'),(46,27,8,2,5.62,'2025-03-31','1, boulevard Schneider, 76205 Monnier'),(47,27,7,3,14.46,'2025-03-30','540, rue Frédérique Guyot, 25621 Dijoux-sur-Mer'),(48,27,10,2,9.77,'2025-03-31','526, chemin de Pons, 32983 Ruiz'),(49,28,10,1,9.88,'2025-04-01','39, rue Frédérique Rossi, 25205 Bouchet-la-Forêt'),(50,28,7,2,5.29,'2025-04-01','42, rue Gonzalez, 99499 Grondin-sur-Godard'),(51,28,7,3,6.65,'2025-04-01','6, avenue Lucas, 52677 Goncalves'),(52,29,2,3,9.29,'2025-03-16','rue Richard Pasquier, 33127 Camus-sur-Lagarde'),(53,30,6,2,12.61,'2025-03-22','16, avenue de Fouquet, 69998 ClercVille'),(54,30,5,2,7.52,'2025-03-21','40, boulevard de Delaunay, 86803 Besnard'),(55,31,11,2,9.99,'2025-05-05','Adresse (Métro : Nation)'),(56,32,11,1,9.99,'2025-05-05','Adresse (Métro : Nation)'),(57,33,11,1,9.99,'2025-05-05','Adresse (Métro : Nation)'),(58,34,11,1,9.99,'2025-05-05','Adresse (Métro : Metro)'),(59,35,11,1,9.99,'2025-05-05','Adresse (Métro : Nation)');
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
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `plats`
--

LOCK TABLES `plats` WRITE;
/*!40000 ALTER TABLE `plats` DISABLE KEYS */;
INSERT INTO `plats` VALUES (1,2,'Boeuf Bourguignon','Plat',5,'2025-04-01','2025-04-04',12.48,'Française','Sans gluten','Boeuf, vin rouge, carottes','boeuf.jpg'),(2,3,'Ratatouille','Plat',3,'2025-04-01','2025-04-04',8.67,'Française','Végétarien','Aubergines, courgettes, tomates','ratatouille.jpg'),(3,4,'Poulet Basquaise','Plat',4,'2025-04-01','2025-04-04',10.95,'Française','Aucun','Poulet, poivrons, tomates','poulet.jpg'),(4,5,'Couscous','Plat',6,'2025-04-01','2025-04-04',11.32,'Marocaine','Aucun','Semoule, légumes, agneau','couscous.jpg'),(5,6,'Quiche Lorraine','Entrée',4,'2025-04-01','2025-04-04',7.49,'Française','Végétarien','Pâte, lardons, oeufs','quiche.jpg'),(6,7,'Paella','Plat',5,'2025-04-01','2025-04-04',13.88,'Espagnole','Aucun','Riz, fruits de mer, épices','paella.jpg'),(7,8,'Pad Thaï','Plat',4,'2025-04-01','2025-04-04',9.76,'Thaï','Aucun','Nouilles, crevettes, cacahuètes','padthai.jpg'),(8,9,'Burger Maison','Plat',3,'2025-04-01','2025-04-04',10.12,'Américaine','Aucun','Pain, steak, fromage','burger.jpg'),(9,3,'Soupe Pho','Plat',6,'2025-04-01','2025-04-04',8.95,'Vietnamienne','Aucun','Bouillon, nouilles, boeuf','pho.jpg'),(10,2,'Gâteau au Chocolat','Dessert',4,'2025-04-01','2025-04-04',6.44,'Française','Végétarien','Chocolat, oeufs, sucre','gateau.jpg'),(11,51,'a','Plat',2,'2025-05-05','2025-05-05',9.99,'f','Végan','f',NULL);
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
) ENGINE=InnoDB AUTO_INCREMENT=36 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transactions`
--

LOCK TABLES `transactions` WRITE;
/*!40000 ALTER TABLE `transactions` DISABLE KEYS */;
INSERT INTO `transactions` VALUES (1,1,27.53,'Carte bancaire','2025-03-20 23:00:00','Effectuée'),(2,2,33.29,'PayPal','2025-03-15 23:00:00','Annulée'),(3,3,50.33,'Espèces','2025-03-19 23:00:00','Effectuée'),(4,4,29.11,'PayPal','2025-03-13 23:00:00','Effectuée'),(5,5,26.08,'PayPal','2025-03-08 23:00:00','Effectuée'),(6,6,47.23,'Carte bancaire','2025-03-31 22:00:00','Annulée'),(7,7,59.93,'PayPal','2025-03-21 23:00:00','Effectuée'),(8,8,31.63,'Carte bancaire','2025-03-05 23:00:00','Annulée'),(9,9,55.04,'Carte bancaire','2025-03-30 22:00:00','Annulée'),(10,10,16.98,'Espèces','2025-03-11 23:00:00','Effectuée'),(11,11,18.39,'PayPal','2025-03-09 23:00:00','Effectuée'),(12,12,28.87,'Espèces','2025-03-10 23:00:00','Effectuée'),(13,13,53.91,'PayPal','2025-03-04 23:00:00','Effectuée'),(14,14,46.56,'PayPal','2025-03-19 23:00:00','Annulée'),(15,15,54.21,'PayPal','2025-03-08 23:00:00','Annulée'),(16,16,37.92,'Espèces','2025-03-13 23:00:00','Annulée'),(17,17,42.28,'Espèces','2025-03-30 22:00:00','Annulée'),(18,18,38.40,'PayPal','2025-03-27 23:00:00','Annulée'),(19,19,28.30,'Espèces','2025-03-16 23:00:00','Annulée'),(20,20,39.66,'Espèces','2025-03-29 23:00:00','Annulée'),(21,21,55.55,'Carte bancaire','2025-03-19 23:00:00','Effectuée'),(22,22,28.97,'Espèces','2025-03-21 23:00:00','Effectuée'),(23,23,33.65,'Carte bancaire','2025-03-18 23:00:00','Effectuée'),(24,24,35.54,'PayPal','2025-03-10 23:00:00','Annulée'),(25,25,26.13,'PayPal','2025-03-09 23:00:00','Annulée'),(26,26,55.19,'Espèces','2025-03-21 23:00:00','Effectuée'),(27,27,33.67,'PayPal','2025-03-28 23:00:00','Annulée'),(28,28,39.22,'Carte bancaire','2025-03-29 23:00:00','Effectuée'),(29,29,41.64,'Carte bancaire','2025-03-13 23:00:00','Effectuée'),(30,30,32.06,'PayPal','2025-03-19 23:00:00','Effectuée'),(31,31,19.98,'PayPal','2025-05-05 18:41:23','Effectuée'),(32,32,9.99,'Espèces','2025-05-05 18:43:04','Effectuée'),(33,33,9.99,'PayPal','2025-05-05 18:45:21','Effectuée'),(34,34,9.99,'PayPal','2025-05-05 18:46:20','Effectuée'),(35,35,9.99,'PayPal','2025-05-05 18:46:30','Effectuée');
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
) ENGINE=InnoDB AUTO_INCREMENT=53 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `utilisateurs`
--

LOCK TABLES `utilisateurs` WRITE;
/*!40000 ALTER TABLE `utilisateurs` DISABLE KEYS */;
INSERT INTO `utilisateurs` VALUES (1,'Guillou','Marine','905, rue de Nicolas, 75013 Paris','Lecoq','+33805290965','duboiseugene@bouygtel.fr','T$8FXcq+zN',0,1,'2025-05-05 18:37:41'),(2,'Lévêque','Thierry','93, chemin Christelle Pereira, 75005 Paris','Navarro','0451401051','dianeroger@remy.fr','16UgrLJ!$f',0,1,'2025-05-05 18:37:41'),(3,'Poulain','Victor','51, avenue de Evrard, 75005 Paris','Riou','0496969155','sylviemaillet@club-internet.fr',')(91CPIv)1',1,0,'2025-05-05 18:37:41'),(4,'Joly','Julien','19, rue Claire Dufour, 75019 Paris','Leclercq','0188767677','morenoantoine@klein.net','(giF((jy4m',0,1,'2025-05-05 18:37:41'),(5,'Lamy','François','14, chemin Adèle Fernandez, 75019 Paris','Navarro','+33(0)803395962','sylvieleclerc@colas.org',')98Fksm_hI',0,1,'2025-05-05 18:37:41'),(6,'Rodrigues','Michèle','86, boulevard Lefort, 75012 Paris','Royer','0267116845','lmillet@voila.fr','YdXkHxno+1',1,1,'2025-05-05 18:37:41'),(7,'Le Goff','Maggie','rue Toussaint, 75017 Paris','Jacques','+33(0)112770632','robertmorin@live.com','s0Lvd5ae%1',0,1,'2025-05-05 18:37:41'),(8,'Bazin','Capucine','chemin Mathieu, 75003 Paris','Briand','+33171361115','guillaume62@laposte.net','X@83huaK4S',1,1,'2025-05-05 18:37:41'),(9,'Marty','Aurélie','53, rue de Menard, 75005 Paris','Lenoir','0204389836','dupuisclemence@ifrance.com','@3yzv)puFP',1,0,'2025-05-05 18:37:41'),(10,'Mercier','Alexandre','10, boulevard Sébastien Techer, 75020 Paris','Mendès','0266188924','edouard83@regnier.com','%&6LXXgh(e',1,0,'2025-05-05 18:37:41'),(11,'Barbe','Diane','62, chemin Peron, 75013 Paris','Lemaire','+33(0)156481491','xgros@gmail.com','*j9b(Flp!$',0,1,'2025-05-05 18:37:41'),(12,'Lenoir','Suzanne','63, avenue Fouquet, 75017 Paris','Julien','0119518023','dmuller@becker.org','12RoYMVO^2',0,1,'2025-05-05 18:37:41'),(13,'Lejeune','André','650, avenue Gallet, 75018 Paris','Petitjean','0313836702','bertrandnicolas@wanadoo.fr','&*)m&5Ox57',1,1,'2025-05-05 18:37:41'),(14,'Rey','Denis','29, rue Gaillard, 75018 Paris','Lebreton','0556185374','dominique11@free.fr','_34_exWwAm',0,1,'2025-05-05 18:37:41'),(15,'Berthelot','Océane','81, rue Rivière, 75011 Paris','Richard','+33(0)332365199','simonchristophe@sfr.fr','&o_7vZeKfO',1,0,'2025-05-05 18:37:41'),(16,'Lemoine','Robert','12, boulevard de Chauvet, 75014 Paris','Moulin','0276870146','pbourgeois@lombard.fr','jDTB8PWr+5',1,0,'2025-05-05 18:37:41'),(17,'Rey','Hugues','rue Da Costa, 75001 Paris','Joubert','+33(0)339652239','jeanne05@laposte.net',')0Z%WpNCX3',0,1,'2025-05-05 18:37:41'),(18,'Fischer','Guy','chemin de Legrand, 75017 Paris','Besson','0191545226','jerome89@live.com','Am)9wFGzx$',1,1,'2025-05-05 18:37:41'),(19,'Mahe','Guy','4, chemin Jacques Bousquet, 75010 Paris','Blanc','0570433154','rousseaualice@peron.fr','#6nkPm4Ll#',1,1,'2025-05-05 18:37:41'),(20,'Legrand','Zacharie','22, rue de Maillot, 75012 Paris','Valentin','0606296201','laurentlejeune@bouygtel.fr','_4Jh%!&mYN',1,1,'2025-05-05 18:37:41'),(21,'Diaz','Stéphane','rue Thibault Chauvin, 75020 Paris','Georges','0804186256','carolinebertrand@bouygtel.fr','*T+d*bIh74',0,1,'2025-05-05 18:37:41'),(22,'Baudry','Noël','71, rue de Gaudin, 75016 Paris','Masse','+33117223320','normandbernadette@sfr.fr','Bil&TSTQ_2',1,1,'2025-05-05 18:37:41'),(23,'Legros','Henri','299, boulevard Valette, 75012 Paris','Roussel','0285646799','giraudrobert@ifrance.com','d#r9Thuv@m',0,1,'2025-05-05 18:37:41'),(24,'Lucas','Théophile','55, avenue de Texier, 75008 Paris','Imbert','+33(0)537367850','langloismathilde@dufour.com','6L3e8GPb)#',1,1,'2025-05-05 18:37:41'),(25,'Reynaud','Jacqueline','35, rue Roland Leroy, 75019 Paris','Collin','+33(0)329333346','reynaudgilles@brunel.org','ZJFDWwcm)4',1,1,'2025-05-05 18:37:41'),(26,'Léger','Marianne','rue Yves Baron, 75016 Paris','Riou','0444432830','maggie20@tiscali.fr','G#4UNm4R%t',1,1,'2025-05-05 18:37:41'),(27,'Descamps','Frédérique','81, chemin Pages, 75005 Paris','Vaillant','+33351353465','isabelle47@yahoo.fr','UXM0(UsIq*',0,1,'2025-05-05 18:37:41'),(28,'Albert','Guy','81, rue Thomas Couturier, 75018 Paris','Boyer','+33(0)174329271','bcouturier@gilbert.fr','2&0BBrcY6d',1,0,'2025-05-05 18:37:41'),(29,'Jacob','Constance','22, chemin Charpentier, 75017 Paris','Pineau','0562575326','mauricepetitjean@lecomte.com','k5ZjYVWu@$',0,1,'2025-05-05 18:37:41'),(30,'Fleury','Christelle','13, avenue Margaud Roussel, 75007 Paris','Dupré','0199261891','gautiercolette@sfr.fr',')3EI+StiNY',1,0,'2025-05-05 18:37:41'),(31,'Gérard','Éric','2, rue Cécile Collet, 75013 Paris','Aubry','0501204556','thierrybenjamin@dos.com','^5OD(HtndN',0,1,'2025-05-05 18:37:41'),(32,'Leroux','François','879, boulevard Gillet, 75015 Paris','Merle','0690277167','bertinmarcelle@richard.net','_XQfNbZ+q5',0,1,'2025-05-05 18:37:41'),(33,'Lelièvre','Dominique','81, rue Vincent Lopes, 75004 Paris','Girard','+33686631779','didiercaroline@dbmail.com','@H#7nXxurT',1,1,'2025-05-05 18:37:41'),(34,'De Sousa','Vincent','697, avenue de Noël, 75003 Paris','Pereira','+33605548851','clemencejoly@gautier.org','uHGjf*Id)3',0,1,'2025-05-05 18:37:41'),(35,'Didier','Aimé','9, boulevard Christine Grégoire, 75001 Paris','Valette','+33392216995','sraynaud@orange.fr','L)I6Kjdpe%',1,1,'2025-05-05 18:37:41'),(36,'Maillet','Gilles','98, chemin de Lacombe, 75001 Paris','Ferreira','0687996846','laurentalex@vincent.net','6od2J#v*%g',1,1,'2025-05-05 18:37:41'),(37,'Jacquot','Margot','avenue Arnaude Pottier, 75008 Paris','Bouvier','+33(0)304397359','theodorepons@normand.com','+87+D!Mm#8',1,1,'2025-05-05 18:37:41'),(38,'Baudry','Emmanuelle','6, rue de Gonzalez, 75011 Paris','Dijoux','+33(0)482688615','margaudremy@alves.org','z$y!9QpXXw',1,1,'2025-05-05 18:37:41'),(39,'Gimenez','Monique','9, boulevard Suzanne Grégoire, 75009 Paris','Cohen','0800435811','toussaintchristophe@leconte.fr','r3Rmwc@f@^',0,1,'2025-05-05 18:37:41'),(40,'Bruneau','Valentine','76, avenue Aurore Gomes, 75007 Paris','Durand','0118091901','charpentiersimone@club-internet.fr',')G1#Jyhko9',1,0,'2025-05-05 18:37:41'),(41,'Lenoir','Frédérique','1, boulevard Godard, 75008 Paris','Carlier','+33(0)543536822','laetitiafleury@noel.com','^(67UUEr59',0,1,'2025-05-05 18:37:41'),(42,'Lebreton','Vincent','39, boulevard de Marchal, 75014 Paris','Gomes','0320533645','christiane77@becker.org','8&8nr2fY*D',1,1,'2025-05-05 18:37:41'),(43,'Lecoq','Jeanne','9, boulevard Élodie Georges, 75004 Paris','Guibert','+33156394278','gmarchal@dupre.com','(waOgfE42%',0,1,'2025-05-05 18:37:41'),(44,'Alves','Amélie','10, chemin de Henry, 75012 Paris','Fischer','0149892665','alexandria38@benard.fr','P*07ZTaEf(',0,1,'2025-05-05 18:37:41'),(45,'Leduc','Margot','33, avenue de Simon, 75014 Paris','Berger','+33(0)229922809','brunraymond@blondel.com','Lz+04Ckg1a',0,1,'2025-05-05 18:37:41'),(46,'Godard','Jeanne','avenue Collin, 75002 Paris','Payet','+33(0)603886291','mbonneau@rossi.com','sR!vc7Ved@',1,1,'2025-05-05 18:37:41'),(47,'Traore','Patricia','316, avenue Pauline Rey, 75013 Paris','Perez','0298643009','malletmarcelle@lagarde.fr','V72TXNHu@T',0,1,'2025-05-05 18:37:41'),(48,'Fleury','Thibault','36, rue de Letellier, 75004 Paris','Rolland','0421386589','ameliebousquet@robin.fr',')F6CuHacx%',1,1,'2025-05-05 18:37:41'),(49,'Descamps','Suzanne','13, boulevard de Blondel, 75007 Paris','Rocher','+33692053021','qbenard@ifrance.com','@eu9fTGqm&',0,1,'2025-05-05 18:37:41'),(50,'Thomas','Raymond','28, rue de Gaudin, 75005 Paris','Cousin','0518489476','oliviemaillot@tele2.fr','N_G7SdaIER',0,1,'2025-05-05 18:37:41'),(51,'a','a','a',NULL,'a','a','1234567',0,1,'2025-05-05 18:40:30'),(52,'a','a','a',NULL,'02','b','1234567',1,0,'2025-05-05 18:41:09');
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

-- Dump completed on 2025-05-05 20:52:55
