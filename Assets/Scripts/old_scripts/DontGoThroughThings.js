#pragma strict

var layerMask : LayerMask; //make sure we aren't in this layer
var skinWidth : float = 0.1; //probably doesn't need to be changed
var obj : GameObject;
private var minimumExtent : float;
private var partialExtent : float;
private var sqrMinimumExtent : float;
private var previousPosition : Vector2;
private var myRigidbody : Rigidbody2D;
//initialize values
function Awake() {
   myRigidbody = rigidbody2D;
   previousPosition = obj.transform.position;
   minimumExtent = gameObject.GetComponent(BoxCollider2D).size.x;
   partialExtent = minimumExtent*(1.0 - skinWidth);
   sqrMinimumExtent = minimumExtent*minimumExtent;
}

function FixedUpdate() {
   //have we moved more than our minimum extent?
   var movementThisStep : Vector2 = obj.transform.position - previousPosition;
   var movementSqrMagnitude : float = movementThisStep.sqrMagnitude;
   if (movementSqrMagnitude > sqrMinimumExtent) {
      var movementMagnitude : float = Mathf.Sqrt(movementSqrMagnitude);
      var hitInfo : RaycastHit;
      //check for obstructions we might have missed
      if (Physics.Raycast(previousPosition, movementThisStep, hitInfo, movementMagnitude, layerMask.value))
         obj.transform.position = hitInfo.point - (movementThisStep/movementMagnitude)*partialExtent;
   }
   previousPosition = obj.transform.position;
}