using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGunInterface {
    void Fire();
    void LoadBullets(int index);
    void EquipGun();
    void RemoveGun();
}
