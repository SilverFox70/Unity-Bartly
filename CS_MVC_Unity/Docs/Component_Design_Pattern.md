# Component Based Design Pattern for Unity

## Getting Started
Let's imagine that we a going to create a game where our player confronts waves of enemies (maybe a zombie horde?) in a simple warehouse environment. Where do we start?

Games are driven by interactions or events. Some of these events come from player input (mouse buttons, WASD keys, Spacebar and the like) while others occur because of things that happen in the game (a zombie collides with you and eats your brains). In fact, almost everything is driven by events of one type or another, whether that is the player selecting "Start" on a menu screen or pressing the space bar to fire a shotgun, or the like. So we are going to need an EventSystem. This EventSystem will become the central nervous system for our game.

C# gives us two ways to use an EventSystem. We can either opt for the EventHandler and its EventArgs or we can go with the lighter weight ActionEvent. There are pros and cons to each, of course. EventHandlers and EventArgs give you the ability to pass a lot of data around while also ensuring that delegate functions can almost always handle the passed EventArgs. Action Events allow some parameters to be passed along to delegate functions, but unless you create and pass along custom objects (not difficult to do) there are limitations on how many parameters can be sent and you don't really know what is being sent to you on the receiving end. This would not be a problem in a language like Javascript, but C# expects you to know the type of parameters being sent. This makes Action Event slightly less flexible unless you are willing to throw around custom objects.

