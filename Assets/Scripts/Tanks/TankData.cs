using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankGame
{
	[CreateAssetMenu(fileName = "TankData", menuName = "TankGame/TankData")]
	public class TankData : ScriptableObject, IHealthData, IArmorData
	{
		public float MoveSpeed;
		public float MoveSpeedLerp;
		public float RotateSpeed;
		public float RotateSpeedLerp;
		public float minHealth;
		public float maxHealth;
		[Range(0, 1)]
		public float armor;
		public float CurrentHealth { get; set; }
		public float MinHealth { get => minHealth; set => minHealth = value; }
		public float MaxHealth { get => maxHealth; set => maxHealth = value; }
		public float Armor { get => armor; }
		public void InitHealthData(IHealthData healthData) { }

	}
}
