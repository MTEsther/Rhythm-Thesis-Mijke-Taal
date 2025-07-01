# Rhythm-Thesis-Mijke-Taal

**Thesis Title**: Timing Matters: The Effect of Rhythmic Alignment and Auditory Sensitivity on Cognitive Workload and Performance in Rhythm Games <br>
**Author**: Mijke Taal  <br>
**Supervisor**: Katja Rogers <br>
**Year**: 2025  <br>

This repository contains all the files to make this thesis rhythm game and all the data collected in the experiment. 

```text 
+-- Cleaned Data/ # Dataframes after the data analysis
|   +-- Demographics_cleaned.csv
|   +-- GameScore_cleaned.csv
|   +-- GameStudy_cleaned.csv
+-- Raw Data/ # Used for the data analysis
|   +-- GameScore Participants - Blad1.csv
|   +-- MT Demographics_June 13, 2025_02.45.csv
|   +-- MT Game Study_June 13, 2025_02.45.csv
+-- Thesis Game/
|   +-- .vscode/
|   +-- Assets/
|   |   +-- Animation/ # In this folder are the two different animations used for the game
|   |   |   +-- Enemy1/ 
|   |   |   +-- Player/
|   |   +-- Audio/
|   |   |   +-- 7_t.o.e.wav # Background music audio used for the game
|   |   +-- Input/
|   |   |   +-- InputManager.cs # Movement of the player
|   |   |   +-- Test.cs
|   |   +-- Level 1.unity # Levels
|   |   +-- Level 2.unity
|   |   +-- Level 3.unity
|   |   +-- Level 4.unity
|   |   +-- Level 5.unity
|   |   +-- Level 6.unity
|   |   +-- Level Selection.unity
|   |   +-- OArielG/
|   |   |   +-- 2DSimpleUIPack/
|   |   |   |   +-- Examples/
|   |   |   |   +-- Sprites/
|   |   |   |   |   +-- ui-small-icons.png # Visual of hearts used
|   |   +-- Scenes/
|   |   +-- Script/
|   |   |   +-- BeatPulseEffect.cs # Pulsation of the beat
|   |   |   +-- BeatVisualizer.cs # Visualization of the beat
|   |   |   +-- CameraFollow.cs # Camera follows player
|   |   |   +-- CoinManager.cs # Coin count in the game
|   |   |   +-- EndScreenScript.cs # Text and data on the end screen
|   |   |   +-- EnemyPatrol.cs # Movement of the enemy
|   |   |   +-- GameOverScreen.cs # Text and data on the game over screen
|   |   |   +-- GameTimer.cs # Times the level to make sure each level is played 3 minutes
|   |   |   +-- LevelSelector.cs # Makes sure that the right level is selected in the Level Selection
|   |   |   +-- LevelTransitionHelper.cs # When levels 1, 2 or 3 are completed the player automaticallly goes to their respectively levels 4, 5 or 6
|   |   |   +-- PlayerCollision.cs # Makes sure that the player can be hit by the enemies
|   |   |   +-- StatsTracker.cs # Keeps track of the correct movements, incorrect movements, coins collected and hearts left
|   |   |   +-- Player/
|   |   |   |   +-- HealthManager.cs # Keeps track of the lives lost and the visualization of the lives lost
|   |   |   |   +-- PlayerMovement.cs # Movement of the player
|   |   +-- Settings/
|   |   +-- TextMesh Pro/
|   |   +-- TinyPRGTown/
|   |   |   +-- Artwork/
|   |   |   |   +-- Sprites/
|   |   |   |   |   +-- hero.png # Sprite of main player
|   |   |   +-- Scenes/
|   |   +-- Top Down Adventure Assets/
|   |   |   +-- Scenes/
|   |   |   +-- sounds/
|   |   |   +-- Visuals/
|   |   |   |   +-- CHARACTERS/
|   |   |   |   |   +-- npc/
|   |   |   |   |   +-- player/
|   |   |   |   |   |   +-- hero1.png # Sprite of the enemies
|   |   |   |   |   |   +-- hero2.png
|   |   |   |   |   |   +-- hero3.png
|   |   |   |   |   |   +-- hero4.png
|   |   |   |   |   |   +-- hero5.png
|   |   |   |   |   |   +-- hero6.png
|   |   |   |   |   |   +-- hero7.png
|   |   |   |   |   |   +-- hero8.png
|   |   |   |   |   |   +-- hero9.png
|   |   |   |   |   |   +-- hero10.png
|   |   |   |   |   |   +-- hero11.png
|   |   |   |   |   |   +-- hero12.png
|   |   |   |   |   |   +-- hero13.png
|   |   |   |   |   |   +-- hero14.png
|   |   |   |   |   |   +-- hero15.png
|   |   |   |   |   |   +-- PatrolEnemy2.cs
|   |   |   |   |   |   +-- Materials/
|   |   |   |   +-- ENVIRONMENT/
|   |   |   |   |   +-- cave-trap/
|   |   |   |   |   +-- sea/
|   |   |   |   |   +-- tilesets/
|   |   |   |   |   |   +-- tilesets/
|   |   |   |   |   |   |   +-- tilest-world.png/ # Tiles used as background of the game
|   |   |   |   |   +-- waterfall/
|   |   |   |   +-- FX/
|   |   |   |   +-- HUD/
|   |   |   |   +-- OBJECTS/
|   |   |   |   |   +-- box-splash/
|   |   |   |   |   +-- box-water/
|   |   |   |   |   +-- button/
|   |   |   |   |   +-- coin/
|   |   |   |   |   |   +-- coin1.png/ # Visual of the coins in the game
|   |   |   |   |   |   +-- coin2.png/
|   |   |   |   |   |   +-- coin3.png/
|   |   |   |   |   |   +-- coin4.png/
|   |   |   |   |   +-- items/
|   |   |   |   |   +-- sprites/
|   +-- Library/
|   +-- Logs/
|   +-- Packages/
|   +-- ProjectSettings/
|   +-- Temp/
|   +-- UserSettings/
+-- DataAnalysis.ipynb # All the code used for the data analysis
+-- Game Instructions.docx.pdf # The game instruction that the players received for the experiment
```
## Game

