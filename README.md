# Rhythm-Thesis-Mijke-Taal

This repository contains all the files to make this thesis rhythm game and all the data collected in the experiment. 

```text
to be added
```
---
## Game Description

- **Type**: Rhythm-based timing game  
- **Mechanics**: Player can move only on the visualized beat; moving off-beat prevents movement
- **Beat Visualization**: A pulsing circle indicates the rhythm — the correct moment to move is when the circle is at its largest size  
- **Feedback**:  
  - **On-beat**: Movement is allowed, and the circle flashes **green**  
  - **Off-beat**: Movement is blocked, and the circle flashes **red**  
- **Duration**: Each level lasts exactly 3 minutes  
- **Levels**: Auto-transition from Level 1 → 4, Level 2 → 5, Level 3 → 6  
- **End State**: At the end of each level, a **“Good Job!”** screen appears — there is no traditional win/lose mechanic
---

## Running the Game

To run the game:

1. Open **Unity Hub**  
2. Add the project from `/prototype/src/` (after unzipping)  
3. Open the `LevelSelector.unity` scene  
4. Play the game in the Unity editor or export it using **Build Settings**
