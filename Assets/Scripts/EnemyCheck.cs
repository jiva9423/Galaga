using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCheck : MonoBehaviour
{
    private bool filled = false;

    public bool getFilled() {
        return filled;
    }

    public void setFilled(bool isFilled) {
        filled = isFilled;
    }
}
