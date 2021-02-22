using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entities;

/*
 * 负责namebar等的增删
 */

public class UIWorldElementManager : MonoSingleton<UIWorldElementManager> 
{
	public GameObject nameBarPrefab;

	private Dictionary<Transform, GameObject> elements = new Dictionary<Transform, GameObject>();

    protected override void OnStart()
    {
		nameBarPrefab.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddCharacterNameBar(Transform owner, Character character)
    {
		GameObject goNameBar = Instantiate(nameBarPrefab, this.transform);
		goNameBar.name = "NameBar" + character.entityId;
		goNameBar.GetComponent<UIWorldElement>().owner = owner;
		goNameBar.SetActive(true);
		this.elements[owner] = goNameBar;
    }

	public void RemoveCharacterNameBar(Transform owner)
    {
		if (this.elements.ContainsKey(owner))
        {
			Destroy(this.elements[owner]);
			this.elements.Remove(owner);
        }
    }
}
