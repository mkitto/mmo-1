using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour {

	public GameObject template;
	private Coroutine _coroutine = null;

	public Vector2 range;


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
			CreateEnemy();
			yield return new WaitForSeconds(2f);
		}
	}

	void CreateEnemy()
	{
			GameObject obj = Instantiate(template, this.transform);
            float y = Random.Range(range.x, range.y);
			obj.transform.localPosition = new Vector3(0, y, 0);
	}
}
