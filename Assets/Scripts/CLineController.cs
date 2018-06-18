using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent (typeof(LineRenderer))]
[RequireComponent (typeof(EdgeCollider2D))]
public class CLineController : MonoBehaviour {

	[SerializeField]	protected float m_MinDistance = 0.1f;
	[SerializeField]	protected float m_MaximumLength = 10f;
	[SerializeField]	protected List<Vector2> m_LineV2;
	public List<Vector2> lineV3 { 
		get { return this.m_LineV2; } 
		set { this.m_LineV2 = new List<Vector2> (value); }
	}

	protected Transform m_Transform;
	protected LineRenderer m_LineRenderer;
	protected EdgeCollider2D m_EdgeCollider2D;

	protected virtual void Awake() {
		this.m_Transform = this.transform;
		this.m_LineRenderer = this.GetComponent<LineRenderer> ();
		this.m_EdgeCollider2D = this.GetComponent<EdgeCollider2D> ();
		this.InitLine ();
	}

	protected virtual void Start() {
		
	}

	public virtual void InitLine() {
		this.m_LineV2 = new List<Vector2> ();
		this.m_EdgeCollider2D.edgeRadius = this.m_LineRenderer.widthMultiplier / 2f;
	}

	public virtual void DrawPoint(Vector2 point) {
		if (this.m_LineV2 == null) {
			this.InitLine ();
		}
		if (this.m_LineV2.Count > 0) {
			if (Vector2.Distance (this.m_LineV2.Last(), point) < this.m_MinDistance) {
				return;
			}
			var previousPoint = this.m_LineV2[0];
			var currentLength = 0f;
			for (int i = 1; i < this.m_LineV2.Count; i++)
			{
				var linePoint = this.m_LineV2[i];
				var distance = (linePoint - previousPoint).magnitude;
				currentLength += distance;
				previousPoint = linePoint;
				if (currentLength >= this.m_MaximumLength) {
					return;
				}
			}
		} 
		this.m_EdgeCollider2D.enabled = this.m_LineV2.Count > 0;
		this.m_LineV2.Add (point);
		this.m_LineRenderer.positionCount = this.m_LineV2.Count;
		this.m_LineRenderer.SetPosition (this.m_LineV2.Count - 1, point);
		this.m_EdgeCollider2D.points = this.m_LineV2.ToArray();
	}

	public virtual void Redraw() {
		this.m_LineRenderer.positionCount = this.m_LineV2.Count;
		for (int i = 0; i < this.m_LineV2.Count; i++)
		{
			var point = this.m_LineV2[i];
			this.m_LineRenderer.SetPosition (i, point);
		}
	}
	
}
