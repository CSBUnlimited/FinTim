using System.Collections.Generic;

namespace FinAndTime.Entities
{
    public delegate void NotifyDataChangesEvent<T>(T currentValue);
    public delegate void NotifyDataChangesListEvent<T>(IEnumerable<T> currentValueList);
}
