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
    AnimationCurve _valueCurve = AnimationCurve.Linear(0f, 0f, 1f, 1f);

    [SerializeField]
    float _multiplier = 1f;

    [SerializeField]
    bool _debug;

    OSC _osc;

    void Start()
    {
        _osc = OSC.instance;
    }

    void Update () {

        float dist = _volume.DistanceTo(transform.position);
        Debug.Log(dist);
        float freq = 0f;
        if (_mode == ParameterMode.Linear)
        {
            float input = Mathf.Clamp01((dist - _distanceRange.x) / (_distanceRange.y - _distanceRange.x));
            freq = _valueCurve.Evaluate(input) * _multiplier;
        }
        else if (_mode == ParameterMode.Inverse)
        {
            freq = _multiplier / dist;
        }

        var message = new OscMessage();
        message.address = _oscAddress;
        message.values = new ArrayList(new[] { freq });
        _osc.Send(message);

        if (_debug)
        {
            Debug.Log(_oscAddress + ": " + freq);
        }
    }
}
