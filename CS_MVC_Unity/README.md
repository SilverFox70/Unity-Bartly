# Unity/C# MVC vs Component Design Pattern
This is an example of using MVC within Unity along with a Factory Pattern Builder.

Many of the classes are portable outside of Unity as they do not rely on Unity's MonoBehaviour
in order to work. 

## Getting Started
You'll need to have Unity 5.6.0f3 installed. Clone the repo and open Unity. Search for the folder of the repo and open that in Unity. From there, it should be ready to go. 

## Project Structure
- [`/Assets`](./Assets/) - where the majority of Unity assets are stored (scenes, scripts, prefabs)
- [`/Assets/Scripts/`](./Assets/Scripts/) - all C# scripts can be found here
- [`/Assets/Scripts/MVC_Pattern/`](./Assets/Scripts/MVC_Pattern/) - C# scripts implementing an MVC and Factory design pattern
- [`/Assets/Scripts/Component_Pattern/`](./Assets/Scripts/Component_Pattern/) - C# scripts implementing a Component and EventManager design pattern

## MVC and Factory Pattern
The file names should make this all pretty self explanatory in terms of what is going on. The only scripts that require Unity's underlying MonoBehaviour are **MainScript.cs** and **EnemyView.cs**. Both the MVC pattern and the factory pattern as applied here appeal to a the familiar design patterns seen in other software. But is it the best approach for game design?

The benefit of the MVC approach using interfaces is that it would make testing much easier. But the components are tightly coupled and in order to implement several different "flavors" of enemies, it encourages inheritance over composition. There is also an implicit assumption of "silo-ing" elements that occurs in MVC, which is great for data, but limiting when different controllers need to be able to affect models from another controller. This exacerbates the issues of tight coupling since suddenly components have to have awareness of each other on an intimate level.

## Component Pattern
This pattern fits more naturally into Unity's framework where almost everything is a GameObject or a component of a GameObject. Most of the tutorials for Unity games follow this pattern. The loose coupling of components along with the use of an EventManager makes for easier refactoring or swapping out of components. Furthermore, the "FLyeweight" pattern can be implemented through the use of managers, for example an EnemyManager, to allow the core functionality of Enemies to be separated from the actual behavior of Enemy instances. Data, rather then inheritence, drives the behavior of components while keeping the components themselves lightweight and simple.
