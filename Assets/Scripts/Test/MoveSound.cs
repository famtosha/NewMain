using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MoveSound : MonoBehaviour
{
    [SerializeField] private float stepCoolDownLeft;
    public Tilemap groundTileMap;
    public Tilemap floorTileMap;
    private AudioSource stepSoundSource;

    public List<TileBase> SnowTiles;
    public List<TileBase> WoodTiles;
    public List<TileBase> RoadTiles;

    public AudioClip SnowStepSound;
    public AudioClip RoadStepSound;
    public AudioClip WoodStepSound;
    public AudioClip DefaultGroundSound;

    public float StepCoolDown = 0.5f;

    private void Start()
    {
        Movement.OnPlayerMove += PlayerStepHandler;
        stepSoundSource = gameObject.GetComponent<AudioSource>();
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
        if (stepSoundSource)
        {
            TileBase shit = floorTileMap.GetTile(Vector3Int.FloorToInt(transform.position));            
            AudioClip sound = GetSound(shit);          

            if(sound == null)
            {
                shit = groundTileMap.GetTile(Vector3Int.FloorToInt(transform.position));
                sound = GetSound(shit);
            }

            if(sound != null)
            {
                stepSoundSource.PlayOneShot(sound);
            }
            else
            {
                stepSoundSource.PlayOneShot(DefaultGroundSound);
            }
        }
    }

    private AudioClip GetSound(TileBase tile)
    {
        if (SnowTiles.IndexOf(tile) != -1) return SnowStepSound;
        if (RoadTiles.IndexOf(tile) != -1) return RoadStepSound;
        if (WoodTiles.IndexOf(tile) != -1) return WoodStepSound;
        return null;
    }
}