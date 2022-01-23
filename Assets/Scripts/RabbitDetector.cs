using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitDetector : MonoBehaviour
{
    private int stayTime;
    private LevelController levelController;
    public GameObject particle;

    void Awake()
    {
        levelController = FindObjectOfType<LevelController>();
    }

    void OnTriggerStay2D(Collider2D col)
    {
        stayTime++;
        if (col.gameObject.layer != 0)
        {
            if (this.transform.parent.GetComponent<AI>().rabbitType == AI.Aggresive.Bad && stayTime > 15 && col.GetComponent<AI>().rabbitType == AI.Aggresive.Good)
            {
                Destroy(col.gameObject);
                stayTime = 0;
                levelController.normalRabbitsNumber--;
                levelController.allRabbitsNumber--;
                this.transform.parent.GetComponent<AI>().PauseRabbit();
                Instantiate(particle, this.transform.position, Quaternion.identity);
            }
        }
        else
        {
            if (stayTime > 15 && this.transform.parent.GetComponent<AI>().rabbitType == AI.Aggresive.Bad)
            {
                Debug.LogError("Kill");
                stayTime = 0;
                this.transform.parent.GetComponent<AI>().PauseRabbit();
                Instantiate(particle, this.transform.position, Quaternion.identity);
            }
        }
        
    }

    void OnTriggerExit2D(Collider2D col)
    {
        stayTime = 0;
    }
}
