using UnityEngine;
using UnityEngine.UI;

public class AudioEvents : MonoBehaviour
{

	public AudioSource[] Audios;

	private Slider slider;

	private SwapSoundButton _swapSoundButton;

	private void Awake()
	{
		_swapSoundButton = transform.parent.GetComponentInChildren<SwapSoundButton>();
		slider = GetComponent<Slider>();
	}

	public void SetVolume()
	{
		foreach (AudioSource a in Audios)
			a.volume = slider.value;
	}

	public void CancelMute()
	{
		foreach (AudioSource a in Audios)
			a.volume = slider.value;
		_swapSoundButton.AudioOn();
	}
}
