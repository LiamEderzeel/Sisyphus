using UnityEngine;
using System.Collections;

public delegate void PlayerPressent(Bridge bridge);

public class Bridge : MonoBehaviour {

    public event PlayerPressent _playerPressent;

    private void OnTriggerEnter(Collider collider)
    {
        print("jaja");
        _playerPressent(this);
    }
}
