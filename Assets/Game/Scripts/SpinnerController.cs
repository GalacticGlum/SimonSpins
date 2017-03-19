using UnityEngine;
using System.Collections;

public class SpinnerController : MonoBehaviour
{
    [SerializeField]
    private float spinSpeed = 100f;
    [SerializeField]
    private bool invertControls = false;

	// Update is called once per frame
	private void Update ()
    {
        if (CrossPlatformManager.Standalone)
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                Left();
            }

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                Right();
            }
        }
        else if(CrossPlatformManager.Mobile)
        {
            if (Input.GetMouseButton(0))
            {
                if (Input.mousePosition.x < Screen.width / 2f)
                {
                    Left();
                }
                
                if(Input.mousePosition.x > Screen.width / 2f)
                {
                    Right();
                }
            }
        }
    }

    private void Left()
    {
        Vector3 eulerAngles = transform.eulerAngles;
        if(invertControls)
        {
            eulerAngles.z -= spinSpeed * Time.deltaTime;
        }
        else
        {
            eulerAngles.z += spinSpeed * Time.deltaTime;
        }
        transform.localEulerAngles = eulerAngles;
    }

    private void Right()
    {
        Vector3 eulerAngles = transform.eulerAngles;
        if (invertControls)
        {
            eulerAngles.z += spinSpeed * Time.deltaTime;
        }
        else
        {
            eulerAngles.z -= spinSpeed * Time.deltaTime;
        }
        transform.localEulerAngles = eulerAngles;
    }
}
