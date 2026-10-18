# Assignment 5: Upgrading Base Game with Intelligent AI (NavMesh Pathfinding)
**Course Code**: ETCS406 | **Duration**: 4 Hours | **Total Marks**: 10

---

## 1. What This Upgrade Adds to the Base Game
In this practical, we upgrade the game with an **Intelligent Enemy / NPC Guard** that can navigate complex terrain:
- **Unity NavMesh**: Calculates walkable geometry and bakes an navigation mesh.
- **NavMeshAgent**: Directs the NPC character along the shortest path around walls and obstacles.
- **Smart Behavior Logic**:
  - **Patrol Mode**: Walks automatically between waypoints on the map.
  - **Chase Mode**: Senses the player character within a detection radius and chases via `SetDestination()`.
  - **Attack/Stop Mode**: Halts and faces the player when within interaction range.
  - **Color Feedback**: Green (Patrolling) -> Yellow (Chasing) -> Red (Attacking).

---

## 2. Step-by-Step Instructions (Click-by-Click)

### Step 1: Open Your Base Project
1. Open your Unity Project.
2. In the Project window, create a new scene: right-click `Assets/Scenes` -> **Create** -> **Scene**.
3. Name it `Scene_05_NavMesh_AI` and double-click to open it.
4. Copy the scripts from `Assignment_05_NavMesh_AI/Scripts/` into `Assets/Scripts/`:
   - `EnemyAIController.cs`
   - `SimplePlayerController3D.cs`
   - `AIStateIndicator.cs`

### Step 2: Build the Environment (Floor & Obstacles)
1. In Hierarchy, right-click -> **3D Object** -> **Plane**. Name it `GroundPlane`.
   - Scale: `3, 1, 3` (makes a large 30x30 arena).
2. Add Walls and Obstacles:
   - Right-click -> **3D Object** -> **Cube**. Name it `Obstacle_Wall1`.
   - Scale: `1, 3, 10`, Position: `0, 1.5, 0` (places a barrier in the center).
   - Add 2 or 3 smaller cubes around the arena to act as pillars/cover.

### Step 3: Bake the NavMesh (Crucial Step!)
1. Select all your floor and obstacle objects in the Hierarchy (`GroundPlane`, `Obstacle_Wall1`, etc.).
2. In the top-right of the **Inspector**, check the box **Static** (or click the dropdown and select **Navigation Static**).
3. Open the Navigation window:
   - Go to top menu: **Window** -> **AI** -> **Navigation** (in Unity 6, if using NavMeshSurface, you can simply add a `NavMeshSurface` component to `GroundPlane`).
4. In the Navigation window, click the **Bake** tab at the bottom.
5. Click the blue **Bake** button!
   - You will see a blue mesh appear over all walkable flat surfaces. Notice how the blue mesh neatly wraps around your walls!

### Step 4: Create the Player
1. Right-click Hierarchy -> **3D Object** -> **Capsule**. Name it `Player`.
2. Position: `-8, 1, -8`.
3. Set its Tag: at top of Inspector, set **Tag** to `Player`.
4. Add Component -> **Character Controller**.
5. Drag `SimplePlayerController3D.cs` onto `Player`.

### Step 5: Create the AI Enemy Guard
1. Right-click Hierarchy -> **3D Object** -> **Capsule**. Name it `EnemyAI`.
2. Position: `8, 1, 8`.
3. In Inspector, click **Add Component** -> add **NavMeshAgent**:
   - Set **Speed**: `5`
   - Set **Stopping Distance**: `1.8`
   - Set **Acceleration**: `8`
4. Drag `EnemyAIController.cs` onto `EnemyAI`:
   - Drag the `Player` GameObject into the **Player Target** slot.
   - Set **Detection Radius** to `10`.
   - Set **Attack Range** to `2`.
5. Create Waypoints:
   - In Hierarchy, right-click -> **Create Empty**. Name it `Waypoints`.
   - Create 3 empty children inside it: `Point1` (position `8, 0, -8`), `Point2` (position `-8, 0, 8`), `Point3` (position `0, 0, 8`).
   - Drag these 3 points into the **Waypoints** list in `EnemyAIController`.
6. Drag `AIStateIndicator.cs` onto `EnemyAI`.

### Step 6: Test & Document
1. Press the **Play (▶)** button!
2. Watch the AI patrol smoothly between the waypoints.
3. Move your player (WASD) near the AI — as soon as you enter its 10-meter detection sphere, its color turns yellow and it chases you!
4. Run behind the central wall — observe the AI intelligently pathfinding around the wall corner instead of walking into it!
5. Stop moving: when the AI catches up, its color turns red and it stops at attack range.
6. Take screenshots of:
   - The blue baked NavMesh in Scene view.
   - The Enemy Inspector showing `NavMeshAgent` settings.
   - The AI actively chasing the player around an obstacle.
