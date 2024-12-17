namespace DapperConsoleDemo.UI
{
    public static class Menu
    {
        public static void Home()
        {
            string menuText = "DAPPER CONSOLE DEMO\n[1] - List All Products\n[2] - Search\n[0] - Exit\nOption: ";
            string errorText = "Invalid Option!";
            switch (ReadDigit.Check(menuText, errorText, 2, 600, 8, 4))
            {
                case 1: break;
                case 2: break;
                case 3: break;
                default: break;
            }
        }
    }
}
