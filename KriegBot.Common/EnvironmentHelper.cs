namespace KriegBot.Common;
public static class EnvironmentHelper
{
    public static string GetEnviromentVariableValue(string enviromentVariableName)
    {
        return System.Environment.GetEnvironmentVariable(enviromentVariableName);
    }
}
