using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{

    private Touch touch;
    private float speedModifier;
    public GameObject won;
    public GameObject play;

    void Start()
    {
        speedModifier = 0.01f;
    }

    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<AudioManager>().Play("Wall");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("ik heb de muur geraakt");
        play.SetActive(false);
        won.SetActive(true);
    }
    

    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                transform.position = new Vector3(
                    transform.position.x + touch.deltaPosition.x * speedModifier,
                    transform.position.y,
                    transform.position.z + touch.deltaPosition.y * speedModifier
                    );
            }
        }
    }

}
