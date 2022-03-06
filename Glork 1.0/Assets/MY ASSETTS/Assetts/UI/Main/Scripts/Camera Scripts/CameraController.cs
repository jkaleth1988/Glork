using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera MainCamera;
    public Camera SecondCamera;
    public bool myVar;
    public bool TextBoxVanish1;
    public bool NewCamera;
    private Vector3 offset;
    public bool IsItFixed;

    [SerializeField] private Transform player;


    private void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {

        transform.position = player.transform.position + offset;
    }

    public void Update()
    {
        IsItFixed = GameObject.Find("ColliderLogic").GetComponent<FixedCamera>().IsFixed;

        if (MainCamera.enabled == true)
        {

            transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
            SecondCamera.enabled = false;
        }

        if (IsItFixed == false)
        {
            MainCamera.enabled = true;
            SecondCamera.enabled = false;
        }

        if (IsItFixed == true)
        {
            MainCamera.enabled = false;
            SecondCamera.enabled = true;
        }
    }
}
