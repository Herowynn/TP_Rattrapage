using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    public float MoveForce = 20f;
    public string InterractButtonName;

    Rigidbody2D _playerBody;
    Vector2 _direction;
    Animator _playerAnimator;
    SpriteRenderer _spriteRenderer;
    [SerializeField] Tree _tree;
    [SerializeField] Skeleton _skeleton;
    [SerializeField] Carrot _carrot;

    private void Start()
    {
        _playerBody = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        _direction = new Vector2(horizontal, vertical);

        if(Input.GetKeyDown(InterractButtonName))
        {
            if(_tree != null)
            {
                _playerAnimator.SetTrigger("CutWood");
                StartCoroutine("WaitForAnimation", 1f);
            }
            else if(_skeleton != null)
            {
                _playerAnimator.SetTrigger("Attack");
                StartCoroutine("WaitForAnimation", 1f);
            }
            else if(_carrot != null)
            {
                _carrot.PickCarrot();
            }
        }
    }

    IEnumerator WaitForAnimation(float time)
    {
        yield return new WaitForSeconds(time);

        if(_tree != null) 
            _tree.ReduceLife();

        else if(_skeleton != null)
            _skeleton.ReduceLife();
    }

    private void FixedUpdate()
    {
        if (_direction.magnitude > .1f)
        {
            _direction.Normalize();
            _playerBody.AddForce(_direction * MoveForce);

            if (_direction.x > 0) _spriteRenderer.flipX = false;
            else _spriteRenderer.flipX = true;

            _playerAnimator.SetBool("IsWalking", true);
        }

        else
            _playerAnimator.SetBool("IsWalking", false);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Tree>(out _tree)) _tree.ActivateCanvas(true);
        if(collision.gameObject.TryGetComponent<Skeleton>(out _skeleton)) _skeleton.ActivateCanvas(true);
        if(collision.gameObject.TryGetComponent<Carrot>(out _carrot)) _carrot.ActivateCanvas(true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (_tree != null)
        {
            _tree.ActivateCanvas(false);
            _tree = null;            
        }
        else if(_skeleton != null)
        {
            _skeleton.ActivateCanvas(false);
            _skeleton = null;
        }
        else if(_carrot != null)
        {
            _carrot.ActivateCanvas(false);
            _carrot = null;
        }
    }
}
