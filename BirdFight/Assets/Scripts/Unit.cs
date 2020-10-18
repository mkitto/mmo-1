using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

	public Rigidbody2D rigidbodyBird;
	public Animator ani;
	protected bool _death;
	public delegate void DeathNotify();

	public float speed;
	public int fireRate;
	protected float fireTimer = 0;
	public GameObject bulletTemplate;
	public SIDE side;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Idle()
	{
		this.rigidbodyBird.simulated = false;
		this.ani.SetTrigger("Idle");
	}

	public void Fly()
	{
		this.rigidbodyBird.simulated = true;
		this.ani.SetTrigger("Fly");
	}

	public void Fire()
	{
		if (fireTimer > 1.0 / fireRate)
		{
			GameObject bullet = Instantiate(bulletTemplate);
			bullet.transform.position = this.transform.position;
			fireTimer = 0.0f;
		}
	}

	public virtual void Die()
    {

    }
}
