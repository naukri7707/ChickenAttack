using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Focus : MonoBehaviour
{
	float posX;
	Rigidbody2D _rigidbody;

	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
	}

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.touchCount > 0)
		{
			if (Input.touches[0].phase == TouchPhase.Began)
			{
				posX = Input.touches[0].position.x;
			}
			else if (Input.touches[0].phase == TouchPhase.Moved)
			{
				_rigidbody.AddForce(new Vector2(posX - Input.mousePosition.x, 0));
				posX = Input.mousePosition.x;
			}
		}
		else
		{
			if (Input.GetMouseButtonDown(0))
			{
				posX = Input.mousePosition.x;
			}
			else if (Input.GetMouseButton(0))
			{
				_rigidbody.AddForce(new Vector2(posX - Input.mousePosition.x, 0));
				posX = Input.mousePosition.x;
			}
		}
		if (transform.position.x < -31) transform.position = new Vector3(-31f, transform.position.y, transform.position.z);
		if (transform.position.x > 31) transform.position = new Vector3(31f, transform.position.y, transform.position.z);
	}
}