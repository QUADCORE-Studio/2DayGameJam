using UnityEngine;
using UnityEngine.InputSystem;
public class bulletscript : MonoBehaviour
{
    private Vector3 mousePos;
    private InputAction mousePositionAction;
    private Camera mainCam;
    private Rigidbody2D rb;
    private PlayerControls controls;
    public float force;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        controls = new PlayerControls();
    }
    void Start()
    {
        mainCam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        mousePos = controls.Player.Pointer.ReadValue<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
