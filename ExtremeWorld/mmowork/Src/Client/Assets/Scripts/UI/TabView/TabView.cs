using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TabView : MonoBehaviour {

	public TabButton[] tabButtons;
	public GameObject[] tabPage;
	public UnityAction<int> OnTabSelect;

	public int index = -1;

	// Use this for initialization
	IEnumerator Start () {
		for (int i = 0; i < tabButtons.Length; i++)
        {
			tabButtons[i].tabView = this;
			tabButtons[i].tabIndex = i;
        }
		yield return new WaitForEndOfFrame();
		SelectTab(0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SelectTab(int selectIndex)
    {
		if (this.index != selectIndex)
        {
			for (int i = 0; i < tabButtons.Length; i++)
            {
				tabButtons[i].Select(i == selectIndex);
				if (tabPage.Length > i)
					tabPage[i].SetActive(i == selectIndex);
            }
			this.index = selectIndex;
        }
		if (OnTabSelect != null)
			OnTabSelect(selectIndex);
	}
}
