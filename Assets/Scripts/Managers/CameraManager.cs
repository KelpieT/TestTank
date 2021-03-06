using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankGame
{
	[RequireComponent(typeof(Camera))]
	public class CameraManager : MonoBehaviour, IGameStates
	{
		public static CameraManager Instance;
		public Vector3 offsetTarget;
		Transform target;
		bool needFollow;
		Vector3 currentVelocity;
		public float smoothTime = 0.15f;

		public void FinishGame()
		{
			target = null;
			needFollow = false;
		}

		public void RestartGame()
		{
			StartGame();
		}

		public void StartGame()
		{
			target = MainGame.Instance.player.transform;
			needFollow = true;
		}
		void FollowPlayer()
		{
			if (!needFollow) return;
			if (target == null) return;
			transform.position = Vector3.SmoothDamp(transform.position, target.position + offsetTarget, ref currentVelocity, smoothTime);
		}

		void Awake()
		{
			Instance = this;
		}
		void FixedUpdate() => FollowPlayer();
	}
}
