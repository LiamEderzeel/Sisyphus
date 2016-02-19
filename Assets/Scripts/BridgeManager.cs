using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class BridgeManager : MonoBehaviour {

    [SerializeField] private List<Bridge> _bridgParts = new List<Bridge>();


	private void Start ()
    {
        for (int i = 0; i < _bridgParts.Count; ++i)
        {
            _bridgParts[i]._playerPressent += PlayerPressent;
        }
	}

	private void Update ()
    {
        //if(
	}

    private void OnTriggerEnter(Collider collider)
    {
    }

    private void PlayerPressent(Bridge bridge)
    {
        if(_bridgParts[4] == bridge)
        {
            _bridgParts[0].gameObject.transform.position += new Vector3(0,0,-72f);
            _bridgParts.Add(_bridgParts[0]);
            _bridgParts.RemoveAt(0);

            //_bridgParts[_bridgParts.Count]
        }
    }
}
