# MapMaker
 **Dungeon Keeper map type unity editor 3d map creation tool**<br />
Create a 3d map from a bitmap image

##  How to use the example map:
- Open the ExampleMap Scene
- Select the MapMaker GameObject
- Press the Generate New Map button
- Select the Player GameObject and drag the new gameMap GameObject to the PlayerController MapInfo field
- You can not press the unity play button to move around the map

## How to create a new map:
- Right click in project folder
- Navigate to MapMaker entry
- Select MapPalette
- Fill out your MapPalette scriptable object fields
- Right click in project folder
- Navigate to MapMaker entry
- Select GameMap
- Fill out your GameMap scriptable object fields
- Set a bitmap with palette colors you specified earlier to the terrain field
- The territory bitmap is not a requiered field
- Set your MapPalette in the map palette field
- Create an empty game object in your scene
- Attach the MapMaker script
- Assign your GameMap to the GameMap field
- Press the Create New Map button
- Select the Player GameObject and drag the new gameMap GameObject to the PlayerController MapInfo field
- You can not press the unity play button to move around the map

## Terrain and Territory Bitmaps
![](https://github.com/gpelletier0/MapMaker/blob/main/Assets/Textures/ExampleMap/ExampleTerrain.bmp)<br />
Terrain Bitmap Example
<br /><br />
![](https://github.com/gpelletier0/MapMaker/blob/main/Assets/Textures/ExampleMap/ExampleTerritory.bmp)<br />
Territory Bitmap Example
<br /><br />
Created using Paint. The dimenions of the image will define the map size, every pixel encodes the information about one tile.