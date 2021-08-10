using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TankGame
{

	public class SimpleBullet : Bullet
	{
		public Rigidbody rb;
		public override void Fire()
		{
			if (bulletData == null) return;
			Vector3 dir = transform.rotation * Vector3.forward * bulletData.Speed;
			rb.AddForce(dir, ForceMode.Impulse);
		}

		protected override void Collide(Collider col)
		{
			if(CheckNull()) return;
			var healthObject = col.gameObject.GetComponent<IHealth>();
			Destroy(gameObject);
			if (healthObject == null) return;
			damageble.SetDamage(healthObject);
		}

	}

}