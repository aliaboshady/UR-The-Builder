using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlacementManager placementManager;
    public InputManager inputManager;

    GridStructure grid;
	int cellSize = 3;

	private void Start()
	{
		grid = new GridStructure(cellSize);
		inputManager.AddListenerOnPointerDownHandlerEvent(HandleInput);
	}

	void HandleInput(Vector3 position)
	{
		placementManager.CreateBuilding(grid.CalculateGridPosition(position));
	}

}
