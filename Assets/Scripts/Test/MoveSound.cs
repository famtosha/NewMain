using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MoveSound : MonoBehaviour
{
    [SerializeField] private float stepCoolDownLeft;
    private AudioSource stepSoundSource;

    public Tilemap groundTileMap;
    public Tilemap floorTileMap;

    public AudioClip SnowStepSound;
    public AudioClip WoodStepSound;
    public AudioClip StoneGroundSound;
    public AudioClip IronGroundSound;
    public AudioClip DefaultGroundSound;

    public float StepCoolDown = 0.5f;

    private Dictionary<TileMaterial, AudioClip> StepSoundDict = new Dictionary<TileMaterial, AudioClip>();

    private void Awake()
    {
        StepSoundDict.Add(TileMaterial.Snow, SnowStepSound);
        StepSoundDict.Add(TileMaterial.Wood, WoodStepSound);
        StepSoundDict.Add(TileMaterial.Stone, StoneGroundSound);
        StepSoundDict.Add(TileMaterial.Iron, IronGroundSound);
        StepSoundDict.Add(TileMaterial.Default, DefaultGroundSound);
    }

    private void Start()
    { 
        stepSoundSource = gameObject.GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        Movement.OnPlayerMove += PlayerStepHandler;
    }

    private void OnDisable()
    {
        Movement.OnPlayerMove -= PlayerStepHandler;
    }

    private void Update()
    {
        if (stepCoolDownLeft >= 0)
        {
            stepCoolDownLeft -= Time.deltaTime;
        }
    }

    private void PlayerStepHandler()
    {
        if (stepCoolDownLeft <= 0)
        {
            PlayStepSound();
            stepCoolDownLeft = StepCoolDown;
        }
    }

    private void PlayStepSound()
    {
        var tile = GetHighestTile();
        if (tile)
        {
            AudioClip stepSound = StepSoundDict[tile.tileMaterial];
            stepSoundSource.PlayOneShot(stepSound);
        }

    }

    private MattersTile GetHighestTile()
    {
        if (floorTileMap)
        {
            MattersTile tile = floorTileMap.GetTile(Vector3Int.FloorToInt(transform.position)) as MattersTile;
            if (tile)
            {
                return tile;
            }
            else
            {
                if (groundTileMap)
                {
                    tile = groundTileMap.GetTile(Vector3Int.FloorToInt(transform.position)) as MattersTile;
                    return tile;
                }
            }
        }
        return null;
    }
}