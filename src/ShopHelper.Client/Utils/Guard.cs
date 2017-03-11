using System;

namespace ShopHelper.Client
{
    static class Guard
    {
        public static void NotNull(object obj, string paramName, string message = null)
        {
            if (obj == null)
            {
                if (string.IsNullOrWhiteSpace(message))
                {
                    throw new ArgumentNullException(paramName);
                }
                else
                {
                    throw new ArgumentNullException(paramName, message);
                }
            }
        }
    }
}
