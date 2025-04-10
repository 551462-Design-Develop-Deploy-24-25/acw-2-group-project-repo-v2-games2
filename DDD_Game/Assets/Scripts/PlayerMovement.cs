using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public Camera playerCamera;
    public float walkSpeed = 6f;
    public float runSpeed = 12f;
    public float jumpPower = 7f;
    public float gravity = 15f;
    public float lookSpeed = 2f;
    public float lookXLimit = 45f;
    public float defaultHeight = 2f;
    public float crouchHeight = 1f;
    public float crouchSpeed = 3f;
    public bool isRunning = false;
    public bool onCooldown = false;
    public float runMeter = 200;
    public float cooldownTime = 4f;
    [SerializeField]
    public GameObject Flashlight;
    public Transform playerTransform;
    public Camera mapCam;

    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;
    private CharacterController characterController;
    public Vector3 originalPosition;
    private bool canMove = true;
    public bool isHiding = false;
    private KeyInventory keyInventory;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        keyInventory = GetComponent<KeyInventory>();
    }

    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        isRunning = false;
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            playerCamera.gameObject.SetActive(false);
            mapCam.gameObject.SetActive(true);
        }
        if(Input.GetKeyUp(KeyCode.Tab))
        {
            playerCamera.gameObject.SetActive(true);
            mapCam.gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, 3f))
            {
                if (hit.collider.CompareTag("HidingSpot")&&!isHiding)
                {
                        isHiding = true;
                        originalPosition = transform.position;
                        characterController.enabled = false;
                        playerTransform.position = hit.collider.transform.GetChild(hit.collider.transform.childCount - 1).position;
                        playerCamera.transform.localPosition = new Vector3(0, 0.97f, 0);
                }
                if (hit.collider.CompareTag("Key"))
                {
                    KeyInventory keyInventory = GetComponent<KeyInventory>();
                    if (keyInventory != null)
                    {
                        keyInventory.addKey(hit.collider.gameObject);
                        hit.collider.gameObject.SetActive(false);
                    }
                }
                if (hit.collider.CompareTag("Door"))
                {
                    Doors door = hit.collider.GetComponent<Doors>();
                    door.ToggleDoor(keyInventory.getKeys());
                }

            }
            else if (isHiding)
            {
                isHiding = false;
                transform.position = originalPosition;
                playerCamera.transform.localPosition = new Vector3(0, 0.672f, 0);
                characterController.enabled = true;

            }

        }
            if (Input.GetKeyDown(KeyCode.F))
            {
                Flashlight.SetActive(!Flashlight.activeSelf);
            }
            if (Input.GetKey(KeyCode.LeftShift) && runMeter > 0 && onCooldown == false && !Input.GetKey(KeyCode.LeftControl))
            {
                isRunning = true;
                runMeter -= 1;
            }
            if (runMeter <= 0)
            {
                onCooldown = true;

            }
            if (!Input.GetKey(KeyCode.LeftShift) || onCooldown)
            {
                isRunning = false;
                runMeter += 0.4f;
                if (runMeter > 200)
                {
                    runMeter = 200;
                }
            }
            if (onCooldown)
            {
                cooldownTime -= Time.deltaTime;
            }
            if (cooldownTime <= 0f)
            {
                onCooldown = false;
                cooldownTime = 4f;
            }

            float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
            float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
            float movementDirectionY = moveDirection.y;
            moveDirection = (forward * curSpeedX) + (right * curSpeedY);

            //jump functionality - remove subsequent 'moveDirection.y = movementDirectionY;' if uncommenting this section
            //if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
            //{
            //    moveDirection.y = jumpPower;
            //}
            //else
            //{
            //    moveDirection.y = movementDirectionY;
            //}
            moveDirection.y = movementDirectionY;

            if (!characterController.isGrounded)
            {
                moveDirection.y -= gravity * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.LeftControl) && canMove)
            {
                characterController.height = crouchHeight;
                walkSpeed = crouchSpeed;
                runSpeed = crouchSpeed;

            }
            else
            {
                characterController.height = defaultHeight;
                walkSpeed = 6f;
                runSpeed = 12f;
            }

            characterController.Move(moveDirection * Time.deltaTime);

            if (canMove)
            {
                rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
                rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
                playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
                transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
            }
        }
    }