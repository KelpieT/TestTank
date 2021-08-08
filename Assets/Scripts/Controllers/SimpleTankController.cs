using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TankGame
{

	public class SimpleTankController : IController
	{
		public IControllerPreference controllerPreference { get; set; }
		public IControllerActions controllerActions { get; set; }


		public void Update()
		{
			if (controllerPreference == null) return;
			if (controllerActions == null) return;

			if (Input.GetKey(controllerPreference.left)
			&& controllerActions.Rotate != null) controllerActions.Rotate(-1);

			if (Input.GetKey(controllerPreference.right)
			&& controllerActions.Rotate != null) controllerActions.Rotate(1);

			if (Input.GetKeyDown(controllerPreference.weaponSwitchUp)
			&& controllerActions.SwitchWeapons != null) controllerActions.SwitchWeapons(1);

			if (Input.GetKeyDown(controllerPreference.weaponSwitchDown)
			&& controllerActions.SwitchWeapons != null) controllerActions.SwitchWeapons(-1);

			if (Input.GetKeyDown(controllerPreference.fire) ||
			Input.GetKey(controllerPreference.fire)
			&& controllerActions.Fire != null) controllerActions.Fire();
		}
		public void FixedUpdate()
		{
			if (controllerPreference == null) return;
			if (controllerActions == null) return;

			if (Input.GetKey(controllerPreference.forward)
			&& controllerActions.Move != null) controllerActions.Move(1);

			if (Input.GetKey(controllerPreference.backward)
			&& controllerActions.Move != null) controllerActions.Move(-1);
		}
	}
}
