using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMovement : MonoBehaviour
{
    [SerializeField] private float _minSpeedOfRotation;
    [SerializeField] private float _maxSpeedOfRotation;
    private float _speedOfRotation;

    [SerializeField] private float _speedOfLifting;
    [SerializeField] private Transform _parent;
    [SerializeField] private int _currentLap;

    private Coroutine _coroutine;

    private int _laps;

    private void Start()
    {
        _speedOfRotation = _minSpeedOfRotation;

        Bonuses.instance.OnAddLap += UpdateLaps;
        Click.instance.OnClick += OnClick;
    }

    private void OnClick()
    {
        _speedOfRotation = _maxSpeedOfRotation;
        if (_coroutine != null) StopCoroutine(_coroutine);
        _coroutine = StartCoroutine(SetDefaultSpeed());
    }
    
    private IEnumerator SetDefaultSpeed()
    {
        yield return new WaitForSeconds(1);
        _speedOfRotation = _minSpeedOfRotation;
    }

    private void Update()
    {
        TrajectoryMovement();
    }

    private void UpdateLaps()
    {
        _laps = Bonuses.instance.CurrentLaps;
    }

    private void TrajectoryMovement()
    {
        _parent.transform.eulerAngles = new Vector3(0, _parent.transform.eulerAngles.y + _speedOfRotation, 0);
        if (_currentLap > 0)
        {
            _parent.transform.position = new Vector3(0, _parent.transform.position.y + _speedOfLifting, 0);
        }
    }

    private void NewLap()
    {
        _currentLap = 0;
        _parent.transform.localPosition = new Vector3(_parent.transform.localPosition.x, -6.4f, _parent.transform.localPosition.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FinishLap"))
        {
            if (_currentLap >= _laps)
                NewLap();
            else
                _currentLap++;
        }
    }
}
