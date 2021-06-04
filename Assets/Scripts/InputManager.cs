using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
	public LayerMask mouseInputMask;
	//public GameObject buildingPrefab;

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
				//CreateBuilding(CalculateGridPosition(position));
			}
		}
	}	

	//void CreateBuilding(Vector3 gridPosition)
	//{
	//	Instantiate(buildingPrefab, gridPosition, Quaternion.identity);
	//}
}
