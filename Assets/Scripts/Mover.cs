using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _arrayPlaces;

    private Vector3 _target;
    private int _countTarget;

    private void Awake()
    {
        _countTarget = _arrayPlaces.Length -1 ;
        _target = _arrayPlaces[_countTarget].position;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);

        if (Vector3.SqrMagnitude(transform.position - _target) == 0)
            _target = NextTarget();
    }

    private Vector3 NextTarget()
    {
        _countTarget = ++_countTarget % _arrayPlaces.Length;

        Vector3 nextTarget = _arrayPlaces[_countTarget].transform.position;
        transform.forward = nextTarget - transform.position;
        return nextTarget;
    }
}
