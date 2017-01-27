using UnityEngine;
using System.Collections;
using System;

public class DelegatController : MonoBehaviour {

    private delegate void Method();

    //Method CallSomeMethod;

    private Action CallSomeMethod; //принимаем void Method
    private Action<int, bool,string,float> CallSomeMethod2; //принимаем void Method
    private Func<string> CallSomeMethod3;//string Method()
    private Func<int, bool, char, string> CallSomeMethod4; //string Method(int, bool, char)
    private void Awake()
    {
        CallSomeMethod = HugeMethod2;
        CallSomeMethod2 = HugeMethod;
        CallSomeMethod3 = HugeMethod3;
        CallSomeMethod4 = HugeMethod4;
    }

    // Use this for initialization
    private void Start() {

        if (CallSomeMethod != null) CallSomeMethod();
        if (CallSomeMethod2 != null) CallSomeMethod2(1, false, "Kubik", 1.5f);
        if (CallSomeMethod3 != null) Debug.LogFormat("{0} ", HugeMethod3());
        if (CallSomeMethod4 != null) Debug.LogFormat("{0} ", HugeMethod4(1, true, 'd'));
        // if (true)
        //   HugeMethod();
        //else
        //  HugeMethod2();

    }

    // Update is called once per frame
    void HugeMethod (int a, bool b, string g, float f) 
	{
		var go = Instantiate (GameObject.CreatePrimitive (PrimitiveType.Cube));
		go.name = g;

		if (Time.realtimeSinceStartup > f) {
			go.SetActive (b);
		}
        Debug.Log("HugeMethod"+a+" "+b+" "+g+" " +f);
    }

    void HugeMethod2()
    {
        Debug.Log("HugeMethod2");
    }

    string HugeMethod3()
    {
        return "Helo world!";
    }

    string HugeMethod4(int a, bool b, char c)
    {
        Debug.Log("HugeMethod");

        return string.Format ("{0} {1} {2}",a,b,c);
    }
}
