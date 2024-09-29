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

            _newBullet.GetComponent<Rigidbody>().transform.up = _direction;
            _newBullet.GetComponent<Rigidbody>().velocity = _direction * _number;

            yield return new WaitForSeconds(_timeWaitShooting);
        }
    }
}
