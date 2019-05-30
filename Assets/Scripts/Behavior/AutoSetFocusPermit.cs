using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSetFocusPermit : MonoBehaviour
{
	private void OnEnable()
	{
		GameArgs.FocusPermit = false;
	}

	private void OnDisable()
	{
		GameArgs.FocusPermit = true;
	}
}
