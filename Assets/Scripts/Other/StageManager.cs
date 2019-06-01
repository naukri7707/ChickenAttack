using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
	public static int MaxStagePage = 2;
	/// <summary>
	/// 目前選關頁面(1頁10關)
	/// </summary>
	public static int CurrentPage
	{
		get => PlayerPrefs.GetInt("CurrentPage", 0);
		set => PlayerPrefs.SetInt("CurrentPage", value);
	}
	/// <summary>
	/// 對大可選擇關卡 (PlayerPrefs)
	/// </summary>
	public static int MaxStage
	{
		get => PlayerPrefs.GetInt("MaxStage", 1);
		set => PlayerPrefs.SetInt("MaxStage", value);
	}

	public void Start()
	{
		SetStageList();
	}

	// Update is called once per frame
	private void Update()
	{

	}

	public static void SetStageList()
	{
		GameObject stages = GameObject.Find("Stages");
		var s = stages.GetComponentsInChildren<Transform>();
		for (int i = 1; i < s.Length; i++)
		{
			Destroy(s[i].gameObject);
		}
		int currentStage = CurrentPage * 10;
		for (int i = 0; i < 2; i++)
		{
			for (int j = 1; j <= 5; j++)
			{
				GameObject btn = Instantiate(Resources.Load("UI/StageButton") as GameObject, stages.transform);
				btn.GetComponent<StageButtonBehavior>().Init(++currentStage);
				btn.GetComponent<RectTransform>().localPosition = new Vector3(-450 + 150 * j, i == 0 ? 75 : -75, 0);
			}

		}

	}
}
