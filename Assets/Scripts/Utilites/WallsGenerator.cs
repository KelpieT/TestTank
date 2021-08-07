using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankGame
{

	public class WallsGenerator : MonoBehaviour
	{
		public GameObject wallPrefab;
		public Vector3 minWallSize;
		public Vector3 maxWallSize;
		public Transform parentWalls;
		public Transform minBorder;
		public Transform maxBorder;
		public float gridSize;
		public float forceRandom;
		public float halfHeighWall = 0.5f;
		public void GenerateWalls()
		{
			Vector3 minB = minBorder.position;
			Vector3 zone = maxBorder.position - minB;
			int countGridX = (int)(zone.x / gridSize);
			int countGridZ = (int)(zone.z / gridSize);
			float y = transform.position.y + halfHeighWall;
			for (int i = 0; i < countGridX; i++)
			{
				for (int j = 0; j < countGridZ; j++)
				{
					float randomX = (Random.value - 0.5f) * forceRandom;
					float randomZ = (Random.value - 0.5f) * forceRandom;
					Vector3 randomSize = RandomVector3(minWallSize, maxWallSize);
					Vector3 pos = new Vector3(gridSize * i + gridSize * randomX, randomSize.y / 2, gridSize * j + gridSize * randomZ);
					pos += minB;
					Quaternion randomRotation = Quaternion.Euler(0, Random.Range(0, 360f), 0);
					GameObject g = Instantiate(wallPrefab, pos, randomRotation, parentWalls);
					g.transform.localScale = randomSize;
				}
			}
		}

		Vector3 RandomVector3(Vector3 min, Vector3 max)
		{
			return new Vector3(
				Random.Range(min.x, max.x),
				Random.Range(min.y, max.y),
				Random.Range(min.z, max.z)
				);
		}

	}
}
