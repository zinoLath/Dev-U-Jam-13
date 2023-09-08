using UnityEngine;

public class ZPhysicsEntity : MonoBehaviour
{
    public Vector2 position;
    public Vector2 velocity;
    public Vector2 acceleration;
    public Vector2 scale = new Vector2(1, 1);
    public Angle angle;
    public bool rotateTransform;
    public float maxSpeed = 999999f;
    private Transform _transform;

    public void ApplyTransformation(float dt)
    {
        if (_transform == null)
        {
            _transform = transform;
        }
        velocity += acceleration * dt;
        if(velocity.x * velocity.x + velocity.y * velocity.y > maxSpeed * maxSpeed)
        {
            velocity = velocity.normalized * maxSpeed;
        }
        position += velocity * dt;
        _transform.localPosition = new Vector3(position.x, position.y, 0);
        if (rotateTransform)
        {
            _transform.localRotation = angle.quaternion;
        }
        _transform.localScale = (Vector3)scale;
    }
    public void SetPosition(Vector2 position)
    {
        this.position = position;
    }

    public void SetVelocity(Vector2 velocity)
    {
        this.velocity = velocity;
    }

    public void SetVelocity(float speed, Angle angle)
    {
        this.velocity = angle.heading * speed;
    }
    
    public void SetVelocity(float speed)
    {
        this.velocity =  speed * angle.heading;
    }

    public void SetAcceleration(Vector2 acceleration)
    {
        this.acceleration = acceleration;
    }

    public void SetAcceleration(float accel, Angle angle)
    {
        this.acceleration = angle.heading * accel;
    }
    
    public void SetAcceleration(float accel)
    {
        this.acceleration =  accel * angle.heading;
    }

    public bool IsInRect(Rect rect)
    {
        return rect.Contains(position);
    }
}