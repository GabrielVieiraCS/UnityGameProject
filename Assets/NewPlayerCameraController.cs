using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class NewPlayerCameraController : NetworkBehaviour
{
    [Header("Camera")]
    [SerializeField] private Vector2 maxFollowOffset = new Vector2(-1f, 6f);
    [SerializeField] private Vector2 cameraVelocity = new Vector2(4f, 0.25f);
    [SerializeField] private Transform playerTransform = null;
    [SerializeField] private CinemachineVirtualCamera virtualCamera = null;

    private Controls controls;

    private Controls Controls
    {
        get
        {
            if(controls != null) { return controls; }
            return controls = new Controls();
        }
    }

    private CinemachineTransposer transposer;

    // Gets called on object that has authority over specified game obejct, enabling camera
    public override void OnStartAuthority()
    {
        transposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();

        virtualCamera.gameObject.SetActive(true);
        enabled = true;

        Controls.Player.Look.performed += ctx => Look(ctx.ReadValue<Vector2>());
    }

    // tags = only gets called on the client
    [ClientCallback]

    private void OnEnable() => Controls.Enable();
    [ClientCallback]

    private void OnDisable() => Controls.Disable();

    private void Look(Vector2 lookAxis)
    {
        float deltaTime = Time.deltaTime;

        float followOffset = Mathf.Clamp(
            transposer.m_FollowOffset.y - (lookAxis.y * cameraVelocity.y * deltaTime),
            maxFollowOffset.x,
            maxFollowOffset.y);

        transposer.m_FollowOffset.y = followOffset;

        // X-Axis will rotate the player
        playerTransform.Rotate(0f, lookAxis.x * cameraVelocity.x * deltaTime, 0f);    
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
