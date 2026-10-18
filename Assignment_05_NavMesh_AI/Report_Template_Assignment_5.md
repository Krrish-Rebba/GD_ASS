# LAB REPORT: PRACTICAL 5
**Course**: ETCS406 Game Development  
**Practical Title**: Build a Unity-Based Game Prototype Integrating Simple AI (NavMesh Pathfinding)  
**Student Name**: [Your Name]  
**Roll Number / PRN**: [Your Roll Number]  
**Semester**: VII | **Date**: [Date]  

---

## 1. Objective
To design and implement an artificial intelligence navigation system in Unity using NavMesh baking and the `NavMeshAgent` component, enabling non-player characters (NPCs) to intelligently pathfind around static obstacles, patrol waypoints, and dynamically chase the player character.

---

## 2. Tools & Software Environment
- **Game Engine**: Unity Editor (Version 6000.5.4f1 / 2020.3+ LTS)
- **AI System**: Unity Navigation (NavMesh & NavMeshAgent)
- **Scripting Language**: C#
- **IDE**: Visual Studio / Visual Studio Code

---

## 3. Implementation Details

### 3.1 Environment & NavMesh Generation
- Assembled an arena environment consisting of a ground surface and multiple static obstacles/barriers.
- Marked all boundary and floor geometry as `Navigation Static`.
- Baked the NavMesh using the Navigation tool to compute convex walkable polygons and calculate agent radius clearances and step heights.

### 3.2 NPC Architecture & NavMeshAgent Configuration
- Attached a `NavMeshAgent` to the enemy character GameObject.
- Configured key physical navigation properties:
  - **Speed**: $3.5\text{ m/s}$ (Patrol) / $6.0\text{ m/s}$ (Chase)
  - **Stopping Distance**: $1.8\text{ m}$
  - **Acceleration**: $8.0\text{ m/s}^2$
  - **Obstacle Avoidance**: Set to High Quality.

### 3.3 AI State Machine Logic (`EnemyAIController.cs`)
Implemented a 3-state finite state machine (FSM):
1. **Patrol State**: Iterates sequentially through an array of waypoint vectors using `agent.SetDestination()`. Automatically detects waypoint arrival when `agent.remainingDistance < 0.8f`.
2. **Chase State**: Triggered when the Euclidean distance between NPC and Player is less than or equal to the detection threshold ($\le 10\text{ m}$). Dynamically updates `agent.SetDestination(player.position)` each frame.
3. **Attack / Stop State**: Triggered within close combat range ($\le 2\text{ m}$). Halts the agent (`agent.isStopped = true`) and executes `Quaternion.Slerp` rotation to maintain visual lock on the player.

### 3.4 Visual State Indicator (`AIStateIndicator.cs`)
- Dynamically swaps the enemy's material color (Green for Patrol, Yellow for Chase, Red for Attack) to provide immediate visual confirmation of state transitions.

---

## 4. Evaluation Rubric & Self-Assessment

| Component | Max Marks | Description of Implementation |
|---|---|---|
| **NavMesh Setup & Environment** | 3 | Static environmental geometry configuration and successful NavMesh baking |
| **NPC Configuration & Movement** | 3 | Rigged `NavMeshAgent` with appropriate speed, acceleration, and stopping distances |
| **AI Scripting & Behavior Logic** | 2 | Implemented 3-state FSM (Patrol, Chase, Attack) with dynamic target evaluation |
| **Code Quality & Debugging** | 2 | Clean C# architecture, scene gizmos for radius visualization, and material feedback |
| **Total** | **10** | Complete AI pathfinding practical implementation |

---

## 5. Screenshots & Evidence of Work
*(Insert screenshots here)*

1. **Scene View Displaying Baked Blue NavMesh & Obstacle Clearances**:
   `[Insert Screenshot Here]`
2. **Enemy NPC Inspector Showing NavMeshAgent & AI Controller**:
   `[Insert Screenshot Here]`
3. **Active Playtest Showing Enemy Pathfinding Around Central Wall to Chase Player**:
   `[Insert Screenshot Here]`

---

## 6. Conclusion
This practical provided essential hands-on experience in generating Unity NavMeshes, configuring AI navigation agents, and scripting autonomous behavior routines capable of real-time obstacle avoidance and target pursuit.
