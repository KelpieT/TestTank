using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankGame
{

	public class BulletDamageble : IDamageble
	{
		WeaponData weaponData;
		public void SetDamage(IHealth healthObject)
		{
			healthObject.TakeDamage(weaponData.damagePerBullet);
		}
		public BulletDamageble(WeaponData weaponData)
		{
			this.weaponData = weaponData;
		}
	}
}
