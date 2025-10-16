using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public Camera cam;
    public Transform followTarget;
    Vector2 startingPosition;
    float startingZ;
    float ZdistanceFromTarget => transform.position.z - followTarget.transform.position.z;
    float parallaxFactor => Mathf.Abs(ZdistanceFromTarget) / clippingPlane;
    float clippingPlane => (cam.transform.position.z + (ZdistanceFromTarget > 0 ? cam.farClipPlane : cam.nearClipPlane));
    Vector2 camMoveSinceStart => (Vector2)cam.transform.position - startingPosition;

    void Start()
    {
        startingPosition = transform.position;
        startingZ = transform.position.z;
    }

    void Update()
    {
        Vector2 newPosition = startingPosition + camMoveSinceStart * parallaxFactor;
        transform.position = new Vector3(newPosition.x, newPosition.y, startingZ);
    }
}
