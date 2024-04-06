using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStorable<T>
{
    bool Store(GameObject instigator,T item);

    T Retrieve(GameObject instigator);
}
