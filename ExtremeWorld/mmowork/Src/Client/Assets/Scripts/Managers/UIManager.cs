using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager> {

	// Class
	class UIElement
    {
		public string Resources;
		public bool Cache;
		public GameObject Instance;
    }

	/* Type: Represents type declarations: 
	 *	class types, 
	 *	interface types,
	 *	array types, 
	 *	value types, 
	 *	enumeration types, 
	 *	type parameters, 
	 *	generic type definitions, 
	 *	and open or closed constructed generic types.
	*/
	private Dictionary<Type, UIElement> UIResource = new Dictionary<Type, UIElement>();

	public UIManager()
    {
		this.UIResource.Add(typeof(UITest), new UIElement() { Resources = "UI/UITest", Cache = true });
		this.UIResource.Add(typeof(UIBag), new UIElement() { Resources = "UI/UIBag", Cache = false });
		this.UIResource.Add(typeof(UIShop), new UIElement() { Resources = "UI/UIShop", Cache = false });
		this.UIResource.Add(typeof(UICharEquip), new UIElement() { Resources = "UI/UICharEquip", Cache = false });
		this.UIResource.Add(typeof(UIQuestSystem), new UIElement() { Resources = "UI/UIQuestSystem", Cache = false });
		this.UIResource.Add(typeof(UIQuestDialog), new UIElement() { Resources = "UI/UIQuestDialog", Cache = false });
		this.UIResource.Add(typeof(UIFriend), new UIElement() { Resources = "UI/UIFriend", Cache = false });
	}
	
	~UIManager()
    {
    }

	/// <summary>
	/// Show UI
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <returns></returns>
	public  T Show<T>()
    {
		Type type = typeof(T);
		if (this.UIResource.ContainsKey(type))
        {
			UIElement info = this.UIResource[type];
			if (info.Instance != null)
            {
				info.Instance.SetActive(true);
            }
            else
            {
				UnityEngine.Object prefab = Resources.Load(info.Resources);
				if (prefab == null)
                {
					// default(T)可以得到该类型的默认值.
					return default(T);
                }
				info.Instance = (GameObject)GameObject.Instantiate(prefab);
            }
			return info.Instance.GetComponent<T>();
        }
		return default(T);
	}

	public void Close(Type type)
    {
		if (this.UIResource.ContainsKey(type))
        {
			UIElement info = this.UIResource[type];
			if(info.Cache)
            {
				info.Instance.SetActive(false);
            }
			else
            {
				GameObject.Destroy(info.Instance);
				info.Instance = null;
            }
        }
    }
}
