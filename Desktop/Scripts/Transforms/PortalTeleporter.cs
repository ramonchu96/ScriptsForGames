using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{
    public Transform TransformCamera;
    public Transform portal;

    public Camera thecamera;
    public GameObject theplayer;

    void OnTriggerEnter2D(Collider2D other)
    {
        theplayer.transform.position = portal.position;
        thecamera.transform.position = TransformCamera.position;
    }


}
