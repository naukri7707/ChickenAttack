using Naukri.ExtensionMethods;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildBtnEvent : MonoBehaviour
{
	public int BuildingID;

	public AudioSource btnApply, btnCancel;

	/// <summary>
	/// 目標建築
	/// </summary>
	public static GameObject BuildingGameObject;

	private static Vector3 _colliderSize, _colliderOffset;

	private static Vector3 cursorWorldPos => Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));

	void Start()
	{
		Button btn = this.GetComponent<Button>();
		btn.onClick.AddListener(OnClick);
	}

	private bool isCollisionWithBuilding()
	{
		Naukri.Tools.NDebug.DrawBox(BuildingGameObject.transform.position + _colliderOffset, _colliderSize);
		foreach (Collider2D hit in Physics2D.OverlapBoxAll(BuildingGameObject.transform.position + _colliderOffset, _colliderSize, 0, GameArgs.ObjectLayer))
		{
			if (hit.tag == GameArgs.Building || hit.tag == GameArgs.Background)
			{
				return true;
			}
		}
		return false;
	}

	private void Update()
	{
		if (BuildingGameObject != null)
		{
			Vector3 newPos = Vector3Int.RoundToInt(cursorWorldPos);
			newPos.z = 0;
			BuildingGameObject.transform.position = newPos;

			if (isCollisionWithBuilding() || !BuildingGameObject.transform.IsNearGround(_colliderSize))
			{
				foreach (SpriteRenderer sr in BuildingGameObject.GetComponents<SpriteRenderer>())
					sr.color = new Color(1, 0, 0, 1);
				if (Input.GetMouseButton(0))
				{
					btnCancel.Play();
				}
			}
			else
			{
				foreach (SpriteRenderer sr in BuildingGameObject.GetComponents<SpriteRenderer>())
					sr.color = new Color(1, 1, 1, 1);
				if (Input.GetMouseButton(0))
				{
					btnApply.Play();
					GameArgs.Gold -= BuildingGameObject.GetComponent<CoreBase>().GetDetails<BuildingDetails>().UpgradeCost;
					BuildingGameObject.GetComponent<CoreBase>().enabled = true;
					BuildingGameObject.GetComponent<Collider2D>().enabled = true;
					BuildingGameObject = null;
					transform.parent.gameObject.SetActive(false);
				}
			}

			if (Input.GetMouseButton(1))
			{
				Destroy(BuildingGameObject);
				BuildingGameObject = null;
				transform.parent.gameObject.SetActive(false);
			}
		}
	}

	public void OnClick()
	{
		if (BuildingGameObject != null)
		{
			Destroy(BuildingGameObject);
		}
		BuildingGameObject = Prefabs.Instantiate(BuildingID);
		if (GameArgs.Gold < BuildingGameObject.GetComponent<CoreBase>().GetDetails<BuildingDetails>().UpgradeCost)
		{
			btnCancel.Play();
			Destroy(BuildingGameObject);
			BuildingGameObject = null;
			return;
		}
		btnApply.Play();
		BuildingGameObject.transform.parent = GameArgs.World.transform;
		_colliderOffset = BuildingGameObject.GetComponent<BoxCollider2D>().BoundsOffset();
		_colliderSize = BuildingGameObject.GetComponent<BoxCollider2D>().bounds.size;
		BuildingGameObject.GetComponent<CoreBase>().enabled = false;
		BuildingGameObject.GetComponent<Collider2D>().enabled = false;
	}
}
