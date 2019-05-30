using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlarAtStart : MonoBehaviour
{
	public List<GameObject> DisableObjects;
	public Image fliter;
	public Material material;
    // Start is called before the first frame update
    void Start()
    {
		foreach (var g in DisableObjects)
		{
			g.SetActive(false);
		}
		fliter.material = material;
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
