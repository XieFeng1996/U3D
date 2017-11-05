using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public void Click()
    {
        int Number = PlayerPrefs.GetInt("playerLevelChange", 0);

        if (Number < 2)
        {
            Number++;
        }

        PlayerPrefs.SetInt("playerLevelChange", Number);

        SceneManager.LoadScene("02");
    }
}
