using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An <c>Actor</c> is a Player or an NPC 
/// </summary>
public class Actor : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] AnimationType initialAnimation;

    [Header("References")]
    [SerializeField] SpriteAnimations body;
    [SerializeField] SpriteAnimations clothes;

    void Start(){
        PlayAnimation(initialAnimation);
    }

    public void PlayAnimation(AnimationType animationType){
        body.PlayAnimation(animationType);
        clothes.PlayAnimation(animationType);
    }

    public void UpdateDepth(){
        body.UpdateDepth();
        clothes.UpdateDepth();
    }
}
