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
 public GameObject winTextObject;

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
        winTextObject.SetActive(false);
    }
 

 // FixedUpdate is called once per fixed frame-rate frame.
 private void FixedUpdate() 
    {
    }

 
 void OnTriggerEnter(Collider other) 
    {
 // Check if the object the player collided with has the "Ghost" tag.
 if (other.gameObject.CompareTag("Ghost")) 
        {
 // Deactivate the collided object (making it disappear).
            other.gameObject.SetActive(false);

 // Increment the count of "PickUp" objects collected.
            count = count + 1;

 // Update the count display.
            SetCountText();
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