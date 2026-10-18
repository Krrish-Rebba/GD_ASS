# LAB REPORT: PRACTICAL 6
**Course**: ETCS406 Game Development  
**Practical Title**: Design and Develop a Narrative-Based Interactive Story Game Using Unity's Timeline and Animator  
**Student Name**: [Your Name]  
**Roll Number / PRN**: [Your Roll Number]  
**Semester**: VII | **Date**: [Date]  

---

## 1. Objective
To design and implement a narrative-driven interactive storytelling sequence in Unity using the Timeline sequencer, Animator controller, and custom C# scripting to create branching dialogue paths with player choices, cinematic camera transitions, and state-driven character animations.

---

## 2. Tools & Software Environment
- **Game Engine**: Unity Editor (Version 6000.5.4f1 / 2020.3+ LTS)
- **Cinematic Tools**: Unity Timeline (`UnityEngine.Playables`) & Cinemachine
- **Animation Engine**: Unity Animator Controller (Mecanim)
- **Scripting Language**: C#
- **IDE**: Visual Studio / Visual Studio Code

---

## 3. Implementation Details

### 3.1 Narrative Architecture & Branching Design
- Conceived a high-stakes fantasy narrative set in the "Ruins of Valdor".
- Structured an interactive choice juncture where the player interacts with Elder Gwydion:
  - **Branch 1 (Acceptance)**: Awards the Golden Amulet granting defensive score/shield bonus.
  - **Branch 2 (Defiance)**: Initiates an alternate path challenging the player to survive on skill alone.

### 3.2 Unity Timeline Cutscene Sequencing
- Utilized a `PlayableDirector` on an `IntroCutscene` GameObject.
- Created an `IntroTimeline.playable` asset containing an `Animation Track` bound to the `Main Camera`.
- Keyframed smooth linear interpolation from an establishing wide shot (panoramic environment view) down to a tight medium shot framing the NPC Elder.
- Bound event callbacks to seamlessly activate the dialogue UI upon timeline completion.

### 3.3 Dynamic Dialogue System (`DialogueManager.cs`)
- Programmed a coroutine-based typewriter text effect (`TypeSentence`) yielding on configurable delay per character.
- Integrated `characterAnimator.SetBool("isTalking", true)` during active typewriter delivery and resetting to `Idle` on sentence completion.
- Dynamically binds Unity UI button listeners to execute anonymous lambdas matching player decisions.

---

## 4. Evaluation Rubric & Self-Assessment

| Component | Max Marks | Description of Implementation |
|---|---|---|
| **Story Design & Structure** | 3 | Developed engaging narrative scenario with meaningful player choices and distinct outcomes |
| **Timeline & Animator Usage** | 3 | Sequenced camera cutscene tracks in Timeline and animated NPC states via Animator Controller |
| **Interactivity & Dialogue System** | 2 | Implemented typewriter UI, sentence queueing, and responsive branching choice buttons |
| **Code Quality & Debugging** | 2 | Clean C# architecture with separation of concerns and robust delegate event callbacks |
| **Total** | **10** | Complete interactive narrative practical implementation |

---

## 5. Screenshots & Evidence of Work
*(Insert screenshots here)*

1. **Unity Timeline Window Displaying Camera Track Keyframes**:
   `[Insert Screenshot Here]`
2. **Dialogue Canvas Hierarchy & Inspector Bindings**:
   `[Insert Screenshot Here]`
3. **In-Game Screenshot of Active Branching Dialogue Choice Selection**:
   `[Insert Screenshot Here]`

---

## 6. Conclusion
This practical demonstrated the power of Unity Timeline and Animator tools in sequencing cinematic game transitions, and showcased how C# scripted dialogue systems can provide immersive interactive player agency.
