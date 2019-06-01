using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageButtonBehavior : MonoBehaviour
{
	private bool isLock;

	public bool IsLock
	{
		get
		{
			return isLock;
		}
		set
		{
			isLock = imgLock.enabled = value;
		}
	}

	[SerializeField] private Text text;
	[SerializeField] private Image imgLock;
	// Start is called before the first frame update

	public int Stage { get; set; }

	public void Init(int stage)
	{
		text = GetComponentInChildren<Text>();
		imgLock = GetComponentsInChildren<Image>()[1];
		//
		Stage = stage;
		IsLock = stage > StageManager.MaxStage;
		text.text = stage.ToString();
	}

	public void OnClick()
	{
		if (IsLock) return;
		GameArgs.CurrentStage = Stage;
		new ButtonEvents().LoadSecne(3);
	}
}
