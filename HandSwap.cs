using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandSwap : MonoBehaviour
{
    
    public RectTransform playerArea;
    public RectTransform enemyArea;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwapHands()
    {
        // Store the original anchored positions
        Vector2 tempAnchoredPosition = playerArea.anchoredPosition;

        // Set the anchored position of playerArea to the anchored position of enemyArea
        playerArea.anchoredPosition = enemyArea.anchoredPosition;

        // Set the anchored position of enemyArea to the original anchored position of playerArea
        enemyArea.anchoredPosition = tempAnchoredPosition;
    }
}
