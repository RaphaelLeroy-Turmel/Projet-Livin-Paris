-- DROP DATABASE livinparis;
CREATE DATABASE livinparis;
USE livinparis;

-- Table Utilisateurs
CREATE TABLE Utilisateurs
(
    id_utilisateur INT AUTO_INCREMENT PRIMARY KEY,
    nom VARCHAR(55) NOT NULL,
    prenom VARCHAR(55) NOT NULL,
    adresse VARCHAR(100) NOT NULL,
    metro_proche VARCHAR(100),
    telephone VARCHAR(20) UNIQUE,
    email VARCHAR(150) UNIQUE NOT NULL,
    mdp VARCHAR(255) NOT NULL,
    CHECK(LENGTH(mdp) > 6), -- Le mdp doit contenir au moins 6 caractères
    -- penser à faire une condition de mettre au moins un chiffre --
    est_client BOOL DEFAULT FALSE,
	est_cuisinier BOOL DEFAULT FALSE,
    date_insciption TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);
-- Table Plats
CREATE TABLE Plats
(
	id_plat INT PRIMARY KEY AUTO_INCREMENT,
    id_cuisinier INT NOT NULL,
    nom_plat VARCHAR(150) NOT NULL,
    type_plat ENUM('Entrée', 'Plat', 'Dessert') NOT NULL,
    nombre_personnes INT NOT NULL,
    date_fabrication DATE NOT NULL,
    date_peremption DATE NOT NULL,
    prix_par_personne DECIMAL(6,2) NOT NULL,
    nationalite VARCHAR(100),
    regime_alimentaire VARCHAR(255),
    ingredients VARCHAR(255),
    photo VARCHAR(255), -- Stockage du lien vers une image et pas de BLOB car ça ralentirait trop la BDD (pas encore au point)
    FOREIGN KEY (id_cuisinier) REFERENCES Utilisateurs(id_utilisateur)
);

-- Table Commandes
CREATE TABLE Commandes 
(
    id_commande INT PRIMARY KEY AUTO_INCREMENT,
    id_client INT NOT NULL,
    date_commande TIMESTAMP,
    total DECIMAL(10,2),
    statut ENUM('En cours', 'Livrée', 'Annulée'),
    FOREIGN KEY (id_client) REFERENCES Utilisateurs(id_utilisateur)
);

-- Table Lignes de Commande (plusieurs plats)
CREATE TABLE Lignes_Commande 
(
    id_ligne INT PRIMARY KEY AUTO_INCREMENT,
    id_commande INT NOT NULL,
    id_plat INT NOT NULL,
    quantite INT NOT NULL,
    prix_unitaire DECIMAL(10,2) NOT NULL,
    date_livraison DATE NOT NULL,
    adresse_livraison VARCHAR(255),
    FOREIGN KEY (id_commande) REFERENCES Commandes(id_commande),
    FOREIGN KEY (id_plat) REFERENCES Plats(id_plat)
);

-- Table Livraisons
CREATE TABLE Livraisons 
(
    id_livraison INT PRIMARY KEY AUTO_INCREMENT,
    id_commande INT NOT NULL,
    id_cuisinier INT NOT NULL,
    adresse_depart VARCHAR(255) NOT NULL,
    adresse_arrivee VARCHAR(255) NOT NULL,
    date_livraison DATE NOT NULL,
    distance_km DECIMAL(5,2),
    statut ENUM('En attente', 'En cours', 'Livrée'),
    FOREIGN KEY (id_commande) REFERENCES Commandes(id_commande),
    FOREIGN KEY (id_cuisinier) REFERENCES Utilisateurs(id_utilisateur)
);

-- Table Historique des Transactions
CREATE TABLE Transactions 
(
    id_transaction INT PRIMARY KEY AUTO_INCREMENT,
    id_commande INT NOT NULL,
    montant DECIMAL(10,2) NOT NULL,
    mode_paiement ENUM('Carte bancaire', 'PayPal', 'Espèces') NOT NULL,
    date_transaction TIMESTAMP,
    statut ENUM('Effectuée', 'Annulée'),
    FOREIGN KEY (id_commande) REFERENCES Commandes(id_commande)
);

-- Commandes simples pour vérifier les tables et leurs contenues
SELECT * FROM Utilisateurs; -- tous les utilisateurs de la plateforme
SELECT * FROM Utilisateurs WHERE est_cuisinier = TRUE AND est_client = FALSE; -- les cuisinier uniquements
SELECT * FROM Utilisateurs WHERE est_cuisinier = TRUE AND est_client = TRUE; -- les cuisiniers qui sont aussi clients
SELECT * FROM Utilisateurs WHERE est_cuisinier = FALSE AND est_client = TRUE; -- les clients uniquement
SELECT * FROM Plats;
SELECT * FROM Livraisons WHERE statut = 'En Cours';
SELECT *FROM Transactions;
SELECT * FROM commandes;
SELECT * FROM lignes_commande;

