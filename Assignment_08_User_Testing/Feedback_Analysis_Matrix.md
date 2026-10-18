# User Testing Feedback Analysis & Issue Prioritization Matrix
**Practical 8**: ETCS406 Game Development  
**Session Scope**: 4 Independent Testers (Peers from Computer Science & Engineering)  

---

## 1. Quantitative Feedback Summary (Mean Scores out of 5.0)

| Metric Evaluated | Tester 1 | Tester 2 | Tester 3 | Tester 4 | Average Score |
|---|---|---|---|---|---|
| Movement Responsiveness | 4.0 | 4.0 | 3.0 | 4.0 | **3.75 / 5.0** |
| Jump & Springboard Fairness | 3.0 | 3.0 | 4.0 | 3.0 | **3.25 / 5.0** |
| Enemy AI Warning & Clarity | 3.0 | 4.0 | 3.0 | 3.0 | **3.25 / 5.0** |
| Dialogue UI Readability | 5.0 | 5.0 | 4.0 | 5.0 | **4.75 / 5.0** |
| Goal Clarity & Orientation | 4.0 | 4.0 | 5.0 | 4.0 | **4.25 / 5.0** |
| Overall Enjoyment | 4.0 | 4.0 | 4.0 | 4.0 | **4.00 / 5.0** |

---

## 2. Qualitative Feedback Thematic Categorization

| Category | Observed User Issue / Quote | Frequency | Severity | Priority | Action Plan / Fix |
|---|---|---|---|---|---|
| **Responsiveness / Feel** | *"Sometimes when running off a ledge and pressing Jump at the very edge, the character drops into the pit without jumping."* | 3 / 4 Users | High | **P1 (Immediate)** | Implement **Coyote Time** (0.15s window) and **Jump Buffering** in player script. |
| **Balance / AI** | *"The enemy catches up a bit too quickly when turning corners around walls; hard to escape once spotted."* | 2 / 4 Users | Medium | **P2 (High)** | Reduce Enemy chase speed from $6.0\text{ m/s}$ to $4.8\text{ m/s}$ and increase detection alert time. |
| **Physics Polish** | *"Springboard launch height varied slightly if I held down the key or hit the edge."* | 2 / 4 Users | Medium | **P2 (High)** | Zero out vertical velocity completely prior to applying upward impulse vector. |
| **UI / Audio** | *"Dialogue was great, but a subtle text-beep sound effect when typing letters would make it feel even more polished."* | 1 / 4 Users | Low | **P3 (Polish)** | Added audio chirp trigger per dialogue character display. |
