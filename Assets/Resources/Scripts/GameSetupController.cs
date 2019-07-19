    using Photon.Pun;
    using System.IO;
    using UnityEngine;
    public class GameSetupController : MonoBehaviour
    {
        public Camera mainCamera;
        public Transform rig;
        private string playerPath = Path.Combine("PhotonPrefabs", "PhotonPlayer");

        // This script will be added to any multiplayer scene
        void Start()
        {
            CreatePlayer(); //Create a networked player object for each player that loads into the multiplayer scenes.
        }
        private void CreatePlayer()
        {
            Debug.Log("Creating Player");
            GameObject newGO = PhotonNetwork.Instantiate(playerPath, Vector3.zero, Quaternion.identity);
            newGO.GetComponent<Transform>().parent = rig;
            newGO.GetComponent<PlayerMover>().Setup(mainCamera);
        }
    }