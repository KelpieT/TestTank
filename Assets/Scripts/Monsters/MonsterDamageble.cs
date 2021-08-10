using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TankGame
{
	public class MonsterDamageble : IDamageble
	{

		MonsterData monsterData;
		public void SetDamage(IHealth healthObject)
		{
			healthObject.TakeDamage(monsterData.Damage);
		}
		public MonsterDamageble(MonsterData monsterData)
		{
			this.monsterData = monsterData;
		}
	}
}

