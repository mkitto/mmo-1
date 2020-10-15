using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public Rigidbody2D rigidbodyBird;
	public Animator ani;
	private bool _death;
	public delegate void DeathNotify();

	public event DeathNotify OnDeath;

	public float speed;
	public GameObject bulletTemplate;
	public int fireRate;
	private float fireTimer = 0;
	public float lifeTime;

	// Use this for initialization
	void Start()
	{
		this.ani = this.GetComponent<Animator>();
		Idle();
		Destroy(this.gameObject, lifeTime);
	}

	// Update is called once per frame
	void Update()
	{
		if (this._death)
			return;

		fireTimer += Time.deltaTime;

		this.transform.position += new Vector3(-Time.deltaTime * speed, 0, 0);

		Fire();
	}

	public void Fire()
	{
		if (fireTimer > 1.0 / fireRate)
		{
			GameObject bullet = Instantiate(bulletTemplate);
			bullet.transform.position = this.transform.position;
			bullet.GetComponent<Bullet>().direction = -1;

			//// 每个周期去进行遍历操作，消耗是比较大的，使用预制体
			//SpriteRenderer[] sprs = bullet.GetComponentsInChildren<SpriteRenderer>();
			//foreach(SpriteRenderer spr in sprs)
   //         {
			//	spr.color = Color.red;
   //         }
			fireTimer = 0.0f;
		}
	}

	public void Init()
	{
		this.Fly();
		this._death = false;
	}

	public void Idle()
	{
		this.rigidbodyBird.simulated = false;
		this.ani.SetTrigger("Idle");
	}

	public void Fly()
	{
		//this.rigidbodyBird.simulated = true;
		this.ani.SetTrigger("Fly");
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		Debug.Log("OnTriggerEnter2D " + col.gameObject.name);
		if (!col.gameObject.name.Equals("ScoreArea"))
			Die();
	}

	void OnTriggerExit2D(Collider2D col)
	{
		Debug.Log("OnTriggerExit2D " + col.gameObject.name);
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		Die();
		Debug.Log("OnCollisionEnter2D " + col.gameObject.name);
	}

	public void Die()
	{
		this._death = true;
		if (this.OnDeath != null)
		{
			this.OnDeath();
		}
	}
}
