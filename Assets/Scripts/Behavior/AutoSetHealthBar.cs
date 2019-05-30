using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSetHealthBar : MonoBehaviour
{
	public SpriteRenderer[] srs;

	public float MaxShowTime;

	public float showTime;
	public int MaxHitPoint { get => det.MaxHitPoint; }
	public int HitPoint { get => det.HitPoint; }

	private DetailsBase det;

	private int tempHitPoint;
	void Start()
	{
		det = GetComponentInParent<CoreBase>().GetDetails<DetailsBase>();
		tempHitPoint = HitPoint;
		srs = transform.parent.GetComponentsInChildren<SpriteRenderer>();
		showTime = 0;
	}

	// Update is called once per frame
	void Update()
	{
		if (tempHitPoint != HitPoint)
		{
			foreach (var s in srs)
				s.enabled = true;
			Vector3 targetScale = transform.localScale;
			targetScale.x = (float)HitPoint / (float)MaxHitPoint;
			//targetScale.x = -targetScale.x;
			transform.localScale = Vector3.Lerp(transform.localScale, targetScale, 0.1f);
			tempHitPoint = HitPoint;
			showTime = MaxShowTime;
		}
		else if (showTime > 0)
		{
			showTime -= Time.deltaTime;
		}
		else
		{
			foreach (var s in srs)
				s.enabled = false;
		}
	}
}
