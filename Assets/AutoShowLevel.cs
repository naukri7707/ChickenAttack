using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoShowLevel : MonoBehaviour
{
	private void Update()
	{
		GetComponent<Text>().text = GameArgs.FocusBuilding.GetDetails<DetailsBase>().Name + " (Level " + GameArgs.FocusBuilding.GetDetails<DetailsBase>().Level + ")";
	}
}
