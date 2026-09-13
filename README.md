# ATTForestSeedUtility
This mod allows you to get and set your forest seed.  
This mod only needs to be on the server side.

## How to use
Add the ForestSeedUtil.dll to your mods folder and turn on your server. This will add a seed entry to your MelonPreferences.cfg file, which will have the seed of your current forest.  
To generate a forest with a different seed, simply replace the seed value with a new number.

## Requirements, Tips, and Recommendations
Entered seeds **must** be a whole number within the signed 32-bit integer limit (2,147,483,647). Setting it to anything below 0 will cause it to be set back to your current forest seed.  

I would *highly* recommend making a backup of your server files before installing this mod or changing your forest seed. I haven't encountered anything being negatively affected, but better to be safe than sorry.

While it is not required, I would recommend clearing your cache folder before starting your server with a new seed. The cache folder can be found at %APPDATA%/A Township Tale/servers/-1/Save/Cache. Not doing so *shouldn't* effect anything, the folder just gets very cluttered very fast and could unnecessarily fill up your storage if you don't have a lot (each forest takes up just over 10 mb).

Some numbers seem to cause the forest to not generate anything. The only time I encountered this while testing was with 1, but my testing was admittedly not extensive so there may be other numbers that will fail or other factors that caused it to not work.
