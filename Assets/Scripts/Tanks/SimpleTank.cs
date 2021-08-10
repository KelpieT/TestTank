using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TankGame
{
	public class SimpleTank : Tank
	{
		public override void InitController()
		{
			controller = new SimpleTankController();
			controller.controllerPreference = new PlayerControllerPreference();
			controller.controllerActions = new SimpleTankControllerActions(this);
		}

		public override void Move(float moveDir)
		{
			Vector3 targetPos = transform.position;
			Vector3 toAdd = transform.rotation * Vector3.forward * tankData.MoveSpeed * moveDir * tankData.MoveSpeedLerp * Time.fixedDeltaTime;
			targetPos += toAdd;
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
