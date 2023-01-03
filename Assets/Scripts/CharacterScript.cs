using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    [Header("Character Depndencies")]
    public Rigidbody2D charRB;
    public SpriteRenderer charSR;
    public GroundChecker groundChecker;

    [Header("Character Settings")]
    public float movementForce;
    public float JumpForce;
    public float JumpHeight;
    public float normalGravity;
    public float fallGravity;
    private bool Grounded;
    private float horizontaldirectionMultiplier;//in which direction the character will move. eg. -1 / 1;

    void Update()
    {
        #region JumpConditions
        Grounded = groundChecker.GroundCheck;
        if (charRB.velocity.y >= 0)//Haven't Jump. So gravity should be normal
        {
            charRB.gravityScale = normalGravity;
        }
        else if (charRB.velocity.y < 0)//Jumped. So gravity should be increased
        {
            charRB.gravityScale = fallGravity;
        }
        #endregion

        #region HorizontalMovementMisc
        if (horizontaldirectionMultiplier < 0)
        {
            charSR.flipX = true;
        }
        else
        {
            charSR.flipX = false;
        }
        #endregion
    }

    private void FixedUpdate()
    {
        #region HorizontalMovement
        horizontaldirectionMultiplier = Input.GetAxis("Horizontal");

        float calulateMovement = horizontaldirectionMultiplier * movementForce * Time.deltaTime;

        Vector2 finalForce = new Vector2(calulateMovement, 0);

        Debug.Log(finalForce);

        charRB.AddForce(finalForce);
        #endregion

        #region Jump
    /*refernce : https://gamedevbeginner.com/how-to-jump-in-unity-with-or-without-physics/#:~:text=The%20basic%20method%20of%20jumping,using%20the%20Add%20Force%20method.&text=The%20Rigidbody%20component%20in%20Unity,to%20move%20under%20physics%20simulation.*/

        if (Input.GetButton("Jump"))
        {
            if (Grounded == true)
            {
                float calculateJump = Mathf.Sqrt(JumpHeight * -2 * (Physics2D.gravity.y * charRB.gravityScale));
                charRB.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            }
        }
        #endregion
    }
}
