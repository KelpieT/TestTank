using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankGame
{

	public interface IArmor
	{
		float RecalculateDamage(float damage);
	}
}
