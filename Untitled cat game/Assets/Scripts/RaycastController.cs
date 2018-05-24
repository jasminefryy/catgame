using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (BoxCollider2D))]
public class RaycastController : MonoBehaviour {

	public LayerMask collisionMask;

	public const float skinWidth = .015f; //value cant be change after being set

	//this defines how many rays are being fired horizontally and vertically
	public int horizontalRayCount = 4;
	public int verticalRayCount = 4;

	/*This will calulate the spacing between each horizontal/vertical ray depending on 
	how many I've chosen to fire as well as the size of the bounds*/
	[HideInInspector]
	public float horizontalRaySpacing;
	[HideInInspector]
	public float verticalRaySpacing;

	[HideInInspector]//references to other sections of the code
	public BoxCollider2D collider;
	public RaycastOrigins raycastOrigins;

	public virtual void Awake() {
		collider = GetComponent<BoxCollider2D> ();
		CalculateRaySpacing ();
	}

	/* method for updating the raycastOrigins: to recieve the bounds of the collider and 
	shrink the bounds so that on all sides its inset by skin width*/
	public void UpdateRaycastOrigins() {
		Bounds bounds = collider.bounds;
		bounds.Expand (skinWidth * -2);

		raycastOrigins.bottomLeft = new Vector2 (bounds.min.x, bounds.min.y);
		raycastOrigins.bottomRight = new Vector2 (bounds.max.x, bounds.min.y);
		raycastOrigins.topLeft = new Vector2 (bounds.min.x, bounds.max.y);
		raycastOrigins.topRight = new Vector2 (bounds.max.x, bounds.max.y);
	}

	/*I want to get the bounds and make sure that the horizontal and vertical
	ray count are greater than or equal to 2 since when there are fired there needs to be 
	one in each corner*/
	public void CalculateRaySpacing() {
		Bounds bounds = collider.bounds;
		bounds.Expand (skinWidth * -2);

		horizontalRayCount = Mathf.Clamp (horizontalRayCount, 2, int.MaxValue);
		verticalRayCount = Mathf.Clamp (verticalRayCount, 2, int.MaxValue);	

		horizontalRaySpacing = bounds.size.y / (horizontalRayCount - 1);
		verticalRaySpacing = bounds.size.x / (verticalRayCount - 1);
	}
	//This allows for easy recieving of any of the corners of the box collider (the struct will store these positions)
	public struct RaycastOrigins {
		public Vector2 topLeft, topRight;
		public Vector2 bottomLeft, bottomRight;
	}
}
