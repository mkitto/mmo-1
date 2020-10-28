using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {
	public event DeathNotify OnDeath;
	public Rigidbody2D rigidbodyBird;
	public Animator ani;
	protected bool _death;
	public delegate void DeathNotify();

	public float speed;
	public int fireRate;
	protected float fireTimer = 0;
	public GameObject bulletTemplate;
	public SIDE side;

	public int HP = 100;
	public int MaxHp = 100;

	protected Vector3 _initPos;
	public Transform firePoint1;

	public float Attack;

	// Use this for initialization
	void Start () {
		this.ani = this.GetComponent<Animator>();
		_initPos = this.transform.position;
		Idle();
		OnStart();
	}
	
	public virtual void OnStart()
    {

    }

	// Update is called once per frame
	void Update () {
		if (this._death)
			return;

		fireTimer += Time.deltaTime;
		OnUpdate();
	}

	public virtual void OnUpdate()
	{

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
		this._death = true;
		this.ani.SetTrigger("Die");
		if (this.OnDeath != null)
		{
			this.OnDeath();
		}
		Destroy(this.gameObject, 0.15f);
	}

	public void Damage(int power)
    {
		HP -= power;
    }
}
