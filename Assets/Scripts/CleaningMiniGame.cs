using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CleaningMiniGame : MonoBehaviour
{
   public Transform centerPoint;    // The center of the circular area (can be the middle of the screen)
    public float radius = 200f;      // The radius within which the player needs to move the mouse
    public float requiredCircleTime = 3f; // The time to complete the circle in seconds

    private bool isInProgress = false;
    private float angleTravelled = 0f;   // The accumulated angle of the mouse movement
    private float timeSpentInCircle = 3f;  // Time spent within the required circular motion
    

    private void Update()
    {
        if (isInProgress)
        {
            // Track the mouse position
            Vector3 currentMousePosition = Input.mousePosition;
            

            // Calculate the direction of movement relative to the center
            Vector3 direction = currentMousePosition - centerPoint.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Check if the movement is going around the circle
            if (angleTravelled == 0f || Mathf.Abs(angle - angleTravelled) < 180f)
            {
                angleTravelled = angle;
                timeSpentInCircle += Time.deltaTime;
            }
            
            // Check if the player has completed the circular motion
            if (timeSpentInCircle >= requiredCircleTime)
            {
                CompleteMiniGame();
            }
        }
    }

    public void Start()
    {
        centerPoint = GameObject.Find("CleaningCenter").transform;
        isInProgress = true;
        timeSpentInCircle = 0f;
        angleTravelled = 0f;
        
    }

    private void CompleteMiniGame()
    {
        isInProgress = false;
        Debug.Log("Mini-game completed!");

        // Trigger event or hide the mini-game UI
        // For example:
        MiniGamHandle.instance.OnFinishMiniGame?.Invoke();
    }
}
