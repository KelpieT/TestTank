using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankGame
{
	[CreateAssetMenu(fileName = "BulletData", menuName = "TankGame/BulletData")]
	public class BulletData : ScriptableObject
	{
		public float LifeTimeBullet=5f;
		public float Speed;
		public float ExplosionRadius;
		public int CountShards;
	}
}
