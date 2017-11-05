using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroShield : MonoBehaviour
{
    public GameObject heroShield;
    private int beAtkCount = 0;

    public void Behit(int count)
    {
        beAtkCount += count;

        if (beAtkCount >= 5)
        {
            heroShield.gameObject.SetActive(false);
            beAtkCount = 0;
        }
    }

    public void useShield()
    {
        beAtkCount = 0;
        heroShield.gameObject.SetActive(true);
    }
}
