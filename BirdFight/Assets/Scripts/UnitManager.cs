using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour {

	public GameObject template1;
	public GameObject template2;
	public GameObject template3;

	private Coroutine _coroutine = null;

	public int speed1;
	public int speed2;
	public int speed3;

	int timer1 = 0;
	int timer2 = 0;
	int timer3 = 0;


	public void StartRun()
	{
		_coroutine = StartCoroutine(GenerateEnemys());
	}

	public void Stop()
	{
		StopCoroutine(_coroutine);
	}

	IEnumerator GenerateEnemys()
	{
		while(true)
		{
			if (timer1 > speed1)
            {
				CreateEnemy(template1);
				timer1 = 0;
			}

			if (timer2 > speed2)
			{
				CreateEnemy(template2);
				timer2 = 0;
			}

			if (timer3 > speed3)
			{
				CreateEnemy(template3);
				timer3 = 0;
			}

			timer1++;
			timer2++;
			timer3++;

			yield return new WaitForSeconds(2f);
		}
	}

	void CreateEnemy(GameObject template)
	{
		if (!template)
			return;
			
		GameObject obj = Instantiate(template, this.transform);
	}
}
