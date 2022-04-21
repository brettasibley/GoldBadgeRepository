public class BadgeRepository
{
    private readonly Dictionary<int, Badge> Badges = new Dictionary<int, Badge>();
    private int _count = 0;

    public bool CreateNewBadge(Badge badge)
    {
        if(badge != null)
        {
            _count++;
            badge.ID = _count;
            Badges.Add(badge.ID, badge);
            return true;
        }
        return false;
    }

    public Dictionary<int, Badge> GetAllBadges()
    {
        return Badges;
    }

    // GetBadgeByKey is our helper method
    public Badge GetBadgeByKey(int Key)
    {
        foreach(var BadgeKV in Badges)
        {
            if(BadgeKV.Key == Key)
            {
                return BadgeKV.Value;
            }
        }
        return null;
    }

    public bool DeleteAllDoors(int Key)
    {
        var badge = GetBadgeByKey(Key);
        if(badge == null)
        {
            return false;
        }
        foreach (var door in badge.Doors)
        {
            badge.Doors.Remove(door);
        }
        return true;
    }

    public bool UpdateBadge(int Key, Badge newBadgeData)
    {
        var oldBadgeData = GetBadgeByKey(Key);
        if(oldBadgeData != null)
        {
            oldBadgeData.Doors = newBadgeData.Doors;
            return true;
        }
        return false;
    }

    public bool AddDoorToBadge(int Key, string door)
    {
        var badge = GetBadgeByKey(Key);
        if(badge == null)
        {
            return false;
        }
        var doors = badge.Doors;
        if(!doors.Contains(door))
        {
            doors.Add(door);
        }
        return true;
    }

    public bool RemoveDoorFromBadge(int Key, string door)
    {
        var badge = GetBadgeByKey(Key);
        if (badge == null)
        {
            return false;
        }
        var doors = badge.Doors;
        if (doors.Contains(door))
        {
            doors.Remove(door);
        }
        return true;
    }
}
