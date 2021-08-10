using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankGame
{
	public class AIManager : MonoBehaviour, IGameStates
	{
		public static AIManager Instance;
		public List<Monster> monstersPrefab;
		public List<Monster> monstersOnLevel = new List<Monster>();
		private int countKills;
		public int CountMonstersOnSameTime = 10;
		bool needToFollowPlayer;

		public int CountKills
		{
			get => countKills; set
			{
				countKills = value;
				UIManager.Instance.SetKills(countKills);
			}
		}

		void Awake()
		{
			Instance = this;
		}
		public void InstantiateMonster()
		{
			Monster monstPref = monstersPrefab[Random.Range(0, monstersPrefab.Count)];
			Vector3 pos = LevelManager.Instance.GetRandomPointToSpawn();
			Monster monst = Instantiate<Monster>(monstPref, pos, Quaternion.identity);
			monst.Init();
			monstersOnLevel.Add(monst);
			monst.DeadAct += () =>
			{
				RecheckList();
				InstantiateNotEnoughMonstrs();
				CountKills++;
			};
		}
		public void FinishGame()
		{
			needToFollowPlayer = false;
		}

		public void RestartGame()
		{
            CountKills = 0;
			DestroyCurrentMonsters();
			InstantiateNotEnoughMonstrs();
			needToFollowPlayer = true;
		}

		public void StartGame()
		{
            CountKills = 0;
			DestroyCurrentMonsters();
			InstantiateNotEnoughMonstrs();
			needToFollowPlayer = true;
		}
		void DestroyCurrentMonsters()
		{
			RecheckList();
			for (int i = monstersOnLevel.Count - 1; i >= 0; i--)
			{
				Destroy(monstersOnLevel[i].gameObject);
			}
			monstersOnLevel.Clear();
		}
		void RecheckList()
		{
			for (int i = monstersOnLevel.Count - 1; i >= 0; i--)
			{
				if (monstersOnLevel[i] != null) continue;
				monstersOnLevel.RemoveAt(i);

			}
		}

		void InstantiateNotEnoughMonstrs()
		{
			if (monstersOnLevel.Count >= CountMonstersOnSameTime) return;
			int countToSpawn = CountMonstersOnSameTime - monstersOnLevel.Count;
			for (int i = 0; i < countToSpawn; i++)
			{
				InstantiateMonster();
			}
		}
		void Update() => MoveAllToPlayer();
		void MoveAllToPlayer()
		{
			if (!needToFollowPlayer) return;
			if (MainGame.Instance.player == null) return;
			Transform target = MainGame.Instance.player.transform;
			foreach (var m in monstersOnLevel)
			{
				m.Move(target.position);
			}
		}
	}
}
