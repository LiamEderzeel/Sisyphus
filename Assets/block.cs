using UnityEngine;
using System.Collections;

public class block : MonoBehaviour {

    private Transform _stack;
    private Rigidbody _rigidbody;
    private Collider _collider;
    private Vector3 _posInStack;
    private Vector3 _holding = new Vector3(0,0,0);
    public Vector3 holding
    {
        set{_holding = value;}
    }

	private void Start ()
    {
        _stack = transform.parent;
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        _collider = gameObject.GetComponent<Collider>();
        DeactivatePhysics();
	}

	private void Update ()
    {
        if(gameObject.transform.position.y < -20f)
        {
            Reset();
        }
	}

    public void SavePosition()
    {
    _posInStack = gameObject.transform.position;
    }

    public void ReturnPosition()
    {
        gameObject.transform.localPosition = new Vector3(0f,_posInStack.y,0f);
        gameObject.transform.rotation = Quaternion.identity;
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
        transform.parent = _stack;
        gameObject.SetActive(false);
        gameObject.transform.localPosition = _holding;
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

    public void UnParrent()
    {

        transform.parent = null;
    }
}

