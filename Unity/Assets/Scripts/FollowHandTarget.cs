using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHandTarget : MonoBehaviour {

    [System.Serializable]
    public enum HandType
    {
        Left,
        Right,
    }

    [SerializeField]
    HandType _hand;

    Transform _target;

    // Use this for initialization
    void Start () {
        GameObject[] objects = SteamVR_ControllerManager.instance.objects;
        if (_hand == HandType.Left)
        {
            _target = objects[1].transform;
        }
        else if (_hand == HandType.Right)
        {
            _target = objects[0].transform;
        }
    }
    
    // Update is called once per frame
    void Update () {
        transform.SetPositionAndRotation(_target.position, _target.rotation);
    }
}
