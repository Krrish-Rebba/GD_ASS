# Assignment 6: Upgrading Base Game with Story, Timeline, and Animator
**Course Code**: ETCS406 | **Duration**: 3 Hours | **Total Marks**: 10

---

## 1. What This Upgrade Adds to the Base Game
In this practical, we transform our game into a **narrative-driven experience**:
1. **Unity Timeline (`PlayableDirector`)**: An introductory cinematic camera cutscene that pans across the ruins before gameplay begins.
2. **Animator Controller**: Animates the character between `Idle` and `Talking` states during conversations.
3. **Interactive Dialogue System (`DialogueManager.cs`)**:
   - Displays character dialogue with typewriter animation.
   - Provides branching choices on screen:
     - **Choice A**: Accept the Amulet (+Shield & Score bonus).
     - **Choice B**: Refuse (+Brave Path).
   - Dialogues update game state dynamically!

---

## 2. Step-by-Step Instructions (Click-by-Click)

### Step 1: Open Your Base Project
1. Open your Unity Project.
2. In Project window, create a new scene: right-click `Assets/Scenes` -> **Create** -> **Scene** -> name it `Scene_06_Interactive_Story`.
3. Copy the scripts from `Assignment_06_Interactive_Story/Scripts/` into `Assets/Scripts/`:
   - `DialogueManager.cs`
   - `StoryBranchController.cs`

### Step 2: Create the Dialogue UI Canvas
1. In Hierarchy, right-click -> **UI** -> **Canvas**.
2. Inside `Canvas`, right-click -> **UI** -> **Panel**. Name it `DialoguePanel`.
   - In Inspector, set RectTransform anchor to **Bottom Stretch**.
   - Height: `200`. Change color to dark semi-transparent blue (`RGBA: 20, 25, 45, 230`).
3. Add Speaker Name:
   - Inside `DialoguePanel`, right-click -> **UI** -> **Text**. Name it `SpeakerNameText`.
   - Set Font Size: `22`, Color: Yellow/Gold. Position top-left of the panel.
4. Add Dialogue Body:
   - Inside `DialoguePanel`, right-click -> **UI** -> **Text**. Name it `DialogueBodyText`.
   - Set Font Size: `18`, Color: White. Position in the center of the panel.
5. Add Choice Buttons:
   - Inside `DialoguePanel`, right-click -> **Create Empty**. Name it `ChoicesContainer`.
   - Inside `ChoicesContainer`, create two **UI -> Button** GameObjects: `ChoiceAButton` and `ChoiceBButton`.
   - Position Choice A on the left, Choice B on the right.
6. Attach `DialogueManager.cs`:
   - Drag `DialogueManager.cs` onto `DialoguePanel`.
   - Drag all the corresponding text and button elements into the Inspector slots.

### Step 3: Create the Cutscene with Unity Timeline
1. In Hierarchy, right-click -> **Create Empty**. Name it `IntroCutscene`.
2. In Inspector, click **Add Component** -> add **Playable Director**.
3. Open Timeline Window:
   - Top menu: **Window** -> **Sequencing** -> **Timeline**.
   - With `IntroCutscene` selected, click the **Create** button in the Timeline window.
   - Save the asset as `IntroTimeline.playable` in `Assets`.
4. Add an Animation Track:
   - In the Timeline window, click the **+** button -> **Animation Track**.
   - Drag your `Main Camera` into the track.
   - Click the red **Record** button:
     - At frame 0: Position camera high above the level looking down.
     - At frame 120 (2 seconds): Move camera smoothly down to focus on the Elder NPC.
   - Click the red Record button again to finish recording!

### Step 4: Configure the Story Controller
1. In Hierarchy, right-click -> **Create Empty**. Name it `StoryController`.
2. Drag `StoryBranchController.cs` onto it.
3. In Inspector, drag `IntroCutscene` into the **Intro Cutscene** slot.

### Step 5: Test & Document
1. Press the **Play (▶)** button!
2. Watch the opening camera cutscene smoothly sweep across the environment.
3. As the cutscene concludes, the dialogue box appears with Elder Gwydion speaking to you.
4. Read the text, click between the two branching choice buttons, and observe the alternate responses and score bonuses!
5. Take screenshots of:
   - The Timeline window showing track keyframes.
   - The Dialogue UI Canvas layout and Inspector bindings.
   - Active dialogue with branching choice buttons visible.
