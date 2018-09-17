using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionDeath : MonoBehaviour
{

    TeamController tc;
    SoundManager sm;

    private void Awake()
    {
        tc = GetComponentInParent<TeamController>();
        sm = SoundManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z <= -0.9)
        {
            MinionDies();
        }

        if (transform.position.y < -2) MinionDies();
    }

    void MinionDies()
    {
        sm.PlayHurtAudio();
        tc.CheckTeamNumber();
        Destroy(gameObject);
    }
}
