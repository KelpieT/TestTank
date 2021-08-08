using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TankGame
{
	public abstract class Tank : MonoBehaviour
	{
		public Rigidbody rb;
		public IController controller;
		public TankData tankData;
		public List<Weapon> weapons;
		int selectedWeapon;
		int SelectedWeapon
		{
			get => selectedWeapon;
			set
			{
				selectedWeapon = value;
				if (value > weapons.Count - 1) selectedWeapon = 0;
				if (value < 0) selectedWeapon = weapons.Count - 1;
				
			}
		}
		public abstract void InitController();
		public abstract void Move(float moveDir);
		public abstract void Rotate(float rotateDir);
		public void SwitchWeapons(int dir)
		{
			if (weapons == null) return;
			SelectedWeapon += dir;
			for (int i = 0; i < weapons.Count; i++) weapons[i].gameObject.SetActive(i == SelectedWeapon);
		}
		public void Fire()
		{
			if (weapons == null || weapons.Count == 0) return;
			weapons[SelectedWeapon]?.Fire();
		}
		void Update()
		{
			controller?.Update();
		}
		void FixedUpdate()
		{
			controller?.FixedUpdate();
		}
	}
}
