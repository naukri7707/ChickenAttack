using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// 載入
/// </summary>
public class Loading : MonoBehaviour
{
	/// <summary>
	/// 載入文本
	/// </summary>
	public Text loadingText;
	
	/// <summary>
	/// 初始化
	/// </summary>
	void Start()
	{
		loadingText.text = "0%";
		StartCoroutine(LoadingScreenAsync(GameArgs.LoadingScene));
	}

	/// <summary>
	/// 動態載入畫面
	/// </summary>
	/// <param name="sceneNum">目標視窗ID</param>
	/// <returns></returns>
	private IEnumerator LoadingScreenAsync(int sceneNum)
	{
		int fPogress = 0, tPogress;
		AsyncOperation async = SceneManager.LoadSceneAsync(sceneNum);
		async.allowSceneActivation = false;
		while (async.progress < 0.9f)
		{
			tPogress = (int)(async.progress * 100);
			while (fPogress < tPogress)
			{
				//fPogress++;
				fPogress = (fPogress + tPogress + 1) >> 1;
				SetLoading(fPogress);
				yield return new WaitForEndOfFrame();
			}
			yield return null;
		}
		tPogress = 100;
		while (fPogress < tPogress)
		{
			//fPogress++;
			fPogress = (fPogress + tPogress + 1) >> 1;
			SetLoading(fPogress);
			yield return new WaitForEndOfFrame();
		}
		async.allowSceneActivation = true;
	}

	/// <summary>
	/// 設定載入進度
	/// </summary>
	/// <param name="percent">百分比</param>
	private void SetLoading(int percent)
	{
		loadingText.text = percent.ToString() + "%";
	}
}
