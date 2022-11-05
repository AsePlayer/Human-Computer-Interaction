using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SearchTarget : MonoBehaviour {

    [SerializeField]
    public Transform _destination;

    NavMeshAgent _navMeshAgent;
    // Use this for initialization
    void Start () {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();

        if(_navMeshAgent == null)
        {
            Debug.LogError("Tha nav mesh agent is not attached to " + gameObject.name);
        }
        else
        {
            SetDestination();
        }
	}

    private void SetDestination()
    {
        if(_destination != null)
        {
            Vector3 targetVector = _destination.transform.position;
            _navMeshAgent.SetDestination(targetVector);
        }
    }
	
	// Update is called once per frame
	void Update () {
        SetDestination();
    }
}
