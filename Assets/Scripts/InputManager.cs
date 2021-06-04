using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
	public LayerMask mouseInputMask;
	public GameObject buildingPrefab;
	public int cellSize = 3;

	private void Update()
	{
		GetInput();
	}

	public void GetInput()
	{
		bool leftMousePressed = Input.GetMouseButtonDown(0);
		bool mouseOverUI = EventSystem.current.IsPointerOverGameObject();

		if (leftMousePressed && !mouseOverUI)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			bool didHit = Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity, mouseInputMask);

			if (didHit)
			{
				Vector3 position = hit.point - transform.position;
				CreateBuilding(CalculateGridPosition(position));
			}
		}
	}

	public Vector3 CalculateGridPosition(Vector3 inputPosition)
	{
		int x = Mathf.FloorToInt((float)inputPosition.x / cellSize);
		int z = Mathf.FloorToInt((float)inputPosition.z / cellSize);
		return new Vector3(x * cellSize, 0, z * cellSize);
	}

	void CreateBuilding(Vector3 gridPosition)
	{
		Instantiate(buildingPrefab, gridPosition, Quaternion.identity);
	}
}
