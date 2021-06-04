using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridStructure
{
	int cellSize;
	Cell[,] grid;
	int width;
	int length;

	public GridStructure(int cellSize, int width, int length)
	{
		this.cellSize = cellSize;
		this.width = width;
		this.length = length;
		grid = new Cell[width, length];

		for (int i = 0; i < grid.GetLength(0); i++)
		{
			for (int j = 0; j < grid.GetLength(1); j++)
			{
				grid[i, j] = new Cell();
			}
		}
	}
	public Vector3 CalculateGridPosition(Vector3 inputPosition)
	{
		int x = Mathf.FloorToInt((float)inputPosition.x / cellSize);
		int z = Mathf.FloorToInt((float)inputPosition.z / cellSize);
		return new Vector3(x * cellSize, 0, z * cellSize);
	}

	public Vector2Int CalculateGridIndex(Vector3 gridPosition)
	{
		return new Vector2Int((int)(gridPosition.x / cellSize), (int)(gridPosition.z / cellSize));
	}

	public bool IsCellTaken(Vector3 gridPosition)
	{
		Vector2Int cellIndex = CalculateGridIndex(gridPosition);
		if (CheckIndexValidity(cellIndex))
		{
			return grid[cellIndex.y, cellIndex.x].IsTaken;
		}

		throw new System.IndexOutOfRangeException("No index " + cellIndex + " in grid!");
	}

	public void PlaceStructureOnTheGrid(GameObject structure, Vector3 gridPosition)
	{
		Vector2Int cellIndex = CalculateGridIndex(gridPosition);
		if (CheckIndexValidity(cellIndex))
		{
			grid[cellIndex.y, cellIndex.x].SetConstruction(structure);
		}
	}

	bool CheckIndexValidity(Vector2Int index)
	{
		if (index.x >= 0 && index.x < grid.GetLength(1) && index.y >= 0 && index.y < grid.GetLength(0))
			return true;
		return false;
	}
}
