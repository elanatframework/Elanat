namespace Elanat.ListClass
{
    public class Common
    {
        public void SetOrderListValue(List<string> ValueList, List<int> OrderList, out List<string> OutValueList, out List<int> OutOrderList)
        {
            List<string> TmpValueList = ValueList;
            List<int> TmpOrderList = OrderList;
            List<string> TmpValueListSort = TmpValueList;
            List<int> TmpOrderListSort = TmpOrderList;
            TmpOrderListSort.Sort();

            for (int i = 0; i < TmpOrderListSort.Count; i++)
            {
                foreach (int Order in TmpOrderList)
                {
                    int iOrder = 0;
                    if (Order == TmpOrderListSort[i])
                    {
                        TmpValueListSort.Add(TmpValueList[iOrder]);
                        TmpValueList.RemoveAt(iOrder);
                    }
                    iOrder++;
                }
            }

            OutValueList = TmpValueList;
            OutOrderList = TmpOrderList;
        }
    }
}