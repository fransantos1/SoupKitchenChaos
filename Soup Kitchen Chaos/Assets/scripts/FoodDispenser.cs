using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FoodDispenser : MonoBehaviour, IInteractable
{
    public string ingrediente;
    public Sprite sprite;

    public GameObject ingredientText;

    public TextMeshProUGUI textMesh;

    public Vector2 offset;

    Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    public virtual void Interact(GameObject instigator)
    {
        Debug.Log(instigator);
        instigator.GetComponent<PlayerGrab>().SetFood(new Food(new Ingredient(ingrediente,1),sprite));
    }

    private void Update()
    {
        Vector3 screenPos = mainCamera.WorldToScreenPoint(gameObject.transform.position + (Vector3)offset);

       // RectTransform textRectTransform = textMesh.rectTransform;
       // textRectTransform.position = screenPos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ingredientText.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ingredientText.SetActive(false);
        }
    }

}
