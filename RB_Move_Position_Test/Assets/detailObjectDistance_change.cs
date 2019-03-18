using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detailObjectDistance_change : MonoBehaviour {
    Terrain terr;
    [SerializeField] float distance;
	// Use this for initialization
	void Start () {
        terr = GetComponent<Terrain>();
	}
	
	// Update is called once per frame
	void Update () {
        terr.detailObjectDistance = distance;
	}
}
