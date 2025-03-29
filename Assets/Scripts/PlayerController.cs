using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public InputAction MoveAction;
    public InputAction talkAction;
    public float pushForce = .5f;
    Rigidbody2D rigidbody2d;
    Vector2 move;
    int direction = 3;
    public TextMeshProUGUI instruction;
    public TextMeshProUGUI talking;
    public float talkingTime = 5f;
    private float timer = 0f;
    public bool isTalking=false;
    public bool firstEnter=true;

    void Start()
    {
        MoveAction.Enable();
        talkAction.Enable();
        rigidbody2d = GetComponent<Rigidbody2D>();
        instruction.enabled=false;
        talking.enabled=false;
    }

    void findBunny()
    {
        Vector2 rayDirection = direction > 0 ? Vector2.right : Vector2.left;
        Vector2 origin = rigidbody2d.position + Vector2.up * 0.2f;
        Debug.DrawRay(origin, rayDirection * 1.54f, Color.red, 2.0f);
        RaycastHit2D hit = Physics2D.Raycast(origin, rayDirection, 3.54f, LayerMask.GetMask("NPC"));
        if (hit.collider != null)
        {
            bunn character = hit.collider.GetComponent<bunn>();
            if (character != null && firstEnter)
            {
                instruction.enabled=true;
                firstEnter=false;
            }
        }
    }

    void Update()
    {
        move = MoveAction.ReadValue<Vector2>();
        if (move.x > 0)
        {
            if (direction != 3)
                {direction = 3;
                transform.localScale = new Vector3(direction, 3, 3);}
        }
        else if (move.x < 0)
        {
            if (direction != -3){
                direction = -3;
                transform.localScale = new Vector3(direction, 3, 3);}
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            instruction.enabled=false;
                if (!isTalking){
                    talking.enabled = true;
                    isTalking = true;
                    timer = Time.time + talkingTime;
        }
        }
         if (isTalking && Time.time >= timer){
            talking.enabled = false;
            isTalking = false;
        }
        moveBox();
    }

    void FixedUpdate()
    {
        Vector2 position = (Vector2)rigidbody2d.position + move * 3.0f * Time.deltaTime;
        rigidbody2d.MovePosition(position);
        findBunny();
    }

    void moveBox()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, move, .02f, LayerMask.GetMask("Crate"));
        if (hit.collider != null)
        {
            Rigidbody2D crate = hit.collider.GetComponent<Rigidbody2D>();
            if (crate != null){
                Vector2 pushDirection = move.normalized; // Ensure the direction is normalized
                crate.velocity = new Vector2(pushDirection.x * pushForce, crate.velocity.y);
            }
        }
    }
}
