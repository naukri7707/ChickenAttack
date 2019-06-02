using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AuotSetCost : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		var det = GameArgs.FocusBuilding.GetDetails<BuildingDetails>();
		if (det.Level == 10)
			GetComponent<Text>().text = "X";
		else
			GetComponent<Text>().text = det.UpgradeCost.ToString();
	}
}
