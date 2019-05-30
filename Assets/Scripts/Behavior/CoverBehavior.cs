using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoverBehavior : MonoBehaviour
{
	static bool flag = false;

	Image view;
	// Start is called before the first frame update
	void Start()
	{
		if (flag)
			Destroy(gameObject);
		flag = true;
		view = GetComponent<Image>();
		view.color = new Color(1, 1, 1, 1);
	}

	// Update is called once per frame
	void Update()
	{
		view.color -= new Color(0, 0, 0, 0.02f);
		if (view.color.a <= 0)
			Destroy(gameObject);
	}
}
