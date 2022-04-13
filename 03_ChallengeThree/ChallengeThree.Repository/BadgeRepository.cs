public class BadgeRepository
{
    private readonly Dictionary<int, Badge> BadgeList = new Dictionary<int, Badge>();
    private int _count = 0;
    public bool AddBadgeToList(Badge badge)
    {
        if(badge != null)
        {
            _count++;
            badge.ID = _count;
            BadgeList.Add(badge.ID, badge);
            return true;
        }
        return false;
    }

    public Dictionary<int, Badge> GetAllBadges()
    {
        return BadgeList;
    }

    public Badge GetBadgeByKey(int userKeyInput)
    {
        foreach(KeyValuePair<int,Badge> badge in BadgeList)
        {
            if(badge.Key == userKeyInput)
            {
                return badge.Value;
            }
        }
        return null;
    }
}
