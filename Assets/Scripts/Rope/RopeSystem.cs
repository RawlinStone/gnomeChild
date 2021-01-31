using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RopeSystem : MonoBehaviour
{
    public GameObject ropeHingeAnchor;
    public DistanceJoint2D ropeJoint;
    public Transform crosshair;
    public SpriteRenderer crosshairSprite;
    private bool ropeAttached;
    private Rigidbody2D ropeHingeAnchorRb;
    private SpriteRenderer ropeHingeAnchorSprite;
    public LineRenderer ropeRenderer;
    public LayerMask ropeLayerMask;
    private float ropeMaxCastDistance = 8f;
    private List<Vector2> ropePositions = new List<Vector2>();
    private bool distanceSet;
    public static bool rappel;
    [SerializeField]
    private float crosshairDistance = 2.5f;
    public Transform player;
    public List<AudioClip> myClips;
    public AudioSource audioSource;

    private void Awake()
    {
        rappel = false;
        ropeJoint.enabled = false;
        ropeHingeAnchorRb = ropeHingeAnchor.GetComponent<Rigidbody2D>();
        ropeHingeAnchorSprite = ropeHingeAnchor.GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        var worldMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
        var facingDirection = worldMousePosition - player.transform.position;
        var aimAngle = Mathf.Atan2(facingDirection.y, facingDirection.x);
        if (aimAngle < 0f)
        {
            aimAngle = Mathf.PI * 2 + aimAngle;
        }

        var aimDirection = Quaternion.Euler(0, 0, aimAngle * Mathf.Rad2Deg) * Vector2.right;

        if(!ropeAttached)
            SetCrosshairPosition(aimAngle);
        else
            crosshairSprite.enabled = false;

        HandleInput(aimDirection);
        UpdateRopePositions();
        rappelling();

    }

    private void SetCrosshairPosition(float aimAngle)
    {
        if (!crosshairSprite.enabled)
            crosshairSprite.enabled = true;

        var x = player.transform.position.x + crosshairDistance * Mathf.Cos(aimAngle);
        var y = player.transform.position.y + crosshairDistance * Mathf.Sin(aimAngle);

        var crossHairPosition = new Vector3(x, y, -1);
        crosshair.transform.position = crossHairPosition;
    }
    
    private void HandleInput(Vector2 aimDirection)
    {
        if (Input.GetMouseButton(0))
        {
            if (ropeAttached) return;
            ropeRenderer.enabled = true;
            audioSource.clip = myClips[0];
            audioSource.Play(); 

            var hit = Physics2D.Raycast(player.transform.position, aimDirection, ropeMaxCastDistance, ropeLayerMask);
            
            if (hit.collider != null)
            {
                ropeAttached = true;

                if (!ropePositions.Contains(hit.point))
                {
                    ropePositions.Add(hit.point);
                    ropeJoint.distance = Vector2.Distance(player.transform.position, hit.point);
                    ropeJoint.enabled = true;
                    ropeHingeAnchorSprite.enabled = true;
                }
            }
            else
            {
                ropeRenderer.enabled = false;
                ropeAttached = false;
                ropeJoint.enabled = false;
            }
            
        }

        if (Input.GetMouseButton(1))
        {
            ResetRope();
        }
    }
    
    private void ResetRope()
    {
        audioSource.clip = myClips[1];
        audioSource.Play();
        ropeJoint.enabled = false;
        ropeAttached = false;
        ropeRenderer.positionCount = 2;
        ropeRenderer.SetPosition(0, player.transform.position);
        ropeRenderer.SetPosition(1, player.transform.position);
        ropePositions.Clear();
        ropeHingeAnchorSprite.enabled = false;
        rappel = false;
    }

    private void UpdateRopePositions()
    {
        if (!ropeAttached)
        {
            return;
        }

        ropeRenderer.positionCount = ropePositions.Count + 1;

        for (var i = ropeRenderer.positionCount - 1; i >= 0; i--)
        {
            if (i != ropeRenderer.positionCount - 1) // if not the Last point of line renderer
            {
                ropeRenderer.SetPosition(i, ropePositions[i]);
                
                if (i == ropePositions.Count - 1 || ropePositions.Count == 1)
                {
                    var ropePosition = ropePositions[ropePositions.Count - 1];
                    if (ropePositions.Count == 1)
                    {
                        ropeHingeAnchorRb.transform.position = ropePosition;
                        if (!distanceSet)
                        {
                            ropeJoint.distance = Vector2.Distance(player.transform.position, ropePosition);
                            distanceSet = true;
                        }
                    }
                    else
                    {
                        ropeHingeAnchorRb.transform.position = ropePosition;
                        if (!distanceSet)
                        {
                            ropeJoint.distance = Vector2.Distance(player.transform.position, ropePosition);
                            distanceSet = true;
                        }
                    }
                }
                else if (i - 1 == ropePositions.IndexOf(ropePositions.Last()))
                {
                    var ropePosition = ropePositions.Last();
                    ropeHingeAnchorRb.transform.position = ropePosition;
                    if (!distanceSet)
                    {
                        ropeJoint.distance = Vector2.Distance(player.transform.position, ropePosition);
                        distanceSet = true;
                    }
                }
            }
            else
            {
                ropeRenderer.SetPosition(i, player.transform.position);
            }
        }

        if (Vector2.Distance(player.transform.position, ropeHingeAnchorSprite.transform.position) > 8.0f)
        {
            ResetRope();
        }
    }

    private void rappelling()
    {
        if (Input.GetMouseButton(0) && ropeAttached)
        {
            rappel = true;
            if (ropeHingeAnchorSprite.transform.position.y > player.transform.position.y)
                this.GetComponent<Rigidbody2D>().gravityScale = 0.1f;
            player.transform.position = Vector2.MoveTowards(player.transform.position, ropeHingeAnchorSprite.transform.position, 0.175f);
        }
        else
        {
            rappel = false;
            this.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
        }
    }
}
