using System.Collections;
using System.Collections.Generic;
using Unity.Transforms;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Character character;
    [SerializeField]private Transform CameraLook;

    private float Horizontal,Vertical;
    public float speed;
    public float RotationSpeed;
    private Rigidbody rb;
    float CharacterYAngle;
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<Character>();
        speed = character.GetStatComponent().GetStatsComponent().Speed;
        RotationSpeed = character.GetStatComponent().GetStatsComponent().RotationSpeed;
        rb = character.GetCharacterComponent().GetRigidbodyComponent();
        Cursor.lockState = CursorLockMode.Locked;  
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(Horizontal, rb.velocity.y, rb.velocity.z) * speed * Time.deltaTime;

        float RotationX = Input.GetAxis("Mouse X")* RotationSpeed;
         float RotationY = Input.GetAxis("Mouse Y") * RotationSpeed;
        CharacterYAngle -= RotationY;
        CharacterYAngle = Mathf.Clamp(CharacterYAngle, -90f, 90f);
        CameraLook.localEulerAngles=Vector3.right * CharacterYAngle;
        transform.Rotate(Vector3.up*RotationX);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed *= 10;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed /= 10;

        }
    }
}
