using UnityEngine;
using System.Collections;
using System;

public class MoveComponent : MonoBehaviour {

    public enum MoveType
    {
        PingPong,
        Once,
        Loop
    }

    [SerializeField]
    private Transform[] _transf;

    [SerializeField]
    private MoveType _type;

    [SerializeField]
    private float _speed;

    private Vector3 _targetPoint;
    private int _currenIndex = -1;
    private Func<int, int> _idexFunc;
    // Use this for initialization
    void Start () {

        if (_transf.Length == 0) return;
        _idexFunc = Increment;
        GetNextPoint();


    }
	
	// Update is called once per frame
	private IEnumerator MoveToPoints ()
    {

        while (Vector3.Distance(transform.position, _targetPoint) > .1)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPoint, Time.deltaTime * _speed);
            yield return null;
        }
        GetNextPoint();
    }

    private void GetNextPoint()
    {
        _currenIndex=_idexFunc(_currenIndex);

        if(_currenIndex<0 && _type==MoveType.PingPong)
            {
            _idexFunc = Increment;
            _currenIndex = 0;
        }

        if (_currenIndex >= _transf.Length)
        {
            if (_type == MoveType.PingPong)
            {
                _idexFunc = Decrement;
                _currenIndex -= 2;
            }


           else if (_type == MoveType.Loop) {
                _currenIndex = 0;
                transform.position = _transf[_currenIndex].position;
        }
            else if(_type==MoveType.Once) return;
        }
        _targetPoint = _transf[_currenIndex].position;
        StartCoroutine(MoveToPoints());
    }

    private int Increment (int index)
    {
        return ++index;
    }

    private int Decrement(int index)
    {
        return --index;
    }
}
