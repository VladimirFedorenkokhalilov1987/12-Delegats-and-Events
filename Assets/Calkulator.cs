using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;


public class Calkulator : MonoBehaviour {


    [SerializeField]
    private float _operand1;

    [SerializeField]
    private float _operand2;

    [SerializeField]
    private string _operator;

	private string onlyNumbers = "";
	private string onlyOperators = "";
	private string onlyNumbers2 = "";

    private Dictionary<string, Func<float, float,float>> _actionDict;
    
    void Start () {

	}

    void OnGUI()
    {
		
		onlyNumbers= GUI.TextField(new Rect(30, 40, 100, 20), onlyNumbers, 10);
		onlyNumbers= Regex.Replace(onlyNumbers, "[^0-9]", "");

		onlyOperators= GUI.TextField(new Rect(140, 40, 20, 20), onlyOperators, 1);
		onlyOperators= Regex.Replace(onlyOperators, "[^-,+, *, /]", "");

		onlyNumbers2= GUI.TextField(new Rect(170, 40, 100, 20), onlyNumbers2, 10);
		onlyNumbers2= Regex.Replace(onlyNumbers2, "[^0-9]", "");

        if (GUI.Button(new Rect(100, 80, 100, 50), "Calculate"))
        {
			if (_operand1!=null && _operand2!=null && _operator!=string.Empty) {
				StartCoroutine (WaitAndDo
                (
					0f,
					() => {
							this.GetComponent<GUIText> ().text = onlyNumbers + onlyOperators + onlyNumbers2 + "="
						+ Calculate ().ToString ();
						Debug.LogFormat ("{0}", Calculate ().ToString ());
					}
				));
			}
        }
    }

    private float Calculate()
    {
		float.TryParse (onlyNumbers, out _operand1);
		float.TryParse (onlyNumbers2, out _operand2);
		_operator = onlyOperators;

        if (_actionDict == null) InitDict();
        return (_actionDict[_operator])(_operand1, _operand2);

        
       /* switch(_operator)
        {
            case "+":
                return Sum(_operand1, _operand2);

            case "-":
                return Substraktion(_operand1, _operand2);

            case "*":
                return Multiply(_operand1, _operand2);

            case "/":
                return Division(_operand1, _operand2);

            default: throw new ArgumentException(_operator);

        }*/
    }

    private void InitDict()
    {
        _actionDict = new Dictionary<string, Func<float, float,float>>
        {
            { "+", Sum},
            { "-", Substraktion},
            { "*", Multiply},
            { "/", Division}
        };
    }

    private float Sum(float f, float f1)
    {
		//var tempf = float.TryParse (onlyNumbers, out f);
		//var tempf1 = float.TryParse (onlyNumbers2, out f1);
        return f + f1;
    }

    private float Substraktion(float f, float f1)
    {
        return f - f1;
    }

    private float Multiply (float f, float f1)
    {
        return f * f1;
    }

    private float Division(float f, float f1)
    {
        return f / f1;
    }

    private IEnumerator WaitAndDo(float time, Action action)
    {
        yield return new WaitForSeconds(time);

        if (action != null)
        {
            action();
        }
    }
}
