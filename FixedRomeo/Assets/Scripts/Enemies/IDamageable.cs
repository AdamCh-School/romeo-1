﻿using UnityEngine;
using System.Collections;

public interface IDamageable
{
    void TakeDamage(int damageAmount);

    void Die();
}
