using System.Collections;
using DG.Tweening;
using UnityEngine;

public class GunMovement : MonoBehaviour
{
    [SerializeField] private float _minSpeedOfRotation;
    [SerializeField] private float _maxSpeedOfRotation;
    private float _speedOfRotation;

    [SerializeField] private float _speedOfLifting;
    [SerializeField] private Transform _parent;
    [SerializeField] private int _currentLap;

    public Vector3 _targetPos = new (0, 4.1f, -8f);
    public float _timeToMerge = 1;
    private bool isMerged;

    private Coroutine _coroutine;

    private int _laps;

    private void Start()
    {
        _speedOfRotation = _minSpeedOfRotation;
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

    private void FixedUpdate()
    {
        if (isMerged) 
        {
            if (transform.position == _targetPos)
                Destroy(gameObject);
            return;
        }
        TrajectoryMovement();
    }

    public void UpdateLaps(int laps) => _laps = laps;

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
        _parent.transform.localPosition = new Vector3(_parent.transform.localPosition.x, 0, _parent.transform.localPosition.z);
    }

    public void OnMerge()
    {
        isMerged = true;
        transform.DOMove(_targetPos, _timeToMerge);
        Destroy(transform.parent.gameObject, _timeToMerge + 0.02f);
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

    private void OnDestroy()
    {
        Click.instance.OnClick -= OnClick;
    }
}
