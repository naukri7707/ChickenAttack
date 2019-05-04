using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEvent : MonoBehaviour
{
	public GameObject BuildingList;

	public CoreBase Focus;

	private void LateUpdate()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Input.GetMouseButton(0))
		{
			var hits = Physics2D.RaycastAll(ray.origin, ray.direction, 10, -1);
			foreach (var hit in hits)
			{
				if (hit.transform.tag == GameArgs.Building && hit.transform.GetComponent<CoreBase>().Team == AgentTeam.Ally)
				{
					Focus = hit.transform.GetComponent<CoreBase>();
					BuildingList.SetActive(true);
					return;
				}
			}
			if (hits.Length == 0)
				BuildingList.SetActive(false);
			Debug.Log(hits.Length);
			return;
		}
	}
}
