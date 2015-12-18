using UnityEngine;
using System.Collections;

public class CameraControls : MonoBehaviour
{
    public float m_AngleRotation = 90;

    GameObject m_Player;

    // Use this for initialization
    void Start()
    {
        m_Player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter(Collider aCollider)
    {
        if (aCollider.tag == "Player")
        {
            //Ease the rotation.
            Easing.StartTween(this, Easing.Type.BounceIn, 0, 1, 0.3f, rotate);
            Debug.Log("I got hit");
        }
    }

    private void rotate(float aRotate)
    {
        //Checks if the angle is at a certain degree rotate it properly.
        if (m_AngleRotation == 0 && m_Player.transform.eulerAngles.y >= 260)
        {
            //Lerp the camera for a smooth follow.
            m_Player.transform.eulerAngles = Vector3.Lerp(new Vector3(0, -90, 0), new Vector3(0, m_AngleRotation, 0), aRotate);
        }
        else if (m_AngleRotation == 270 && m_Player.transform.eulerAngles.y <= 1)
        {
            m_Player.transform.eulerAngles = Vector3.Lerp(new Vector3(0, 360, 0), new Vector3(0, m_AngleRotation, 0), aRotate);
        }
        else
        {
            m_Player.transform.eulerAngles = Vector3.Lerp(m_Player.transform.eulerAngles, new Vector3(0, m_AngleRotation, 0), aRotate);
        }

    }
}
