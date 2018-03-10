using UnityEngine;
using System.Collections;

[System.Serializable]
public class SineMovement {

    public Axis axis;
    public float amplitude;
    public float frequency;
    public bool absolute;
    public bool infinite;
    public float x;
    public float min;

}

[System.Serializable]
public enum Axis
{
    NONE,
    POSITION_X,
    POSITION_Y,
    POSITION_Z,
    ROTATION_X,
    ROTATION_Y,
    ROTATION_Z,
    SCALE_X,
    SCALE_Y,
    SCALE_Z
}
