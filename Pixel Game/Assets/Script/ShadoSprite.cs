using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadoSprite : MonoBehaviour
{
    private Transform Player;

    private SpriteRenderer thisSprite;
    private SpriteRenderer playerSprite;

    private Color color;

    [Header("時間控制參數")]
    public float activeTime;
    public float activeStart;

    [Header("不透明度控制")]
    private float alpha;
    public float alphaSet;
    public float alphaMultiplier;

    private void OnEnable()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        thisSprite = GetComponent<SpriteRenderer>();
        playerSprite = Player.GetComponent<SpriteRenderer>();

        alpha = alphaSet;

        thisSprite.sprite = playerSprite.sprite;

        transform.position = Player.position;
        transform.localScale = Player.localScale;
        transform.rotation = Player.rotation;

        activeStart = Time.time;
    }
    void Update()
    {
        alpha *= alphaMultiplier;

        color = new Color(0.5f, 0.5f, 1, alpha);

        thisSprite.color = color;
        if (Time.time >= activeStart + activeTime)
        {
            ShadowPoll.instance.ReturnPool(this.gameObject);
        }
    }
}
