using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Makes an NPC Actor move in a random pattern
/// </summary>
public class MoveRandomly : MonoBehaviour
{
    [Header("Properties")]
    [SerializeField] private float timeToWalk;
    [SerializeField] private float timeStopped;

    [Header("References")]
    [SerializeField] private MoveActor moveActor;



    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return null;

        while(enabled){
            int direction = Random.Range(0,4);
            float horizontal;
            float vertical;
            float timeWalking = 0;
            float timeWaiting = 0;
            if (direction==0){
                horizontal = 1;
                vertical = 0;
            }
            else if (direction==1){
                horizontal = -1;
                vertical = 0;
            }
            else if (direction==2){
                horizontal = 0;
                vertical = 1;
            }
            else{
                horizontal = 0;
                vertical = -1;
            }
            while(timeWalking<timeToWalk){
                moveActor.setInput(horizontal,vertical);
                timeWalking+=Time.deltaTime;
                yield return null;
            }

            while(timeWaiting<timeStopped){
                moveActor.setInput(0,0);
                timeWaiting+=Time.deltaTime;
                yield return null;
            }
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
