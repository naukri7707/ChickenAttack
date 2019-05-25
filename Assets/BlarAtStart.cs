using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlarAtStart : MonoBehaviour
{
	public Image fliter;
	public Material material;
    // Start is called before the first frame update
    void Start()
    {
		fliter.material = material;
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
