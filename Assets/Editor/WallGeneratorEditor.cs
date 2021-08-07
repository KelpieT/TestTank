using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace TankGame
{

	[CustomEditor(typeof(WallsGenerator))]
	public class WallGeneratorEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			DrawDefaultInspector();
			WallsGenerator spawner = (WallsGenerator)target;
			if (GUILayout.Button("Spawn"))
				spawner.GenerateWalls();
		}
	}
}
