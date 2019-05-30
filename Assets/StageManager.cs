using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
	public static int CurrentPage;

	public static int MaxStage
	{
		get => PlayerPrefs.GetInt("MaxStage", 1);
		set => PlayerPrefs.SetInt("MaxStage", value);
	}

	private void Start()
	{
		SetStageList();
	}

	// Update is called once per frame
	private void Update()
	{

	}

	private void SetStageList()
	{
		GameObject stages = GameObject.Find("Stages");
		int currentStage = CurrentPage;
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
