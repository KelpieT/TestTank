using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TankGame
{
	public class UIManager : MonoBehaviour, IGameStates
	{
		public static UIManager Instance;
		public Button startButton;
		public Button restartButton;
		public Text CountKillsText;
		string killsString = "Count Kills: ";

		void Awake()
		{
			Instance = this;
		}
		void Start()
		{
			startButton.onClick.AddListener(() => MainGame.Instance.StartGame());
			restartButton.onClick.AddListener(() => MainGame.Instance.RestartGame());
			ShowStartGame();
		}
		void ShowStartGame()
		{
			ShowGame(false);
			ShowStart(true);
			ShowRestart(false);
		}


		public void FinishGame()
		{
			ShowGame(false);
			ShowStart(false);
			ShowRestart(true);
		}

		public void RestartGame()
		{
			ShowGame(true);
			ShowStart(false);
			ShowRestart(false);
		}

		public void StartGame()
		{
			ShowGame(true);
			ShowStart(false);
			ShowRestart(false);
		}
		void ShowRestart(bool show)
		{
			restartButton.gameObject.SetActive(show);
		}
		void ShowStart(bool show)
		{
			startButton.gameObject.SetActive(show);
		}
		void ShowGame(bool show)
		{
			CountKillsText.gameObject.SetActive(show);
		}
		public void SetKills(int count)
		{
			CountKillsText.text = killsString + count.ToString();
		}
	}
}
