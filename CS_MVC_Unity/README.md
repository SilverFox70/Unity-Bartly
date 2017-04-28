# Unity/C# MVC Example
This is an example of using MVC within Unity along with a Factory Pattern Builder.

Many of the classes are portable outside of Unity as they do not rely on Unity's MonoBehaviour
in order to work. 

## Getting Started
You'll need to have Unity 5.6.0f3 installed. Clone the repo and open Unity. Search for the folder of the repo and open that in Unity. From there, it should be ready to go. 

## Notes
The file names should make this all pretty self explanatory in terms of what is going on. The only scripts that require Unity's underlying MonoBehaviour are **MainScript.cs** and **EnemyView.cs**.

## Observations
Both the MVC pattern and the factory pattern as applied here appeal to a the familiar design patterns seen in other software. But is it the best approach for game design? 

The benefit of the MVC approach using interfaces is that it would make testing much easier. But the components are tightly coupled and in order to implement several different "flavors" of enemies, it encourages inheritance over composition. There is also an implicit assumption of "silo-ing" elements that occurs in MVC, which is great for data, but limiting when different controllers need to be able to affect models from another controller. This exacerbates the issues of tight coupling since suddenly components have to have awareness of each other on an intimate level. 

A better approach within Unity is think in terms of components, and composition over inheritance. For example, if you are creating a game with two types of enemies, say Vampires and Werewolves, it is tempting to create a parent EnemyClass and have each flavor of enamy inherit from that parent class. In component terms, the creation of an EnemyClass is still a good idea, but instead of creating sub-classes we can simply have some instance of the EnemyClass implement a Vampire Mesh and Vampire Movement Animation, and others implement a Werewolve Mesh and Werewolf Movement Animation. All instances of the EnemyClass could implement a separate, singular Movement script, in which data passed in would determine the rate of movement itself. By avoiding inheritance and using small, single purpose components, you can easily scale the number and types of enemies and also modify inidividual components (think plug-n-play) easily without having to change code or dependenices in multiple locations.
