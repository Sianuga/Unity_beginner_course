using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] int stars = 100;
    Text starText;
    void Start()
    {
        starText = GetComponent<Text>();
        UpdateDisplay();
    }

   private void UpdateDisplay()
    {
        starText.text = stars.ToString();
    }

    public void AddStars(int amount)
    {
        stars += amount;
        UpdateDisplay();
    }
    public bool SpendStars(int amount)
    {
        if(amount>stars)
        { 
            StartCoroutine(ColorChange());
            return false;
                }
        else
        {
stars -= amount;
            UpdateDisplay();
            return true;
        }
        
    }
    IEnumerator ColorChange()
    {
 starText.GetComponent<Text>().color = Color.red;
        yield return new WaitForSeconds(0.5f);
        starText.GetComponent<Text>().color = Color.yellow;
    }
}
