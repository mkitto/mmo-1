using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : Singleton<UnitManager> {

	public Enemy CreateEnemy(GameObject template)
	{
		if (!template)
			return null;
			
		GameObject obj = Instantiate(template, this.transform);
		Enemy p = obj.GetComponent<Enemy>();
		return p;
	}
}
