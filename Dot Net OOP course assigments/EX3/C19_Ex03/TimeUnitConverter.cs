public static partial class TimeUnitConverter
{
    public static float FromMinutesToSeconds(float i_minutes)
    {
        return i_minutes * 60f;
    }

    public static double FromMinutesToSeconds(double i_minutes)
    {
        return i_minutes * 60d;
    }

    public static decimal FromMinutesToSeconds(decimal i_minutes)
    {
        return i_minutes * 60m;
    }

    public static float FromHoursToMinutes(float i_hours)
    {
        return i_hours * 60f;
    }

    public static double FromHoursToMinutes(double i_hours)
    {
        return i_hours * 60d;
    }

    public static decimal FromHoursToMinutes(decimal i_hours)
    {
        return i_hours * 60m;
    }

    public static float FromHoursToSeconds(float i_hours)
    {
        return i_hours * 3600f;
    }

    public static double FromHoursToSeconds(double i_hours)
    {
        return i_hours * 3600d;
    }

    public static decimal FromHoursToSeconds(decimal i_hours)
    {
        return i_hours * 3600m;
    }

    public static float FromSecondsToMinutes(float i_seconds)
    {
        return i_seconds / 60f;
    }

    public static double FromSecondsToMinutes(double i_seconds)
    {
        return i_seconds / 60d;
    }

    public static decimal FromSecondsToMinutes(decimal i_seconds)
    {
        return i_seconds / 60m;
    }

    public static float FromMinutesToHours(float i_minutes)
    {
        return i_minutes / 60f;
    }

    public static double FromMinutesToHours(double i_minutes)
    {
        return i_minutes / 60d;
    }

    public static decimal FromMinutesToHours(decimal i_minutes)
    {
        return i_minutes / 60m;
    }

    public static float FromSecondsToHours(float i_seconds)
    {
        return i_seconds / 3600f;
    }

    public static double FromSecondsToHours(double i_seconds)
    {
        return i_seconds / 3600d;
    }

    public static decimal FromSecondsToHours(decimal i_seconds)
    {
        return i_seconds / 3600m;
    }
}