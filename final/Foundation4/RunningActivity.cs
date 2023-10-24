class RunningActivity : Activity
{
    private float _distance;
    public RunningActivity(float distance, string date, int length): base(date,length,"Running")
    {
        _distance = distance;
    }
    public override float GetDistance()
    {
        return _distance;
    }
    public override float GetSpeed()
    {
        return _distance/GetLength() * 60;
    }
    public override float GetPace()
    {
        return GetLength()/_distance;
    }
}