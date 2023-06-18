using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

// Requerimento de segurança para garantir que qualquer item que esse script esteja ligado possui uma cinemachine virtual camera anexado a ele
[RequireComponent(typeof(CinemachineVirtualCamera))]
public class MainCamera : MonoBehaviour
{
    Camera mainCamera;
    GameObject virtualCameraObject;
    GameObject player;
    private Transform objectTransform;

    CinemachineVirtualCamera cinemachineVirtualCamera;

    /// <summary>
    /// Awake is called when the script instance is being loaded. Eh como um viewWillAppear.
    /// Usaremos ela pra checar se o a Main Camera possui um cinemachine brain
    /// </summary>
    private void Awake()
    {   
        Camera.main.gameObject.TryGetComponent<CinemachineBrain>(out var brain); // out var brain fornece um output com o valor da variavel brain
        if (brain == null) {
            brain = Camera.main.gameObject.AddComponent<CinemachineBrain>();
        }

        brain.m_ShowDebugText = true;
        cinemachineVirtualCamera = gameObject.AddComponent<CinemachineVirtualCamera>();

        cinemachineVirtualCamera.Follow = objectTransform;
        cinemachineVirtualCamera.LookAt = objectTransform;
        cinemachineVirtualCamera.Priority = 1;

        CinemachineTransposer transposer = cinemachineVirtualCamera.AddCinemachineComponent<CinemachineTransposer>();
        CinemachineComposer composer = cinemachineVirtualCamera.AddCinemachineComponent<CinemachineComposer>();
        transposer.m_FollowOffset = new Vector3(0f, 0f, -20f);
        composer.m_ScreenX = 0.30f;
        composer.m_ScreenY = -0.11f;
    }

    private GameObject GetGameObject(string name) 
    {
        GameObject gameObject = GameObject.Find(name);
        if (gameObject == null) {
            Debug.Log("Empty GameObject");
            return null;
        }
        return gameObject;
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
