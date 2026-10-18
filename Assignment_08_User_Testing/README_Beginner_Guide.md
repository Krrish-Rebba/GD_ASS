# Assignment 8: User Testing, Feedback Collection, and Game Iteration
**Course Code**: ETCS406 | **Duration**: 3 Hours | **Total Marks**: 10

---

## 1. What You Are Doing in This Practical
In Practical 8, you evaluate your **fully upgraded game** through structured user testing:
1. **Prepare Testing**: Recruit 3–4 testers (classmates or friends). Use the provided `User_Testing_Feedback_Form.md`.
2. **Conduct Sessions**: Have testers play through the levels (moving, jumping on springboards, avoiding the NavMesh enemy guard, and choosing dialogue options).
3. **Analyze Data**: Tally the ratings and categorize comments into the `Feedback_Analysis_Matrix.md`.
4. **Iterate & Patch**: Apply the `GameplayBalancePatch.cs` (Coyote Time & Jump Buffering) and balance enemy speed to fix player complaints!
5. **Document**: Capture Before vs After proof for your lab report!

---

## 2. Step-by-Step Instructions (Click-by-Click)

### Step 1: Prepare the Game Build
1. In Unity, open your base project.
2. Ensure your scenes (`Scene_03`, `Scene_04`, `Scene_05`, `Scene_06`) are listed in **File** -> **Build Settings** -> **Scenes in Build**.
3. You can either test inside the Unity Editor directly or click **Build and Run** to create a standalone Windows `.exe`.

### Step 2: Run the Playtest Sessions
1. Seat your tester in front of the screen.
2. Brief them briefly: *"Use WASD/Arrow keys to move, Spacebar to jump. Explore the level, interact with the Elder, and try to escape the enemy guard."*
3. Watch them play quietly without interfering or telling them what to press! Note down where they hesitate, stumble, or smile.
4. Hand them the `User_Testing_Feedback_Form.md` to fill out their scores and feedback.

### Step 3: Analyze the Results
1. Average the numerical scores across the 4 testers.
2. Identify the #1 gameplay issue:
   - *Example*: Almost all testers experienced dropped jumps when pressing Spacebar right as they slipped off platform edges!

### Step 4: Apply the Iteration Patch
1. Copy `GameplayBalancePatch.cs` into your project's `Assets/Scripts/` folder.
2. Attach it to your `Player` GameObject.
3. In `EnemyAIController.cs`, fine-tune the chase speed from `6f` to `4.8f` to give players a fair chance to navigate around obstacles.

### Step 5: Verify the Improvement (Playtest Again)
1. Run the game again — test jumping off ledges. Notice how Coyote Time gives you a 0.15-second grace window to jump smoothly even if you pressed Spacebar a millisecond after leaving the platform!
2. Take side-by-side screenshots showing:
   - Tester filling out the feedback form or gameplay in action.
   - The Player Inspector with the `GameplayBalancePatch` component.
   - The Before vs After performance data.
