using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowObjectOnDestroy : MonoBehaviour
{
	public GameObject ShowObject;

	private void OnDestroy()
	{
		Time.timeScale = 0;
		if (ShowObject != null)
			ShowObject.SetActive(true);
	}
}
