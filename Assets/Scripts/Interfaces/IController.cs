using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

namespace TankGame
{
	public interface IController
	{
		IControllerPreference controllerPreference { get; set; }
		IControllerActions controllerActions{get;set;}
		void Update();
		void FixedUpdate();
	}
}
