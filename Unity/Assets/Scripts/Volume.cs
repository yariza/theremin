using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Volume : MonoBehaviour {

    public abstract float DistanceTo(Vector3 position);
}
