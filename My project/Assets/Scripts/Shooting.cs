using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    private float timer;
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    public float timeBetweenFiring;

    // Reference to the player input
    private PlayerControls controls;
    private InputAction mousePositionAction;
    private InputAction mouseFireAction;

    void Awake()
    {
        mainCam = Camera.main;

        controls = new PlayerControls();
    }
    private void OnEnable()
    {
        controls.Enable();
        mouseFireAction = controls.Player.Fire;
        mousePositionAction = controls.Player.Pointer;
    }
    private void OnDisable()
    {
        controls.Disable();
    }

    void Update()
    {
        // Read mouse position (screen space)
        Vector2 screenPos = mousePositionAction.ReadValue<Vector2>();

        // Convert screen position to world position
        mousePos = mainCam.ScreenToWorldPoint(screenPos);

        // Rotate towards mouse
        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer>timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }
        if (mouseFireAction.IsPressed()&& canFire)
        {
            canFire = false;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        }


    }
}
