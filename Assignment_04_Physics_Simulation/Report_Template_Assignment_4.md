# LAB REPORT: PRACTICAL 4
**Course**: ETCS406 Game Development  
**Practical Title**: Implement Unity's Physics Components to Simulate Motion and Collisions  
**Student Name**: [Your Name]  
**Roll Number / PRN**: [Your Roll Number]  
**Semester**: VII | **Date**: [Date]  

---

## 1. Objective
To understand and apply Unity’s 2D physics components to simulate realistic motion, elasticity, restitution, and collision dynamics by upgrading the base platformer game with interactive springboards, dynamic rolling physics hazards, physics materials, and collision impact telemetry.

---

## 2. Tools & Software Environment
- **Game Engine**: Unity Editor (Version 6000.5.4f1 / 2020.3+ LTS)
- **Physics Engine**: Unity 2D Physics (Box2D)
- **Programming Language**: C#
- **IDE**: Visual Studio / Visual Studio Code

---

## 3. Implementation Details

### 3.1 Physics Material 2D Configuration
Created a custom `PhysicsMaterial2D` named `HighBounciness`:
- **Bounciness ($e$)**: Configured to `0.85` to ensure realistic energy rebound upon impact.
- **Friction**: Set to `0.1` to reduce surface resistance during angular movement.

### 3.2 Springboard & Impulse Dynamics
Implemented `BouncySpringboard.cs`:
- Evaluates `Collision2D.relativeVelocity` to confirm downward landing angle.
- Uses `rb.AddForce(Vector2.up * bounceImpulse, ForceMode2D.Impulse)` to apply an instant momentum boost, launching the player onto elevated platforms.
- Includes a squash-and-stretch coroutine for responsive visual feedback.

### 3.3 Dynamic Physics Hazards
Implemented `DynamicPhysicsHazard.cs`:
- Configured dynamic `Rigidbody2D` with customizable mass ($3\text{ kg}$) and continuous collision detection.
- Computes kinetic energy ($E_k = \frac{1}{2} m v^2$) on collision and logs impact telemetry in real-time.
- Applies directional knockback impulses to the player upon heavy impact.

### 3.4 Live Telemetry & Debugging
- `PhysicsTelemetryUI.cs` hooks into the player's `Rigidbody2D` to output live velocity vector components ($v_x, v_y$), net speed, and collision mode directly on the game canvas.

---

## 4. Evaluation Rubric & Self-Assessment

| Component | Max Marks | Description of Implementation |
|---|---|---|
| **Physics Setup (Rigidbody, Collider)** | 3 | Configured mass, continuous collision detection, and Physics Material 2D bounciness |
| **Motion & Force Application** | 3 | Applied `ForceMode2D.Impulse` on springboards and directional knockback forces |
| **Collision Detection & Response** | 2 | Implemented `OnCollisionEnter2D`, relative velocity evaluation, and visual feedback |
| **Code Quality & Debugging** | 2 | Modular C# architecture with real-time on-screen telemetry and console logging |
| **Total** | **10** | Complete physics simulation upgrade |

---

## 5. Screenshots & Evidence of Work
*(Insert screenshots here)*

1. **Physics Material 2D Inspector Properties**:
   `[Insert Screenshot Here]`
2. **Springboard Actuation & Player Launch in Scene View**:
   `[Insert Screenshot Here]`
3. **Console Log Output with Impact Velocity Telemetry**:
   `[Insert Screenshot Here]`

---

## 6. Conclusion
This practical successfully expanded our base game with realistic physics simulation, demonstrating the difference between continuous forces and instantaneous impulses, the practical utility of physics materials, and robust collision handling.
