using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class InputManager : MonoBehaviour
{
	public LayerMask mouseInputMask;
	Action<Vector3> OnPointerDownHandler;


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
				if (OnPointerDownHandler != null)
				{
					OnPointerDownHandler.Invoke(position);
				}
			}
		}
	}

	public void AddListenerOnPointerDownHandlerEvent(Action<Vector3> listener)
	{
		OnPointerDownHandler += listener;
	}

	public void RemoveListenerOnPointerDownHandlerEvent(Action<Vector3> listener)
	{
		OnPointerDownHandler -= listener;
	}

}
