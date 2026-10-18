# LAB REPORT: PRACTICAL 7
**Course**: ETCS406 Game Development  
**Practical Title**: Create a Basic AR or VR Mini-Experience Using Unity and XR Interaction Toolkit  
**Student Name**: [Your Name]  
**Roll Number / PRN**: [Your Roll Number]  
**Semester**: VII | **Date**: [Date]  

---

## 1. Objective
To design and implement an immersive Augmented Reality (AR) / Extended Reality (XR) mini-experience in Unity, enabling surface plane detection, raycast-driven object placement, and real-time user touch manipulation (rotation, scaling, dynamic material swapping).

---

## 2. Tools & Software Environment
- **Game Engine**: Unity Editor (Version 6000.5.4f1 / 2021.3+ LTS)
- **XR Framework**: Unity AR Foundation / XR Interaction Toolkit
- **Simulation**: Unity Editor XR Device Simulator & Screen-Raycast Fallback
- **Scripting Language**: C#
- **IDE**: Visual Studio / Visual Studio Code

---

## 3. Implementation Details

### 3.1 XR Setup & Session Architecture
- Established an XR scene hierarchy featuring an `AR Session` to manage device tracking lifecycle and an `XR Origin` (or `AR Session Origin`) configuring the virtual camera offset.
- Incorporated `ARRaycastManager` to compute spatial intersections between 2D screen coordinate input points and reconstructed physical planar polygons.

### 3.2 Dynamic Surface Placement (`ARItemPlacementController.cs`)
- Programmed conditional touch handling:
  - On mobile AR targets: Evaluates `Input.GetTouch(0)` phase against `ARRaycastManager.Raycast`.
  - On PC editor targets: Utilizes `Camera.main.ScreenPointToRay` with physics plane raycasting to enable immediate iterative debugging without mobile compilation delays.
- Instantiates the 3D Trophy/Relic asset upon detected valid hit poses and maintains spatial persistence.

### 3.3 Interactive Object Manipulation (`XRInteractiveObject.cs`)
- **Color Cycling**: Implemented `OnMouseDown` / tap detection cycling through an array of dynamic materials to provide instant visual tactile feedback.
- **Rotational Control**: Intercepts horizontal touch drag deltas to rotate the asset $360^\circ$ on its vertical axis.
- **Scale Adjustment**: Modulates `transform.localScale` via touch pinch or scroll inputs clamped safely between $0.2\times$ and $3.0\times$.

---

## 4. Evaluation Rubric & Self-Assessment

| Component | Max Marks | Description of Implementation |
|---|---|---|
| **XR Setup & Configuration** | 3 | Configured AR Session, XR Origin, and Raycast managers with simulator fallback |
| **Scene Design & Immersion** | 3 | Structured clean visual showcase with responsive spatial lighting and 3D relic model |
| **Interaction Implementation** | 2 | Implemented tap-to-place, touch color-cycling, continuous rotation, and scaling |
| **Code Quality & Testing** | 2 | Clean C# architecture with conditional compilation (`#if`) and null-safety |
| **Total** | **10** | Complete XR interactive practical implementation |

---

## 5. Screenshots & Evidence of Work
*(Insert screenshots here)*

1. **XR Session & Origin Configuration in Inspector**:
   `[Insert Screenshot Here]`
2. **Object Placement on Detected Surface**:
   `[Insert Screenshot Here]`
3. **Interactive Manipulation Showing Material Color Swap & Rotation**:
   `[Insert Screenshot Here]`

---

## 6. Conclusion
This practical provided essential competencies in modern XR development workflows, highlighting spatial raycasting, planar detection algorithms, and interactive manipulation patterns in Unity.
