using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DisableObjectOnEnable : MonoBehaviour
{
	[SerializeField] private GameObject _disableObject;

	public void OnEnable()
	{
		_disableObject.SetActive(false);
	}

}
