using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBehavior : MonoBehaviour
{
	public AgentTeam Team;
	public int HitPoint;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnColliderEnter2D(Collider2D col)
	{
		Debug.Log(1);
		//Object
		if (col.gameObject.layer == 13)
		{
			Debug.Log(13);
			col.gameObject.GetComponent<EffectBase>().DestroyThis();
		}
		//Effect
		else if (col.gameObject.layer == 14)
		{

			Debug.Log(14);
			HitPoint -= col.gameObject.GetComponent<EffectBase>().Damage;
			col.gameObject.GetComponent<EffectBase>().DestroyThis();
			if (HitPoint <= 0)
			{
				Destroy(gameObject);
			}
		}
	}
}
