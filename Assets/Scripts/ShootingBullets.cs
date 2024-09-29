using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class ShootingBullets : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _number;
    [SerializeField] private float _timeWaitShooting;
    [SerializeField] private Transform ObjectToShoot;

    private Vector3 _direction;
    private GameObject _newBullet;
    private Rigidbody _rigidbodyBullet;

    private void Start()
    {
        StartCoroutine(ShootingWorker());
    }

    private IEnumerator ShootingWorker()
    {
        while (enabled)
        {
            _direction = (ObjectToShoot.position - transform.position).normalized;
            _newBullet = Instantiate(_prefab, transform.position + _direction, Quaternion.identity);

            _rigidbodyBullet = _newBullet.GetComponent<Rigidbody>();
            _rigidbodyBullet.transform.up = _direction;
            _rigidbodyBullet.velocity = _direction * _number;

            yield return new WaitForSeconds(_timeWaitShooting);
        }
    }
}
