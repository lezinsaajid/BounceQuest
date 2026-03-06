# Bounce Quest - Unity 2D Platformer

Welcome to the Bounce Quest project! This project has been initialized with the necessary C# scripts for a complete 2D platforming experience inspired by the classic Nokia Bounce game.

## Folder Structure

The basic Unity structure has been outlined for you:
- **Assets/Scripts/**: Contains all gameplay logic (Player, Collectible, Game Manager, Hazard, Goal)
- **Assets/Prefabs/**: For saving GameObjects like Rings, Spikes, and the Player.
- **Assets/Sprites/**: Used for storing placeholder basic shapes (Circle, Square, Triangle).
- **Assets/Scenes/**: Save your levels here (`MainMenu`, `Level1`, `Level2`).
- **Assets/UI/**: UI Text fonts and prefabs.

## Scene Setup Instructions

### 1. Preparation (Sprites & Physics)
1. In the Unity Project window, right-click inside `Assets/Sprites/` -> **Create > 2D > Sprites**.
   - Create a **Circle** (Name: `Ball`)
   - Create a **Square** (Name: `Platform`)
   - Create an **Isometric Triangle** (Name: `Spike`)
2. In **Edit > Project Settings > Tags and Layers**, add a new Tag: `Platform`.

### 2. The Player (Red Bouncing Ball)
1. Drag the `Ball` sprite into your Scene. Name it `Player`.
2. Set its Color to **Red** inside the Sprite Renderer.
3. Change its Tag to **Player**.
4. Add components:
   - **Rigidbody2D**: 
     - Set *Collision Detection* to `Continuous`.
     - (Optional) Change *Gravity Scale* to `2` for snappier falling.
   - **Circle Collider 2D**.
   - **Physics Material 2D**: Right-click in `Assets/` -> Create -> 2D -> Physics Material 2D. Set Bounciness to `0.6` and Friction to `0`. Attach to the Collider.
   - Attach the **PlayerController** script. Ensure Move Speed is 5 and Jump Force is 10.

### 3. The Camera
1. Select the `Main Camera`.
2. To follow the player smoothly, you can attach a parent to the Player or use a basic script. For a basic start, Drag the `Main Camera` onto `Player` to make it a child. (Or use Unity Cinemachine/Virtual Camera for better results).

### 4. The Environment (Platforms)
1. Drag the `Platform` sprite into the Scene.
2. Scale it into a wide rectangle. 
3. Change its Color as you like (e.g., Green or Gray).
4. Set its Tag to **Platform**.
5. Add a **Box Collider 2D**.
6. Save this as a Prefab in `Assets/Prefabs/`.

### 5. Hazards (Spikes)
1. Drag the `Spike` sprite into the Scene.
2. Add a **Polygon Collider 2D** (to fit the triangle shape). Check the **Is Trigger** box (Optional but recommended for `Hazard.cs`).
3. Attach the **Hazard** script.
4. Save as Prefab in `Assets/Prefabs/`.

### 6. Collectibles (Rings)
1. Drag the `Ball` sprite into the scene. Scale it slightly smaller.
2. Color it **Yellow**.
3. Add a **Circle Collider 2D** and check **Is Trigger**.
4. Attach the **Collectible** script. Set `Score Value` to 10.
5. Save as Prefab in `Assets/Prefabs/`.

### 7. The Goal
1. Drag a `Platform` sprite into the Scene to act as the goal post. Scale and color it distinctly (e.g., Gold/White).
2. Add a **Box Collider 2D** and check **Is Trigger**.
3. Attach the **Goal** script.

### 8. The Game Manager and UI
1. Create an Empty GameObject and name it `GameManager`.
2. Attach the **GameManager** script.
3. Add a Canvas (Right-click Hierarchy -> UI -> Canvas). Scale Mode: Scale With Screen Size.
4. Inside the Canvas, add:
   - **Text (Legacy)**: Name it `ScoreText`. Anchor Top-Left.
   - **Panel**: Name it `GameOverPanel`. Disable it by default. 
     - Add a **Text** inside explaining "Game Over! Press R to Restart".
5. Drag `ScoreText` and `GameOverPanel` to the `GameManager` script slots in the Inspector.

### 9. Build Settings
For scene transitions to work:
1. Go to **File > Build Settings**.
2. Click **Add Open Scenes**. Ensure your Main Menu is Index `0`, Level1 is `1`, Level2 is `2`, etc.

## Controls
- **A/D or Left/Right Arrow**: Move Horizontal
- **Space**: Jump (Only when touching the "Platform" tag)
- **R**: Restart Level
