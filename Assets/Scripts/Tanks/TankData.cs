﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankGame
{
	[CreateAssetMenu(fileName = "TankData", menuName = "TankGame/TankData")]
	public class TankData : ScriptableObject
	{
		public float MoveSpeed;
		public float MoveSpeedLerp;
		public float RotateSpeed;
		public float RotateSpeedLerp;

	}
}
