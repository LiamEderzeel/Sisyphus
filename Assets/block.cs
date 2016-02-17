using UnityEngine;
using System.Collections;

public class block : MonoBehaviour {

    private Rigidbody _rigidbody;

	void Start ()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        ActivatePhysics();
	}

	void Update ()
    {

	}

    void DeactivatePhysics()
    {
        _rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX;
    }

    void ActivatePhysics()
    {
        _rigidbody.constraints = RigidbodyConstraints.None;
    }
}

