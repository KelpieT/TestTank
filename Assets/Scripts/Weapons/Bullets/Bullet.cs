using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TankGame
{
	public abstract class Bullet : MonoBehaviour
	{
		public IDamageble damageble;
		public BulletData bulletData;
		public abstract void Fire();
		protected abstract void Collide(Collider col);
		protected bool CheckNull()
		{
			return damageble == null || bulletData == null;
		}
		void OnTriggerEnter(Collider col)
		{
			Collide(col);
		}
		void OnEnable()
		{
			Invoke(nameof(DestroyByTime), bulletData.LifeTimeBullet);
		}
		void DestroyByTime()
		{
			Destroy(gameObject);
		}
	}
}
