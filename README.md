# Changelog

* [Eris] 6/3/22: Set up character movement, animation, idle, camera follow
   * [Tutorial levels completed:](https://www.youtube.com/watch?v=BfgyI1RkVo4&list=PLLtCXwcEVtulmgxqM_cA8hjIWkSNMWuie&index=1)
      * 01 Setup
      * 02 Movement
      * 03 Animation
      * 04 Idle & Face Correct
      * 06 Camera Follow (excluding parts related to tilemaps)
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

* [Germaine] 16/3/22: Set up basic boss enemy movement, animations and enraged mode based on health
   * Dealing damage to player is not implemented yet


# Folder Hierarchy-ish

* Assets
   * Animations
      * Boss
         * ...
      * [Idle___]
      * [Walk___]
   * Art
      * TopDownCharacter
         * Character
            * ...
         * Weapon
            * ...
      * GhostBoss
         * ...
   * Tiles
      * SupermarketProps
         * Tiles, Tileset and Sprite...
      * SupermarketBackground
         * Tiles, Tileset and Sprite...
   * Prefabs
   * Scenes
      * Test
      * Boss_Enemy
   * Scripts
      * CameraController
      * PlayerController
      * BossController
      * BossHealth
   * Boss_Enrage [State Machine Script]
   * Boss_Move [State Machine Script]
* ...

# Acknowledgements

### Tutorials

* Used [this tutorial](https://www.youtube.com/watch?v=BfgyI1RkVo4&list=PLLtCXwcEVtulmgxqM_cA8hjIWkSNMWuie&index=1) for setting up the project

### Assets

* [8-direction top down character - Gamekrazzy](https://gamekrazzy.itch.io/8-direction-top-down-character)
* [Modern Tilesets](https://limezu.itch.io/moderninteriors)
* [8-direction top down Boss Enemy](https://e-bros-assets.itch.io/top-down-enemy-animated-8-directions)
