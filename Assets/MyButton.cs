using UnityEngine;
using System.Collections;
using System;

public class MyButton : MonoBehaviour {

    //public Action SomeAction { get; set; }
    public event Action OnMouseDown;

    private void OnMouseDownHandler()
    {
        if (OnMouseDown != null) OnMouseDown();

    }
  
	
	// Update is called once per frame
	void OnGUI () {
        if (GUI.Button(new Rect(10, 10, 100, 50), "Click"))
        {
            OnMouseDownHandler();
        }
    }
}
