using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerfire : MonoBehaviour
{
    int catclick = 0;
    int pseudoclick = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "Cat")
            {
                if(catclick < 2)
                {
                    catclick += 1;
                    GameManager.gm.gState = GameManager.GameState.Cat;
                }

            }

            else if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "Pseudo")
            {
                if (pseudoclick < 3)
                {
                    pseudoclick += 1;
                    GameManager.gm.gState = GameManager.GameState.Pseudo;
                }

            }

            else if (Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "Stranger")
            {
                if (pseudoclick < 3)
                {
                    pseudoclick += 1;
                    GameManager.gm.gState = GameManager.GameState.Stranger;
                }

            }

            else if(Physics.Raycast(ray, out hit) && hit.transform.gameObject.tag == "OtherBox")
            {
                GameManager.gm.gState = GameManager.GameState.Misunderstand;
            }
        }
    }
}
