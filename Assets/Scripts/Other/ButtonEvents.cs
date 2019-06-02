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
			s.material = GameArgs.World.GetComponent<World>().MateriaGrayScale;
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
			i.material = GameArgs.World.GetComponent<World>().MateriaGrayScale;
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
			s.material = GameArgs.World.GetComponent<World>().MaterialBlurGass;
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
			i.material = GameArgs.World.GetComponent<World>().MaterialBlurGass;
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
			s.material = GameArgs.World.GetComponent<World>().MaterialDefault;
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
			i.material = GameArgs.World.GetComponent<World>().MaterialDefault;
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
		SceneManager.LoadScene(4);
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
		BuildingDetails det = GameArgs.FocusBuilding.GetDetails<BuildingDetails>();
		if (det.Level < 10 && GameArgs.Gold >= det.UpgradeCost)
		{
			GameArgs.Gold -= det.UpgradeCost;
			det.Upgrade();
			GameArgs.World.GetComponent<World>().FX_Apply.PlayIfNotPlaying();
			UpgradeEffect();
		}
		else
		{
			GameArgs.World.GetComponent<World>().FX_Cancel.PlayIfNotPlaying();
		}
	}

	public void UpgradeEffect()
	{
		GameObject eff = Prefabs.Instantiate(30001);
		GameObject foc = GameArgs.FocusBuilding.gameObject;
		eff.transform.position = foc.transform.position;
		SpriteRenderer es = eff.GetComponent<SpriteRenderer>();
		SpriteRenderer fs = foc.GetComponent<SpriteRenderer>();
		float scale = fs.bounds.size.x * 1.5f / es.bounds.size.x;
		eff.transform.localScale = new Vector3(scale, scale, 1);
		float newY = GameArgs.Horizon + es.bounds.size.y / 2 - 2f;
		eff.transform.position = new Vector3(eff.transform.position.x, newY, eff.transform.position.z);
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
	public void PlaySoundIfNotPlaying(AudioSource src)
	{
		src.PlayIfNotPlaying();
	}
	public void PrevTraining(ChangeInfo panel)
	{
		var ins = GameArgs.FocusBuilding.GetComponent<InstantiateAbility>();
		ins.TempIndex--;
		panel.ChangePanelInfo(ins.TempID);
	}
	public void NextTraining(ChangeInfo panel)
	{
		var ins = GameArgs.FocusBuilding.GetComponent<InstantiateAbility>();
		ins.TempIndex++;
		panel.ChangePanelInfo(ins.TempID);
	}

	public void ConfirmTraining()
	{
		var target = GameArgs.FocusBuilding.GetComponent<InstantiateAbility>();
		target.ChangeTraining(target.TempIndex);
	}

	public void SetFocusPermit(bool permit)
	{
		GameArgs.FocusPermit = permit;
	}

	public void ExitApplication()
	{
		Application.Quit();
	}

	public void DestoryGameObject<T>(T mono) where T : MonoBehaviour
	{
		Destroy(mono.gameObject);
	}

	public void DestoryBuildingGameObject()
	{
		Destroy(BuildBtnEvent.BuildingGameObject);
	}

	public void NextStagesPage()
	{
		if (StageManager.CurrentPage < StageManager.MaxStagePage)
		{
			StageManager.CurrentPage++;
			StageManager.SetStageList();
		}
	}

	public void PrevStagesPage()
	{
		if (StageManager.CurrentPage > 0)
		{
			StageManager.CurrentPage--;
			StageManager.SetStageList();
		}
	}
}
