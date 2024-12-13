# Quiz Game

A simple quiz game where you pick the correct card to progress through levels.

---

## 🎮 **Gameplay Overview**

In this game:
- You are presented with a set of cards.
- Your task is to pick the correct card.
- After completing all levels, the game can be restarted.
- The game minimizes repetition by prioritizing unused "correct" cards. However, if all cards in a bundle are used, they can repeat to prevent softlocks.

![Game Screenshot](https://github.com/user-attachments/assets/bf5402b0-1a32-4dcd-809a-a46f55820f4b)


![Game Preview](https://github.com/user-attachments/assets/fb83de86-0d4b-4032-bfc1-e2989a98991e)

---

## 🔧 **Features**

### 1. **Dynamic Grid Generation**
- Levels are dynamically generated based on grid configurations.
- The grid is defined by `GridDifficultyData` ScriptableObjects, which specify the number of rows and columns.

![Grid Setup](https://github.com/user-attachments/assets/7b33fa7c-82cd-41be-b4cb-09dbf3f17fa4)

### 2. **Level Progression**
- The sequence of "levels" is defined by assigning `GridDifficultyData` objects to the `Bootstrap` script's `Grid Difficulty Datas` array.

![Level Sequence](https://github.com/user-attachments/assets/f0e22055-2588-4d85-a07c-e656545e7708)

### 3. **Card Bundles**
- Cards are sourced from customizable bundles defined in `CardBundleData` ScriptableObjects.
- Each card in a bundle contains:
  - A string identifier.
  - A sprite image.
  - An option to rotate the card during spawning (in case the sprite is rotated in atlas).

![Card Bundles](https://github.com/user-attachments/assets/45ed8b03-e2df-49f9-a8c8-3b37ef6de3da)

### 4. **Card Spawning**
- Card bundles are assigned to the `CardSpawner` script via the `Card Bundles` array.
- A random bundle is picked, and then a random card is picked from that bundle, prioritizing unused cards.

![Card Spawner](https://github.com/user-attachments/assets/b6b76ef2-dd6c-4167-b645-9b2ade78bc9e)

---

## 🛠️ **Customization**

### Grid Difficulty
- Create new grid difficulty setups via `Assets/Data/Grid Difficulties`.
- Right-click in the Project view and select **Create -> Grid Difficulty Data**.

### Card Bundles
- Add new card bundles via `Assets/Data/Card Bundles`.
- Right-click in the Project view and select **Create -> Card Bundle Data**.

---


