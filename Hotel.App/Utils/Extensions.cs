namespace Hotel.App.Utils
{
    public static class Extensions
    {
        public static string BeautifyPhoneNumber(this string str)
        {
            int position = str.Length - 3;
            while (position > 3)
            {
                str = str.Insert(position, " ");
                position -= 3;
            }

            return str;
        }
    }
}