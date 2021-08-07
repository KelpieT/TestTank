using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TankGame
{
	public interface IDamageble {
		void SetDamage(IHealth healthObject);
	 }
}
