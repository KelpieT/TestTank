using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankGame
{
	public class LevelManager : MonoBehaviour
	{
		public static LevelManager Instance;
		public Transform MinOutBorderLevel;
		public Transform MaxOutBorderLevel;
		public Transform MinInBorderLevel;
		public Transform MaxInBorderLevel;
		public float MinHeighOfDeath = -100f;
		void Awake()
		{
			Instance = this;
		}
		public Vector3 GetRandomPointToSpawn()
		{
			Vector3 minO = MinOutBorderLevel.transform.position;
			Vector3 maxO = MaxOutBorderLevel.transform.position;
			Vector3 minI = MinInBorderLevel.transform.position;
			Vector3 maxI = MaxInBorderLevel.transform.position;
			float x = Random.Range(minO.x, maxO.x);
			float z = minO.z;
			if (x < minI.x || x > maxI.x)
			{
				z = Random.Range(minO.z, maxO.z);
			}
			else
			{
				float chooseSide = Random.value - 0.5f;
				if (chooseSide > 0) z = Random.Range(maxI.z, maxO.z);
				else z = Random.Range(minO.z, minI.z);
			}
			return new Vector3(x, transform.position.y, z);
		}
	}
}
