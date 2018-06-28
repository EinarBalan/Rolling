using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCharacteristics : MonoBehaviour {
    public bool isGravitySwitch;
    public bool isInfinite;

    void Start()
    {
        if (isGravitySwitch)
        {
            GravitySwitch();
        }
    }

    void Update()
    {
        if (isGravitySwitch && Physics2D.gravity == new Vector2(0, -9.81f))
        {
            Physics2D.gravity = new Vector2(9.81f, 0);
        }

        if (!isGravitySwitch && Physics2D.gravity == new Vector2(9.81f, 0))
        {
            Physics2D.gravity = new Vector2(0, -9.81f);
        }
    }

    public void GravitySwitch()
    {
        if (!isGravitySwitch)
            Physics2D.gravity = new Vector2(0, -9.81f);
        else if (isGravitySwitch)
            Physics2D.gravity = new Vector2(9.81f, 0);

    }
}
