using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkDestroy : MonoBehaviour
{
    private float time = 0;
    public float TimeDelay = 5f;
    
    private void OnEnable() {
        time = 0f;
    }

    private void Update() {
        time += Time.deltaTime;
        if (time > TimeDelay) {
            time = 0;
            PhotonNetwork.Destroy(gameObject);
        }
    }
}
