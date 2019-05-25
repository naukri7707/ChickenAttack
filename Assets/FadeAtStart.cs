using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeAtStart : MonoBehaviour
{
	public Image img;

	// Start is called before the first frame update
	void Start()
	{
		img = GetComponent<Image>();
	}
	// Update is called once per frame
	void Update()
	{
		img.color = new Color(img.color.r, img.color.g, img.color.b, img.color.a - 0.02f);
		if (img.color.a <= 0)
		{
			Destroy(gameObject);
		}
	}
}
