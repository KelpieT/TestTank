using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace TankGame
{
	public abstract class Tank : MonoBehaviour, IHealth, IHealthData
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
		public Transform pointToSpawn;
		public IHealthData healthData { get; set; }
		public Action DeadAct { get; set; }
		public float CurrentHealth { get; set; }
		public float MinHealth { get; set; }
		public float MaxHealth { get; set; }
		public Action TakeDamageAct { get; set; }

		public IArmor armor;
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
			if (pointToSpawn == null) return;
			weapons[SelectedWeapon]?.Fire(pointToSpawn);
		}
		void Update()
		{
			controller?.Update();
			if (transform.position.y < LevelManager.Instance.MinHeighOfDeath) Dead();
		}
		void FixedUpdate()
		{
			controller?.FixedUpdate();
		}
		public void Dead()
		{
			DeadAct?.Invoke();
			Destroy(gameObject);
		}

		public void TakeDamage(float forceDamage)
		{
			CurrentHealth -= armor.RecalculateDamage(forceDamage);
			TakeDamageAct?.Invoke();
			CheckForDead(this);
		}

		public void InitHealthData(IHealthData tankData)
		{
			CurrentHealth = tankData.MaxHealth;
			MinHealth = 0;
			MaxHealth = tankData.MaxHealth;
			healthData = this;
		}

		public void CheckForDead(IHealthData healthData)
		{
			if (healthData.CurrentHealth > MinHealth) return;
			Dead();
		}
		public void Init()
		{
			InitController();
			InitHealthData(tankData);
			armor = new MainArmor(tankData);
		}
	}
}
