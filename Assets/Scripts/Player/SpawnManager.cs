using System;
using UnityEngine;

public class SpawnManager : Project.Behaviour
{
    public delegate void SpawnEventHandler(SpawnEventArgs e);

    [Serializable]
    public class SpawnEventArgs
    {
        public enum Unit
        {
            Worker,
            Archer,
            Soldier
        }

        public Unit UnitToSpawn { get; set; }

        public int LaneToSpawn { get; set; }
    }

    public event SpawnEventHandler SpawnUnit;

    private int Lane;

    private void Start()
    {
        if (GameObject.Find("Units") == null)
            new GameObject() { name = "Units" };
    }

    public void SetLane(int Lane)
    {
        this.Lane = Lane;
    }

    public void SpawnWorker()
    {
        if (SpawnUnit != null && Lane != 0)
            SpawnUnit(new SpawnEventArgs() { UnitToSpawn = SpawnEventArgs.Unit.Worker, LaneToSpawn = Lane });
        Lane = 0;
    }

    public void SpawnArcher()
    {
        if (SpawnUnit != null && Lane != 0)
            SpawnUnit(new SpawnEventArgs() { UnitToSpawn = SpawnEventArgs.Unit.Archer, LaneToSpawn = Lane });
        Lane = 0;
    }

    public void SpawnSoldier()
    {
        if (SpawnUnit != null && Lane != 0)
            SpawnUnit(new SpawnEventArgs() { UnitToSpawn = SpawnEventArgs.Unit.Soldier, LaneToSpawn = Lane });
        Lane = 0;
    }
}