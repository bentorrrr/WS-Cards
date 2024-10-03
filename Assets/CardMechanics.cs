using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;
using UnityEngine;

public class CardMechanics : MonoBehaviour
{
    public float x, y, z;
    public GameObject cardBack;
    public bool cardBackActive = false;
    public int timer;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
            OnCardCliked();
    }

    void OnCardCliked()
    {
        StartFlipping();
    }

    public void StartFlipping()
    {
        StartCoroutine(CalculateFlip());
    }

    public void Flip()
    {
        if (cardBackActive == true)
        {
            cardBack.SetActive(false);
            cardBackActive = false;
        }
        else
        {
            cardBack.SetActive(true);
            cardBackActive = true;
        }
    }

    IEnumerator CalculateFlip()
    {
        for (int i = 0; i < 180; i++)
        {
            yield return new WaitForSeconds(0.005f);
            transform.Rotate(new Vector3(x,y,z));
            timer++;

            if (timer == 90 || timer == -90)
            {
                Flip();
            }
        }

        timer = 0;
    }
    
    
}
