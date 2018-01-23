using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ColliderVolume : Volume {

    Collider _collider;

    // Use this for initialization
    void Awake () {
        _collider = GetComponent<Collider>();
    }

    public override float DistanceTo(Vector3 position)
    {
        return Vector3.Distance(_collider.ClosestPoint(position), position);
    }

    public override Vector3 ClosestPoint(Vector3 position)
    {
        return _collider.ClosestPoint(position);
    }
}
