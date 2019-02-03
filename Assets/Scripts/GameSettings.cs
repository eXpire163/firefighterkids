using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameSettings
{
	public enum GameDifficulty{Easy = 0, Medium = 1, Hard = 2};

	public static GameDifficulty Difficulty = GameDifficulty.Easy;


}
