# Practical 2.1: Creating a Mountainous Terrain

In the last lecture, you learned about how terrain is created and represented in an Interactive Environment. You also learned about a number of different approaches for creating terrain using Unity and Photoshop. In this practical, you are going to use these approaches to create the terrain for a simple mountainous environment.

By the end of this practical you will:

- Be able to create a Unity terrain object using either: an imported height map, a height map created using the terrain editor a procedurally generated height map
- Be able to add multiple textures to a terrain using interactive texture splatting in Unity
- Be able to add a character controller prefab to a terrain, so that it can be explored from the first-person perspective

This repository includes a Unity project with some assets (e.g. trees, textures) that you can use to create terrains. To get started make a copy of this repository on your GitHub account and clone it onto your local computer.

## Task 1: Creating the Terrain

In the first task you are going to create a terrain for a simple mountainous environment in Unity. 

Your terrain should include a valley that snakes up through mountains. At the head of this valley is a higher mountain, which can be climbed by following a windy path. The simple map below indicates roughly how you should lay out these elements of your terrain, but it’s up to you to decide exactly what your terrain should be like.

![A mountain with a windy path](https://github.com/UoY-IM-MPIE/mpie-p21-creating-terrain/blob/main/Instructions/mountainmap.jpg)

You can use any of the following approaches (or a combination of a number of them) to create your terrain:

- Painting a heightmap in Photoshop for import into a Unity Terrain Game Object
- Manipulating the height map of a Unity Terrain Game Object using the Terrain Editor
- Procedurally generating a ‘Perlin Noise’ terrain using Photoshop’s ‘Render Clouds’ Filter

For this task, it would be ideal if you could create your own terrain, and not base it on a height map that stores real geographic data (or any other height map data downloaded from the Internet). However, if you would like to experiment with creating a terrain from a height map once you’ve done the tasks, you can find one in the root of the Unity project (australia-gray.raw).

## Task 2: Texturing the Terrain

In this task you are going to make your terrain look more realistic by applying a range of textures to it. You should use Unity’s interactive texture splatting approach, which you were taught about in the lecture, to do this.

It’s up to you to decide how to texture your terrain. However, you might consider adding the following texture details:

- A rocky texture on any steep mountainous terrain (i.e. cliffs)
- A snowy cap on the highest mountain
- Grass on the valley floor at lower altitudes
- A muddy track marking the path up the valley and highest mountain

You’ll find the textures used in the lecture in the “Standard Assets” folder of the project. If you don’t like these, you can find lots more on Unity’s asset store. Terrain Tools Sample Asset Pack is a good one, made by the creators of Unity. Also, you may consider browsing the web for additional textures to include.

## Task 3: Exploring Using a 1st Person Character

Now your environment is complete, you should explore it using a first-person character.

You are going to use something called a character controller prefab, to add a first person character to your environment. A prefab is a convenient template from which you can create pre-configured game objects. A character controller prefab is a prefab that helps you create a game object that contains all the components needed to let you walk around in a first-person view.

There is a first-person controller prefab included in the project for you to use. To find it, search for ‘FPSController’ using the search box at the top right of the project window. If you’ve typed the correct search term into the box, you should see a blue cube icon with ‘FPSController’ below it. Drag this cube icon onto your terrain to create an FPSController game object at a position of your choice.

Once you’ve created the FPSController game object, press play and explore your terrain using the ‘WSAD’ keys and the mouse. If you find that your character ‘falls through’ the terrain, you may need to set the starting position of your FPSController to be higher up. If you notice anything that could be improved about your environment while exploring, return to the scene view and make changes to your terrain.

## Optional Extensions

- Explore how to use the second 'Normal Map' texture in the terrain editor to add detail to your terrain (see https://docs.unity3d.com/Manual/StandardShaderMaterialParameterNormalMap.html)
- Write a script that automatically generates alpha maps for a procedurally generated terrain, based on elevation and terrain ‘steepness’. See the following tutorial for more information about how this might be achieved: https://alastaira.wordpress.com/2013/11/14/procedural-terrain-splatmapping.


