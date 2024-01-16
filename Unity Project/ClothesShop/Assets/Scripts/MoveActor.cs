using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Moves an Actor
/// </summary>
public class MoveActor : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private float speed;

    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Actor actor;

    private Vector2 movementInput;
    private enum Direction{down,up,left,right};
    private Direction direction = Direction.down;

    public void setInput(float horizontal,float vertical)
    {
        movementInput = new Vector2(horizontal,vertical);
        movementInput.Normalize();

        if (horizontal>0){
            direction = Direction.right;
        }
        else if (horizontal<0){
            direction = Direction.left;
        }
        else if (vertical>0){
            direction = Direction.up;
        }
        else if (vertical<0){
            direction = Direction.down;
        }
        
        if (movementInput.magnitude == 0){
            if (direction == Direction.down)
                actor.PlayAnimation(AnimationType.stand_down);
            else if (direction == Direction.up)
                actor.PlayAnimation(AnimationType.stand_up);
            else if (direction == Direction.left)
                actor.PlayAnimation(AnimationType.stand_left);
            else
                actor.PlayAnimation(AnimationType.stand_right);
        }
        else{
            if (direction == Direction.down)
                actor.PlayAnimation(AnimationType.walk_down);
            else if (direction == Direction.up)
                actor.PlayAnimation(AnimationType.walk_up);
            else if (direction == Direction.left)
                actor.PlayAnimation(AnimationType.walk_left);
            else
                actor.PlayAnimation(AnimationType.walk_right);
            
            actor.UpdateDepth();
        }
    }

    void FixedUpdate(){
        rb.velocity = movementInput * speed;
    }
}
