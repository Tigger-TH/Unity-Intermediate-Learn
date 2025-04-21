using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform[] ObserveLocation => _observeLocation;
    [SerializeField] private Transform[] _observeLocation;
    [SerializeField] private NavMeshAgent _agent;

    private State _currentState;

    private void Start()
    {
        _currentState = new Roaming(this, _agent);
    }
    private void Update()
    {
        _currentState = _currentState.Process();
    }

}

