using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeInfo : MonoBehaviour
{
	public Image Chicken, TrainTimeBar;
	public Text Name, Comment, HitPoint, GrowthRate, Damage, HitRange, Speed, KnockBack;
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
		Chicken.overrideSprite = target.GetComponent<SpriteRenderer>().sprite;
		Chicken.SetNativeSize();
		//Chicken.transform.localScale = new Vector3(0.5f * target.transform.localScale.x, 0.5f * target.transform.localScale.y, 1);
		var det = target.GetDetails<TroopDetails>();
		Name.text = det.Name;
		Comment.text = det.Comment;
		HitPoint.text = det.HitPoint.ToString();
		GrowthRate.text = det.GrowthRate.ToString();
		Damage.text = det.Damage.ToString();
		HitRange.text = det.KnockBack.ToString();
		Speed.text = det.Speed.ToString();
		KnockBack.text = det.KnockBack.ToString();
		Destroy(temp);
	}

	public void Update()
	{
		if (GameArgs.FocusBuilding.GetComponent<CoreBase>().Identify == 20001)
			TrainTimeBar.fillAmount = GameArgs.FocusBuilding.GetComponent<GoldProduceAbility>().GoldBar.fillAmount;
		else
		{
			var ia = GameArgs.FocusBuilding.GetComponent<InstantiateAbility>();
			TrainTimeBar.fillAmount = (ia.MaxTrainingTime - ia.TrainingTime) / ia.MaxTrainingTime;
		}
	}
}
