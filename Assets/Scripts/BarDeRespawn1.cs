using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarDeRespawn1 : MonoBehaviour
{
    [Header("Rect Transform")]
    public RectTransform barreDeRespawn;

    [Header("Script")]
    public CarSwitcher1 carSwitcher1;

    private float scale;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        scale = carSwitcher1.respawnTime / 100f;
        barreDeRespawn.localScale = new Vector3(scale, 1, 1);
    }
}
