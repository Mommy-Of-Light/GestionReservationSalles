# GestionReservationSalles
# Application de Gestion de Réservation de Salles

## Présentation du projet

Ce mini-projet a pour objectif de développer une application en **C# Windows Forms** permettant la **gestion et la réservation des salles de classe d’une école**.

L’application permet aux utilisateurs de réserver des salles, consulter les disponibilités et gérer les informations liées aux salles et aux réservations.

Le projet utilise :

* **C# / Windows Forms**
* **SQL Server**
* **Prometheus** pour le monitoring
* **Grafana** pour la visualisation des métriques

---

# Objectifs du projet

L’objectif principal est de simplifier l’organisation des salles de classe dans une école grâce à un système centralisé.

L’application permet notamment :

* d’éviter les conflits de réservation,
* de consulter les salles disponibles,
* de gérer les utilisateurs,
* d’assurer un suivi du bon fonctionnement de l’application grâce au monitoring.

---

# Fonctionnalités principales

## Gestion des utilisateurs

Les utilisateurs peuvent :

* créer un compte,
* se connecter,
* se déconnecter,
* accéder à l’application selon leur rôle.

### Formulaires concernés

* `FrmLogin.cs`
* `FrmInscription.cs`

---

## Gestion des salles

L’application permet de :

* consulter les salles disponibles,
* afficher les informations d’une salle,
* voir la capacité des salles,
* identifier le bâtiment et l’étage.

### Informations enregistrées

* nom de la salle,
* capacité,
* bâtiment,
* étage.

---

## Gestion des réservations

Les utilisateurs peuvent :

* réserver une salle,
* consulter les réservations existantes,
* vérifier si une salle est déjà occupée,
* choisir une date et une heure.

Le système empêche les conflits de réservation.

---

# Structure du projet

## Fichiers principaux

| Fichier             | Description                        |
| ------------------- | ---------------------------------- |
| `FrmAccueil.cs`     | Fenêtre principale                 |
| `FrmLogin.cs`       | Connexion utilisateur              |
| `FrmInscription.cs` | Création de compte                 |
| `Room.cs`           | Classe représentant une salle      |
| `User.cs`           | Classe représentant un utilisateur |
| `RoomManager.cs`    | Gestion des salles                 |
| `UserManager.cs`    | Gestion des utilisateurs           |
| `Program.cs`        | Point d’entrée de l’application    |

---

# Base de données

## MCD (Modèle Conceptuel de Données)

Le système est composé de trois entités principales :

### Users

* name
* email
* password
* role

### Rooms

* name
* capacity
* building
* floor

### Reservations

* date
* hours
* className

### Relations

* Un utilisateur peut effectuer plusieurs réservations.
* Une réservation concerne une seule salle.
* Une salle peut recevoir plusieurs réservations.

---

## MLD (Modèle Logique de Données)

### Table `Users`

| Champ    | Type            |
| -------- | --------------- |
| idUser   | INT PRIMARY KEY |
| name     | VARCHAR         |
| email    | VARCHAR         |
| password | VARCHAR         |
| role     | VARCHAR         |

### Table `Rooms`

| Champ    | Type            |
| -------- | --------------- |
| idRoom   | INT PRIMARY KEY |
| name     | VARCHAR         |
| capacity | INT             |
| building | VARCHAR         |
| floor    | INT             |

### Table `Reservations`

| Champ     | Type            |
| --------- | --------------- |
| idUsers   | INT FOREIGN KEY |
| idRoom    | INT FOREIGN KEY |
| date      | DATE            |
| hours     | TIME            |
| className | VARCHAR         |

---

# Scripts SQL

Les scripts SQL permettent de :

* créer la base de données,
* créer les tables,
* définir les clés primaires,
* définir les clés étrangères,
* ajouter des données de test.

## Exemple de script SQL

```sql
CREATE TABLE Users (
    idUser INT PRIMARY KEY IDENTITY,
    name VARCHAR(100),
    email VARCHAR(100),
    password VARCHAR(100),
    role VARCHAR(50)
);

CREATE TABLE Rooms (
    idRoom INT PRIMARY KEY IDENTITY,
    name VARCHAR(100),
    capacity INT,
    building VARCHAR(100),
    floor INT
);

CREATE TABLE Reservations (
    idUsers INT,
    idRoom INT,
    date DATE,
    hours TIME,
    className VARCHAR(100),

    FOREIGN KEY (idUsers) REFERENCES Users(idUser),
    FOREIGN KEY (idRoom) REFERENCES Rooms(idRoom)
);
```

---

# Monitoring avec Prometheus et Grafana

## Objectif du monitoring

Le monitoring permet de surveiller le fonctionnement de l’application en temps réel afin de détecter rapidement les erreurs ou comportements anormaux.

---

# Points critiques surveillés

## Connexion utilisateur

Surveillance :

* nombre de connexions réussies,
* nombre d’échecs de connexion,
* tentatives suspectes.

---

## Réservations

Surveillance :

* conflits de réservation,
* erreurs lors des réservations,
* salles déjà occupées.

---

## Base de données

Surveillance :

* temps de réponse SQL,
* erreurs de connexion,
* disponibilité de la base.

---

## Sécurité

Surveillance :

* saisies invalides,
* erreurs utilisateur,
* comportements malveillants.

---

# Métriques envoyées à Prometheus

Exemples de métriques surveillées :

| Métrique                     | Description                     |
| ---------------------------- | ------------------------------- |
| `login_success_total`        | Nombre de connexions réussies   |
| `login_failed_total`         | Nombre d’échecs de connexion    |
| `reservation_total`          | Nombre total de réservations    |
| `reservation_conflict_total` | Nombre de conflits              |
| `database_response_time`     | Temps de réponse SQL            |
| `active_users`               | Nombre d’utilisateurs connectés |

---

# Configuration de Prometheus

Prometheus est configuré pour récupérer automatiquement les métriques exposées par l’application C#.

## Exemple de configuration

```yaml
scrape_configs:
  - job_name: 'reservation-app'
    static_configs:
      - targets: ['localhost:5000']
```

---

# Utilisation de Grafana

Grafana est connecté à Prometheus afin d’afficher les métriques dans un tableau de bord.

Le dashboard permet de visualiser :

* les connexions utilisateurs,
* les erreurs système,
* les réservations,
* les performances SQL.

---

# Alertes

Des alertes ont été mises en place afin de détecter rapidement les problèmes.

## Exemples d’alertes

* base de données indisponible,
* trop grand nombre d’erreurs,
* conflits de réservation importants.

---

# Conclusion

## Première conclusion

Certaines fonctionnalités pourraient encore être améliorées afin d’assurer une meilleure fiabilité de l’application.

Par exemple :

* gestion avancée des permissions,
* historique des réservations,
* notifications automatiques,
* amélioration de la sécurité.

Le monitoring pourrait également être enrichi avec davantage de métriques détaillées.

---

## Deuxième conclusion

Ce projet nous a permis d’apprendre :

* le développement d’une application en C#,
* la création d’une base de données relationnelle,
* l’utilisation du SQL,
* la gestion des utilisateurs et des réservations,
* le monitoring avec Prometheus,
* la visualisation des données avec Grafana.

Nous avons également compris l’importance de la surveillance et de la fiabilité d’une application informatique.

---

# Auteurs
Erdi Ibrahimi, Kevin Rios, Bastien Jacolino
Projet réalisé dans le cadre du module 110.
