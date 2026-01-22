using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakPlatform : MonoBehaviour
{
    public float breakDelay = 0.5f;   // “¥‚ñ‚Å‚©‚ç‰ó‚ê‚é‚Ü‚Å
    public float respawnDelay = 3f;   // •œŠˆ‚Ü‚Å‚ÌŠÔ

    bool isBreaking = false;

    Collider col;
    Renderer rend;

    void Start()
    {
        col = GetComponent<Collider>();
        rend = GetComponent<Renderer>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (isBreaking) return;
        if (!collision.gameObject.CompareTag("Player")) return;

        isBreaking = true;
        StartCoroutine(BreakAndRespawn());
    }

    IEnumerator BreakAndRespawn()
    {
        // ­‚µ‘Ò‚Á‚Ä‰ó‚ê‚é
        yield return new WaitForSeconds(breakDelay);

        // ‰ó‚ê‚éiŒ©‚¦‚È‚­•“–‚½‚è”»’è‚È‚µj
        col.enabled = false;
        rend.enabled = false;

        // •œŠˆ‘Ò‚¿
        yield return new WaitForSeconds(respawnDelay);

        // •œŠˆ
        col.enabled = true;
        rend.enabled = true;

        isBreaking = false;
    }
}
