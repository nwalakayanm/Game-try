# 🌱 Echo-Architect

**A cooperative, asynchronous terraforming experiment.**

## 📖 The Vision
*Echo-Architect* is not a game about conquering a map or hoarding resources. It explores the existential weight of a dying planet and the ambiguity of creation. Players act as solitary actants in a massive, shared narrative, leaving ecological "fingerprints" that ripple across the globe. 

You might plant a forest that saves a region, or your bio-engineered flora might inadvertently choke out another player's ecosystem. It is a study in communication without words—where our actions and their consequences are the only language.

## ⚙️ Core Mechanics
*   **The Persistent Planet:** A shared, procedurally generated wasteland that persists across all sessions.
*   **The Echo System:** Asynchronous multiplayer. When you alter the terrain, those changes manifest in the worlds of other players occupying the same geographic coordinates.
*   **Procedural Cross-Pollination:** Flora and fauna mutate based on the interaction between different players' contributions (e.g., your seeds + a stranger's water source = a new, undiscovered species).
*   **Micro-Dose Gameplay:** Designed for short, high-impact sessions. Plant a seed, fix a valve, and let the Zeigarnik effect pull you back to check on your ecosystem.

## 💻 Under the Hood
This repository contains the foundational logic for the game engine. 

**Current Modules:**
*   `CrossPollinationEngine.cs`: The core C# genetics system that calculates the procedural generation of new plant species based on intersecting elemental tags (e.g., Mineral Water + Bioluminescent Seed).

## 🚀 Future Roadmap
- [ ] Implement the `PulseMap` UI for real-time global visualization.
- [ ] Develop the server architecture for asynchronous state saving.
- [ ] Add dynamic weather events (Cataclysms) requiring real-time community response.

---
*Conceptualized and developed by Troll.*
