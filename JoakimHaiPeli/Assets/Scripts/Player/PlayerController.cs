using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Transform gunTransform;
    public Sprite sideSprite;
    public Sprite topSprite;
    private SpriteRenderer spriteRenderer;
    public float moveSpeed = 5f;
    private Vector2 moveInput;
    private Vector2 AimInput;
    private MASTER controls;
    private Rigidbody2D body;
    // Start is called before the first frame update
    void Awake()
    {
        controls = new MASTER();
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start(){
        GameManager.Instance.playerController = this;
    }
    private void OnEnable(){
        controls.Enable();
    }
    private void onDisable(){
        controls.Disable();
    }
    
    void FixedUpdate()
    {
      Move();
    }
    void Move(){
        moveInput = controls.Player.Move.ReadValue<Vector2>();
        Vector2 movement = new Vector2(moveInput.x, moveInput.y) * moveSpeed * Time.fixedDeltaTime;
        body.MovePosition(body.position + movement);
    }

    void Update(){
        Shoot();
        Aim();
        UpdateSpriteDirection();
    }
    private void UpdateSpriteDirection()
    {
        if(moveInput.sqrMagnitude > 0.1f){
            if(Mathf.Abs(moveInput.x) > Mathf.Abs(moveInput.y)){
                spriteRenderer.sprite = sideSprite;
                spriteRenderer.flipX = moveInput.x < 0;
                spriteRenderer.flipY = false;
            }
            else{
                spriteRenderer.sprite = topSprite;
                spriteRenderer.flipY = moveInput.y < 0;
            }
        }
    }
    void Aim()
    {
        AimInput = controls.Player.Aim.ReadValue<Vector2>();
        if(AimInput.sqrMagnitude > 0.1){
        //Debug.Log(AimInput);
         Vector2 aimDirection = Vector2.zero;  
         if(UsingMouse()){
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            mousePosition.z = 0;
            aimDirection = mousePosition - gunTransform.position;
         }
         else{
            aimDirection = AimInput;
         }
         float angle = Mathf.Atan2(aimDirection.x, -aimDirection.y) * Mathf.Rad2Deg;
         gunTransform.rotation = Quaternion.Euler(0,0,angle);
        }
    }


     bool UsingMouse(){
        if(Mouse.current.delta.ReadValue().sqrMagnitude > 0.1){
            return true;
        }
        return false;
     }
        void Shoot()
    {
        if(controls.Player.Shoot.triggered){
          GameObject bullet = BulletPoolManager.Instance.GetBullet();
          bullet.transform.position = gunTransform.position;
          bullet.transform.rotation = gunTransform.rotation;

        }
    }
}
    

    