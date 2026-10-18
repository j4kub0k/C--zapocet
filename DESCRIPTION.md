# Top-down shooter (Unity / C#) – project description

**Author:** Jakub Baumgartner · **Engine:** Unity · **Language:** C# · **Docs:** `README.md` (Slovak, detailed)

## What it does
A top-down shooter. The player moves with WASD, aims with the mouse and shoots to defeat every
enemy (melee and ranged) and the boss. When no enemies are left, the win UI is shown.

- **Health and ammo limits**, shown next to the player by the HUD scripts.
- **Weapons:** pistol (limited ammo, slow fire), machine gun (fast fire), shotgun (3-bullet spread).
  Running out of ammo falls back to the pistol.
- **Enemies:** `Patrol` (waypoints, loop / back-and-forth), `Attack` (melee chase when the player is
  in range and visible), `RangeAttack` (shoots at intervals within a 60° field of view), `Die` (health, death effect).
- **Power-ups** (pickups handled by one small script each): heal, max-health up, ammo/weapon pickups
  (machine gun, shotgun), damage boost, infinite ammo, invincibility, wider vision, faster movement.
- **Save system:** `PLayerData` (serializable snapshot of health, ammo, gun, position) is written to /
  read from `save.json` in `Application.persistentDataPath` by the static `save` class using
  `JsonUtility`. Saved on quit or on request, loaded on start, deleted on game over / new game.
- **Menus:** main menu (new game, continue, quit), pause menu (Esc: resume, save, load, reset, quit), game over screen.

## Design notes
- Each behaviour is its own `MonoBehaviour` component (composition over inheritance); the player's
  weapons expose a common `fire(bool infinite)` method that `controller` dispatches on `gunType`.
- Persistence is isolated in the static `save` class and the plain data class `PLayerData`.
- Code is documented with XML (`///`) comments on classes and methods.

## Repository structure
| Path | Content |
|---|---|
| `Assets/scripts/` | All game logic (C#) – player, weapons, enemies, power-ups, UI, save system |
| `Assets/*.unity` | Scenes: `Menu` (`mm`), `Game`, `GameOver` |
| `Assets/*.prefab`, `*.mat` | Bullets, power-ups, doors, materials |
| `Assets/Plugins/Demigiant/` | Third-party DOTween (camera shake) – not my code |
| `Assets/*.mp3`, `*.png`, `M1911.fbx` | Audio, images and weapon model |
| `Packages/`, `ProjectSettings/` | Unity package manifest and project settings |
| `.gitignore` | Unity ignore rules (`Library/`, `obj/`, `Logs/`, `.vs/`, … are not versioned) |

## Build
Open the project in Unity, then *File → Build Settings → Build* (scenes: Menu, Game, GameOver).
