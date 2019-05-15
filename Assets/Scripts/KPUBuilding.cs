using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KPUBuilding : MonoBehaviour
{

    public int currentBox = 0;
    public int isWin;
    public bool winning = false;
    public SFX sfx;

    private void Start()
    {
        sfx = FindObjectOfType<SFX>();
    }

    void Update()
    {
        if (currentBox == isWin)
        {
            winning = true;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "KotakSuara")
        {
            currentBox += 1;
            Debug.Log(currentBox);
            Destroy(other.gameObject);
            sfx.PlayBerhasil();
        }
    }
}
