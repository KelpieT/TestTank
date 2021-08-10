using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TankGame
{
	public class SimpleTank : Tank
	{
		void Start()
		{
			InitController();
			InitHealthData(tankData);
			armor = new MainArmor(tankData);
		}
		public override void InitController()
		{
			controller = new SimpleTankController();
			controller.controllerPreference = new PlayerControllerPreference();
			controller.controllerActions = new SimpleTankControllerActions(this);
		}

		public override void Move(float moveDir)
		{
			Vector3 targetPos = transform.position + transform.rotation * Vector3.forward * tankData.MoveSpeed * moveDir;
			targetPos = Vector3.Lerp(transform.position, targetPos, tankData.MoveSpeedLerp * Time.fixedDeltaTime);
			rb.MovePosition(targetPos);

		}

		public override void Rotate(float rotateDir)
		{
			Vector3 curRot = transform.rotation.eulerAngles;
			Quaternion targetRot = Quaternion.Euler(curRot.x, curRot.y + tankData.RotateSpeed * rotateDir, curRot.z);
			transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, tankData.RotateSpeedLerp * Time.deltaTime);
		}
	}
}
