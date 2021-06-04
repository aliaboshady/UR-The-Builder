using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlacementManager placementManager;
    public InputManager inputManager;
	public int width;
	public int length;

	GridStructure grid;
	int cellSize = 3;

	private void Start()
	{
		grid = new GridStructure(cellSize, width, length);
		inputManager.AddListenerOnPointerDownHandlerEvent(HandleInput);
	}

	void HandleInput(Vector3 position)
	{
		Vector3 gridPosition = grid.CalculateGridPosition(position);
		if (!grid.IsCellTaken(gridPosition))
		{
			placementManager.CreateBuilding(gridPosition, grid);
		}
	}

}
