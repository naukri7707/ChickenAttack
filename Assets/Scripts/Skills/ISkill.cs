using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface ISkill
{
	float CoolDown { get; set; }

	float CurrentCoolDown { get; set; }

	Image CoolDownCover { get; set; }

	Button SkillButton { get; set; }

	void OnSkillAsync();
}
