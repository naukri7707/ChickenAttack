using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioEvents : MonoBehaviour {

	public AudioSource Audio;

	private SwapSoundButton _swapSoundButton;

	private void Awake()
	{
		_swapSoundButton = transform.parent.GetComponentInChildren<SwapSoundButton>();
	}

	public void SetVolume()
	{
		Audio.volume = GetComponent<Slider>().value;
	}

	public void CancelMute()
	{
		Audio.volume = GetComponent<Slider>().value;
		_swapSoundButton.AudioOn();
	}
}
