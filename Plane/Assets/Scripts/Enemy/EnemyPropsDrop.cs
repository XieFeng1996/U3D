using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPropsDrop : MonoBehaviour {
    [System.Serializable]
    public class Props
    {
        public GameObject m_Prop;   //道具预制体
        public int m_Probability;   //道具产生概率
    }

    public Props[] m_Props;                                 //储存道具
    private int m_PropNumber;                               //记录随机产生道具的下标

    public void PropDrop()
    {
        GetNumberFormProbability();

        if (m_PropNumber != -1)
        {
            Instantiate(m_Props[m_PropNumber].m_Prop, transform.position, transform.rotation);
        }
    }

    private void GetNumberFormProbability()
    {
        int RandomNumber = Random.Range(0, 1000);

        int calculate = 0;

        if (m_Props.Length == 0)
        {
            m_PropNumber = -1;
            return;
        }

        for (int i = 0; i < m_Props.Length; i++)
        {
            if (calculate < RandomNumber && RandomNumber <= (calculate + m_Props[i].m_Probability))
            {
                m_PropNumber = i;
                break;
            }

            calculate += m_Props[i].m_Probability;

            if (i == m_Props.Length - 1)
            {
                m_PropNumber = -1;
            }
        }
    }
}
