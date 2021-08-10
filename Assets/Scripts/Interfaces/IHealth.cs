using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace TankGame
{
	public interface IHealth
	{
		Action DeadAct { get; set; }
		Action TakeDamageAct { get; set; }
		IHealthData healthData { get; set; }
		void Dead();
		void TakeDamage(float forceDamage);
		void CheckForDead(IHealthData healthData);

	}
}