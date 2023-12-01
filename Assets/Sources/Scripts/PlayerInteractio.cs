using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Camera _fpsCamera;
    //[SerializeField] private GameObject _interactionPanel;
    [SerializeField] private SpriteRenderer _crosshair;
    [SerializeField] private TMP_Text interactText;
    [SerializeField] private float _interactDistance;
    private Ray _ray;
    private RaycastHit _hit;
    private bool _hitSomething = false;
    private int lenght = 0;

    private void Update()
    {
        Ray();
        DrawRay();
        Interact();
    }

    private void Ray()
    {
        _ray = _fpsCamera.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
    }

    private void DrawRay()
    {
        if (Physics.Raycast(_ray, out _hit, _interactDistance))
        {
            Debug.DrawRay(_ray.origin, _ray.direction * _interactDistance, Color.blue);
        }

        if (_hit.transform == null)
        {
            Debug.DrawRay(_ray.origin, _ray.direction * _interactDistance, Color.red);
        }
    }

    private void InteractionRay()
    {
        /*_hitSomething = false;
        if (Physics.Raycast(_ray, out _hit, _interactDistance))
        {
            IInteractable interactable = _hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                _hitSomething = true;
                interactText.text = interactable.GetDescription();

                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.Interact();
                }
            }
        }
        _interactionPanel.SetActive(_hitSomething);*/
    }
    private void Interact()
    {
        
    }
}