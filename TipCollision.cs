using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipCollision : MonoBehaviour
{

    public GameObject TipText;
    public GameObject TipText2;
    public GameObject TipText3;
    public GameObject TipText4;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Tip"))
        TipText.SetActive(true);

        if (other.CompareTag("Tip2"))
        TipText2.SetActive(true);

        if (other.CompareTag("Tip3"))
        TipText3.SetActive(true);

        if (other.CompareTag("Tip4"))
            TipText4.SetActive(true);
    }

    
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Tip"))
        TipText.SetActive(false);

        if (other.CompareTag("Tip2"))
        TipText2.SetActive(false);

        if (other.CompareTag("Tip3"))
        TipText3.SetActive(false);

        if (other.CompareTag("Tip4"))
            TipText4.SetActive(false);
    }
}