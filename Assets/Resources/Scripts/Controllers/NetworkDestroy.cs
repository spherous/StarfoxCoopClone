using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkDestroy : MonoBehaviour {
    // Start is called before the first frame update
    private float time = 0f;
    private PhotonView pv;
    private void Start() {
        pv = GetComponent<PhotonView>();
    }
    private void OnEnable() {
        time = 0f;
    }
    // Update is called once per frame
    void Update() {
        if (!pv.IsMine)
            return;
        time += Time.deltaTime;
        if (time > 5f) {
            PhotonNetwork.Destroy(gameObject);
        }
    }
}
