using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SmoothSineMovement : MonoBehaviour {

    [HideInInspector]
    public List<SineMovement> movements = new List<SineMovement>();

    [HideInInspector]
    public bool dirty;

    private float bias = 0;

    private float posX;
    private float posY;
    private float posZ;

    private float rotX;
    private float rotY;
    private float rotZ;

    private float scaleX;
    private float scaleY;
    private float scaleZ;

    // Use this for initialization
    void Start () {
        posX = transform.position.x;
        posY = transform.position.y;
        posZ = transform.position.z;

        rotX = transform.rotation.eulerAngles.x;
        rotY = transform.rotation.eulerAngles.y;
        rotZ = transform.rotation.eulerAngles.z;

        scaleX = transform.localScale.x;
        scaleY = transform.localScale.y;
        scaleZ = transform.localScale.z;

        dirty = true;
    }

    void Update() {
        if (!GameObject.FindGameObjectWithTag("Manager").GetComponent<Rotation>().isRotating())
        {
            if (dirty)
            {
                transform.position = new Vector3(posX, posY, posZ);
                transform.rotation = Quaternion.Euler(rotX, rotY, rotZ);
                transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
                bias = Time.time;
                dirty = false;
            }

            foreach (SineMovement move in movements)
            {
                float speed = sinSpeed(Time.time - bias, move.amplitude, move.frequency, move.x);

                if (move.infinite) speed = Mathf.Abs(speed);
                if (speed < move.min) speed = move.min;

                if (move.absolute)
                {
                    switch (move.axis)
                    {
                        case Axis.POSITION_X:
                            this.transform.position = new Vector3(posX + speed, this.transform.position.y, this.transform.position.z);
                            break;
                        case Axis.POSITION_Y:
                            this.transform.position = new Vector3(this.transform.position.x, posY + speed, this.transform.position.z);
                            break;
                        case Axis.POSITION_Z:
                            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, posZ + speed);
                            break;
                        case Axis.ROTATION_X:
                            this.transform.eulerAngles = new Vector3(rotX + speed, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
                            break;
                        case Axis.ROTATION_Y:
                            this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, rotY + speed, this.transform.eulerAngles.z);
                            break;
                        case Axis.ROTATION_Z:
                            this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y, rotZ + speed);
                            break;
                        case Axis.SCALE_X:
                            this.transform.localScale = new Vector3(scaleX + speed, this.transform.localScale.y, this.transform.localScale.z);
                            break;
                        case Axis.SCALE_Y:
                            this.transform.localScale = new Vector3(this.transform.localScale.x, scaleY + speed, this.transform.localScale.z);
                            break;
                        case Axis.SCALE_Z:
                            this.transform.localScale = new Vector3(this.transform.localScale.x, this.transform.localScale.y, scaleZ + speed);
                            break;
                    }
                }
                else
                {
                    switch (move.axis)
                    {
                        case Axis.POSITION_X:
                            this.transform.Translate(speed, 0, 0);
                            break;
                        case Axis.POSITION_Y:
                            this.transform.Translate(0, speed, 0);
                            break;
                        case Axis.POSITION_Z:
                            this.transform.Translate(0, 0, speed);
                            break;
                        case Axis.ROTATION_X:
                            this.transform.Rotate(speed, 0, 0);
                            break;
                        case Axis.ROTATION_Y:
                            this.transform.Rotate(0, speed, 0);
                            break;
                        case Axis.ROTATION_Z:
                            this.transform.Rotate(0, 0, speed);
                            break;
                        case Axis.SCALE_X:
                            this.transform.localScale = new Vector3(this.transform.localScale.x + speed, this.transform.localScale.y, this.transform.localScale.z);
                            break;
                        case Axis.SCALE_Y:
                            this.transform.localScale = new Vector3(this.transform.localScale.x, this.transform.localScale.y + speed, this.transform.localScale.z);
                            break;
                        case Axis.SCALE_Z:
                            this.transform.localScale = new Vector3(this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z + speed);
                            break;
                    }
                }
            }
        }
    }

    public float sinSpeed(float t, float amplitude, float frequency, float x)
    {
        float omega = ((Mathf.PI * 2) / frequency);
        float current = amplitude * omega * Mathf.Sin(omega * (t + x));
        return current;
    }
}
