using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace TankGame
{

	public class Monster : MonoBehaviour, IHealth, IHealthData
	{
		public MonsterData monsterData;
		public float CurrentHealth { get; set; }
		public float MinHealth { get; set; }
		public float MaxHealth { get; set; }
		public IHealthData healthData { get; set; }
		public Action DeadAct { get; set; }
		public Action TakeDamageAct { get; set; }

		public IArmor armor;
		public NavMeshAgent navMeshAgent;
		public IDamageble damageble;
		float lastTimeAttacked;
		bool isDead = false;
		public void Init()
		{
			damageble = new MonsterDamageble(monsterData);
			armor = new MainArmor(monsterData);
			InitHealthData(monsterData);
			navMeshAgent.speed = monsterData.MoveSpeed;
		}

		public void Dead()
		{
			if (isDead) return;
			isDead = true;
			DeadAct?.Invoke();
			Destroy(gameObject);

		}
		public void TakeDamage(float forceDamage)
		{
			CurrentHealth -= armor.RecalculateDamage(forceDamage);
			TakeDamageAct?.Invoke();
			CheckForDead(this);
		}
		public void Move(Vector3 pos)
		{
			if (navMeshAgent == null) return;
			navMeshAgent.SetDestination(pos);
		}
		void OnTriggerEnter(Collider col)
		{
			Tank tank = col.GetComponent<Tank>();
			if (tank == null) return;
			Attack(tank);
		}
		void OnTriggerStay(Collider col)
		{
			Tank tank = col.GetComponent<Tank>();
			if (tank == null) return;
			Attack(tank);
		}

		public void InitHealthData(IHealthData monsterData)
		{
			CurrentHealth = monsterData.MaxHealth;
			MinHealth = 0;
			MaxHealth = monsterData.MaxHealth;
			healthData = this;
		}
		public void CheckForDead(IHealthData healthData)
		{
			if (healthData.CurrentHealth > MinHealth) return;
			Dead();
		}
		void Update()
		{
			if (transform.position.y < LevelManager.Instance.MinHeighOfDeath) Dead();
		}
		void Attack(Tank tank)
		{
			if (monsterData.AttackRatePerSecond == -1) return;
			float time = Time.time;
			if (lastTimeAttacked + 1 / monsterData.AttackRatePerSecond > time) return;
			damageble.SetDamage(tank);
			lastTimeAttacked = Time.time;
		}

	}
}
