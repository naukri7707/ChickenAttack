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
		BuildingDetails det = GameArgs.FocusBuilding.GetDetails<BuildingDetails>();
		GetComponent<Text>().text = ((int)(det.UpgradeCost * Mathf.Pow(det.GrowthRate, det.Level - 1))).ToString();
	}
}
