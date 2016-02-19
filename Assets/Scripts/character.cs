using UnityEngine;
using System.Collections;

public class character : MonoBehaviour {

	void Start () {

	}

	void Update () {
        gameObject.transform.Translate(new Vector3(0.7f,0,0) * Time.deltaTime * 1f);

	}
}
