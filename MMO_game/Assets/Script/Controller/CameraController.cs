using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class CameraController : NetworkBehaviour
{

    public Transform target;
    public Vector3 offset;
    //public float zoomSpeed = 4f;
    //public float minZoom = 5f;
    //public float maxZoom = 15f;
    public float pitch = 1f;
    public float yawSpeed = 100f;
    Transform mainCamera;


    private float currentZoom = 5f;
    private float currentYaw = 0f;


    private void Start()
    {
        if (!isLocalPlayer)
        {
            Destroy(this);
            return;
        }
        offset.Set(0f, -0.5f, -0.8f);
        mainCamera = Camera.main.transform;
    }
    // Update is called once per frame 
    void Update()
    {
        //    currentZoom -= Input.GetAxis("Mouth ScrollView") * zoomSpeed;   //currently Mouth ScrollView cannot be setup
        //    currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom); 
        currentYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
    }

    // LateUpdate is rightafter Update
    void LateUpdate()
    {
        mainCamera.position = target.position - offset * currentZoom;
        mainCamera.LookAt(target.position + Vector3.up * pitch);
        mainCamera.RotateAround(target.position, Vector3.up,currentYaw);
    }
}
