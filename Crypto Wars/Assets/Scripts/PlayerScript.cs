using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    private bool isDone;
    private string playerName;
    private Material playerColor;
    private double percentControlled;
    private int tilesControlled;
    private List<TileScript.TileReference> tilesOwned = new List<TileScript.TileReference>();

    // Constructs the player, used a reference when hotswapping 
    public Player(string name, Material color) { 
        isDone = false;
        playerName = name;
        playerColor = color;
        percentControlled = 0;
    }

    // Returns whether the player is done with there turn
    // Turn master will refer to this when calculating whether a full turn will elapse
    public bool IsPlayerTurnFinished() {
        return isDone;
    }

    // Sets the player's turn to finished
    // Not finalized, may have further functionality 
    public void PlayerFinishTurn() {
        isDone = true;
    }

    // Sets the player's turn to a new turn
    // Not finalized, may have further functionality 
    public void PlayerStartTurn(){
        isDone = false;
    }

    // Add one tile to a player's ownership
    // Simple reference for calculating victory, etc
    // Not finalized, may have further functionality 
    // For adding references to the actual tiles
    public void AddTiles(TileScript.TileReference tile) {
        tilesControlled += 1;
        if(!tilesOwned.Contains(tile))
        {
            tilesOwned.Add(tile);
            Debug.Log("Tile added to player's ownership");
        }
    }

    // Overloaded adding tiles for if amount is more than 1
    // Simple reference for calculating victory
    // Not finalized, may have further functionality 
    // For adding references to the actual tiles
    public void AddTiles(List<TileScript.TileReference> tiles, int amount)
    {
        tilesControlled += amount;
        foreach (TileScript.TileReference tile in tiles)
        {
            if (!tilesOwned.Contains(tile))
            {
                tilesOwned.Add(tile);
                Debug.Log("Tile added to player's ownership");
            }         
        }
    }

    // Remove one tile to a player's ownership
    // Simple reference for calculating victory, etc
    // Not finalized, may have further functionality 
    // For removing references to the actual tiles
    public void RemoveTiles(TileScript.TileReference tile)
    {
        tilesControlled -= 1;
        bool isRemoved = tilesOwned.Remove(tile);
        if(!isRemoved)
            Debug.Log("A tile cannot be removed without prior ownership");
    }

    // Overloaded removing tiles for if amount is more than 1
    // Simple reference for calculating victory, etc
    // Not finalized, may have further functionality 
    // For removing references to the actual tiles
    public void RemoveTiles(List<TileScript.TileReference> tiles, int amount)
    {
        tilesControlled -= amount;
        foreach (TileScript.TileReference tile in tiles)
        {
            bool isRemoved = tilesOwned.Remove(tile);
            if (!isRemoved)
                Debug.Log("A tile cannot be removed without prior ownership");
        }
    }

    // Simple Getters and Setters
    public Material GetColor() 
    { 
        return playerColor;
    }

    public string GetName()
    {
        return playerName;
    }

    public void SetColor(Material color)
    {
        playerColor = color;
    }

    public void SetName(string name)
    {
        playerName = name;
    }

    // This will be called after tiles are added or removed from player's control
    // And if a turn has elapsed, to make all win conditions checked after the turn is over
    public double CalculatePercentage() { 
        return 0;
    }
}