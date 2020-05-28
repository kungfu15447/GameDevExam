using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    private GameObject player;
    private CinemachineVirtualCamera camera;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        camera = gameObject.GetComponent<CinemachineVirtualCamera>();
        camera.Follow = player.transform;
    }
}
