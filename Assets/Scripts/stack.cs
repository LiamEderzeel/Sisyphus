﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class stack : MonoBehaviour {

    private Vector3 spawnPos = new Vector3(0, 6f, 0);

    [SerializeField] private GameObject _block;
    [SerializeField] private List<GameObject> _blocks = new List<GameObject>();
    [SerializeField] private int _stackSize;
    public int StackSize
    {
        get{return _stackSize;}
    }

    void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject obj = Spawn();
            obj.transform.position += spawnPos;
        }
    }

    private int CountStack()
    {
        int count = 0;
            foreach(Transform child in transform)
            {
                if ( child.gameObject.activeInHierarchy )
                {
                    count++;
                }
            }
        return count;
    }

    public void OnTriggerExit (Collider collider)
    {
            print("unparent");
        if(collider.tag == "block")
        {
            print("unparent");
            //transform.parent = null;
            collider.GetComponent<block>().UnParrent();
        }
    }


    private void Start()
    {
        for(int i =0; i < 8; ++i)
        {
            CreateNew();
        }
    }

    public void ActivatePhysics()
    {
        for (int i = 0; i < _blocks.Count; ++i)
        {
            if ( _blocks[i].activeInHierarchy )
            {
                _blocks[i].GetComponent<block>().ActivatePhysics();
            }
        }
    }

    public void DeactivatePhysics()
    {
        for (int i = 0; i < _blocks.Count; ++i)
        {
            if ( _blocks[i].activeInHierarchy )
            {
                _blocks[i].GetComponent<block>().DeactivatePhysics();
            }
        }
    }

    public void SavePosition()
    {
        for (int i = 0; i < _blocks.Count; ++i)
        {
            if ( _blocks[i].activeInHierarchy )
            {
                _blocks[i].GetComponent<block>().SavePosition();
            }
        }
    }

    public void ReturnPosition()
    {
        _stackSize = CountStack();
        for (int i = 0; i < _blocks.Count; ++i)
        {
            if ( _blocks[i].activeInHierarchy )
            {
                _blocks[i].GetComponent<block>().ReturnPosition();
            }
        }
    }

    public GameObject Spawn()
    {
        for (int i = 0; i < _blocks.Count; ++i)
        {
            if ( !_blocks[i].activeInHierarchy )
            {
                _blocks[i].SetActive(true);
        _stackSize = CountStack();
                return _blocks[i];
            }
        }

        GameObject obj = CreateNew ();
        obj.SetActive (true);
        _stackSize = CountStack();
        return obj;
    }

    private GameObject CreateNew()
    {
        GameObject obj = GameObject.Instantiate( _block ) as GameObject;
        _blocks.Add ( obj );
        obj.transform.SetParent(gameObject.transform,false);
        obj.gameObject.transform.Rotate(0,180f,0);
        obj.SetActive( false );
        return obj;
    }
}