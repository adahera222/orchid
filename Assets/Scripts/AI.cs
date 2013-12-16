﻿using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {
	
	public const float SPAWN_TIME = 5f;
	public const float SPAWN_TIME_VARIANCE = 5f;
	
	Timer m_time;
	public UnitFactory m_unitFactory;
	
	void Awake() {
		m_time = new Timer();
	}
	
	void Start () {
		SetRandomTime();
	}
	
	void Update () {
		m_time.elapsed += Time.deltaTime;
		while(m_time.HasElapsed()) {
			SpawnUnits();
			
			m_time.SetBack();
			SetRandomTime();
		}
	}
	
	void SpawnUnits() {
		if(State.EnemyMoney > 0) {
			State.EnemyMoney -= State.GetCostOf(Entity.Type.fighter);
			
			GameObject go = m_unitFactory.SpawnUnit(Entity.Type.fighter);
			go.GetComponent<Unit>().SetSourceAndTarget(State.instance.EnemyFabs[Random.Range(0,State.instance.EnemyFabs.Count-1)],
			                                           State.instance.PlayerCities[Random.Range(0,State.instance.PlayerCities.Count-1)]);
		}
	}
	
	void SetRandomTime() {
		m_time.time = Random.Range(SPAWN_TIME,SPAWN_TIME_VARIANCE);
	}
}