using UnityEngine;
using System.Collections;

// Interface for the model factory
public interface IEnemyModelFactory
{
	// Get the created model
	IEnemyModel Model { get; }
}

// Implementation of the model factory
public class EnemyModelFactory : IEnemyModelFactory
{
	public IEnemyModel Model { get; private set; }

	// create the model
	public EnemyModelFactory()
	{
		Model = new EnemyModel();
	}
}

// interface for the view factory
public interface IEnemyViewFactory
{
	// Get the created view
	IEnemyView View { get; }
}

public class EnemyViewFactory : IEnemyViewFactory
{
	public IEnemyView View { get; private set; }

	// Create the view
	public EnemyViewFactory()
	{
		var prefab = Resources.Load<GameObject>("Enemy");
		var instance = UnityEngine.Object.Instantiate(prefab);
		View = instance.GetComponent<IEnemyView>();
	}
}

// interface of the view factory
public interface IEnemyControllerFactory
{
	// Get the created controller
	IEnemyController Controller { get; }
}

// Implementation of the controller factory
public class EnemyControllerFactory : IEnemyControllerFactory
{
	public IEnemyController Controller { get; private set; }

	// create just the controller
	public EnemyControllerFactory(IEnemyModel model, IEnemyView view)
	{
		Controller = new EnemyController (model, view);
	}

	public EnemyControllerFactory()
		: this(new EnemyModel(), new EnemyView())
	{
	}

}