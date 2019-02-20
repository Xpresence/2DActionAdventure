using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    private enum ButtonType
    {
        NotReturnable,
        Returnable,
        Rechargeable
    }

    [SerializeField]
    private ButtonType buttonType = new ButtonType();


    private bool isDown = false;
    private bool isUp = false;
    private bool isPressed = false;

    private Vector3 initialPosition;
    private Vector3 endPosition;

    void Start()
    {
        initialPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        endPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - 0.5f, transform.localPosition.z);

    }

    void FixedUpdate()
    {
        if (isDown)
        {
            //isUp = false;

            if (transform.localPosition.y > endPosition.y)
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, endPosition, Time.deltaTime);


            }

            if (transform.localPosition.y < 0f)
            {
                isPressed = true;
                Debug.Log("Pressed");
            }

            //isDown = false;
        }
        else
        {
            if (!isPressed)
            {
                if (transform.localPosition.y <= initialPosition.y)
                {
                    transform.localPosition = Vector3.Lerp(transform.localPosition, initialPosition, Time.deltaTime);

                }
            }
            

            //isUp = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("enter");
        isDown = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (buttonType == ButtonType.NotReturnable)
        {
            isDown = false;
        }
        else if (buttonType == ButtonType.Returnable)
        {
            // ??? 
            //Debug.Log("exit");
            //isPressed = false;
            //isDown = false;
        }
        else if (buttonType == ButtonType.Rechargeable)
        {

        }
    }
}