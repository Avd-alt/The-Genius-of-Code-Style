using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;

    private Transform[] _pointsTarget;
    private int _currentPoint;

    private void Start()
    {
        _pointsTarget = new Transform[_target.childCount];

        for (int i = 0; i < _target.childCount; i++)
        {
            _pointsTarget[i] = _target.GetChild(i).GetComponent<Transform>();
        }
    }

    private void Update()
    {
        var place = _pointsTarget[_currentPoint];
        transform.position = Vector3.MoveTowards(transform.position, place.position, _speed * Time.deltaTime);

        if (transform.position == place.position)
        {
            GetNextPlace();
        }
    }

    private void GetNextPlace()
    {
        _currentPoint++;

        if (_currentPoint == _pointsTarget.Length)
        {
            _currentPoint = 0;
        }
    }
}