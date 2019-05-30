using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickCancel : MonoBehaviour
{
	[SerializeField] private List<GameObject> _disableList;

	private void OnMouseUpAsButton()
	{
		foreach (GameObject g in _disableList)
		{
			g.SetActive(false);
		}
	}
}