Note: The file structure of the game (Thesis Game) lists only the main folders and files used in the game or personally created. Not all third-party assets or Unity-generated files are shown.

---
### Game Description

- **Type**: Rhythm-based timing game  
- **Mechanics**: Player can move only on the visualized beat; moving off-beat prevents movement  
- **Beat Visualization**: A pulsing circle indicates the rhythm — the correct moment to move is when the circle is at its largest size  
- **Feedback**:  
  - **On-beat**: Movement is allowed, and the circle flashes **green**  
  - **Off-beat**: Movement is blocked, and the circle flashes **red**  
- **Duration**: Each level lasts exactly 3 minutes  
- **Levels**:  
  - **Level 1 – Minneapolis**: On-beat alignment with music  
  - **Level 2 – Chicago**: Off-beat alignment with music
  - **Level 3 – Denver**: No music, only a beat visual  
  - Auto-transition to Level 4, 5, and 6 respectively  
- **End State**: At the end of each level, a **“Good Job!”** screen appears — there is no traditional win/lose mechanic
- **Instructions**: See 'Game Instructions.docx.pdf' for the full gameplay instructions

---
### Controls

- Arrow keys or AWSD keys: Move player
- Movement only possible on the beat (visualized via pulsing circle)
- No mouse input used

---

### Visuals & Animation

- The player and enemies have directional walking animations (up, down, left, right) to match movement direction.
- Animations are handled using Unity Animator Controllers and switch based on input direction.
- There are no rhythm-specific animations, but the player's sprite color changes to indicate beat accuracy: green (on-beat) or red (off-beat).
- A pulsing circle expands and contracts on screen to visualize the rhythm, implemented via code (`BeatPulseEffect.cs`).
- The rhythm is synchronized to a custom audio track (`7_t.o.e.wav`) with a fixed tempo of 120 BPM.
- Movement logic and beat detection are implemented in custom scripts like `PlayerMovement.cs` and `StatsTracker.cs`.

---

### Requirements

- Unity version: **3.12.1 (3.12.1)**
- Tested on MacOS

Open using Unity Hub for best results.

---
### Running the Game

To run the game:

1. Open **Unity Hub**  
2. Add the project from `/prototype/src/` (after unzipping)  
3. Open the `Level Selection.unity` scene  
4. Play the game in the Unity editor or export it using **Build Settings**

---

## Data Cleaning & Analysis

---

All processing and analysis steps are in 'DataAnalysis.ipynb'. Below is a high-level map from notebook sections to the raw/cleaned data files.

1. **Import data**  
   - **Notebook section:** “Import data”  
   - **Raw inputs (in `/Raw Data/`):**  
     - `GameScore Participants - Blad1.csv`  
     - `MT Demographics_June 13, 2025_02.45.csv`  
     - `MT Game Study_June 13, 2025_02.45.csv`  

2. **Clean data**  
   - **Notebook section:** “Clean data”  
   - **Sub-steps:**  
     - Remove first two rows (metadata)  
     - Convert columns to appropriate types  
     - Drop unusable/incomplete participants  
     - Split combined level columns into separate variables  
   - **Cleaned outputs (in `/Cleaned Data/`):**  
     - `Demographics_cleaned.csv`  
     - `GameStudy_cleaned.csv`  
     - `GameScore_cleaned.csv`  

