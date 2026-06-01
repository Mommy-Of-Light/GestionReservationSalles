-- phpMyAdmin SQL Dump
-- version 5.2.1deb3
-- https://www.phpmyadmin.net/
--
-- Hôte : localhost:3306
-- Généré le : lun. 01 juin 2026 à 09:30
-- Version du serveur : 10.11.14-MariaDB-0ubuntu0.24.04.1
-- Version de PHP : 8.4.20

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `gestion_salles`
--

-- --------------------------------------------------------

--
-- Structure de la table `Reservations`
--

CREATE TABLE `Reservations` (
  `IdUser` int(11) NOT NULL,
  `IdRoom` int(11) NOT NULL,
  `Date` date NOT NULL,
  `Hours` varchar(50) NOT NULL,
  `ClassName` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Déchargement des données de la table `Reservations`
--

INSERT INTO `Reservations` (`IdUser`, `IdRoom`, `Date`, `Hours`, `ClassName`) VALUES
(1, 1, '2026-06-01', '2', '2');

-- --------------------------------------------------------

--
-- Structure de la table `Rooms`
--

CREATE TABLE `Rooms` (
  `IdRoom` int(11) NOT NULL,
  `Name` varchar(100) NOT NULL,
  `Capacity` int(11) NOT NULL,
  `Building` varchar(100) NOT NULL,
  `Floor` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Déchargement des données de la table `Rooms`
--

INSERT INTO `Rooms` (`IdRoom`, `Name`, `Capacity`, `Building`, `Floor`) VALUES
(1, '1', 1, '1', 1);

-- --------------------------------------------------------

--
-- Structure de la table `Users`
--

CREATE TABLE `Users` (
  `IdUser` int(11) NOT NULL,
  `Name` varchar(100) NOT NULL,
  `Email` varchar(255) NOT NULL,
  `Password` varchar(255) NOT NULL,
  `Role` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Déchargement des données de la table `Users`
--

INSERT INTO `Users` (`IdUser`, `Name`, `Email`, `Password`, `Role`) VALUES
(1, 'Admin', 'admin@exemple.com', 'admin123', 'admin'),
(2, 'Teacher', 'teacher@exemple.com', 'teacher1', 'teacher'),
(3, 'User', 'user@exemple.com', 'user1234', 'user');

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `Reservations`
--
ALTER TABLE `Reservations`
  ADD KEY `IdUser` (`IdUser`),
  ADD KEY `IdRoom` (`IdRoom`);

--
-- Index pour la table `Rooms`
--
ALTER TABLE `Rooms`
  ADD PRIMARY KEY (`IdRoom`);

--
-- Index pour la table `Users`
--
ALTER TABLE `Users`
  ADD PRIMARY KEY (`IdUser`),
  ADD UNIQUE KEY `Email` (`Email`);

--
-- AUTO_INCREMENT pour les tables déchargées
--

--
-- AUTO_INCREMENT pour la table `Rooms`
--
ALTER TABLE `Rooms`
  MODIFY `IdRoom` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT pour la table `Users`
--
ALTER TABLE `Users`
  MODIFY `IdUser` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `Reservations`
--
ALTER TABLE `Reservations`
  ADD CONSTRAINT `Reservations_ibfk_1` FOREIGN KEY (`IdUser`) REFERENCES `Users` (`IdUser`),
  ADD CONSTRAINT `Reservations_ibfk_2` FOREIGN KEY (`IdRoom`) REFERENCES `Rooms` (`IdRoom`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
