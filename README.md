createCube.ino file is the Arduino codes and createCube.png is the circuit of Arduino.
FPSController.cs is the C# code trhat provides an object to move with W/A/S/D keys and rotate with mouse.
You should drag it (FPSController.cs) to the main object of the program (for me it was a Sphere).
CubeSpawner.cs is the file of the Empty Game Object (in order to make the project more clean).
Drag it (CubeSpawner.cs) to the Empty GFame Object then start the game.
When the Arduino encounters with an object within 5 cm the main object in the unity will create the object that you select as prefab (for me it was a cube).
You can change all the variables which are public (like main object, prefab...). 
