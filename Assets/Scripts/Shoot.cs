﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
    public GameObject webShot;

    private SteamVR_Controller.Device controller;

	// Use this for initialization
	void Start () {
        SteamVR_TrackedObject obj = gameObject.GetComponent<SteamVR_TrackedObject>();
        controller = SteamVR_Controller.Input((int) obj.index);
	}
	
	// Update is called once per frame
	void Update () {
		if (controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip)) {
            ShootWebShot();
        }
	}

    private void ShootWebShot() {
        GameObject shot = Instantiate(webShot, transform.position, transform.rotation);
    }
}