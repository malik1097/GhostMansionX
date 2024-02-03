using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Ghostcounter : MonoBehaviour
{
 // Rigidbody of the player.
 private Rigidbody rb; 

 
 private int count;



 public TextMeshProUGUI countText;

 // UI object to display winning text.
 public TextMeshProUGUI winTextObject;

//Timer für Ende
 //public GameObject Timer;

   


 // Start is called before the first frame update.
 void Start()
    {
 // Get and store the Rigidbody component attached to the object.
        rb = GetComponent<Rigidbody>();

 // Initialize count to zero.
        count = 0;

 // Update the count display.
        SetCountText();

 // Initially set the win text to be inactive.
        

       // winTextObject.SetActive(false);
    }
 

 // FixedUpdate is called once per fixed frame-rate frame.
  void FixedUpdate() 
    {  

   
    }
    
    
void OnTriggerStay(Collider other) 
{
    // Check if the object the player collided with has the "Ghost" tag.
    if (other != null && other.gameObject.CompareTag("Ghost")) 
    {
        // Get the current scale of the collided object.
        Vector3 newScale = other.gameObject.transform.localScale;

        // Reduce the size of the collided object.
        newScale *= 0.99f;

        // Check if the scale has reached or gone below 0.5.
        if (newScale.x <= 0.1f && newScale.y <= 0.1f && newScale.z <= 0.1f)
        {
            // If the scale is 0.5 or less, deactivate the object.
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        else
        {
            // Update the scale of the object.
            other.gameObject.transform.localScale = newScale;
        }
    }
    else{

    }
}



 


    

    


 // Function to update the displayed count of "PickUp" objects collected.
 void SetCountText() 
    {
 // Update the count text with the current count.
        countText.text = "Count: " + count.ToString();

 // Check if the count has reached or exceeded the win condition.
 if (count >= 12)
        {
 // Display the win text.
        
            winTextObject.SetActive(true);
        }
    }
}