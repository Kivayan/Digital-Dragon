using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovement
{
    //Basic container method for everything that is necessary to ensure proper movement
    void Move();

    //Should read current rotation
    Vector3 GetCurrentRotation();

    //Sets rotation - this will have a value of GetCurrentRotation() from previous Movement model.
    //Ensure that rotation does not change
    void SetCurrentRotation(Vector3 startingRotation);

    //necessary for flight
    void EnableGravity();
    void DisableGravity();
    void BlockMovement();
 
}
