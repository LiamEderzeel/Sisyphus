﻿using UnityEngine;
using System.Collections;

public class stack : MonoBehaviour {

    private Vector3 spawnPos = new Vector3(0, 6f, 0);
    [SerializeField] private GameObject block;

	void Start ()
    {

        Spawn();
	}

	void Update ()
    {

	}

    void Spawn ()
    {
        GameObject obj = Instantiate(block, gameObject.transform.position + spawnPos, Quaternion.identity) as GameObject;
    }
}
