using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(FollowHandTarget))]
public class ParameterControl : MonoBehaviour {

    [SerializeField]
    Volume _volume;

    [SerializeField]
    string _oscAddress = "pitch";

    [System.Serializable]
    public enum ParameterMode
    {
        Linear,
        Inverse,
    }
    [SerializeField]
    ParameterMode _mode;

    [SerializeField]
    Vector2 _distanceRange = new Vector3(0.1f, 1f);

    [SerializeField]
    float _zeroBeat = 1f;

    [SerializeField]
    AnimationCurve _valueCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

    FollowHandTarget _hand;

    void Awake () {
        _hand = GetComponent<FollowHandTarget>();
    }
    
    // Update is called once per frame
    void Update () {
        
    }
}
