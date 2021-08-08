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
        protected void Collide(){}
	}
}
