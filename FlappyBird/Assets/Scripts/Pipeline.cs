using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Pipeline : MonoBehaviour {

	public float Speed;
	public float min;
	public float max;

	private float t = 0;
	// Use this for initialization
	void Start () {
		Init();
	}

	public void Init()
    {
		float y = Random.Range(min, max);
		this.transform.localPosition = new Vector3(0.0f, y, 0.0f);
	}	
	// Update is called once per frame
	void Update () {
        this.transform.position += new Vector3(Speed, 0.0f, 0.0f) * Time.deltaTime;
		t += Time.deltaTime;
		if (t > 6)
        {
			Init();
			t = 0;
        }
    }
}
