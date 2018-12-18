using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFactory<T> where T: class {

    T Create(string type);
}
