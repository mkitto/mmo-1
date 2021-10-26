using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// abstact:
/// 抽象类不能实例化
/// 抽象类可以包含抽象方法和抽象访问器
/// 不能用 sealed 修饰符修饰抽象类，因为这两个修饰符的含义是相反的。
///		采用 sealed 修饰符的类无法继承，而abstract修饰符要求对类进行继承。
/// 从抽象类派生的非抽象类必须包括继承的所有抽象方法和抽象访问器的实际实现
/// </summary>
public abstract class UIWindow : MonoBehaviour {

	public delegate void CloseHander(UIWindow sender, WindowResult result);
	public event CloseHander OnClose;

	/// <summary>
	/// 1.virtual方法本身是包含函数体的,是可以被执行调用的.这个是其与abstract方法的本质区别
	/// 2. 对于基类中标识为virtual方法的函数,如果在其派生类中有同名方法,则需加上new或者override分别表示重新写或者覆盖
	/// 3.如果不加new或者override,编译器会发出警报但是不会判定错误，编译的效果和new相同
	/// 4.对于使用派生类构造函数实例化基类一个对象的常见用法，如果使用new修饰，则该对象调用基类方法，如果用override,则该对象调用派生类方法
	/// </summary>
	public virtual System.Type Type { get { return this.GetType(); } }

	public enum WindowResult
    { 
		None = 0,
		Yes,
		No,
	}


	public void Close(WindowResult result = WindowResult.None)
    {
		UIManager.Instance.Close(this.Type);
		if (this.OnClose != null)
			this.OnClose(this, result);
		this.OnClose = null;
    }

	public virtual void OnCloseClick()
    {
		this.Close();
    }

	public virtual void OnYesClick()
    {
		this.Close(WindowResult.Yes);
    }

	public virtual void OnNoClick()
    {
		this.Close(WindowResult.No);
	}

	void OnMouseDown()
    {
		Debug.LogFormat(this.name + " Clicked");
    }
}
