using UnityEngine;
using System.Collections;

public class backpack : MonoBehaviour {
    [SerializeField] private GameObject _backpackAnker;

	void Start ()
    {

	}

	void Update ()
    {
        gameObject.transform.position = _backpackAnker.transform.position;
	}
}
