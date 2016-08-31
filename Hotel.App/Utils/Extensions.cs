namespace Hotel.App.Utils
{
    public static class Extensions
    {
        public static string BeautifyPhoneNumber(this string phoneAsString)
        {
            int position = phoneAsString.Length - 3;
            while (position > 3)
            {
                phoneAsString = phoneAsString.Insert(position, " ");
                position -= 3;
            }

            return phoneAsString;
        }
    }
}