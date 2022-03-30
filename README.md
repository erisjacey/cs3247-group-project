# About

### Welcome to Upside Down!

* 2D top-down dungeon crawler
* Optimised for FHD 1920x1080 resolution

### Story (WIP)

Benjamin Parker is a depressed man who is emotionally damaged from his bad life experiences. 
He is too sad to wake up unless he overcomes all his inner demons. 
Despite all that, he still has a ray of hope in him, equipping him with the power to fight and face his inner demons. (Missing animation for that, Coming Soon!)
In the first level, Benjamin is facing his childhood fear of being lost in a huge supermarket.

### Controls

* Move - WASD/arrow-keys
* Attack - Spacebar
* Escape - Pause/Resume

### Flow

1. Main menu -> tutorial room
1. Tutorial room -> main supermarket room
1. Main supermarket room -> fake boss room / actual boss room
1. Actual boss room

### Objective

* Navigate through the maze-like structure of the supermarket
* Beat any enemy guard that tries to attack you before you get swarmed by multiple guards
* Reach the boss (the manifestation of anxiety itself)
* Beat the boss

### Coming soon

* General game polish
* Game victory screen upon beating boss
* More mechanics (dash, shield, etc.)
* Expansion of supermarket
* More health collectibles!
* More maps! (fear - classroom, anger - house)
* More enemy types!
* More sounds!

# Changelog

