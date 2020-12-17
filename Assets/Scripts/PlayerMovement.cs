using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement: MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRigidBody;
    [SerializeField] private Animator playerAnimator;
    private Vector2 lastMove;
    public float moveSpeed;
    private bool isPlayerMoving;
    private bool isSwordAttack;
    public PlayerStatsController statsController;
    public GameObject bloodSplash;
    public bool isPlayerDead;
    // Start is called before the first frame update

    void Awake()
    {

        playerRigidBody = transform.GetComponent<Rigidbody2D>();
        playerAnimator = transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isSwordAttack = false;
        isPlayerMoving = false;

        if (!isPlayerDead && !isPlayerDead)
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");

            if (moveX > 0.5f || moveX < -0.5f)
            {
                playerRigidBody.transform.Translate(moveX * moveSpeed * Time.deltaTime, 0f, 0f);
                isPlayerMoving = true;
                lastMove = new Vector2(moveX, 0f);
            }

            if (moveY > 0.5f || moveY < -0.5f)
            {
                playerRigidBody.transform.Translate(0f, moveY * moveSpeed * Time.deltaTime, 0f);
                isPlayerMoving = true;
                lastMove = new Vector2(0f, moveY);
            }

            //Player can only attack while not moving!
            if (!isPlayerMoving)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    isSwordAttack = true;
                }
            }
        if (PlayerStatsController.instance.currentHealth<=0){
            isPlayerDead=true;
                    Instantiate(bloodSplash, transform.position,Quaternion.identity );

        }
        
            //Setting parameters in the animator
            playerAnimator.SetFloat("MoveX", moveX);
            playerAnimator.SetFloat("MoveY", moveY);
            playerAnimator.SetFloat("LastMoveX", lastMove.x);
            playerAnimator.SetFloat("LastMoveY", lastMove.y);
            playerAnimator.SetBool("IsPlayerMoving", isPlayerMoving);
            playerAnimator.SetBool("IsSwordAttack", isSwordAttack);
            playerAnimator.SetBool("IsDead", isPlayerDead);
            
        }

    }


}
