# Assignment 3: Develop a Simple 2D Platformer in Unity
**Course Code**: ETCS406 | **Duration**: 4 Hours | **Total Marks**: 10

---

## 1. What You Are Building
A classic 2D side-scrolling platformer game where:
- The player moves left/right with `A`/`D` or Arrow Keys and jumps with `Spacebar`.
- The environment has platforms created using Unity's **Tilemap** system.
- The player collects items (coins/gems) which update the on-screen score.
- The camera follows the player smoothly.

---

## 2. Step-by-Step Instructions (Click-by-Click)

### Step 1: Create the Project
1. Open **Unity Hub**.
2. Click the blue **New Project** button.
3. Select the **2D (Core)** template.
4. Set the project name to `Platformer2D_Practical3` and set the location to this folder (`Assignment_03_2D_Platformer`).
5. Click **Create project**. Wait for the Unity Editor to load.

### Step 2: Import the Pre-Written Scripts
1. In the bottom **Project** window, right-click on `Assets` -> **Create** -> **Folder**. Name it `Scripts`.
2. Copy the 4 C# files from this folder's `Scripts/` directory into that `Assets/Scripts/` folder:
   - `PlayerMovement2D.cs`
   - `CoinCollectible.cs`
   - `SimpleCameraController.cs`
   - `GameManager2D.cs`

### Step 3: Build the Environment (Tilemap)
1. In the **Hierarchy** window, right-click -> **2D Object** -> **Tilemap** -> **Rectangular**.
   - You will see a `Grid` GameObject with a child named `Tilemap`.
2. Select the `Tilemap` child object in Hierarchy:
   - In the **Inspector** on the right, click **Add Component** and add **Tilemap Collider 2D**.
   - Also add a **Composite Collider 2D** (this automatically adds a `Rigidbody2D` — change its **Body Type** to `Static`).
   - On the `Tilemap Collider 2D`, check the box **Used By Composite**.
3. Create platforms:
   - Go to top menu: **Window** -> **2D** -> **Tile Palette**.
   - Click **Create New Palette** -> name it `LevelTiles` -> save it in `Assets`.
   - Drag any 2D sprite or ground image into the palette.
   - Select the brush icon and paint platforms in the **Scene** view.

### Step 4: Create the Player Character
1. In Hierarchy, right-click -> **2D Object** -> **Sprites** -> **Capsule** (or **Square**).
2. Rename this object to `Player`.
3. Set its Tag: at top of Inspector, click **Tag: Untagged** -> select **Player**.
4. In Inspector, click **Add Component** -> add **Rigidbody 2D**:
   - Set **Collision Detection** to `Continuous`.
   - Expand **Constraints** -> check **Freeze Rotation Z** (prevents player from falling over).
5. Click **Add Component** -> add **Box Collider 2D**.
6. Create Ground Check:
   - In Hierarchy, right-click on `Player` -> **Create Empty**.
   - Rename it to `GroundCheck`.
   - In Scene view, drag this object slightly below the player's feet (Y position around `-0.6`).
7. Create Ground Layer:
   - Click the `Tilemap` object -> in Inspector, click **Layer** -> **Add Layer...** -> Type `Ground` in Layer 8.
   - Select `Tilemap` again and set its Layer to `Ground`.
8. Attach Script:
   - Select `Player` -> drag `PlayerMovement2D.cs` onto the Inspector.
   - Drag the `GroundCheck` object into the **Ground Check Point** slot.
   - Set **Ground Layer** dropdown to `Ground`.
   - Set **Move Speed** to `8` and **Jump Force** to `12`.

### Step 5: Setup Camera & Collectibles
1. Select `Main Camera` in Hierarchy.
   - Drag `SimpleCameraController.cs` onto it.
   - Drag the `Player` object into the **Target** slot.
2. Create a Coin:
   - In Hierarchy, right-click -> **2D Object** -> **Sprites** -> **Circle**.
   - Name it `Coin`, scale it down to `0.5, 0.5, 1`, and change color to Yellow in `Sprite Renderer`.
   - Click **Add Component** -> **Circle Collider 2D** -> **CHECK `Is Trigger`** (Crucial!).
   - Drag `CoinCollectible.cs` onto it.
   - Duplicate it (`Ctrl + D`) across your platforms!

### Step 6: Test & Record
1. Click the **Play (▶)** button at top center.
2. Use `A`/`D` to move and `Spacebar` to jump! Collect coins.
3. Take screenshots (`Win + Shift + S`) showing:
   - The Tilemap and Level in Scene view.
   - The Player Inspector with Rigidbody2D and PlayerMovement2D.
   - Active gameplay with collected coins.
4. Record a 30-second gameplay video (Press `Win + Alt + R` to record with Windows Game Bar).
