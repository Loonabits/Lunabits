using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PowerUps : MonoBehaviour
{
    public enum Powers
    {
        Coin,
        Live
    }
    public Powers powerUpType;

    private Transform childSprite;

    void Awake()
    {
        childSprite = this.transform.GetChild(0);
        DOTween.Sequence()
        .Append(childSprite.transform.DOLocalMoveY(-0.1f, 1f))
        .Append(childSprite.transform.DOLocalMoveY(0.1f, 1f))
        .SetLoops(int.MaxValue);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (powerUpType == Powers.Coin)
        {
            //coin+
            Destroy(this.gameObject);
        }
        else if (powerUpType == Powers.Live)
        {
            //Lives++
            Destroy(this.gameObject);
        }
    }
}
