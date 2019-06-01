using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoShowStage : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
		GetComponent<Text>().text = "Stage " + GameArgs.CurrentStage.ToString();
		Destroy(this);
    }

}
