using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Camera _fpsCamera;
    //[SerializeField] private GameObject _interactionPanel;
    [SerializeField] private SpriteRenderer _crosshair;
    [SerializeField] private TMP_Text interactText;
    [SerializeField] private float _interactDistance;
    [SerializeField] private GameManagment GMT;
    private Ray _ray;
    private RaycastHit _hit;
    private bool _hitSomething = false;

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

    }
    private void Interact()
    {
        if (Input.GetMouseButtonDown(0))
        {
            string tagger = _hit.collider.gameObject.tag;
            if (Input.GetMouseButtonDown(0))
            {   
                Debug.Log(tagger);
                /*switch (tagger)
                {
                    case "Card":
                        GMT.TakeCard();
                        break;
                    case "LockedDoor":
                        GMT.UseCard();
                        break;
                    case "Keyboard":
                        GMT.UseKey();
                        break;
                    case "StealObj":
                        GMT.Steal();
                        break;
                    case "GoAway":
                        GMT.GoAway();
                        break;
                    case "Passed":
                        GMT.PassedTest();
                        break;
                    case "unPassed":
                        GMT.UnPassedTest();
                        break;
                    case "Wood":
                        GMT.TakeWood(_hit.collider.gameObject);
                        break;  
                }
                */
            }
        }
    }
}