using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Listen to the player's input and contains a useful singleton to reference the player anywhere in the game.
/// </summary>
public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [Header("References")]
    [SerializeField] private MoveActor moveActor;

    void Awake(){
        instance = this;
    }

    void Update(){
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        moveActor.setInput(horizontal,vertical);
    }
}
