using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayerTest : MonoBehaviour
{

    public Transform Player;
    private SpriteRenderer spriteRenderer;

    public void Awake()
    {
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        this.spriteRenderer.flipX = Player.transform.position.x > this.transform.position.x;
    }
}