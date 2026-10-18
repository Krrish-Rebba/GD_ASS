# Assignment 7: Upgrading Base Game with AR/VR (XR Interactive Mode)
**Course Code**: ETCS406 | **Duration**: 4 Hours | **Total Marks**: 10

---

## 1. What This Upgrade Adds to the Base Game
In this practical, we upgrade the game by adding an **AR / XR Trophy Showcase Mode**:
- Allows the player to view, place, and inspect 3D relics or character models in Augmented Reality on a real or simulated surface.
- Implements:
  - **Surface Raycasting**: Detects horizontal planes (tables, floor).
  - **Touch Placement**: Places the game asset onto the surface on tap.
  - **Interactive Controls**: Touch/click to cycle colors, drag to rotate 360 degrees, and scroll/pinch to scale.
  - **Dual Compatibility**: Runs seamlessly on mobile AR (AR Foundation) AND inside the Unity Editor simulator on your PC!

---

## 2. Step-by-Step Instructions (Click-by-Click)

### Step 1: Open Your Base Project
1. Open your Unity Project.
2. In Project window, create a new scene: right-click `Assets/Scenes` -> **Create** -> **Scene** -> name it `Scene_07_XR_Showcase`.
3. Copy the scripts from `Assignment_07_AR_VR_XR/Scripts/` into `Assets/Scripts/`:
   - `ARItemPlacementController.cs`
   - `XRInteractiveObject.cs`

### Step 2: Install AR / XR Packages (If Deploying to Mobile)
1. In Unity top menu: **Window** -> **Package Manager**.
2. Select **Packages: Unity Registry** from the dropdown.
3. Search for and install:
   - **AR Foundation**
   - **XR Interaction Toolkit** (optional for VR)

### Step 3: Build the XR Showcase Scene
1. Create a Floor Surface (for PC Editor testing):
   - In Hierarchy, right-click -> **3D Object** -> **Plane**. Position at `0, 0, 0`.
   - Add a subtle dark gray material to it.
2. Setup AR Session Origin (or XR Origin):
   - If using AR Foundation: In Hierarchy, right-click -> **XR** -> **XR Origin (AR)** and **AR Session**.
   - If testing in Editor without packages: Create an Empty GameObject named `XR_Manager`.
3. Add Placement Controller:
   - Select `XR_Manager` (or `XR Origin`).
   - Drag `ARItemPlacementController.cs` onto it.

### Step 4: Create the 3D Relic Prefab
1. In Hierarchy, right-click -> **3D Object** -> **Cylinder** (or **Sphere**). Name it `GoldenRelic`.
2. Scale: `0.5, 0.5, 0.5`.
3. In Inspector, change its color to Gold / Yellow.
4. Click **Add Component** -> add **XRInteractiveObject.cs**.
5. Drag `GoldenRelic` from Hierarchy into your `Assets` folder to turn it into a **Prefab**!
6. Delete the `GoldenRelic` from the Hierarchy.
7. Select `XR_Manager` -> drag the `GoldenRelic` prefab from Assets into the **Object To Place Prefab** slot in `ARItemPlacementController`.

### Step 5: Test & Document
1. Press the **Play (▶)** button!
2. Left-click anywhere on the plane surface — watch the 3D Golden Relic instantiate exactly where you clicked!
3. Left-click directly on the Relic to cycle through vibrant materials (Cyan, Magenta, Yellow).
4. Right-click and drag horizontally to spin the model 360 degrees.
5. Use the mouse scroll wheel to scale the relic up and down.
6. Record a short video of the interaction and capture screenshots:
   - The XR Manager Inspector showing placement prefab bindings.
   - The Relic positioned and rotating on the surface.
   - The color swap interaction.
