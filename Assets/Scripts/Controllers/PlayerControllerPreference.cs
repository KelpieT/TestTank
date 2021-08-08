using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankGame
{
	public class PlayerControllerPreference : IControllerPreference
	{
		public KeyCode forward => KeyCode.UpArrow;

		public KeyCode backward => KeyCode.DownArrow;

		public KeyCode left => KeyCode.LeftArrow;

		public KeyCode right => KeyCode.RightArrow;

		public KeyCode weaponSwitchUp => KeyCode.W;

		public KeyCode weaponSwitchDown => KeyCode.Q;

		public KeyCode fire => KeyCode.X;
	}
}
