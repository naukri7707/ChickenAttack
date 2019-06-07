using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface ISkill
{
	int Cost { get; set; }

	float CoolDown { get; set; }

	float CurrentCoolDown { get; set; }

	Image CoolDownCover { get; set; }

	Button SkillButton { get; set; }

	Text CostText { get; set; }

	void OnSkillAsync();
}
