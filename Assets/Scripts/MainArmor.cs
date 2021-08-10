using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TankGame
{

	public class MainArmor : IArmor
	{
		IArmorData data;

		public float RecalculateDamage(float damage)
		{
			return damage * (1 - data.Armor);
		}

		public MainArmor(IArmorData data)
		{
			this.data = data;
		}

	}
}
