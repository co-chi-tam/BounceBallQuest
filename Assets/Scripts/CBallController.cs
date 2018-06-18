using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CBallController : MonoBehaviour {

	[SerializeField]	protected Vector3 m_StartPosition;

	protected Transform m_Transform;
	protected Rigidbody2D m_Rigidbody2D;

	protected virtual void Awake() {
		this.m_Transform = this.transform;
		this.m_Rigidbody2D = this.GetComponent<Rigidbody2D>();
	}

	public virtual void InitBall() {
		this.m_Transform.position = this.m_StartPosition;
		this.m_Rigidbody2D.velocity = Vector2.zero;
	}

	protected virtual void OnBecameInvisible()
	{
		this.InitBall ();
	}
	
}
