using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TankGame
{
	public class ShardsBullet : Bullet
	{
		private const float FULL_ANGLE = 360f;
		public Rigidbody rb;
		public Bullet bullet;
		public override void Fire()
		{
			if (bulletData == null) return;
			Vector3 dir = transform.rotation * Vector3.forward * bulletData.Speed;
			rb.AddForce(dir, ForceMode.Impulse);
		}

		protected override void Collide(Collider col)
		{
			if (CheckNull()) return;
			var healthObject = col.gameObject.GetComponent<IHealth>();
			Destroy(gameObject);
			InstShared();
			if (healthObject == null) return;
			damageble.SetDamage(healthObject);

		}
		void InstShared()
		{
			if (bulletData.CountShards <= 0) return;
			float startAngle = transform.rotation.eulerAngles.y;
			float angleToAdd = FULL_ANGLE / bulletData.CountShards;
			startAngle -= angleToAdd / 2;
			for (int i = 0; i < bulletData.CountShards; i++)
			{
				Quaternion rot = Quaternion.Euler(0, startAngle + angleToAdd * i, 0);
				Bullet bullet = Instantiate<Bullet>(this.bullet, transform.position + rot * Vector3.forward, rot);
				bullet.damageble = this.damageble;
				bullet.Fire();
			}
		}
	}
}
