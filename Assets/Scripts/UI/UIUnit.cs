﻿using UnityEngine;
using System.Collections;

public class UIUnit : MonoBehaviour {
	
	private UIFab m_fab;
	private Entity.Type m_type;
	
	public UIFab fab {
		get { return m_fab; }
		set { m_fab = value; }
	}
	
	public Entity.Type type {
		get { return m_type; }
		set { m_type = value; }
	}
	
	void OnMouseDown() {
		m_fab.AddToSpawnList(m_type);
	}
}
