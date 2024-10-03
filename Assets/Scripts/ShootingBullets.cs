using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class ShootingBullets : MonoBehaviour
{
    [SerializeField] private Bullet _prefab;
    [SerializeField] private float _number;
    [SerializeField] private float _timeWaitShooting;
    [SerializeField] private Transform _objectToShoot;

    private Vector3 _direction;
    private Bullet _newBullet;
    private Rigidbody _rigidbodyBullet;
    private WaitForSeconds _waitForSeconds;

    private void Awake()
    {
        _waitForSeconds = new WaitForSeconds(_timeWaitShooting);
    }

    private void Start()
    {
        StartCoroutine(ShootingWorker());
    }

    private IEnumerator ShootingWorker()
    {
        while (enabled)
        {
            _direction = (_objectToShoot.position - transform.position).normalized;
            _newBullet = Instantiate(_prefab, transform.position + _direction, Quaternion.identity);

            _rigidbodyBullet = _newBullet.GetComponent<Rigidbody>();
            _rigidbodyBullet.transform.up = _direction;
            _rigidbodyBullet.velocity = _direction * _number;

            yield return _waitForSeconds;
        }
    }
}
