using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICharInfo : MonoBehaviour {
	public SkillBridge.Message.NCharacterInfo info;

	public Text charClass;
	public Text charName;
	public Image highlight;

	public bool Selected
    {
		get { return highlight.IsActive(); }
        set
        {
			highlight.gameObject.SetActive(value);
        }
    }

	// Use this for initialization
	void Start () {
		initUI();
		if (info != null)
        {
			this.charClass.text = this.info.Class.ToString();
			Debug.LogFormat("charClass.text: {0}", this.charClass.text);
			this.charName.text = this.info.Name;
			Debug.LogFormat("charName.text: {0}", this.charName.text);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void initUI()
    {
		GameObject root = this.gameObject;
		charClass = root.transform.Find("Image/Type").GetComponent<Text>();
        charName = root.transform.Find("Name").GetComponent<Text>();
		highlight = root.transform.Find("Img_Select").GetComponent<Image>();
	}
}
