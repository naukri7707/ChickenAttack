using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// 按鈕事件集
/// </summary>
public class ButtonEvents : MonoBehaviour
{
	/// <summary>
	/// 預設材質
	/// </summary>
	[SerializeField] private Material _materialDefault;

	/// <summary>
	/// 毛玻璃材質
	/// </summary>
	[SerializeField] private Material _materialBlurGass;

	/// <summary>
	/// 灰階材質
	/// </summary>
	[SerializeField] private Material _materiaGrayScale;

	/// <summary>
	/// 暫停遊戲
	/// </summary>
	public void PauseGame()
	{
		Time.timeScale = 0;
	}

	public void ResumeGame()
	{
		Time.timeScale = 1;
	}

	/// <summary>
	/// 將渲染器材質設成灰階
	/// </summary>
	/// <param name="target">目標</param>
	public void SetRenderer_GrayScale(GameObject target)
	{
		SpriteRenderer[] sr = target.GetComponentsInChildren<SpriteRenderer>();
		foreach (SpriteRenderer s in sr)
		{
			s.material = _materiaGrayScale;
		}
	}

	/// <summary>
	/// 將圖片材質設成灰階
	/// </summary>
	/// <param name="target">目標</param>
	public void SetImage_GrayScale(GameObject target)
	{
		Image[] im = target.GetComponentsInChildren<Image>();
		foreach (Image i in im)
		{
			i.material = _materiaGrayScale;
		}
	}

	/// <summary>
	/// 將渲染器材質設成毛玻璃
	/// </summary>
	/// <param name="target">目標</param>
	public void SetRenderer_BlurGass(GameObject target)
	{
		SpriteRenderer[] sr = target.GetComponentsInChildren<SpriteRenderer>();
		foreach (SpriteRenderer s in sr)
		{
			s.material = _materialBlurGass;
		}
	}

	/// <summary>
	/// 將圖片材質設成毛玻璃
	/// </summary>
	/// <param name="target">目標</param>
	public void SetImage_BlurGass(GameObject target)
	{
		Image[] im = target.GetComponentsInChildren<Image>();
		foreach (Image i in im)
		{
			i.material = _materialBlurGass;
		}
	}

	/// <summary>
	/// 將渲染器材質設成預設
	/// </summary>
	/// <param name="target">目標</param>
	public void SetRenderer_Default(GameObject target)
	{
		SpriteRenderer[] sr = target.GetComponentsInChildren<SpriteRenderer>();
		foreach (SpriteRenderer s in sr)
		{
			s.material = _materialDefault;
		}
	}

	/// <summary>
	/// 將圖片材質設成預設
	/// </summary>
	/// <param name="target">目標</param>
	public void SetImage_Default(GameObject target)
	{
		Image[] im = target.GetComponentsInChildren<Image>();
		foreach (Image i in im)
		{
			i.material = _materialDefault;
		}
	}

	public void SetGameObject_Enable(GameObject target)
	{
		target.SetActive(true);
	}

	public void SetGameObject_Disable(GameObject target)
	{
		target.SetActive(false);
	}


	public void SwapGameObject_Active(GameObject target)
	{
		target.SetActive(!target.activeSelf);
	}

	/// <summary>
	/// 載入視窗
	/// </summary>
	/// <param name="sceneNum"></param>
	public void LoadSecne(int sceneNum)
	{
		GameArgs.LoadingScene = sceneNum;
		SceneManager.LoadScene(3);
	}

	public void SelectStage(int stage)
	{
		GameArgs.CurrentStage = stage;
	}

	public void NextStage()
	{
		GameArgs.CurrentStage++;
	}


	public void FreezeRigidbody(Rigidbody2D rigid)
	{
		rigid.isKinematic = true;
	}

	public void UnFreezeRigidbody(Rigidbody2D rigid)
	{
		rigid.isKinematic = false;
		//rigid.constraints = RigidbodyConstraints2D.None;
	}

	public void BuildingUpgarde()
	{
		BuildingDetails focus = GameArgs.FocusBuilding.GetDetails<BuildingDetails>();
		if (GameArgs.Gold > focus.UpgradeCost)
		{
			GameArgs.Gold -= focus.UpgradeCost;
			focus.Level++;
		}
	}

	public void BuildingDestroy()
	{
		Destroy(GameArgs.FocusBuilding.gameObject);
		GameArgs.FocusBuilding = null;
	}

	public void PlaySound(AudioSource src)
	{
		src.Play();
	}
}
