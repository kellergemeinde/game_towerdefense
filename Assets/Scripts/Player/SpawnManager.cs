using System;

public class SpawnManager : Project.Behaviour
{
    public event EventHandler SpawnWorker;
    public event EventHandler SpawnArcher;
    public event EventHandler SpawnSoldier;

    public void OnSpawnWorker()
    {
        if (SpawnWorker != null)
            SpawnWorker(this, EventArgs.Empty);
    }

    public void OnSpawnArcher()
    {
        if (SpawnArcher != null)
            SpawnArcher(this, EventArgs.Empty);
    }

    public void OnSpawnSoldier()
    {
        if (SpawnSoldier != null)
            SpawnSoldier(this, EventArgs.Empty);
    }

    //[Command]
    //public void CmdSpawnWorker()
    //{
    //    var go = Instantiate(workerPrefab, spawnLocation.position, Quaternion.identity);
    //    go.SendMessage("SetPlayer", null);
    //    NetworkServer.Spawn(go);
    //}

    //[Command]
    //public void CmdSpawnArcher()
    //{
    //    var go = Instantiate(archerPrefab, spawnLocation.position, Quaternion.identity);
    //    go.SendMessage("SetPlayer", null);
    //    NetworkServer.Spawn(go);
    //}

    //[Command]
    //public void CmdSpawnSoldier()
    //{ 
    //    var go = Instantiate(soldierPrefab, spawnLocation.position, Quaternion.identity);
    //    go.SendMessage("SetPlayer", null);
    //    NetworkServer.Spawn(go);
    //}
}
