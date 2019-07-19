using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class PlayerMover : MonoBehaviour {
    public Rigidbody rb;
    public float speedMulti = 18f;
    public PhotonView pv;
    public Image MouseTarget;
    private Vector3 pos;
    private Transform MouseTargetTransform;
    public RectTransform MouseTargetLocation;
    private Camera cam;

    private void Awake() {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    public void Setup (RectTransform canvas)
    {
        MouseTargetLocation = canvas;
        MouseTarget = Instantiate(MouseTarget, Vector3.zero, Quaternion.identity, MouseTargetLocation);
        MouseTargetTransform = MouseTarget.transform;
    }

    private void Update() {
        if (!pv.IsMine)
            return;

        Movement();
        ClampPosition();
    }

    private void ClampPosition ()
    {
        pos = cam.ScreenToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = pos;
    }

    private void Movement() {
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        transform.localPosition += new Vector3(x, y, 0) * speedMulti * Time.deltaTime;

        // if (Input.GetKey(KeyCode.W)) {
        //     transform.Translate(Vector3.up * speedMulti * Time.deltaTime) ;
        // }

        // if (Input.GetKey(KeyCode.S)) {
        //     transform.Translate(Vector3.down * speedMulti * Time.deltaTime);
        // }

        // if (Input.GetKey(KeyCode.A)) {
        //     transform.Translate(Vector3.left * speedMulti * Time.deltaTime);
        // }

        // if (Input.GetKey(KeyCode.D)) {
        //     transform.Translate(Vector3.right * speedMulti * Time.deltaTime);
        // }
    }
}
