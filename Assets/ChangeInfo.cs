using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeInfo : MonoBehaviour
{
	public Image Chicken;
	public Text Name, Comment, HitPoint, Damage, Speed;
	private void OnEnable()
	{
		var ins = GameArgs.FocusBuilding.GetComponent<InstantiateAbility>();
		ins.TempIndex = ins.CurrentIndex;
		ChangePanelInfo(ins.TempID);
	}
	public void ChangePanelInfo(int identify)
	{
		Debug.Log(identify);
		GameObject temp = Instantiate(Prefabs.Troop[identify] as GameObject);
		temp.transform.position = new Vector3(9999999, 9999999, 9999999);
		CoreBase target = temp.GetComponent<CoreBase>();
		Chicken.sprite = target.GetComponent<SpriteRenderer>().sprite;
		Name.text = target.GetDetails<TroopDetails>().Name;
		Comment.text = target.GetDetails<TroopDetails>().Comment;
		HitPoint.text = target.GetDetails<TroopDetails>().HitPoint.ToString();
		Damage.text = target.GetDetails<TroopDetails>().Damage.ToString();
		Speed.text = target.GetDetails<TroopDetails>().Speed.ToString();
		Destroy(temp);
	}
}
