# Assignment 4: Upgrading Base Game with Advanced Physics Simulation
**Course Code**: ETCS406 | **Duration**: 2 Hours | **Total Marks**: 10

---

## 1. What This Upgrade Adds to the Base Game
In this practical, we upgrade the **Adventure Quest base game** created in Assignment 3 by adding interactive physics features:
1. **Physics Material 2D (`BouncySpring`)**: Surface elasticity that bounces objects naturally.
2. **Interactive Springboards / Trampolines (`BouncySpringboard.cs`)**: Launches the player high into the air using `AddForce(ForceMode2D.Impulse)` when stepped on.
3. **Dynamic Physics Hazards (`DynamicPhysicsHazard.cs`)**: Rolling boulders that react to gravity, bounce down slopes, and knock the player back on high-speed impact.
4. **Live On-Screen Telemetry (`PhysicsTelemetryUI.cs`)**: Displays live velocity, momentum, and impact speed on screen for debugging.

---

## 2. Step-by-Step Instructions (Click-by-Click)

### Step 1: Open Your Base Game Project
1. Open the Unity project you created in **Assignment 3**.
2. Copy the new scripts from `Assignment_04_Physics_Simulation/Scripts/` into your project's `Assets/Scripts/` folder:
   - `BouncySpringboard.cs`
   - `DynamicPhysicsHazard.cs`
   - `PhysicsTelemetryUI.cs`

### Step 2: Create a 2D Physics Material
1. In the **Project** window, right-click `Assets` -> **Create** -> **2D** -> **Physics Material 2D** (or **Custom Physics Material 2D**).
2. Name it `HighBounciness`.
3. In the Inspector on the right:
   - Set **Bounciness**: `0.85` (0 = no bounce, 1 = maximum bounce).
   - Set **Friction**: `0.1` (slippery surface).

### Step 3: Add a Bouncy Springboard Platform
1. In the **Hierarchy** window, right-click -> **2D Object** -> **Sprites** -> **Square**.
2. Rename it to `Springboard`.
3. Position it on the ground under a high ledge (e.g., `X: 4, Y: -1`). Scale it to `2, 0.4, 1`.
4. In Inspector, change its color to Bright Green or Yellow.
5. Click **Add Component** -> add **Box Collider 2D**:
   - In the **Material** slot, drag the `HighBounciness` material you just created!
6. Click **Add Component** -> drag `BouncySpringboard.cs` onto it.
   - Set **Bounce Impulse** to `18`.

### Step 4: Add a Dynamic Rolling Boulder
1. In Hierarchy, right-click -> **2D Object** -> **Sprites** -> **Circle**.
2. Rename to `RollingBoulder`.
3. Position it at the top of a slope/platform (e.g., `X: 8, Y: 4`).
4. Click **Add Component** -> add **Rigidbody 2D**:
   - Set **Mass** to `3` (heavier than the player).
   - Set **Collision Detection** to `Continuous`.
5. Click **Add Component** -> add **Circle Collider 2D**:
   - Drag `HighBounciness` into its Material slot.
6. Drag `DynamicPhysicsHazard.cs` onto it.

### Step 5: Add the On-Screen Physics Telemetry
1. In Hierarchy, right-click -> **UI** -> **Text** (or TextMeshPro).
2. Rename to `PhysicsTelemetryHUD`.
3. Attach `PhysicsTelemetryUI.cs` to it.
4. Drag your `Player` object into the **Target Rigidbody** field.

### Step 6: Test & Document
1. Press the **Play (▶)** button!
2. Run your player onto the Springboard — watch the player get catapulted high into the air!
3. Push the Rolling Boulder — watch it tumble down with real angular velocity and bounce.
4. Check the Console window for `[Physics Practical 4]` logs showing exact impact velocity and kinetic energy.
5. Take screenshots of:
   - The Inspector showing `Physics Material 2D` settings.
   - The Player being launched by the Springboard.
   - The Console log output with collision speed.
