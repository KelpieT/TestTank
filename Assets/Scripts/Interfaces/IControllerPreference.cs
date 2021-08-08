using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankGame
{
	public interface IControllerPreference
	{
		KeyCode forward { get; }
		KeyCode backward { get; }
		KeyCode left { get; }
		KeyCode right { get; }
		KeyCode weaponSwitchUp { get; }
		KeyCode weaponSwitchDown { get; }
		KeyCode fire { get; }
	}
}
