using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TankGame
{
	public class SimpleTankControllerActions : IControllerActions
	{
		public Action<float> Move { get; set; }
		public Action<float> Rotate { get; set; }
		public Action<int> SwitchWeapons { get; set; }
		public Action Fire { get; set; }

		public SimpleTankControllerActions(Tank tank)
		{
			if (tank == null) return;
			Move = tank.Move;
			Rotate = tank.Rotate;
			SwitchWeapons = tank.SwitchWeapons;
			Fire = tank.Fire;
		}
	}
}
