using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerActions : MonoBehaviour
{
    public Animator animator;
    private ThirdPersonActionsAsset playerActionsAsset;
    private bool isOpen = false;
    // Start is called before the first frame update
    private void Awake()
    {
        playerActionsAsset = new ThirdPersonActionsAsset();
    }

    private void OnEnable()
    {
        playerActionsAsset.Player.Interact.started += OpenDoor;
        playerActionsAsset.Player.Enable();
    }
    private void OnDisable()
    {
        playerActionsAsset.Player.Interact.started -= OpenDoor;
        playerActionsAsset.Player.Disable();
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OpenDoor(InputAction.CallbackContext _)
    {
        if(isOpen)
            animator.SetTrigger("Activate");
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "OpenDoor")
            isOpen = true;

        if (collider.gameObject.tag == "OpenScene")
            SceneManager.LoadSceneAsync("CarriagaScene");
    }
}
