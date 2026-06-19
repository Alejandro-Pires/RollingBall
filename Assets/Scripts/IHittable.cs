using UnityEngine;

public interface IHittable
{
    void Damage(float damage, Transform attacker);
}