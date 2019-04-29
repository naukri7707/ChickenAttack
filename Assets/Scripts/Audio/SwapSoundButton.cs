using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwapSoundButton : MonoBehaviour
{
	public Image BaseImage;
	public Image StrikeLine;
	// Use this for initialization
	void Start()
	{
		Image[] img = GetComponentsInChildren<Image>();
		BaseImage = img[0];
		StrikeLine = img[1];
		StrikeLine.color = Color.red;
		Button btn = this.GetComponent<Button>();
		btn.onClick.AddListener(OnClick);
	}

	public void OnClick()
	{
		if (StrikeLine.enabled)
			AudioOn();
		else
			AudioOff();
	}

	public void AudioOn()
	{
		StrikeLine.enabled = false;
		BaseImage.color = Color.white;
		transform.parent.GetComponentInChildren<AudioEvents>().SetVolume();
	}

	public void AudioOff()
	{
		StrikeLine.enabled = true;
		BaseImage.color = Color.red;
		transform.parent.GetComponentInChildren<AudioEvents>().Audio.volume = 0;
	}
}
