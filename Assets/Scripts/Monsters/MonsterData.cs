using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TankGame
{
	[CreateAssetMenu(fileName = "MonsterData", menuName = "TankGame/MonsterData")]
	public class MonsterData : ScriptableObject, IHealthData, IArmorData
	{
		public float MoveSpeed;
		public float minHealth;
		public float maxHealth;
		[Range(0, 1)]
		public float armor;
		public float Damage;
		public float CurrentHealth { get; set; }
		public float MinHealth { get => minHealth; set => minHealth = value; }
		public float MaxHealth { get => maxHealth; set => maxHealth = value; }
		public float Armor { get => armor; }
		public float AttackRatePerSecond = -1;
		public void InitHealthData(IHealthData healthData) { }
	}
}
