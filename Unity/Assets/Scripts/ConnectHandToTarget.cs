using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectHandToTarget : MonoBehaviour {

    [System.Serializable]
    public enum HandType
    {
        Left,
        Right,
    }

    [SerializeField]
    HandType _hand;

    Transform _handTransform;

    [SerializeField]
    Volume _volumeTarget;

    // Use this for initialization
    void Start ()
    {
        GameObject[] objects = SteamVR_ControllerManager.instance.objects;
        if (_hand == HandType.Left)
        {
            _handTransform = objects[1].transform;
        }
        else if (_hand == HandType.Right)
        {
            _handTransform = objects[0].transform;
        }
    }
    
    // Update is called once per frame
    void Update ()
    {

        // set and scale the quad between the hand and the target volume

        transform.position = _handTransform.position;

        Vector3 distanceVector = _volumeTarget.ClosestPoint(transform.position) - _handTransform.position;

        transform.right = distanceVector.normalized;
        transform.position += distanceVector / 2;

        transform.localScale = new Vector3(distanceVector.magnitude, 1f, 1f);

        // face the quad toward the camera

        /*Vector3 cameraDistanceVector = Camera.main.transform.position - transform.position;

        Vector3 projection = Vector3.one - transform.right;

        cameraDistanceVector = Vector3.Scale(cameraDistanceVector, projection);

        float dot = Vector3.Dot(cameraDistanceVector, transform.forward);*/

    }
}
