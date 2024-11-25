using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPaddle : Paddle
{

    public Rigidbody2D ball;
    private void FixedUpdate()
    {
        //Moves towards Computer.
        if(this.ball.velocity.x > 0.0f)
        {
            if(ball.position.y > this.transform.position.y)
            {

                rb.AddForce(Vector2.up * this.speed);

            }
            else if(ball.position.y < this.transform.position.y)
            {
                rb.AddForce(Vector2.down * this.speed);
            }
        }
        else
        {
            //If ball moves towards the Player Paddle, center the Computer paddle for higher difficulty.
            if (this.transform.position.y > 0.0f)
            {

                rb.AddForce(Vector2.down * this.speed);

            }
            else if (this.transform.position.y < 0.0f)
            {
                rb.AddForce(Vector2.up * this.speed);
            }

        }

    }

}
