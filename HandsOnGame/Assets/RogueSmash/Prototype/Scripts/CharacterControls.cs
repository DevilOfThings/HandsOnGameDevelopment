using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NCharacterController : MonoBehaviour
{

    [SerializeField] private GameObject actor;

    [SerializeField] private float moveSpeedModifier = 3;

    private Vector3 mousePosition;
    private Vector3 lookDirection;

    #region MonoBehaviour Calls
    private void FixedUpdate()
    {
        HandleInput();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    #endregion

    #region Input Handling
    private void HandleInput()
    {
        Quaternion lookRotation = GetMouseInput();
        actor.transform.rotation = lookRotation;

        Vector3 moveDirection = GetInput();
        actor.transform.Translate(moveDirection * Time.deltaTime * moveSpeedModifier, Space.World);
    }

    private Vector3 GetInput()
    {
        Vector3 input = Vector3.zero;
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");
        return input;
    }

    private Quaternion GetMouseInput()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector2 relativeMousePos = new Vector2(mousePos.x - Screen.width / 2, mousePos.y - Screen.height / 2);
        float angle = Mathf.Atan2(relativeMousePos.y, relativeMousePos.x) * Mathf.Rad2Deg * -1;
        Quaternion rot = Quaternion.AngleAxis(angle, Vector3.up);
        return rot;
    }
    #endregion
}
