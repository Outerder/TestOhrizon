using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAndReturn : MonoBehaviour
{

    [SerializeField]
    Camera camera;

    // Start is called before the first frame update
   

    GameObject card1 =null;
    GameObject card2 = null;

    int card1Index= 0;
    int card2Index= 0;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { // if left button pressed...
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject.GetComponent<Cards>())
                {

                    hit.transform.Rotate(180.0f, 0.0f, 0.0f, Space.World);//add lerp

                    if (card1 == null)
                    {
                        card1 = hit.transform.gameObject;
                        card1Index = card1.GetComponent<Cards>().nbCard;
                        Debug.Log("Card 1 = " + card1Index);
                    }

                    else if (card1 != null && card2 == null)
                    {
                        card2 = hit.transform.gameObject;
                        card2Index = card2.GetComponent<Cards>().nbCard;
                        Debug.Log("Card 2 = " + card2Index);
                    }
                   
                }
            }
        }

        if (card1 != null && card2 != null)
        {
           VerifyContent();

        }

    }


    private void  VerifyContent()
    {
    

        if (card1Index != 0 && card2Index != 0)
        {
            if (card1Index == card2Index)
            {
                Debug.Log("success");
                Destroy(card1.GetComponent<Cards>());
                Destroy(card2.GetComponent<Cards>());
                card2 = null;
                card1 = null;
            }

            else // add wait before the lerp ending 
            {
                Debug.Log("Failed");
                card1.transform.Rotate(180.0f, 0.0f, 0.0f, Space.World);
                card2.transform.Rotate(180.0f, 0.0f, 0.0f, Space.World);
                card2 = null;
                card1 = null;
            }

        }

        

    }
}
