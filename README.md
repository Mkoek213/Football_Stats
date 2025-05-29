# Football Team Manager Web App

This is a web application for managing football teams, players, matches, and statistics. It includes a role-based login system (admin vs. regular user) with hashed password storage and full CRUD functionality.

## 🚀 Getting Started

To run this application locally:

1.  **Build the application:**
    ```bash
    dotnet build
    ```
2.  **Run the application:**
    ```bash
    dotnet run
    ```

Once the application starts, navigate to the following URL in your web browser:

[http://localhost:5112](http://localhost:5112)

You will be greeted by the login page.

### 🖼️ Login Page
![Login Page](https://github.com/Mkoek213/Football_Stats/GitHubphotos/LoginPage.png)

## 🔐 First Login

Use the following credentials to log in for the first time:

* **Username:** `admin`
* **Password:** `admin`

**Note:** Only the admin can manage users. Regular users will have limited access.

### 🖼️ Admin User Management Panel
![Admin User Management Panel](https://github.com/Mkoek213/Football_Stats/GitHubphotos/AdminUserManagementPanel.png)

## 👥 Teams Management

In the "Teams" section, you can perform the following actions:

* **Add new teams.**
* **Edit existing team details.**
* **Delete teams.**
    * ⚠️ **Warning:** Deleting a team will also delete its associated matches. Players assigned to the deleted team will become "Free Agents."
* **While adding a new team, you can also:**
    * Add players to the team.
    * Include initial statistics for these players (goals, assists, appearances).
    * Schedule matches for the team.
        * If no result is provided for a match, it will be marked as "Upcoming".

### 🖼️ Teams View
![Teams View](https://github.com/Mkoek213/Football_Stats/GitHubphotos/TeamsView.png)

### 🖼️ Add Team with Players
![Add Team](https://github.com/Mkoek213/Football_Stats/GitHubphotos/AddTeam.png)
![Add Team with Players](https://github.com/Mkoek213/Football_Stats/GitHubphotos/AddTeamWithPlayers.png)

### 🖼️ Add Team with Matches
![Upcoming Matches](https://github.com/Mkoek213/Football_Stats/GitHubphotos/UpcomingMatches.png)

## 🧍 Players Management

In the "Players" section, you can:

* **Add new players** along with their initial statistics.
* **Edit player details** (name, surname, team).
* **Delete players.**
    * ⚠️ **Warning:** Deleting a player will also remove their statistics from the system.

### 🖼️ Players List
![Players List](https://github.com/Mkoek213/Football_Stats/GitHubphotos/PlayersList.png)

### 🖼️ Add Player
![Add Player](https://github.com/Mkoek213/Football_Stats/GitHubphotos/AddPlayer.png)

### 🖼️ Edit Player
![Edit Player](https://github.com/Mkoek213/Football_Stats/GitHubphotos/EditPlayer.png)

## 🏟️ Matches Management

The "Matches" section allows you to:

* **Add new matches** between teams.
* **Edit details of existing matches** (including scores).
* **Delete matches.**

### 🖼️ Matches List
![Matches List](https://github.com/Mkoek213/Football_Stats/GitHubphotos/MatchesList.png)

### 🖼️ Add Match
![Add/Edit Match](https://github.com/Mkoek213/Football_Stats/GitHubphotos/AddMatch.png)

### 🖼️ Edit Match
![Edit Match](https://github.com/Mkoek213/Football_Stats/GitHubphotos/EditMatch.png)

## 📊 Player Statistics

In the "Player Stats" section, you can:

* **View and edit the statistics** for each player, including:
    * Goals
    * Assists
    * Appearances

### 🖼️ Player Statistics View
![Player Statistics View](https://github.com/Mkoek213/Football_Stats/GitHubphotos/PlayerStatisticsView.png)

### 🖼️ Player Statistics Editor
![Player Statistics Editor](https://github.com/Mkoek213/Football_Stats/GitHubphotos/PlayerStatisticsEditor.png)

## 🥇 Top Scorers

The "Top Scorers" section displays the top 3 goal scorers in the league.

### 🖼️ Top Scorers View
![Top Scorers View](https://github.com/Mkoek213/Football_Stats/GitHubphotos/TopScorersView.png)

## 🔒 Authentication & Authorization

* **Admin users** have full access to all application sections, including user management.
* **Regular users** can view data and manage teams, players, matches, and statistics but cannot manage users.
* Passwords are stored securely using industry-standard **hashing techniques**.