* [Eris] 6/3/22: Set up character movement, animation, idle, camera follow
   * [Tutorial levels completed:](https://www.youtube.com/watch?v=BfgyI1RkVo4&list=PLLtCXwcEVtulmgxqM_cA8hjIWkSNMWuie&index=1)
      * 01 Setup
      * 02 Movement
      * 03 Animation
      * 04 Idle & Face Correct
      * 06 Camera Follow (excluding parts related to tilemaps)
* [Lucas] 9/3/22: Add player attack, interaction with enemy
* [Huiting] 13/3/22: Set up supermarket tileset, replace camera follow with cinemachine camera (plus confiner)
   * Setup background tileset for supermarket
   * Setup tileset for supermarket props
   * Laid out a basic tileset for supermarket
   * Adjusted player movement
   * Added Cinemachine:
      * Camera follows player with added damping and smoothing
      * Follow camera is confined within the tilemap
   * **IMPT NOTE for everyone!!**: Removed all library and temp files from the repo and added .gitignore
      * Do not commit your own temp or library files and remove them if they are in your commits
* [Zx] 17/3/22: Set up Enemy movement, path-finding, Collision
	21/3/22: Set up Start Menu, Dead Menu, Pause Menu and Populate enemies in supermarket 1.
	30/3/22: Develop Range Enemy for Fear Level and Skeleton Enemy for Anger Level.W
* [Germaine] 16/3/22: Set up basic boss enemy movement, animations and enraged mode based on health
   * Enemy flash on receiving damage
   * Enraged mode features: player tracking regardless of distance, faster movement
   * Dealing damage to player is not implemented yet
* [Eris] 20/3/22: Set up player health system, hurt player mechanic/animation
   * [Tutorial levels completed:](https://www.youtube.com/watch?v=BfgyI1RkVo4&list=PLLtCXwcEVtulmgxqM_cA8hjIWkSNMWuie&index=1)
      * 14 Hurt Player
      * 15 Health System
      * 17 Hurt Flash
* [Germaine] 20/3/22: Add boss damage player and player UI health bar
   * Set up boss enemy damaging player
   * Enraged mode features: faster attacking speed, higher attack damage on player
   * Include health bar for player on UI
* [Eris] 20/3/22: Add audio manager, assets for menu theme/player hurt
* [Huiting/Kerwin] 21/3/22: Laid out map for Supermarket levels and level to level transition
   * Set up level to level transition
     Note: To add a transition to a new level
     place a LevelExit at the desired location and place a SpawnPoint gameobject at the location you want to spawn player at (in new map)
     Add to the SpawnPoint to the PlayerLocationManager's SpawnLocations, then input the right index into LevelExit
   * Scenes
      * Supermarket 1 -> Main map
      * Supermarket 2 -> Fake boss level
      * Supermarket 3 -> Bozz level
* [Germaine] 21/3/22: Modifications to player attack
   * Player attack control is now 'Space' key
   * Animations played for 8-dir:
      * SlashUp: Up and NE 
      * SlashRight: Right and SE
      * SlashDown: Down and SW
      * SlashLeft: Left and NW 
* [Huiting/Kerwin] 22/3/22: Added enemy knockback and adjusted camera boundaries
   * Changed AI speed and removed school prefabs
* [Huiting] 26/3/22: Adjusted tilemap colliders and UI fonts
   * Added a bit more of a 3D effect for some objects
   * Added a new [font](https://www.dafont.com/vcr-osd-mono.font) and adjusted UI scenes
   * Fixed flickering lines in tilemap
   * Refactored AudioManager and PlayerLocationManager into a single persistent GameSession object
   * Updated PlayerLocationManager and LevelExit to work with location names instead of indexes

# Template Scene Hierarchy
[Scene_Name]
* Cameras
   * Main Camera
   * Follow Camera
   * Boundary
* Tilemaps
    * Props
      * Props Containers
      * Prop Items
      * Prop Items 2
      * Prop Items 3
      * Foreground
   * Background
   * Walls
* Player
* LevelExits
   * ...
* GameSession
  * AudioManager
  * PlayerLocationManager
     * [SM*_*]
  * LevelCanvas
     * HealthBar
     * Panel (Background)
     * DeathPanel
     * PauseMenu
  * EventSystem
* PathFinding
* Enemies
   * ...
* ...

# Folder Hierarchy-ish

* Assets
   * Animations
      * Boss
         * Spawn
         * Idle
         * Death
         * Enraging
         * [Attack___]
         * [EnragedAttack___]
         * [Walk___]
         * [EnragedWalk___]
      * [Idle___]
      * [Walk___]
      * [Slash___]
   * Art
      * TopDownCharacter
         * Character
            * ...
         * Weapon
            * ...
      * GhostBoss
         * ...
      * HealthBar
         * ...
   * Tiles
      * SupermarketProps
         * Tiles, Tileset and Sprite...
      * SupermarketBackground
         * Tiles, Tileset and Sprite...
   * Prefabs
   * Scenes
      * Audio
      * Test
      * Boss_Enemy
      * Player_Attack_Creation
   * Scripts
      * Audio
         * AudioManager
         * Sound
      * CameraController
      * PlayerController
      * BossController
      * BossHealth
      * EnemyHealthManager
      * HurtEnemy
      * GuardAI
      * GuardHealth
      * HealthBar
      * HealthManager
      * HurtPlayer
      * LevelExit
      * PlayerLocationManager
   * Sounds
      * MenuTheme
      * PlayerHurt
   * Boss_Enrage [State Machine Script]
   * Boss_Move [State Machine Script]
* ...

# Acknowledgements

### Tutorials

* Used [this tutorial](https://www.youtube.com/watch?v=BfgyI1RkVo4&list=PLLtCXwcEVtulmgxqM_cA8hjIWkSNMWuie&index=1) for setting up the project
* Used [this tutorial](https://www.youtube.com/watch?v=6OT43pvUyfY) for setting up audio and for audio manager script

### Assets

* [8-direction top down character - Gamekrazzy](https://gamekrazzy.itch.io/8-direction-top-down-character)
* [Modern Tilesets](https://limezu.itch.io/moderninteriors)
* [8-direction top down Boss Enemy](https://e-bros-assets.itch.io/top-down-enemy-animated-8-directions)
* [Music loop bundle - Tallbeard Studios](https://tallbeard.itch.io/music-loop-bundle)
   * Ludum Dare 32 - Track Five (MenuTheme)
* [SFX Pack v1 - Mythril Age](https://mythril-age.itch.io/mythril-age-sfx-pack-v1)
   * Sound 1 (EnemyHurt)
   * Sound 86 (PlayerHurt)
