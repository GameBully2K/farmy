using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchLeftHand : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject water;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "leftHandTag")
        {
            water.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "leftHandTag")
        {
            water.SetActive(false);
        }
    }
}
