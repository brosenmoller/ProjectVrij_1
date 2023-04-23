// Adapted from by Dapper Dino : https://www.youtube.com/watch?v=f5GvfZfy3yk&t=487s

public interface ISaveable
{
    object CaptureState();
    void RestoreState(object state);
}

