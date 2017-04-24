using UnityEngine;

public class MainScript : MonoBehaviour {

	void Awake()
	{
		// create model
		var modelFactory = new EnemeyModelFactory();
		var model = modelFactory.Model;

		// set some initial state
		model.Position = new Vector3(1, 2, 3);

		// create the view
		var viewFactory = new EnemyViewFactory();
		var view = viewFactory.View;

		// create the controller
		var controllerFactory = new EnemyControllerFactory(model, view);
		var controller = controllerFactory.Controller;
	}
}
