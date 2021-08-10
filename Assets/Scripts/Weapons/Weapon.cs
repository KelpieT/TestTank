using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankGame
{
	public class Weapon : MonoBehaviour
	{
		public WeaponData weaponData;
		float lastTimeFired;
		public void Fire(Transform pointToSpawn)
		{
			if (weaponData == null) return;
			if (weaponData.fireRatePerSecond == -1) return;
			float time = Time.time;
			if (lastTimeFired + 1 / weaponData.fireRatePerSecond > time) return;
			if (weaponData.bullet == null) return;
			Bullet bullet = Instantiate<Bullet>(weaponData.bullet, pointToSpawn.position, pointToSpawn.rotation);
			bullet.damageble = new BulletDamageble(weaponData);
			bullet.Fire();
			lastTimeFired = time;
		}

	}
}
