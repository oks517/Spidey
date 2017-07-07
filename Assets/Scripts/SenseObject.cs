﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenseObject : MonoBehaviour {
    public GameObject webCover;

    private Rigidbody rb;
    private WaitForSeconds velocityEase = new WaitForSeconds(0.1f);

    private void Start() {
        rb = GetComponent<Rigidbody>();
        SpideySense.Instance.SenseObject(gameObject);
        //Destroy(gameObject, 2f);
    }

    private void OnCollisionEnter(Collision collision) {
        WebShot ws = collision.gameObject.GetComponent<WebShot>();
        if (rb == null || ws == null) return;
        GameObject cover = Instantiate(webCover, transform.position, transform.rotation);
        cover.transform.parent = transform;
        rb.useGravity = true;
        StartCoroutine(EaseOutVelocity());
    }

    private IEnumerator EaseOutVelocity() {
        while (rb.velocity.magnitude > 0.1f) {
            rb.velocity *= 0.5f;
            yield return velocityEase;
        }
        rb.velocity = Vector3.zero;
    }
}