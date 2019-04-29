using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowObjectOnDestroy : MonoBehaviour
{
	public GameObject ShowObject;

	private void OnDestroy()
	{
		ShowObject.SetActive(true);
	}
}
