﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActor
{
    void Move();

    void Attack();

    void Wait();

    void UseItem();

    void Trade();

    void EquipWeapon();

    void Rescue();

    void Talk();

}
