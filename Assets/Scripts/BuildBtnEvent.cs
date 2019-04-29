using Naukri.ExtensionMethods;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildBtnEvent : MonoBehaviour
{
	public int BuildingID;

	/// <summary>
	/// 目標建築
	/// </summary>
	private GameObject _buildingGameObject;

	private static Vector2 _colliderSize;

	private static Vector3 cursorWorldPos => Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));

	void Start()
	{
		Button btn = this.GetComponent<Button>();
		btn.onClick.AddListener(OnClick);
	}

	private bool isCollisionWithBuilding()
	{
		foreach (Collider2D hit in Physics2D.OverlapBoxAll(_buildingGameObject.transform.position, _colliderSize, 0, GameArgs.ObjectLayer))
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
		if (_buildingGameObject != null)
		{
			Vector3 newPos = Vector3Int.RoundToInt(cursorWorldPos);
			newPos.z = 0;
			_buildingGameObject.transform.position = newPos;

			if (isCollisionWithBuilding() || !_buildingGameObject.transform.IsNearGround(_colliderSize))
			{
				foreach (SpriteRenderer sr in _buildingGameObject.GetComponents<SpriteRenderer>())
					sr.color = new Color(1, 0, 0, 1);
			}
			else
			{
				foreach (SpriteRenderer sr in _buildingGameObject.GetComponents<SpriteRenderer>())
					sr.color = new Color(1, 1, 1, 1);
				if (Input.GetMouseButton(0))
				{
					_buildingGameObject.GetComponent<CoreBase>().enabled = true;
					_buildingGameObject.GetComponent<Collider2D>().enabled = true;
					_buildingGameObject = null;
					transform.parent.gameObject.SetActive(false);
				}
			}

			if (Input.GetMouseButton(1))
			{
				Destroy(_buildingGameObject);
				_buildingGameObject = null;
				transform.parent.gameObject.SetActive(false);
			}
		}
	}

	public void OnClick()
	{
		_buildingGameObject = Prefabs.Instantiate(BuildingID);
		_buildingGameObject.transform.parent = GameArgs.World.transform;
		_colliderSize = _buildingGameObject.GetComponent<Collider2D>().bounds.size;
		_buildingGameObject.GetComponent<CoreBase>().enabled = false;
		_buildingGameObject.GetComponent<Collider2D>().enabled = false;
	}
}
