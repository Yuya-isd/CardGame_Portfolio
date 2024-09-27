using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.Collections;
using UnityEngine;

public class PlayArea : MonoBehaviour
{
    public GameObject AreaObject;

    private DragDrop dragScript = null;

    List<GameObject> destroyCardsList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        dragScript = GetComponent<DragDrop>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestoryCard()
    {
        foreach (Transform child in AreaObject.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
