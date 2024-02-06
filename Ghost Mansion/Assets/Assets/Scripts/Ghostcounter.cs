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
using UnityEngine.SceneManagement;

public class Ghostcounter : MonoBehaviour
{
 // Rigidbody of the player.
 private Rigidbody rb; 

 
 private int count;


 public GameObject CountObject;
 public TextMeshProUGUI countText;

 public GameObject WinTextObject;
 public TextMeshProUGUI winText;

public GameObject TutorialObject;


//Timer f�r Ende
public GameObject Timer;

public float TimeforEnd = 100;

public OVRInput.Button d;
 public OVRInput.Button b;

 [SerializeField] GhostSauger sauger;

    // Start is called before the first frame update.
    void Start()
    {
 // Get and store the Rigidbody component attached to the object.
        rb = GetComponent<Rigidbody>();

 // Initialize count to zero.
        count = 0;




  // Update the count display.
        SetCountText();



   

    
       WinTextObject.SetActive(false);
       TutorialObject.SetActive(true);
    }
 

 // FixedUpdate is called once per fixed frame-rate frame.
  void FixedUpdate() 
    {
        if (OVRInput.Get(d))
         {
             TutorialObject.SetActive(false);
        }
       
        //get Time left from Timer
        TimeforEnd = Timer.GetComponent<Timer>().TimeLeft;
        SetEndText(TimeforEnd);




    }


    // void OnTriggerStay(Collider other) 
    //{
    // Check if the object the player collided with has the "Ghost" tag.
    //if (other != null && other.gameObject.CompareTag("Ghost") && sauger.suck == true) 
    //{
    //    // Get the current scale of the collided object.
    //    Vector3 newScale = other.gameObject.transform.localScale;

    //    // Reduce the size of the collided object.
    //    newScale *= 0.99f;

    //    // Check if the scale has reached or gone below 0.5.
    //    if (newScale.x <= 0.1f && newScale.y <= 0.1f && newScale.z <= 0.1f)
    //    {
    //       // If the scale is 0.5 or less, deactivate the object.
    //        other.gameObject.SetActive(false);
    //    count = count + 1;
    //    SetCountText();
    //}
    //else
    //{
    //    // Update the scale of the object.
    //    other.gameObject.transform.localScale = newScale;
    //}
    //}
    // else{

    //}

    //}


    void OnTriggerEnter(Collider other)
    {
        // Check if the object the player collided with has the "Ghost" tag. && sauger.suck == true
        if (other.gameObject.tag.Contains("Ghost") )
        {
            // Deactivate the collided object (making it disappear).
            other.gameObject.SetActive(false);

             AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.Play();

            // Increment the count of "PickUp" objects collected.
            count = count + 1;

            // Update the count display.
            SetCountText();
        }
    }





    // Function to update the displayed count of "PickUp" objects collected.
    void SetCountText( ) 
    {
 // Update the count text with the current count.
        countText.text = "Count: " + count.ToString();

    }



// Function to update the displayed count of "PickUp" objects collected.
void SetEndText(float TimeEnd)
{
    // Check if the count has reached or exceeded the win condition.
    if (TimeEnd == 0)
    {
            // Display the win text.       
            winText.text = "YOU CAUGHT " + count.ToString() + " \nGHOSTS! \n\nPress A to Restart";
            WinTextObject.SetActive(true);
            Timer.SetActive(false);
            CountObject.SetActive(false);

            if (OVRInput.Get(b))
            {
                SceneManager.LoadScene("Villa");

            }
        }
   else
    {
        WinTextObject.SetActive(false);
        Timer.SetActive(true);
        CountObject.SetActive(true);
    }
}

}