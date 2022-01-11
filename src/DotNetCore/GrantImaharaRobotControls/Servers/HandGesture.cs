using Microsoft.Extensions.Logging;

public static class HandGesture
{
    public static bool ThumbUp(Axis axis, ILogger logger)
    {
        logger.LogInformation("Thumb up gesture. Axis: {Axis}", axis);

        // Code to make robot perform gesture

        return true;
    }
}
