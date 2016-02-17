using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class stack : MonoBehaviour {

    private Vector3 spawnPos = new Vector3(0, 6f, 0);
    private int stackSize;

    [SerializeField] private GameObject _block;
    [SerializeField] private List<GameObject> _blocks = new List<GameObject>();

    void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject obj = Spawn();
            obj.transform.position += spawnPos;
        }
    }


    private void Start()
    {
        for(int i =0; i < 8; ++i)
        {
            CreateNew();
        }
    }

    public GameObject Spawn()
    {
        stackSize++;
        for (int i = 0; i < _blocks.Count; ++i)
        {
            if ( !_blocks[i].activeInHierarchy )
            {
                _blocks[i].SetActive(true);
                return _blocks[i];
            }
        }

        GameObject obj = CreateNew ();
        obj.SetActive (true);
        return obj;
    }

    private GameObject CreateNew()
    {
        GameObject obj = GameObject.Instantiate( _block ) as GameObject;
        _blocks.Add ( obj );
        obj.transform.parent = gameObject.transform;
        obj.SetActive( false );
        return obj;
    }
}
