using UnityEngine;
using System.Collections;

public class block : MonoBehaviour {

    private Rigidbody _rigidbody;
    private Collider _collider;
    private Vector3 _holding = new Vector3(0,0,0);

	private void Start ()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        _collider = gameObject.GetComponent<Collider>();
        DeactivatePhysics();
	}

	private void Update ()
    {
        if(gameObject.transform.position.y < -10f)
        {
            Reset();
        }
	}

    public void DeactivatePhysics()
    {
        _rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX;
    }

    public void ActivatePhysics()
    {
        _rigidbody.constraints = RigidbodyConstraints.None;
        //_rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionX;
    }

    private void Reset ()
    {
        gameObject.SetActive(false);
        gameObject.transform.position = _holding;
        gameObject.transform.rotation = Quaternion.identity;
        DeactivatePhysics();
        _rigidbody.velocity = Vector3.zero;
    }

    public void Nocolider()
    {
        StartCoroutine(Colideronoff());
    }

    IEnumerator Colideronoff()
    {
        yield return new WaitForSeconds(0.05f);
        _collider.enabled = false;
        yield return new WaitForSeconds(1);
        _collider.enabled = true;
    }
}

