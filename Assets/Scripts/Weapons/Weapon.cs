using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankGame
{
	public abstract class Weapon : MonoBehaviour
	{
		public WeaponData weaponData;
		float lastTimeFired;
		public void Fire()
		{
			if (weaponData == null) return;
			if (weaponData.fireRatePerSecond == -1) return;
			float time = Time.time;
			if (lastTimeFired + 1 / weaponData.fireRatePerSecond > time) return;
			if (weaponData.bullet == null) return;
			Bullet bullet = Instantiate<Bullet>(weaponData.bullet, transform.position + transform.rotation * Vector3.forward, Quaternion.identity);
			bullet.Fire();
			lastTimeFired = time;
		}

	}
}
