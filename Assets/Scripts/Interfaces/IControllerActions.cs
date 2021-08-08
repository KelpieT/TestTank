using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace TankGame
{
	public interface IControllerActions
	{
		Action<float> Move { get; set; }
		Action<float> Rotate { get; set; }
		Action<int> SwitchWeapons { get; set; }
		Action Fire { get; set; }

	}
}
