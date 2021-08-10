using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TankGame
{
	public interface IGameStates
	{
		void StartGame();
		void FinishGame();
		void RestartGame();
	}
}
