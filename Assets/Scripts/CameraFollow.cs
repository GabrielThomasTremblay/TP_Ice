using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform m_PlayerToFollow;
    [SerializeField] private Vector3 m_Offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(1,m_PlayerToFollow.position.y,-10) + m_Offset;
    }
}
