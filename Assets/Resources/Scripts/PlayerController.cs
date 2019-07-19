using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviour
{
    public float thrust;
    public Rigidbody rb;
    PhotonView pv;
    // Start is called before the first frame update
    void Start()
    {
        pv = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if(pv.IsMine)
            Movement();   
    }

    void Movement ()
    {
        if(Input.GetKey(KeyCode.W))
            rb.AddForce(transform.forward * thrust);
        else if(Input.GetKey(KeyCode.S))
            rb.AddForce(-transform.forward * thrust);
        else if(Input.GetKey(KeyCode.A))
            rb.AddForce(-transform.right * thrust);
        else if(Input.GetKey(KeyCode.D))
            rb.AddForce(transform.right * thrust);
    }
}
