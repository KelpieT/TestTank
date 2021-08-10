using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TankGame
{
	public class HeavyBullet : Bullet
	{
		public Rigidbody rb;
		public override void Fire()
		{
			if (bulletData == null) return;
			Vector3 dir = transform.rotation * new Vector3(0, 1, 1).normalized * bulletData.Speed;
			rb.AddForce(dir, ForceMode.Impulse);
		}

		protected override void Collide(Collider col)
		{
			Destroy(gameObject);
			if(CheckNull()) return;
			Explode();
		}
		void Explode()
		{
			int maxColliders = 100;
			Collider[] hitColliders = new Collider[maxColliders];
			int numColliders = Physics.OverlapSphereNonAlloc(transform.position, bulletData.ExplosionRadius, hitColliders);
			for (int i = 0; i < numColliders; i++)
			{
				IHealth health = hitColliders[i].GetComponent<IHealth>();
				if (health == null) continue;
				damageble.SetDamage(health);

			}
		}

	}
}
