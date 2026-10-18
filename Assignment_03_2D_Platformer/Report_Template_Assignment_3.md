# LAB REPORT: PRACTICAL 3
**Course**: ETCS406 Game Development  
**Practical Title**: Develop a Simple 2D Platformer in Unity  
**Student Name**: [Your Name]  
**Roll Number / PRN**: [Your Roll Number]  
**Semester**: VII | **Date**: [Date]  

---

## 1. Objective
To design and implement a basic 2D platformer game using Unity, incorporating 2D sprites, the Tilemap system, Rigidbody2D physics, and fundamental C# scripting for player movement, jumping, ground detection, and collectible interactions.

---

## 2. Tools & Software Environment
- **Game Engine**: Unity Editor (Version 6000.5.4f1 / 2020.3+ LTS)
- **Programming Language**: C#
- **IDE**: Visual Studio / Visual Studio Code
- **Physics Engine**: Unity 2D Physics (Box2D integration)

---

## 3. Implementation Details

### 3.1 Project & Camera Setup
A 2D project was initialized. The Main Camera was configured with an Orthographic projection and coupled with a custom smooth-follow script (`SimpleCameraController.cs`) using `Vector3.SmoothDamp` to eliminate camera jitter.

### 3.2 Environment Design via Tilemap
- Created a `Grid` GameObject with a rectangular `Tilemap`.
- Integrated a `Tilemap Collider 2D` combined with a `Composite Collider 2D` set to `Static` geometry to optimize collision boundary calculations into continuous polygon meshes.
- Configured dedicated physics layers (`Ground`) for precise ground surface checks.

### 3.3 Player Physics & Mechanics
- Attached `Rigidbody2D` with `Continuous` collision detection and `Freeze Rotation Z` enabled to prevent tumbling.
- Implemented `PlayerMovement2D.cs`:
  - **Horizontal Movement**: Applied linear velocity along the X-axis in `FixedUpdate` based on `Input.GetAxisRaw("Horizontal")`.
  - **Ground Detection**: Utilized `Physics2D.OverlapCircle` targeting the player's ground-check transform against the `Ground` layer mask.
  - **Jumping**: Triggered vertical impulse force via velocity override when `Input.GetButtonDown("Jump")` is detected while grounded.

### 3.4 Gameplay Features & Collectibles
- Designed collectible coins with `CircleCollider2D` set as `Is Trigger`.
- Scripted `CoinCollectible.cs` utilizing `OnTriggerEnter2D` to interface with `GameManager2D` for score tracking, audio playback, and object destruction.

---

## 4. Evaluation Rubric & Self-Assessment

| Component | Max Marks | Description of Implementation |
|---|---|---|
| **Level Design & Tilemap Usage** | 3 | Constructed multi-tiered platforms, obstacles, and composite collision boundaries |
| **Player Movement & Controls** | 3 | Responsive WASD/Arrow movement, variable jump height, and ground-check logic |
| **Collision & Physics Setup** | 2 | Rigidbody2D physics, continuous collision detection, and trigger-based pickups |
| **Code Quality & Functionality** | 2 | Modular, clean C# scripts with separation of concerns and robust null-checks |
| **Total** | **10** | Complete playable 2D platformer implementation |

---

## 5. Screenshots & Evidence of Work
*(Insert screenshots here: Scene view of tilemap, Player Inspector settings, running gameplay)*

1. **Tilemap & Level Design in Scene View**:
   `[Insert Screenshot Here]`
2. **Player GameObject & Inspector Configuration**:
   `[Insert Screenshot Here]`
3. **Gameplay Session Showing Movement & Score Collection**:
   `[Insert Screenshot Here]`

---

## 6. Conclusion & Learning Outcomes
Through this practical, I learned how to assemble 2D levels using Unity's Tilemap and Palette, configure 2D physics components (`Rigidbody2D`, `CompositeCollider2D`), and script responsive player movement and trigger-based collectible systems in C#.
