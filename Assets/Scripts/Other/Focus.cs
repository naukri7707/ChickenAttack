using Naukri.ExtensionMethods;
using UnityEngine;
public class Focus : MonoBehaviour
{
	private float posX;
	private Rigidbody2D _rigidbody;
	[SerializeField] private float xMin, xMax;
	private void Awake()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
	}

	// Use this for initialization
	private void Start()
	{
		xMin = -GameArgs.BackGround.GetComponent<SpriteRenderer>().size.x / 2;
		xMax = GameArgs.BackGround.GetComponent<SpriteRenderer>().size.x / 2;
	}

	// Update is called once per frame
	private void Update()
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
		if (transform.position.x < xMin)
		{
			transform.position = new Vector3(xMin, transform.position.y, transform.position.z);
		}

		if (transform.position.x > xMax)
		{
			transform.position = new Vector3(xMax, transform.position.y, transform.position.z);
		}
	}
}