3. **Check for normality**  
   - **Notebook section:** “Check for normality”  
   - **Outputs:** Shapiro–Wilk tests  

4. **Descriptives**  
   - **Notebook section:** “Descriptives”  
   - **Outputs:** Summary tables
     
5. **Data Analysis**  
   - **Notebook section:** “Data Analysis”  
   - **Hypotheses tested:**  
     - **H1**: On-beat vs. off-beat: cognitive workload & performance  
     - **H3**: Audio-susceptibility interactions with workload & performance  
   - **Methods:**  
     - **Wilcoxon signed-rank tests** for comparing workload and performance between on-beat and off-beat levels  
     - **Wilcoxon tests on NASA-TLX subscales** (Experience_1–5)  
     - **Spearman correlations** between SPHHQ scores and workload/performance  
     - **OLS regression model** predicting cognitive workload from SPHHQ, level, and their interaction  
     - **Correlations per SPHHQ subscale** (e.g., F1_annoyance, F3_noise_sensitivity) within each condition
         
6. **Exploratory Analysis**  
   - **Notebook section:** “Exploratory Analysis”  
   - **Sub-steps:**  
     - Re-check normality for exploratory variables  
     - Compute additional Spearman correlations
     - Run **mixed-design ANOVA** on task performance with:  
       - **Within-subjects factor:** beat condition (Minneapolis vs. Chicago)  
       - **Between-subjects factor:** musical training (low vs. high)  
       - **Dependent variable:** CorrectMoves

---

### Labels

Data Labels Explained – GameScore Dataset

| Column           | Description                                                                 |
|------------------|-----------------------------------------------------------------------------|
| `Code`           | Unique participant ID                                         |
| `Level`          | Experimental condition: Minneapolis = on-beat alignment with music, Chicago = off-beat alignment with music, Denver = no music |
| `CorrrrectMoves` | Number of movements made in sync with the visualized beat (note: spelling error in label) |
| `IncorrectMoves` | Number of movements made off the visualized beat                                           |
| `Coins`          | Total number of coins collected during the level                            |
| `Lives`          | Number of lives remaining at the end of the level (max = 3)                 |
| `GameOver`       | Number of times a player was game over       |
| `Notes`          | Manual observations recorded during or after gameplay (e.g. distractions, errors, or technical issues) |


Data Labels Explained – Demographics Dataset

| Column     | Description                                                                                 |
|------------|---------------------------------------------------------------------------------------------|
| `Q1`       | Participant code                                |
| `Q1.1`–`Q1.23` | Responses to the SP-HHQ questionnaire (23 items measuring susceptibility to audio input) |
| `Q2.1`     | Age of participant                                                                           |
| `Q3.1`     | Gender                                                                                       |
| `Q4.1`     | Highest completed level of education                                                         |
| `Q5.1`     | Self-rated musical training and/or experience (5-point Likert scale)                      |
| `Q6.1`     | Self-rated sense of rhythm                                                                  |
| `Q7.1`     | Frequency of listening to music while doing other tasks (e.g., working, studying, gaming)   |
| `Q8.1`     | Frequency of playing video games                                                             |
| `Q9.1`     | Previous experience with rhythm-based video games (open-text: name of game(s) if applicable) |


Data Labels Explained – GameStudy Dataset

| Column             | Description                                                                 |
|--------------------|-----------------------------------------------------------------------------|
| `Participation Code` | Unique participant ID            |
| `Q1`               | Experimental condition: Minneapolis = on-beat alignment with music, Chicago = off-beat alignment with music, Denver = no music |
| `Experience_1`     | NASA TLX – Mental Demand                                  |
| `Experience_2`     | NASA TLX – Temporal Demand                                    |
| `Experience_3`     | NASA TLX – Perceived Performance                           |
| `Experience_4`     | NASA TLX – Effort                                           |
| `Experience_5`     | NASA TLX – Frustration                                   |

---
### Participants that were removed

The following participants were excluded from analysis due to technical issues or invalid data:

| Participant ID | Reason for exclusion                                                             |
|----------------|----------------------------------------------------------------------------------|
| P0             | Test participant (used for debugging the experiment)                        |
| P6             | One level had to be replayed after results were accidentally closed              |
| P18            | Kept keys pressed continuously, resulting in invalid movement data               |
| P20            | Same issue as P18 — held down keys throughout     |
| P23            | Repeated key-holding behavior which led to unrepresentative data                       |
| P42            | Results screen was accidentally clicked away before saving                       |

These cases were manually identified and excluded during the data cleaning step in `DataAnalysis.ipynb`.


