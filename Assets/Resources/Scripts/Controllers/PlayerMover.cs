using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using System.IO;

public class PlayerMover : MonoBehaviour {

    public float speed = 18f;
    public PhotonView photonView;
    Camera cam;
    private string projectilePath = Path.Combine("PhotonPrefabs", "Projectile");


    public void Setup(Camera mainCamera)
    {
        cam = mainCamera;
    }
    public float ShootingForce = 100f;
    private void Update() {
        if(photonView.IsMine)
        {
            Movement();
            ClampPosition();
            if (Input.GetMouseButtonDown(0)) {
                GameObject bullet = PhotonNetwork.Instantiate(projectilePath, transform.position, Quaternion.identity) as GameObject;
                bullet.transform.LookAt(cam.ScreenToWorldPoint(screenPoint));
                bullet.GetComponent<Rigidbody>().AddForce(transform.forward * ShootingForce);
                //TODO Cleanup that needs to be pooled
                Destroy(bullet, 5f);
            }
        }
    }

    public GameObject projectile;
    private void ClampPosition()
    {
        Vector3 pos = cam.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);
        transform.position = cam.ViewportToWorldPoint(pos);
    }
    private Vector3 screenPoint;
    public float followMouseSpeed= 0.1f;
    private void Movement ()
    {
        //Get Mouse Positions
        screenPoint.x = Input.mousePosition.x;
        screenPoint.y = Input.mousePosition.y;
        //Set the camera z distance value using 10 because camera is set at -10
        screenPoint.z = 10f;
        //Ship will move towards mouse
        transform.position = Vector3.Lerp(transform.position, cam.ScreenToWorldPoint(screenPoint), followMouseSpeed * Time.deltaTime);
        //set the Look at position to be 50f in front of the ship
        screenPoint.z = 50f;
        transform.LookAt(cam.ScreenToWorldPoint(screenPoint));
        //float x = Input.mousePosition.x;
      //  float y = Input.mousePosition.y;
       // transform.localPosition += new Vector3(x, y, 0) * speed * Time.deltaTime;
    }
}
