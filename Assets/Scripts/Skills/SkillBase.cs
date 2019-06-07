using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class SkillBase : MonoBehaviour, ISkill
{
	[SerializeField] int cost;
	public int Cost { get => cost; set => cost = value; }

	[SerializeField] private float coolDown;
	public float CoolDown { get => coolDown; set => coolDown = value; }

	[SerializeField] [ReadOnly] private float currentCoolDown;
	public float CurrentCoolDown { get => currentCoolDown; set => currentCoolDown = value; }

	public Image CoolDownCover { get; set; }
	public Button SkillButton { get; set; }

	public Text CostText { get; set; }

	public abstract void OnSkillAsync();

	// Start is called before the first frame update
	public void Awake()
	{
		CoolDownCover = GetComponentsInChildren<Image>()[1];
		SkillButton = GetComponent<Button>();
		SkillButton.onClick.AddListener(OnSkillAsync);
		CostText = GetComponentInChildren<Text>();
		CostText.text = Cost.ToString();
		CurrentCoolDown = CoolDown;
	}

	// Update is called once per frame
	void Update()
	{
		CurrentCoolDown -= Time.deltaTime;
		CoolDownCover.fillAmount = CurrentCoolDown / CoolDown;
	}
}
