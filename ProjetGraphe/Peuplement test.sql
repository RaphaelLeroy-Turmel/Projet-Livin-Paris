-- Peuplement de la table Utilisateurs
INSERT INTO Utilisateurs (nom, prenom, adresse, metro_proche, telephone, email, mdp, est_client, est_cuisinier) VALUES
('Dupont', 'Jean', '12 Rue de Paris, 75001', 'Châtelet', '0601020304', 'jean.dupont@email.com', 'Passw0rd!', TRUE, FALSE),
('Martin', 'Sophie', '23 Avenue de Lyon, 75002', 'Gare de Lyon', '0611223344', 'sophie.martin@email.com', 'Sophie123', FALSE, TRUE),
('Bernard', 'Luc', '45 Boulevard Haussmann, 75009', 'Opéra', '0622334455', 'luc.bernard@email.com', 'Luc2024', TRUE, TRUE);

INSERT INTO Utilisateurs(nom, prenom, adresse, metro_proche, telephone, email, mdp, est_client, est_cuisinier) VALUES
('Durant','Medhy','15 Rue Cardinet, 75017','Cardinet','1234567890','Mdurant@gmail.com','DurantMdp', TRUE, FALSE),
('Dupont','Marie','30 Rue de la République, 75011','République','2345678901','Mdupont@gmail.com','DupontMDP', FALSE, TRUE);

-- Peuplement de la table Plats
INSERT INTO Plats (id_cuisinier, nom_plat, type_plat, nombre_personnes, date_fabrication, date_peremption, prix_par_personne, nationalite, regime_alimentaire, ingredients, photo) VALUES
(2, 'Lasagnes', 'Plat', 4, '2025-02-25', '2025-03-01', 12.50, 'Italienne', 'Végétarien', 'Pâtes, sauce tomate, fromage', '/images/lasagnes.jpg'),
(2, 'Salade César', 'Entrée', 2, '2025-02-26', '2025-03-02', 8.00, 'Américaine', 'Sans gluten', 'Salade, poulet, parmesan', '/images/salade.jpg'),
(3, 'Tiramisu', 'Dessert', 6, '2025-02-27', '2025-03-05', 5.50, 'Italienne', 'Indifférent', 'Mascarpone, café, biscuits', '/images/tiramisu.jpg');

-- Peuplement de la table Commandes
INSERT INTO Commandes (id_client, date_commande, total, statut) VALUES
(1, '2025-02-28 12:30:00', 25.50, 'En cours'),
(1, '2025-02-28 14:00:00', 16.00, 'Livrée');

-- Peuplement de la table Lignes_Commande
INSERT INTO Lignes_Commande (id_commande, id_plat, quantite, prix_unitaire, date_livraison, adresse_livraison) VALUES
(1, 1, 2, 12.50, '2025-03-01', '12 Rue de Paris, 75001'),
(2, 3, 1, 5.50, '2025-03-02', '23 Avenue de Lyon, 75002');

-- Peuplement de la table Livraisons
INSERT INTO Livraisons (id_commande, id_cuisinier, adresse_depart, adresse_arrivee, date_livraison, distance_km, statut) VALUES
(1, 2, '23 Avenue de Lyon, 75002', '12 Rue de Paris, 75001', '2025-03-01', 2.5, 'En cours'),
(2, 3, '45 Boulevard Haussmann, 75009', '23 Avenue de Lyon, 75002', '2025-03-02', 3.2, 'Livrée');

-- Peuplement de la table Transactions
INSERT INTO Transactions (id_commande, montant, mode_paiement, date_transaction, statut) VALUES
(1, 25.50, 'Carte bancaire', '2025-02-28 12:35:00', 'Effectuée'),
(2, 16.00, 'PayPal', '2025-02-28 14:05:00', 'Effectuée');
