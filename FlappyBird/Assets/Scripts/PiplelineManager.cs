using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class PiplelineManager : MonoBehaviour {

	public GameObject template;
	private Coroutine _coroutine = null;
	List<Pipeline> pipelines = new List<Pipeline>();

	public void Init()
    {
		for(int i = 0; i < pipelines.Count; i++)
        {
			Destroy(pipelines[i].gameObject);
        }
		pipelines.Clear();
    }

	public void StartRun()
    {
        _coroutine = StartCoroutine(GeneratePiplelines());
    }

	public void Stop()
    {
		StopCoroutine(_coroutine);
		for (int i = 0; i < pipelines.Count; i++)
        {
			pipelines[i].enabled = false;
        }
    }

	 IEnumerator GeneratePiplelines()
    {
		for(int i = 0; i < 3; i++)
        {
			if (pipelines.Count < 3)
            {
				CreatePipeline();
			}
			else
            {
				pipelines[i].enabled = true;
				pipelines[i].Init();
			}
				
			yield return new WaitForSeconds(2f);
		}
    }

	void CreatePipeline()
    {
		if (pipelines.Count < 3)
        {
			GameObject obj = Instantiate(template, this.transform);
			Pipeline p = obj.GetComponent<Pipeline>();
			pipelines.Add(p);
		}
    }
}
