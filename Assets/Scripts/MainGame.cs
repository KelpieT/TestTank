using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankGame
{
	public class MainGame : MonoBehaviour, IGameStates
	{
		public static MainGame Instance;
		public Transform spawnPoint;
		public Tank tankPrefab;
		[HideInInspector]
		public Tank player;

		public List<IGameStates> managers = new List<IGameStates>();
		public void FinishGame()
		{
			foreach (IGameStates manager in managers)
			{
				manager.FinishGame();
			}
		}

		public void RestartGame()
		{
			if (player != null) Destroy(player.gameObject);
			InitPlayer();
			foreach (IGameStates manager in managers)
			{
				manager.RestartGame();
			}
		}

		public void StartGame()
		{
			InitPlayer();
			foreach (IGameStates manager in managers)
			{
				manager.StartGame();
			}
		}
		void InitManagers()
		{
			managers.Add(AIManager.Instance);
			managers.Add(CameraManager.Instance);
			managers.Add(UIManager.Instance);
		}

		void Awake()
		{
			Instance = this;
		}
		void Start()
		{
			InitManagers();
		}
		void InitPlayer()
		{
			player = Instantiate(tankPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
			player.Init();
			player.DeadAct += () => FinishGame();
		}

	}
}
