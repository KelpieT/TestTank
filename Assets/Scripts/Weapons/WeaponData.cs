using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankGame
{
	[CreateAssetMenu(fileName = "WeaponData", menuName = "TankGame/WeaponData")]
	public class WeaponData : ScriptableObject
	{
		public float fireRatePerSecond = -1;
		public Bullet bullet;
		public float damagePerBullet;
	}
}
