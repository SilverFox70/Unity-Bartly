using UnityEngine;

// Interface for the enemy controller
public interface IEnemyController
{
}

// Implementation fo the enemy controller
public class EnemyController : IEnemyController 
{

	// Keep references to the model and the view
	private readonly IEnemyModel model;
	private readonly IEnemyView view;

	// Controller depends on interfaces for the model and the view
	public EnemyController(IEnemyModel model, IEnemyView view)
	{
		this.model = model;
		this.view = view;

		// Listen to change in the model
		model.OnPositionChanged += HandlePositionChanged;

		// Listen to input from the view
		view.OnClicked += HandleClicked;

		// Set the view's initial state by syncing with the model
		SyncPosition();
	}

	// Called when view is clicked
	private void HandleClicked(object sender, EnemyClickedEventArgs e)
	{
		// Do something to the model, like move it +1 along the x-axis
		model.Position += new Vector3(1, 0, 0);
	}

	// Called when the model's position changes
	private void HandlePositionChanged(object sender, EnemyPositionChangedEventArgs e)
	{
		// Update the view with the new position
		SyncPosition();
	}

	// Sync the view's position with the model's position
	private void SyncPosition()
	{
		view.Position = model.Position;
	}

}
