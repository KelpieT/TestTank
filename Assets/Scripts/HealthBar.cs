using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TankGame
{
	public class HealthBar : MonoBehaviour
	{
		public IHealth health;
		public Transform healthImage;
		Transform cam;
		void Start()
		{
			if (transform.parent == null) return;
			health = transform.parent.GetComponent<IHealth>();
			health.TakeDamageAct = () => SetHealth();
		}
		public void SetHealth()
		{
			if (health == null) return;
			Vector3 scl = healthImage.localScale;
			float h = health.healthData.CurrentHealth / (health.healthData.MaxHealth - health.healthData.MinHealth);
			healthImage.localScale = new Vector3(h, scl.y, scl.z);
			Vector3 lPos = healthImage.localPosition;
			healthImage.localPosition = new Vector3((1 - h) / 2, lPos.y, lPos.z);
		}
		void Update()
		{
			if (cam == null) cam = CameraManager.Instance.transform;
			transform.LookAt(cam);

		}


	}
}
