using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	public float speed;
	public Vector3 direction;
	public SIDE side;
	public int power = 1;
	public float lifeTime;
	// Use this for initialization
	void Start () {
		Destroy(this.gameObject, lifeTime);
	}
	
	// Update is called once per frame
	void Update () {
		OnUpdate();
	}

	public virtual void OnUpdate()
    {
		this.transform.position += speed * Time.deltaTime * direction;
		if (!Screen.safeArea.Contains(Camera.main.WorldToScreenPoint(this.transform.position)))
		{
			Destroy(this.gameObject, 0.5f);
		}
	}
}
