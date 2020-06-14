using System.Collections.Generic;

public class BuffList
{
    public List<Buff> buffList = new List<Buff>();

    public void AddToList(Buff buff)
    {
        if (buff.isRemoveByTime)
        {
            if (!Consist(buff, out Buff buffInList))
            {
                buffList.Add(buff);
            }
            else
            {
                buffInList.Duration += buff.Duration;
            }
        }
        else
        {
            if (!Consist(buff, out Buff bufInList))
            {
                buffList.Add(buff);
            }
        }

    }

    public void RemoveFromList(Buff buff)
    {
        buffList.Remove(buff);
    }
    public void RemoveFromList(BuffType buffType)
    {

        foreach (var x in buffList)
        {
            if (x.buffType == buffType)
            {
                RemoveFromList(x);
                return;
            }
        }
    }

    public bool Consist(Buff buff, out Buff buffInList)
    {
        foreach (Buff currentBuff in buffList)
        {
            if (currentBuff.buffType == buff.buffType)
            {
                buffInList = currentBuff;
                return true;
            }
        }
        buffInList = null;
        return false;
    }
}
