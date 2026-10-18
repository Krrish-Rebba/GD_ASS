# Unified Base Game Guide: "Adventure Quest" (ETCS406)

Welcome! If you **know nothing about Unity**, this unified architecture is designed specifically for you.

Instead of trying to build 6 separate disconnected games from scratch, we build **ONE BASE GAME** ("Adventure Quest") and make progressive, evolutionary upgrades on it for each assignment. Every assignment adds a new skill and feature directly onto your existing game.

---

## 1. The 6-Stage Evolution of Your Game

```
[Assignment 3: Base Game]
   │  • Player Controls (WASD / Space Jump)
   │  • Platforms (Tilemap System)
   │  • Collectibles & Score UI
   ▼
[Assignment 4: Physics Upgrade]
   │  • High-Bounciness Physics Material
   │  • Springboards & Trampolines (Impulse Force)
   │  • Dynamic Rolling Hazards & Collision Telemetry
   ▼
[Assignment 5: AI Navigation Upgrade]
   │  • Walkable Geometry (NavMesh Baking)
   │  • Enemy Guard with Obstacle Avoidance (NavMeshAgent)
   │  • Visual State Indicator (Patrol vs Chase vs Attack)
   ▼
[Assignment 6: Narrative & Cutscene Upgrade]
   │  • Cinematic Opening Pan (Unity Timeline)
   │  • Character Animation Controller (Idle & Talking)
   │  • Interactive NPC Dialogue with Branching Choices
   ▼
[Assignment 7: AR/XR Showcase Upgrade]
   │  • Augmented Reality Surface Detection (AR Foundation)
   │  • Tap-to-Place 3D Relic / Trophy (with PC Editor Simulator)
   │  • Interactive Color Swapping, 360° Drag Rotation, & Pinch Scaling
   ▼
[Assignment 8: Playtesting, Iteration & Polish]
      • Structured User Testing with 4 Testers
      • Feedback Matrix & Issue Prioritization
      • Implementation of "Coyote Time" & Jump Buffering Patch
      • Final Submission-Ready Documentation
```

---

## 2. Assignment Subfolders & File Overview

| Assignment | Subfolder Link | Core Script(s) | Guide & Report |
|---|---|---|---|
| **Practical 3** | [`Assignment_03_2D_Platformer`](./Assignment_03_2D_Platformer) | `PlayerMovement2D.cs`<br>`CoinCollectible.cs`<br>`SimpleCameraController.cs`<br>`GameManager2D.cs` | [`README_Beginner_Guide.md`](./Assignment_03_2D_Platformer/README_Beginner_Guide.md)<br>[`Report_Template_Assignment_3.md`](./Assignment_03_2D_Platformer/Report_Template_Assignment_3.md) |
| **Practical 4** | [`Assignment_04_Physics_Simulation`](./Assignment_04_Physics_Simulation) | `BouncySpringboard.cs`<br>`DynamicPhysicsHazard.cs`<br>`PhysicsTelemetryUI.cs` | [`README_Beginner_Guide.md`](./Assignment_04_Physics_Simulation/README_Beginner_Guide.md)<br>[`Report_Template_Assignment_4.md`](./Assignment_04_Physics_Simulation/Report_Template_Assignment_4.md) |
| **Practical 5** | [`Assignment_05_NavMesh_AI`](./Assignment_05_NavMesh_AI) | `EnemyAIController.cs`<br>`SimplePlayerController3D.cs`<br>`AIStateIndicator.cs` | [`README_Beginner_Guide.md`](./Assignment_05_NavMesh_AI/README_Beginner_Guide.md)<br>[`Report_Template_Assignment_5.md`](./Assignment_05_NavMesh_AI/Report_Template_Assignment_5.md) |
| **Practical 6** | [`Assignment_06_Interactive_Story`](./Assignment_06_Interactive_Story) | `DialogueManager.cs`<br>`StoryBranchController.cs` | [`README_Beginner_Guide.md`](./Assignment_06_Interactive_Story/README_Beginner_Guide.md)<br>[`Report_Template_Assignment_6.md`](./Assignment_06_Interactive_Story/Report_Template_Assignment_6.md) |
| **Practical 7** | [`Assignment_07_AR_VR_XR`](./Assignment_07_AR_VR_XR) | `ARItemPlacementController.cs`<br>`XRInteractiveObject.cs` | [`README_Beginner_Guide.md`](./Assignment_07_AR_VR_XR/README_Beginner_Guide.md)<br>[`Report_Template_Assignment_7.md`](./Assignment_07_AR_VR_XR/Report_Template_Assignment_7.md) |
| **Practical 8** | [`Assignment_08_User_Testing`](./Assignment_08_User_Testing) | `GameplayBalancePatch.cs` | [`User_Testing_Feedback_Form.md`](./Assignment_08_User_Testing/User_Testing_Feedback_Form.md)<br>[`Feedback_Analysis_Matrix.md`](./Assignment_08_User_Testing/Feedback_Analysis_Matrix.md)<br>[`Report_Template_Assignment_8.md`](./Assignment_08_User_Testing/Report_Template_Assignment_8.md) |

---

## 3. How to Execute Each Practical in Unity

### The 5 Essential Unity Windows
1. **Hierarchy (Left)**: The list of every object in the current scene (Player, Camera, Platforms, Enemy).
2. **Scene View (Center Top)**: The visual playground where you place, move, and rotate objects.
3. **Game View (Center Tab)**: What the player sees when the game is running.
4. **Inspector (Right)**: The properties panel where you attach components and adjust speed, mass, jump force, or colors.
5. **Project Window (Bottom)**: Your asset library (`Assets/Scripts`, `Assets/Scenes`, etc.).

### Step-by-Step Workflow
1. Launch Unity and open your project.
2. For each assignment, copy the pre-written C# scripts from that assignment's `Scripts/` folder directly into your Unity project's `Assets/Scripts/` folder.
3. Open the assignment's `README_Beginner_Guide.md` and follow the click-by-click instructions.
4. Press the **Play (▶)** button to test your game.
5. Take screenshots of the scene view, inspector, and active gameplay.
6. Open the `Report_Template.md` for that assignment, paste your screenshots, and export/save as PDF for submission!
