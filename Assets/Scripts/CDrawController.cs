using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDrawController : MonoBehaviour {

	[SerializeField]	protected CLineController m_LinePrefab;

	[SerializeField]	protected CLineController m_CurrentLine;

	protected virtual void Update() {
		if (Input.GetMouseButtonDown (0)) {
			if (this.m_CurrentLine == null) {
				this.m_CurrentLine = Instantiate (this.m_LinePrefab);
			}
			this.m_CurrentLine.InitLine();
		}
		if (Input.GetMouseButton(0)) {
			if (this.m_CurrentLine != null) {
				var drawPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				this.m_CurrentLine.DrawPoint (drawPoint);
			}
		}
	}	
	
}
