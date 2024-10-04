using System.Collections;
using UnityEngine;

public class ShootingBullets : MonoBehaviour
{
    [SerializeField] private Rigidbody _prefab;
    [SerializeField] private float _speed;
    [SerializeField] private float _timeWaitShooting;
    [SerializeField] private Transform _objectToShoot;

    private Vector3 _direction;
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
            _rigidbodyBullet = Instantiate(_prefab, transform.position + _direction, Quaternion.identity);

            _rigidbodyBullet.transform.up = _direction;
            _rigidbodyBullet.velocity = _direction * _speed;

            yield return _waitForSeconds;
        }
    }
}
