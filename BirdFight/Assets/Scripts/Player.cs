using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{

	public Rigidbody2D rigidbodyBird;
	public float forceCoef;
	public Animator ani;
	private bool _death;
	public delegate void DeathNotify();
	public UnityAction<int> OnScore;

	public event DeathNotify OnDeath;

	private Vector3 _initPos;
    public float speed;
    public GameObject bulletTemplate;
	public int fireRate;
	private float fireTimer = 0;

	// Use this for initialization
	void Start()
	{
		this.ani = this.GetComponent<Animator>();
		_initPos = this.transform.position;
		Idle();
	}

	// Update is called once per frame
	void Update()
	{
		if (this._death)
			return;

		fireTimer += Time.deltaTime;

		Vector2 pos = this.transform.position;
		pos.x += Input.GetAxis("Horizontal") * Time.deltaTime * speed;
		pos.y += Input.GetAxis("Vertical") * Time.deltaTime * speed;
		this.transform.position = pos;

		if (Input.GetButton("Fire1"))
        {
			this.Fire();
        }
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

	public void Init()
    {
		this.transform.position = _initPos;
		this.Idle();
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
		if (! col.gameObject.name.Equals("ScoreArea"))
			Die();
	}

	void OnTriggerExit2D(Collider2D col)
	{
		Debug.Log("OnTriggerExit2D " + col.gameObject.name);
		if (col.gameObject.name.Equals("ScoreArea"))
		{
			if (this.OnScore != null)
            {
				this.OnScore(1);
            }
		}
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