using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TankGame
{
	public class HeavyBullet : Bullet
	{
		public Rigidbody rb;
		Vector3 direction = new Vector3(0, 1, 1);
		int maxColliders = 100;
		public override void Fire()
		{
			if (bulletData == null) return;
			
			Vector3 dir = transform.rotation * direction.normalized * bulletData.Speed;
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
