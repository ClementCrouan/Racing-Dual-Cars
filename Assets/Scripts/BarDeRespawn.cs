using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarDeRespawn : MonoBehaviour
{
    [Header("Rect Transform")]
    public RectTransform barreDeRespawn;

    [Header("Script")]
    public CarSwitcher carSwitcher;

    private float scale;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        scale = carSwitcher.respawnTime / 100f;
        barreDeRespawn.localScale = new Vector3(scale, 1, 1);
    }
}

