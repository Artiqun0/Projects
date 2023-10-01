namespace Project_Work_Dictionary_
{
    public static class Replace
    {
        public static void WordReplace<T>(this List<T> list, T oldValue, T newValue)
        {
            int index = list.IndexOf(oldValue);

            if (index >= 0)
            {
                list[index] = newValue;
            }
        }
    }
}