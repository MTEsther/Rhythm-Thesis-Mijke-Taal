# Rhythm-Thesis-Mijke-Taal

This repository contains all the files to make this thesis rhythm game and all the data collected in the experiment. 

```text
+-- Thesis Game/
|   +-- Assets/
|   |   +-- Animation/
|   |   |   +-- Enemy1/
|   |   |   +-- Player/
|   |   +-- Audio/
|   |   |   +-- 7_t.o.e.wav
|   |   +-- Input/
|   |   |   +-- InputManager.cs
|   |   |   +-- Test.cs
|   |   +-- Level 1.unity
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
|   |   |   |   |   +-- ui-small-icons.png
|   |   +-- Scenes/
|   |   +-- Script/
|   |   |   +-- BeatPulseEffect.cs
|   |   |   +-- BeatVisualizer.cs
|   |   |   +-- CameraFollow.cs
|   |   |   +-- CoinManager.cs
|   |   |   +-- EndScreenScript.cs
|   |   |   +-- EnemyPatrol.cs
|   |   |   +-- GameOverScreen.cs
|   |   |   +-- GameTimer.cs
|   |   |   +-- LevelSelector.cs
|   |   |   +-- LevelTransitionHelper.cs
|   |   |   +-- PlayerCollision.cs
|   |   |   +-- StatsTracker.cs
|   |   |   +-- Player/
|   |   |   |   +-- HealthManager.cs
|   |   |   |   +-- PlayerMovement.cs
|   |   +-- Settings/
|   |   +-- TextMesh Pro/
|   |   +-- TinyPRGTown/
|   |   |   +-- Artwork/
|   |   |   |   +-- Sprites/
|   |   |   |   |   +-- hero.png
|   |   |   +-- Scenes/
|   |   +-- Top Down Adventure Assets/
|   |   |   +-- Scenes/
|   |   |   +-- sounds/
|   |   |   +-- Visuals/
|   |   |   |   +-- CHARACTERS/
|   |   |   |   |   +-- npc/
|   |   |   |   |   +-- player/
|   |   |   |   |   |   +-- hero1.png
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
|   |   |   |   |   |   |   +-- tilest-world.png/
|   |   |   |   |   +-- waterfall/
|   |   |   |   +-- FX/
|   |   |   |   +-- HUD/
|   |   |   |   +-- OBJECTS/
|   |   |   |   |   +-- box-splash/
|   |   |   |   |   +-- box-water/
|   |   |   |   |   +-- button/
|   |   |   |   |   +-- coin/
|   |   |   |   |   |   +-- coin1.png/
|   |   |   |   |   |   +-- coin2.png/
|   |   |   |   |   |   +-- coin3.png/
|   |   |   |   |   |   +-- coin4.png/
|   |   |   |   |   +-- items/
|   |   |   |   |   +-- sprites/

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
  - **Level 1 – Minneapolis**: On-beat rhythm with music  
  - **Level 2 – Chicago**: Off-beat rhythm with music (syncopated)  
  - **Level 3 – Denver**: No music, only visual rhythm  
  - Auto-transition to Level 4, 5, and 6 respectively  
- **End State**: At the end of each level, a **“Good Job!”** screen appears — there is no traditional win/lose mechanic

---

### Running the Game

To run the game:

1. Open **Unity Hub**  
2. Add the project from `/prototype/src/` (after unzipping)  
3. Open the `Level Selection.unity` scene  
4. Play the game in the Unity editor or export it using **Build Settings**

---

### Visuals & Animation

- The player and enemies have directional walking animations (up, down, left, right) to match movement direction.
- Animations are handled using Unity Animator Controllers and switch based on input direction.
- There are no rhythm-specific animations, but the player's sprite color changes to indicate beat accuracy: green (on-beat) or red (off-beat).
- A pulsing circle expands and contracts on screen to visualize the rhythm, implemented via code (`BeatPulseEffect.cs`).
- The rhythm is synchronized to a custom audio track (`7_t.o.e.wav`) with a fixed tempo of 120 BPM.
- Movement logic and beat detection are implemented in custom scripts like `PlayerMovement.cs` and `StatsTracker.cs`.

---

### Scripts

Core game functionality is implemented through custom C# scripts located in `Assets/Script/`. This includes:

- Player movement and beat detection (`PlayerMovement.cs`, `BeatPulseEffect.cs`)
- Level logic, timers, and transitions (`GameTimer.cs`, `LevelTransitionHelper.cs`, `LevelSelector.cs`)
- Feedback and statistics tracking (`StatsTracker.cs`, `EndScreenScript.cs`, `GameOverScreen.cs`)
- Basic enemy behavior (`EnemyPatrol.cs`)
- Coin collection and health (`CoinManager.cs`, `HealthManager.cs`)


