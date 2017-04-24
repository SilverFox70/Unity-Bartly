using UnityEngine;

public class MainScript : MonoBehaviour {

	void Awake()
	{
		// create model
		var modelFactory = new EnemyModelFactory();
		var model = modelFactory.Model;
		Debug.Log ("[MainScript] model: " + model.ToString ());

		// set some initial state
		model.Position = new Vector3(1, 2, 3);

		// create the view
		var viewFactory = new EnemyViewFactory();
		var view = viewFactory.View;
		Debug.Log ("[MainScript] view: " + view.ToString ());

		// create the controller
		var controllerFactory = new EnemyControllerFactory(model, view);
		var controller = controllerFactory.Controller;
	}
}
