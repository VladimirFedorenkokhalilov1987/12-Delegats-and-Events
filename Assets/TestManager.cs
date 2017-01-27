using UnityEngine;
using System.Collections;

public class TestManager : MonoBehaviour {

    [SerializeField]
    private Light _light;

    [SerializeField]
    private MyButton _lightButton;

    // Use this for initialization
    void Start () {
        if (_lightButton) _lightButton.OnMouseDown += SomeMethod;
	}
    void OnDestroy()
    {
        if (_lightButton) _lightButton.OnMouseDown -= SomeMethod;
    }
    // Update is called once per frame
    public void SomeMethod () {
        _light.enabled = !_light.enabled;
	}
}
