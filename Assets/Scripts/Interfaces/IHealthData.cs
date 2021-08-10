using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankGame
{
	public interface IHealthData
	{
		float CurrentHealth { get; set; }
		float MinHealth { get; set; }
		float MaxHealth { get; set; }
		void InitHealthData(IHealthData healthData);

	}
}
