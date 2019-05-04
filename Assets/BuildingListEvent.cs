using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingListEvent : MonoBehaviour
{
	public void UpgradeBuilding()
	{
		GameArgs.World.GetComponent<MouseEvent>().Focus.GetDetails<DetailsBase>().Level++;
	}
}
