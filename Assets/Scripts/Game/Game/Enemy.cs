using Core.Game;
using Core.State;
using DG.Tweening;
using UnityEngine;

public class Enemy : MonoBehaviour, IPointerDownSpriteRenderer
{
    [SerializeField] private GameObject[] skins = null;
    private bool isLevelStarted = false;

    public Collider2D Collider => throw new System.NotImplementedException();

    void Start()
    {
        ActivateRandomSkin();

        Vector3[] path = new Vector3[2] { new Vector3(0, 8, 0), new Vector3(Random.Range(-6, 6), Random.Range(-4, 4) , 0)};
        transform.DOPath(path, 0.5f).OnComplete(() => 
        {
            var chance = Random.Range(0, 100);
            if (chance <= 50)
            {
                transform.DOLocalMove(Vector3.up * Random.Range(-4, 4), 22);
            }
            else
            {
                transform.DOLocalMove(Vector3.down * Random.Range(-4, 4), 22);
            }
        });


    }

    private void Awake()
    {
        LevelController.StartWaveAction += OnStartWave;
    }

    private void OnDestroy()
    {
        LevelController.StartWaveAction -= OnStartWave;
    }

    private void OnStartWave()
    {
        isLevelStarted = true;
    }

    public void ActivateRandomSkin()
    {
        int random = Random.Range(0, skins.Length);
        for (int i = 0; i < skins.Length; i++)
        {
            skins[i].SetActive(random == i);
        }
    }

    private void Update()
    {

    }

    internal void Kill()
    {
        Destroy(gameObject);
    }

    public void OnClick()
    {
        Kill();
    }
}